using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbolic
{
    public class For : Statement
    {
        public Statement init;
        public Expression end;
        public Statement inc;
        public Statement statement;

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

        public void accept(Visitor visitor)
        {
            visitor.visit(this);
        }

        public override string ToString()
        {
            return "for " + init + " : " + end + " : " + inc + " : " + statement;
        }
    }
}
