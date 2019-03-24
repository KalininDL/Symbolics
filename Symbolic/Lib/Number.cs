using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbolic
{
    class Number : Value
    {
        private double value;

        public Number(double value)
        {
            this.value = value;
        }

        public Number(bool value)
        {
            if (value == true) this.value = 1;
            else this.value = 0;
        }


        public double asDouble()
        {
            return value;
        }

        public string asString()
        {
            return value.ToString();
        }

        public override string ToString()
        {
            return value.ToString();
        }
    }
}
