using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbolic
{
    public class LogicExpression : Expression
    {
        public enum Operator
        {
            PLUS,
            MINUS,
            MULTIPLY,
            DIVIDE,
            EQUALS,
            NOT_EQUALS,
            LT,
            LTEQ,
            GT,
            GTEQ,
            AND,
            OR
        }
        public Expression a, b;
        private Operator operation;

        public LogicExpression(Operator operation, Expression a, Expression b)
        {
            this.a = a;
            this.b = b;
            this.operation = operation;
        }

        public Value calculate()
        {
            Value value1 = a.calculate();
            Value value2 = b.calculate();
            double nA, nB;
            if (value1 is VString)
            {
                nA = boolToDoub(value1.asString().Equals(value2.asString()));
                nB = 0;
                return new Number(nA);
            }
            else
            {
                nA = value1.asDouble();
                nB = value2.asDouble();
            }
            bool result;
            switch (operation)
            {
                case Operator.LT: result = (nA < nB); break;
                case Operator.LTEQ: result = (nA <= nB); break;
                case Operator.GTEQ: result = (nA >= nB); break;
                case Operator.GT: result = (nA > nB); break;
                case Operator.NOT_EQUALS: result = (nA != nB); break;
                case Operator.AND: result = (nA != 0 && nB != 0); break;
                case Operator.OR: result = (nA != 0 || nB != 0); break;
                case Operator.EQUALS:
                default: result = (nA == nB); break; 
            }
            return new Number(result);
        }

        public override string ToString()
        {
            return String.Format("[{0} {1} {2}]", a, operation, b);
        }

        public void accept(Visitor visitor)
        {
            visitor.visit(this);
        }

        private double boolToDoub(bool x)
        {
            if (x == true) return 1;
            else return 0;
        }
    }
}
