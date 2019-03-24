using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbolic
{
    public class SyntaxLayer
    {
        private static string OP_CHARS = "+-*/()=<>";
        private static TokenType[] OPERATORS = new TokenType[]
        {
            TokenType.ADD,
            TokenType.SUB,
            TokenType.MUL,
            TokenType.DIV,
            TokenType.S_BRAKET,
            TokenType.E_BRACKET,
            TokenType.EQUALS,
            TokenType.LESS,
            TokenType.MORE
        };
        private string input;
        private int length;
        private int currentPosition;

        private List<Token> tokens;


        public SyntaxLayer(string input)
        {
            this.input = input;
            this.length = input.Length;
            this.tokens = new List<Token>();
        }

        public List<Token> toTokens()
        {
            while (currentPosition < length)
            {
                char current = peek(0);
                if (Char.IsDigit(current))
                {
                    numberToToken();
                }
                if (Char.IsLetter(current))
                {
                    wordToToken();
                }
                else if (current == '"')
                {
                    textToToken();
                }
                else if (OP_CHARS.IndexOf(current) != -1)
                {
                    operatorToToken();
                }
                else { next(); }
            }
            return tokens;
        }

        private void textToToken()
        {
            next();
            StringBuilder text = new StringBuilder();
            char current = peek(0);
            while (true)
            {
                if (current == '\\')
                {
                    current = next();
                    switch (current)
                    {
                        case '"':
                            current = next();
                            text.Append('"');
                            continue;
                        case 'n':
                            current = next();
                            text.Append('\n');
                            continue;
                        case 't':
                            current = next();
                            text.Append('\t');
                            continue;
                    }
                    text.Append('\\');
                    continue;
                }
                if (current == '"')
                {
                    break;
                }
                text.Append(current);
                current = next();
            }
            next();
                addToken(TokenType.TEXT, text.ToString());
        }


        private void numberToToken()
        {
            StringBuilder number = new StringBuilder();
            char current = peek(0);
            while (true)
            {
                if (current == ',')
                {
                    if (number.ToString().Contains(',')) throw new FormatException("Number is invalid!");
                }
                else if (!Char.IsDigit(current))
                {
                    break;
                }
                number.Append(current);
                current = next();
            }
            addToken(TokenType.NUMBER, number.ToString());
        }

        private void operatorToToken()
        {
            int position = OP_CHARS.IndexOf(peek(0));
            addToken(OPERATORS[position]);
            next();
        }

        private void wordToToken()
        {
            StringBuilder word = new StringBuilder();
            char current = peek(0);
            while (true)
            {
                if (!Char.IsLetterOrDigit(current) && (current!='_') && (current != '$'))
                {
                    break;
                }
                word.Append(current);
                current = next();
            }
            string _word = word.ToString();
            switch (_word)
            {
                case "PRINT":
                    addToken(TokenType.PRINT);
                    break;
                case "IF":
                    addToken(TokenType.IF);
                    break;
                case "ELSE":
                    addToken(TokenType.ELSE);
                    break;
                default:
                    addToken(TokenType.WORD, _word);
                    break;
            }
        }



        private void addToken(TokenType type)
        {
            addToken(type, "");
        }

        private void addToken(TokenType type, string text)
        {
            tokens.Add(new Token(type, text));
        }

        private char peek(int position)
        {
            int pos = currentPosition + position;

            if (pos >= length) { return '\0'; }

            return input[pos];
        }

        private char next()
        {
            currentPosition++;
            return peek(0);
        }


    }
}
