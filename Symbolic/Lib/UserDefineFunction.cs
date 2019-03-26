using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbolic
{
    class UserDefineFunction : IFunction
    {
        private List<string> arhNames;
        private Statement body;

        public UserDefineFunction(List<string> arhNames, Statement body)
        {
            this.arhNames = arhNames;
            this.body = body;
        }

        public int getArgsCount()
        {
            return arhNames.Count;
        }

        public string getArgsName(int index)
        {
            if (index < 0 || index >= arhNames.Count) return "";
            return arhNames[index];
        }

        public Value execute(params Value[] args)
        {
            try
            {
                body.execute();
                return Number.nil;
            }
            catch (Return ret)
            {
                return ret.getResult();
            }
            
        }
    }
}
