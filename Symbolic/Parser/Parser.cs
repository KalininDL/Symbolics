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

        private Expression expression()
        {
            return logical();
        }

        private Expression logical()
        {
            Expression e = addition();

            while (true)
            {
                if (isEquals(TokenType.EQUALS))
                {
                    e = new LogicExpression('=', e, addition());
                    continue; 
                }
                if (isEquals(TokenType.LESS))
                {
                    e = new LogicExpression('<', e, addition());
                    continue;
                }
                if (isEquals(TokenType.MORE))
                {
                    e = new LogicExpression('>', e, addition());
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
            if (isEquals(TokenType.S_BRAKET))
            {
                Expression result = expression();
                isEquals(TokenType.E_BRACKET);
                return result;
            }
            if (isEquals(TokenType.WORD))
            {
                return new Variable(curr.Text);
            }
            if (isEquals(TokenType.TEXT))
            {
                return new ValueExpression(curr.Text);
            }
            throw new InvalidOperationException();
        }

       
        public List<Statement> parse()
        {
            List<Statement> result = new List<Statement>();
            while (!isEquals(TokenType.END))
            {
                result.Add(statement());
            }
            return result;
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
            return assignment();
        }

        private Statement assignment()
        {
            Token curr = get(0);
            if (isEquals(TokenType.WORD) && get(0).Type == TokenType.EQUALS)
            {
                //consume(TokenType.WORD);
                string var = curr.Text;
                consume(TokenType.EQUALS);
                return new Assignment(var, expression());
            }
            throw new Exception("Unknown operator");
        }

        private Statement ifElse()
        {
            Expression condition = expression();
            Statement ifStatement = statement();
            Statement elseStatement;
            if (isEquals(TokenType.ELSE))
            {
                elseStatement = statement();
            }
            else { elseStatement = null; }
            return new IfStatement(condition, ifStatement, elseStatement);
        }


        private Token get(int position)
        {
            int pos = currentPosition + position;

            if (pos >= size) { return END; }

            return tokens[pos];
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
