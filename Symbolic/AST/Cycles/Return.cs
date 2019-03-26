using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbolic
{
    public class Return : SystemException, Statement
    {
        public Expression e;
        private Value res;

        public Return(Expression e)
        {
            this.e = e;
        }

        public void accept(Visitor visitor)
        {
            visitor.visit(this);
        }

        public Value getResult()
        {
            return res;
        }

        public void execute()
        {
            res = e.calculate();
            throw this;
        }

        public override string ToString()
        {
            return "return";
        }
    }
}
