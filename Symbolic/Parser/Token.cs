using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbolic
{
    public class Token
    {
        private TokenType type;
        private string text;

        public Token()
        {

        }
        public Token(TokenType type, string text)
        {
            this.Type = type;
            this.Text = text;
        }

        public override string ToString()
        {
            return type + " " + text;
        }

        public TokenType Type { get => type; set => type = value; }
        public string Text { get => text; set => text = value; }
    }

    public enum TokenType
    {
        //datatypes
        WORD, 
        TEXT,
        NUMBER,

        //operators
        MUL,
        ADD,
        DIV,
        SUB,
        EQUALS,
        MORE,
        LESS,

        S_BRAKET,
        E_BRACKET,
        END,
        

        //keywords
        PRINT,
        IF,
        ELSE
    }
}
