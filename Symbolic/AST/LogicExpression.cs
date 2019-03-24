using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbolic
{
    class LogicExpression : Expression
    {
        private Expression a, b;
        private char operation;

        public LogicExpression(char operation, Expression a, Expression b)
        {
            this.a = a;
            this.b = b;
            this.operation = operation;
        }

        public Value calculate()
        {
            Value value1 = a.calculate();
            Value value2 = b.calculate();
            if (value1 is VString)
            {
                string string1 = value1.asString();
                string string2 = value2.asString();
                    switch (operation)
                {
                    case '<': return new Number(string1.Length < string2.Length);
                    case '>': return new Number(string1.Length > string2.Length); 
                    default: return new Number(string1.Equals(string2));
                }
            }
            double nA = value1.asDouble();
            double nB = value2.asDouble();
            switch (operation)
            {
                case '<': return new Number(nA < nB);
                case '>': return new Number(nA > nB);
                default: return new Number(nA == nB);
            }
        }

        public override string ToString()
        {
            return String.Format("[{0} {1} {2}]", a, operation, b);
        }
    }
}
