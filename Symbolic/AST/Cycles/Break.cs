using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbolic
{
    class Break :  SystemException, Statement
    {

        public void execute()
        {
            throw this;
        }

        public override string ToString()
        {
            return "break";
        }
    }
}
