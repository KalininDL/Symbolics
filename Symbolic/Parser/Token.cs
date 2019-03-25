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
        LTEQ,
        GTEQ,
        EXL,
        EXCLEQ,
        BAR,
        BARBAR,
        AMP,
        AMPAMP,
        EQEQ,


        S_BRAKET,
        E_BRACKET,
        S_BRACE,
        E_BRACE,
        SEPARATOR,

        END,
        

        //keywords
        PRINT,
        IF,
        ELSE,
        WHILE,
        FOR,
        DO,
        BREAK,
        CONTINUE,
        FUN
    }
}
