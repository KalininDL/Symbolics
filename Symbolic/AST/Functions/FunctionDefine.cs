using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbolic
{
    public class FunctionDefine : Statement
    {
        private string name;
        private List<string> arhNames;
        public Statement body;

        public FunctionDefine(string name, List<string> arhNames, Statement body)
        {
            this.name = name;
            this.arhNames = arhNames;
            this.body = body;
        }

        public void accept(Visitor visitor)
        {
            visitor.visit(this);
        }

        public void execute()
        {
            UserDefineFunction u = new UserDefineFunction(arhNames, body);
            Functions.add(name, u);
        }

        public override string ToString()
        {
            return "def (" + arhNames.ToString() + ") " + body.ToString();
        }
    }
}
