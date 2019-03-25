using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbolic
{
    class FunctionStatement : Statement
    {
        private Function func;

        public FunctionStatement(Function func)
        {
            this.func = func;
        }

        public void execute()
        {
            func.calculate();
        }

        public override string ToString()
        {
            return func.ToString();
        }
    }
}
