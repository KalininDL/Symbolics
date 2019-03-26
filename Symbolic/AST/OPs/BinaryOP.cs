using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbolic
{
    class BinaryOP : Expression
    {
        private Expression a, b;
        private char operation;

        public BinaryOP(char operation, Expression a, Expression b)
        {
            this.a = a;
            this.b = b;
            this.operation = operation;
        }

        public Value calculate()
        {
            Value value1 = a.calculate();
            Value value2 = b.calculate();
            if ((value1 is VString) || (value1 is Array)) {
                string string1 = value1.asString();
                switch (operation)
                {            
                    case '*':
                        int iter = (int)value2.asDouble();
                        StringBuilder builder = new StringBuilder();
                        for (int i = 0; i < iter; i++)
                        {
                            builder.Append(string1);
                        }
                        return new VString(builder.ToString());
                    default: return new VString(string1 + value2.asString());
                }
            }
            if ((value1 is VString && value2 is Number) || (value2 is VString && value1 is Number))
            {
                string string1 = value1.asString();
                switch (operation)
                {
                    case '+':
                        StringBuilder builder = new StringBuilder();
                        builder.Append(value1.asString());
                        builder.Append(value2.asString());
                        return new VString(builder.ToString());
                    default: return new VString(string1 + value2.asString());
                }
            }
            double nA = value1.asDouble();
            double nB = value2.asDouble();
            switch (operation)
            {
                case '+': return new Number(nA + nB);
                case '*': return new Number(nA * nB);
                case '/': return new Number(nA / nB);
                case '-': return new Number(nA - nB);
                default: throw new InvalidOperationException();
            }
        }

        public override string ToString()
        {
            return String.Format("[{0} {1} {2}]", a, operation, b);
        }
    }
}
