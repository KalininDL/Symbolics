using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbolic
{
    public class Function : Expression
    {
        public string name;
        public List<Expression> args;

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

        public void accept(Visitor visitor)
        {
            visitor.visit(this);
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

                Variables.push();
                for (int i = 0; i < size; i++)
                {
                    Variables.add(udef.getArgsName(i), vals[i]);
                }
                Value result = udef.execute(vals);
                Variables.pop();
                return (result);
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
