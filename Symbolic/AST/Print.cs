using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbolic
{
    public class Print : Statement
    {
        public Expression e;

        public Print(Expression e)
        {
            this.e = e;
        }

        public void execute()
        {
            Console.Write(e.calculate());
        }
        public void accept(Visitor visitor)
        {
            visitor.visit(this);
        }


        public override string ToString()
        {
            return "print " + e;
        }
    }
}
