using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbolic
{
    class For : Statement
    {
        private Statement init;
        private Expression end;
        private Statement inc;
        private Statement statement;

        public For(Statement init, Expression end, Statement inc, Statement block)
        {
            this.init = init;
            this.end = end;
            this.inc = inc;
            this.statement = block;
        }

        public void execute()
        {
            for (init.execute(); end.calculate().asDouble() != 0; inc.execute())
                
            try
            {
                    statement.execute();
                }
            catch (Break b)
                {
                    break;
                }
                catch (Continue)
                {
                    continue ;
                }
        }

        public override string ToString()
        {
            return "for " + init + " : " + end + " : " + inc + " : " + statement;
        }
    }
}
