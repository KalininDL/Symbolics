using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbolic
{
    class Assignment : Statement
    {
        private string var;
        private Expression e;

        public Assignment(string var, Expression e)
        {
            this.var = var;
            this.e = e;
        }

        public void execute()
        {
            Value result = e.calculate();
            Variables.add(var, result);
        }

        public override string ToString()
        {
            return String.Format("{0} = {1} ", var, e);
        }
    }
}
