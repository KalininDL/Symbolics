using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbolic
{
    public class Continue : SystemException, Statement
    {
        public void execute()
        {
            throw this;
        }
        public void accept(Visitor visitor)
        {
            visitor.visit(this);
        }
        public override string ToString()
        {
            return "break";
        }
    }
}
