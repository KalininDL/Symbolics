using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbolic
{
    public class Assignment : Statement
    {
        public string var;
        public Expression e;

        public Assignment(string var, Expression e)
        {
            this.var = var;
            this.e = e;
        }

        public void accept(Visitor visitor)
        {
            visitor.visit(this);
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
