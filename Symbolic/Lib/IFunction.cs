using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbolic
{
    interface IFunction
    {
        Value execute(params Value[] args);
    }

}
