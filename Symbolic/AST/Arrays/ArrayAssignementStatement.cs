using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbolic
{
    class ArrayAssignementStatement : Statement
    {
        private string var;
        private Expression index;
        private Expression val;

        public ArrayAssignementStatement(string var, Expression index, Expression val)
        {
            this.var = var;
            this.index = index;
            this.val = val;
        }

        public void execute()
        {
            Value variable = Variables.get(var);
            if (variable is Array)
            {
                Array array = (Array)variable;
                array.set((int)index.calculate().asDouble(), val.calculate());
            }
            else
            {
                throw new Exception("Not an array!");
            }
        }

        public override string ToString()
        {
            return var + "["+index+"]" + " = " + val;
        }
    }
}
