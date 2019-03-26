using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbolic
{
    public class Parser
    {
        private static Token END = new Token(TokenType.END, "");
        private List<Token> tokens;
        private int currentPosition;
        private int size;

        public Parser(List<Token> tokens)
        {
            this.tokens = tokens;
            this.size = tokens.Count;
        }

        private Expression unaryOP()
        {
            if (isEquals(TokenType.SUB))
            {
                return new UnaryOP('-', primary());
            }
            if (isEquals(TokenType.ADD))
            {
                return new UnaryOP('+', primary());
            }

            return primary();
        }

        private Function function()
        {
            string funName = consume(TokenType.WORD).Text;
            consume(TokenType.S_BRAKET);
            Function func = new Function(funName);
            while (!isEquals(TokenType.E_BRACKET))
            {
                func.addArg(expression());
                isEquals(TokenType.SEPARATOR);
            }
            return func;
        }

        private FunctionDefine funDef()
        {
            string funName = consume(TokenType.WORD).Text;
            consume(TokenType.S_BRAKET);
            List<string> argNames = new List<string>();
            while (!isEquals(TokenType.E_BRACKET))
            {
                argNames.Add(consume(TokenType.WORD).Text);
                isEquals(TokenType.SEPARATOR);
            }
            Statement body = statementOrCodeBlock();
            return new FunctionDefine(funName, argNames, body);
        }

        private Expression expression()
        {     
            return logicalOR();
        }

        private Expression logicalOR()
        {
            Expression result = logicalAND();

            while (true)
            {

                if (isEquals(TokenType.BARBAR))
                {
                    result = new LogicExpression(LogicExpression.Operator.OR, result, logicalAND());
                    continue;
                }
                break;
            }

            return result;
        }

        private Expression logicalAND()
        {
            Expression result = equality();

            while (true)
            {

                if (isEquals(TokenType.AMPAMP))
                {
                    result = new LogicExpression(LogicExpression.Operator.AND, result, equality());
                    continue;
                }
                break;
            }

            return result;
        }

        private Expression equality()
        {
            Expression result = logical();

            if (isEquals(TokenType.EQEQ))
            {
                return new LogicExpression(LogicExpression.Operator.EQUALS, result, logical());
            }
            if (isEquals(TokenType.EXCLEQ))
            {
                return new LogicExpression(LogicExpression.Operator.NOT_EQUALS, result, logical());
            }

            return result;
        }

        private Expression logical()
        {
            Expression e = addition();

            while (true)
            {

                if (isEquals(TokenType.LESS))
                {
                    e = new LogicExpression(LogicExpression.Operator.LT, e, addition());
                    continue;
                }
                if (isEquals(TokenType.LTEQ))
                {
                    e = new LogicExpression(LogicExpression.Operator.LTEQ, e, addition());
                    continue;
                }
                if (isEquals(TokenType.MORE))
                {
                    e = new LogicExpression(LogicExpression.Operator.GT, e, addition());
                    continue;
                }
                if (isEquals(TokenType.GTEQ))
                {
                    e = new LogicExpression(LogicExpression.Operator.GTEQ, e, addition());
                    continue;
                }
                break;
            }
            return e;
        }

        private Expression addition()
        {
            Expression e = multiplication();

            while (true)
            {
                if (isEquals(TokenType.ADD))
                {
                    e = new BinaryOP('+', e, multiplication());
                    continue;
                }
                if (isEquals(TokenType.SUB))
                {
                    e = new BinaryOP('-', e, multiplication());
                    continue;
                }
                break;
            }
            return e;
        }

        private Expression multiplication()
        {
            Expression e = unaryOP();

            while (true)
            {
                if (isEquals(TokenType.MUL))
                {
                    e = new BinaryOP('*', e, unaryOP());
                    continue;
                }
                if (isEquals(TokenType.DIV))
                {
                    e = new BinaryOP('/', e, unaryOP());
                    continue;
                }
                break;
            }
            return e;
        }



        private Expression primary()
        {
            Token curr = get(0);
            if (isEquals(TokenType.NUMBER))
            {
                return new ValueExpression(Double.Parse(curr.Text));
            }
            if (lookMatch(0, TokenType.WORD) && lookMatch(1, TokenType.S_BRAKET))
            {
                return function();
            }
            if (lookMatch(0, TokenType.WORD) && lookMatch(1, TokenType.S_QBRACKET))
            {
                return element();
            }
            if (lookMatch(0, TokenType.S_QBRACKET))
            {
                return array();
            }
            if (isEquals(TokenType.WORD))
            {
                return new Variable(curr.Text);
            }
            if (isEquals(TokenType.S_BRAKET))
            {
                Expression result = expression();
                isEquals(TokenType.E_BRACKET);
                return result;
            }
            if (isEquals(TokenType.TEXT))
            {
                return new ValueExpression(curr.Text);
            }
            throw new InvalidOperationException();
        }

        private ArrayGetElement element()
        {
            string var = consume(TokenType.WORD).Text;
            List<Expression> indexes = new List<Expression>();
            do
            {
                consume(TokenType.S_QBRACKET);
                indexes.Add(expression());
                consume(TokenType.E_QBRACKET);
            } while (lookMatch(0, TokenType.S_QBRACKET));
            return new ArrayGetElement(var, indexes);
        }

        private Expression array()
        {
            consume(TokenType.S_QBRACKET);
            List<Expression> elements = new List<Expression>();
            while (!isEquals(TokenType.E_QBRACKET))
            {
                elements.Add(expression());
                isEquals(TokenType.SEPARATOR);
            }
            return new ArrayExpression(elements);
        }




        public Statement parse()
        {
            CodeBlock result = new CodeBlock();
            while (!isEquals(TokenType.END))
            {
                result.add(statement());
            }
            return result;
        }

        private Statement block()
        {
            CodeBlock block = new CodeBlock();
            consume(TokenType.S_BRACE);
            while (!isEquals(TokenType.E_BRACE))
            {
                block.add(statement());
            }
            return block;
        }

        private Statement statement()
        {
            if (isEquals(TokenType.PRINT))
            {
                return new Print(expression());
            }
            if (isEquals(TokenType.IF))
            {
                return ifElse();
            }
            if (isEquals(TokenType.WHILE)){
                return whileOP();
            }
            if (isEquals(TokenType.FOR))
            {
                return forOP();
            }
            if (isEquals(TokenType.BREAK))
            {
                return new Break();
            }
            if (isEquals(TokenType.RETURN))
            {
                return new Return(expression());
            }
            if (isEquals(TokenType.CONTINUE))
            {
                return new Continue();
            }
            if (isEquals(TokenType.DO))
            {
                return doWhileOP();
            }
            if (isEquals(TokenType.FUN))
            {
                return funDef();
            }
            if (lookMatch(0, TokenType.WORD) && lookMatch(1, TokenType.S_BRAKET))
            {
                return new FunctionStatement(function());
            }
            return assignment();
        }

        private Statement assignment()
        {
            //Token curr = get(0);
            //Token curr1 = get(1);
            Console.WriteLine();
            if (lookMatch(0, TokenType.WORD) && lookMatch(1, TokenType.EQUALS))
            {
                //consume(TokenType.WORD);
                string var = consume(TokenType.WORD).Text;
                consume(TokenType.EQUALS);
                return new Assignment(var, expression());
            }
            if (lookMatch(0, TokenType.WORD) && lookMatch(1, TokenType.S_QBRACKET))
            {
                string var = consume(TokenType.WORD).Text;
                ArrayGetElement array = element();
                consume(TokenType.EQUALS);
                return new ArrayAssignementStatement(array, expression());

            }
            throw new Exception("Unknown operator");
        }

        private Statement statementOrCodeBlock()
        {
            if (lookMatch(0, TokenType.S_BRACE))
                return block();
            else
                return statement();
        }

        private Statement ifElse()
        {
            Expression condition = expression();
            Statement ifStatement = statementOrCodeBlock();
            Statement elseStatement;
            if (isEquals(TokenType.ELSE))
            {
                elseStatement = statement();
            }
            else { elseStatement = null; }
            return new IfStatement(condition, ifStatement, elseStatement);
        }

        private Statement whileOP()
        {
            Expression condition = expression();
            Statement statement = statementOrCodeBlock();
            return new While(condition, statement);
        }

        private Statement doWhileOP()
        {
            Statement statement = statementOrCodeBlock();
            consume(TokenType.WHILE);
            Expression condition = expression();
            
            return new DoWhile(condition, statement);
        }


        private Statement forOP()
        {
            Statement initialize = assignment();
            consume(TokenType.SEPARATOR);
            Expression termination = expression();
            consume(TokenType.SEPARATOR);
            Statement increment = assignment();
            Statement statement = statementOrCodeBlock();
            return new For(initialize, termination, increment, statement);
        }


        private Token get(int position)
        {
            int pos = currentPosition + position;

            if (pos >= size) { return END; }

            return tokens[pos];
        }

        private bool lookMatch(int pos, TokenType type)
        {
            Console.WriteLine("--" + get(pos).Type);
            return get(pos).Type == type;
        }

        private bool isEquals(TokenType type)
        {
            Token currToken = get(0);
            if (type != currToken.Type) { return false; }
            else {
                currentPosition++;
                return true;
            }
        }

        private Token consume(TokenType type)
        {
            Token currToken = get(0);
            if (type != currToken.Type) { throw new Exception("Token " + currToken + " doesn't match " + type); }
                currentPosition++;
                return currToken;
        }
    }
}
