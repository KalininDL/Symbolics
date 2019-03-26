using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbolic
{
    public class ArrayGetElement : Expression
    {

        public string var;
        public List<Expression> indexes;

        public ArrayGetElement(string var, List<Expression> indexes)
        {
            this.var = var;
            this.indexes = indexes;
        }

        public Value calculate()
        {
            return getLast().get(lastIndex());
        }

        public Array getLast()
        {
            Array array = isArray(Variables.get(var));
            int last = indexes.Count - 1;
            for (int i = 0; i < last; i++)
            {
                array = isArray(array.get(index(i)));
            }
            return array;
        }

        public int lastIndex()
        {
            return index(indexes.Count - 1);
        }

        public int index(int index)
        {
            return (int)indexes[index].calculate().asDouble();
        }

        private Array isArray(Value variable)
        {
            if (variable is Array)
            {
                return (Array)variable;
            }
            else
            {
                throw new Exception("Not an array!");
            }
        }

        public void accept(Visitor visitor)
        {
            visitor.visit(this);
        }

        public override string ToString()
        {
            return var + indexes;
        }
    }
}
