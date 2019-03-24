using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbolic
{
    public class Variable : Expression
    {
        private string name;

        public Variable(string name)
        {
            this.name = name;
        }

        public Value calculate()
        {
           return Variables.get(name);
        }

        public override string ToString()
        {
            return String.Format("{0}", name);
        }
    }
}
