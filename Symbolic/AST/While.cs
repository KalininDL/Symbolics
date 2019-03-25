using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbolic
{
    class While : Statement
    {

        private Expression condition;
        private Statement statement;

        public While(Expression condition, Statement statement)
        {
            this.condition = condition;
            this.statement = statement;
        }

        public void execute()
        {
            while (condition.calculate().asDouble() != 0)
            {
                statement.execute();
            }
        }

        public override string ToString()
        {
            return "while " + condition + " " + statement;
        }
    }
}
