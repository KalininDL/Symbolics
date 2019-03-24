using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbolic
{
    public interface Value
    {
        double asDouble();

        string asString();
    }
}
