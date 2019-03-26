using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbolic
{
    public class IfStatement : Statement
    {
        public Expression e;
        public Statement ifStatement, elseStatement;

        public IfStatement(Expression e, Statement ifStatement, Statement elseStatement)
        {
            this.e = e;
            this.ifStatement = ifStatement;
            this.elseStatement = elseStatement;
        }

        public void accept(Visitor visitor)
        {
            visitor.visit(this);
        }

        public void execute()
        {
            double res = e.calculate().asDouble();
            if (res != 0)
            {
                ifStatement.execute();
            }
            else if (elseStatement != null)
            {
                elseStatement.execute();
            }
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("if ").Append(e).Append(" ").Append(ifStatement);
            if (elseStatement != null)
            {
                builder.Append("\nelse").Append(elseStatement);
            }
            return builder.ToString();
        }
    }
}
