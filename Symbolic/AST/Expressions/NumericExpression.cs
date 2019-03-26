using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbolic
{
    class ValueExpression : Expression
    {
        private readonly Value value;

        public ValueExpression(double value)
        {
            this.value = new Number(value);
        }

        public ValueExpression(string value)
        {
            this.value = new VString(value);
        }

        public Value calculate()
        {
            return value;
        }

        public override string ToString()
        {
            return value.asString();
        }
    }
}
