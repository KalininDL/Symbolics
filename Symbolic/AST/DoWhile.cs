using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbolic
{
    class DoWhile : Statement
    {

        private Expression condition;
        private Statement statement;

        public DoWhile(Expression condition, Statement statement)
        {
            this.condition = condition;
            this.statement = statement;
        }

        public void execute()
        {
            do
            {
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
                    continue;
                }
            }
            while (condition.calculate().asDouble() != 0);
        }

        public override string ToString()
        {
            return "do " + statement + " while " + condition;
        }
    }
}
