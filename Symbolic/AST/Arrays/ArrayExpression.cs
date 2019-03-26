using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbolic
{
    public class ArrayExpression : Expression
    {
        public List<Expression> elems;

        public ArrayExpression(List<Expression> args)
        {
            this.elems = args;
        }

        public void accept(Visitor visitor)
        {
            visitor.visit(this);
        }

        public Value calculate()
        {
            int size = elems.Count;
            Array  array = new Array(size);
            for (int i = 0; i < size; i++)
            {
                array.set(i, elems[i].calculate());
            }
            return array;
        }

        public override string ToString()
        {
            return elems.ToString();
        }
    }
}
