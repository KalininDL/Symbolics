using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbolic
{
    class Print : Statement
    {
        private Expression e;

        public Print(Expression e)
        {
            this.e = e;
        }

        public void execute()
        {
            Console.Write(e.calculate());
        }

        public override string ToString()
        {
            return "print " + e;
        }
    }
}
