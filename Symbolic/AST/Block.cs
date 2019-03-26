using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbolic
{
    public class CodeBlock : Statement
    {
        public List<Statement> statements;

        public CodeBlock()
        {
            this.statements = new List<Statement>();
        }

        public void add(Statement s)
        {
            statements.Add(s);
        }

        public void accept(Visitor visitor)
        {
            visitor.visit(this);
        }

        public void execute()
        {
            foreach (Statement s in statements)
            {
                s.execute();
            }
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            foreach (Statement s in statements)
            {
                builder.Append(s.ToString()).Append("\n");
            }
            return builder.ToString();
        }
    }
}
