using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbolic
{
    class Array : Value
    {
        private Value[] elements;

        public Array(int size)
        {
            this.elements = new Value[size];
        }

        public Array(Value[] input)
        {
            this.elements = new Value[input.Length];
            System.Array.Copy(input, this.elements, input.Length);
        }

        public void copyArray(Value[] input)
        {
            this.elements = new Value[input.Length];
            System.Array.Copy(input, this.elements, input.Length);
        }

        public Array(Array a)
        {
           this.copyArray(a.elements);
        }

        public Value get(int index)
        {
            return elements[index];
        }

        public void set(int index, Value val)
        {
            elements[index] = val;
        }


        public double asDouble()
        {
            throw new Exception("Can't cast Array to Double");
        }

        public string asString()
        {
            StringBuilder builder = new StringBuilder();
            foreach (Value v in elements)
            {
                builder.Append(v).Append(" ");
            }
            return builder.ToString();
        }

        public override string ToString()
        {
            return asString();
        }
    }
}
