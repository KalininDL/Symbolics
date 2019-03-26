using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbolic
{
    public class ArrayAssignementStatement : Statement
    {
        public ArrayGetElement array;
        public Expression val;

        public ArrayAssignementStatement(ArrayGetElement array, Expression val)
        {
            this.array = array;
            this.val = val;
        }
        public void accept(Visitor visitor)
        {
            visitor.visit(this);
        }

        public void execute()
        {
            array.getLast().set(array.lastIndex(), val.calculate());
        }

        public override string ToString()
        {
            return array.ToString() + val;
        }
    }
}
