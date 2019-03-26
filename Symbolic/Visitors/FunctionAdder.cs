using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbolic
{
    class FunctionAdder : Visitor
    {
        public void visit(Assignment statement)
        {
            statement.e.accept(this);
        }

        public void visit(FunctionDefine statement)
        {
            statement.body.accept(this);
            statement.execute();
        }

        public void visit(ArrayAssignementStatement statement)
        {
            statement.array.accept(this);
            statement.val.accept(this);
        }

        public void visit(ArrayExpression statement)
        {
                foreach (Expression index in statement.elems)
                {
                    index.accept(this);
                }
        }

        public void visit(ArrayGetElement statement)
        {
            foreach (Expression index in statement.indexes)
            {
                index.accept(this);
            }
        }

        public void visit(Break statement)
        {
        }

        public void visit(Continue statement)
        {
        }

        public void visit(DoWhile statement)
        {
            statement.condition.accept(this);
            statement.statement.accept(this);
        }

        public void visit(For statement)
        {
            statement.inc.accept(this);
            statement.end.accept(this);
            statement.init.accept(this);
            statement.statement.accept(this);
        }

        public void visit(Return statement)
        {
            statement.e.accept(this);
        }

        public void visit(While statement)
        {
            statement.condition.accept(this);
            statement.statement.accept(this);
        }

        public void visit(LogicExpression statement)
        {
            statement.a.accept(this);
            statement.b.accept(this);
        }

        public void visit(ValueExpression statement)
        {
        }

        public void visit(Function statement)
        {
            foreach (Expression index in statement.args)
            {
                index.accept(this);
            }
        }

        public void visit(FunctionStatement statement)
        {
        }

        public void visit(BinaryOP statement)
        {
            statement.a.accept(this);
            statement.b.accept(this);
        }

        public void visit(UnaryOP statement)
        {
            statement.a.accept(this);
        }

        public void visit(IfStatement statement)
        {
            statement.e.accept(this);
            if (statement.elseStatement != null) { statement.elseStatement.accept(this); }
            statement.ifStatement.accept(this);

        }

        public void visit(CodeBlock statement)
        {
            foreach (Statement index in statement.statements)
            {
                index.accept(this);
            }
        }

        public void visit(Print statement)
        {
            statement.e.accept(this);
        }

        public void visit(Variable statement)
        {
        }
    }
}
