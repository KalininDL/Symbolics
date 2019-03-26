using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbolic
{
    public interface Visitor
    {
        void visit(Assignment statement);
        void visit(FunctionDefine statement);
        void visit(ArrayAssignementStatement statement);
        void visit(ArrayExpression statement);
        void visit(ArrayGetElement statement);
        void visit(Break statement);
        void visit(Continue statement);
        void visit(DoWhile statement);
        void visit(For statement);
        void visit(Return statement);
        void visit(While statement);
        void visit(LogicExpression statement);
        void visit(ValueExpression statement);
        void visit(Function statement);
        void visit(FunctionStatement statement);
        void visit(BinaryOP statement);
        void visit(UnaryOP statement);
        void visit(IfStatement statement);
        void visit(CodeBlock statement);
        void visit(Print statement);
        void visit(Variable statement);
    }
}
