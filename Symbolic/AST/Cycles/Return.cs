using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbolic
{
    class Return : SystemException, Statement
    {
        private Expression e;
        private Value res;

        public Return(Expression e)
        {
            this.e = e;
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
