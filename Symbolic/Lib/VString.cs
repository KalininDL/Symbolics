using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbolic
{
    class VString :  Value
    {
        private string value;

        public VString(string value)
        {
            this.value = value;
        }

        public double asDouble()
        {
            try
            {
                return (Double.Parse(value));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return 0;
        }

        //public override double asDouble()
        //{
        //    try
        //    {
        //        return (Double.Parse(value));
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //    }
        //    return 0;
        //}

        public string asString()
        {
            return value;
        }

        //public override string asString()
        //{
        //    return value;
        //}

        public override string ToString()
        {
            return value.ToString();
        }
    }
}
