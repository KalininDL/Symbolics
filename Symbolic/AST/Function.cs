using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbolic
{
    class Function : Expression
    {
        private string name;
        private List<Expression> args;

        public Function(string name)
        {
            this.name = name;
            this.args = new List<Expression>();
        }

        public Function(string name, List<Expression> args)
        {
            this.name = name;
            this.args = args;
        }

        public void addArg(Expression arg)
        {
            args.Add(arg);
        }

        public Value calculate()
        {
            int size = args.Count;
            Value[] vals = new Value[size];
            for (int i = 0; i < size; i++)
            {
                vals[i] = args[i].calculate();
            }
            IFunction func = Functions.get(name);
            if (func is UserDefineFunction)
            {
                UserDefineFunction udef = (UserDefineFunction)func;
                if (size != udef.getArgsCount()) throw new Exception("!");
                for (int i = 0; i < size; i++)
                {
                    Variables.add(udef.getArgsName(i), vals[i]);
                }
            }
            //Function func = Functions.get(name);
            //if
            //var a = (Value)Functions.get(name).DynamicInvoke((object)vals);
            return func.execute(vals);
        }

        public override string ToString()
        {
            return name + "(" + args.ToString() + ")";
        }
    }
}
