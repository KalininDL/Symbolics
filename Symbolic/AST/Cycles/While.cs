using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbolic
{
    public class While : Statement
    {

        public Expression condition;
        public Statement statement;

        public While(Expression condition, Statement statement)
        {
            this.condition = condition;
            this.statement = statement;
        }

        public void accept(Visitor visitor)
        {
            visitor.visit(this);
        }
        public void execute()
        {
            while (condition.calculate().asDouble() != 0)
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
        }

        public override string ToString()
        {
            return "while " + condition + " " + statement;
        }
    }
}
