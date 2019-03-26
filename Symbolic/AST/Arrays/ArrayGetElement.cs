using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbolic
{
    class ArrayGetElement : Expression
    {

        private string var;
        private List<Expression> indexes;

        public ArrayGetElement(string var, List<Expression> indexes)
        {
            this.var = var;
            this.indexes = indexes;
        }

        public Value calculate()
        {
            return getLast().get(indexes.Count - 1);
        }

        private Array getLast()
        {
            Array array = isArray(Variables.get(var));
            int last = indexes.Count - 1;
            for (int i = 0; i < last; i++)
            {
                array = isArray(array.get((int)indexes[i].calculate().asDouble()));
            }
            return array;
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

        public override string ToString()
        {
            return var + indexes;
        }
    }
}
