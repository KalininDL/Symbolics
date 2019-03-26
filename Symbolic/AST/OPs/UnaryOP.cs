using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbolic
{
    public class UnaryOP : Expression
    {
        public Expression a;
        private char operation;

        public UnaryOP(char operation, Expression a)
        {
            this.a = a;
            this.operation = operation;
        }

        public Value calculate()
        {
            switch (operation)
            {
                case '-': return new Number(-a.calculate().asDouble());
                case '+': return new Number(a.calculate().asDouble());
                default: throw new InvalidOperationException();
            }
        }

        public override string ToString()
        {
            return String.Format("{0} {1} ", a, operation);
        }

        public void accept(Visitor visitor)
        {
            visitor.visit(this);
        }
    }
}
