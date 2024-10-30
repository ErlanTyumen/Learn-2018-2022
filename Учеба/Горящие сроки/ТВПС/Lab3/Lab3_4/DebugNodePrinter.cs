using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Lab3_4
{
    class DebugNodePrinter : INodeVisitor
    {
        readonly TextWriter o;
        int depth;
        void Print(INode node)
        {
            node.Visitor(this);
        }
        public DebugNodePrinter(TextWriter o)
        {
            this.o = o;
        }
        public void VisitUpdateStmt(UpdateStmt updateStmt)
        {
            o.Write($"new {nameof(UpdateStmt)}(\n");
            depth++;
            Print(updateStmt.TableName);
            o.Write(",\n");
            o.WriteIndent(depth);
            o.Write($"new {nameof(Assignment)}[]{{\n");
            depth++;
            for (int i = 0; i < updateStmt.Assignments.Count; i++)
            {
                if (i != 0)
                {
                    o.Write(",\n");
                }
                Print(updateStmt.Assignments[i]);
            }
            depth--;
            o.WriteIndent(depth);
            o.Write("\n");
            o.WriteIndent(depth);
            o.Write("},\n");
            Print(updateStmt.WhereCondition);
            o.WriteIndent(depth + 1);
            o.WriteIndent(depth);
            o.Write("\n)\n");
        }
        public void VisitAssignment(Assignment assignment)
        {
            o.WriteIndent(depth);
            o.Write($"new {nameof(Assignment)}(\n");
            depth++;
            Print(assignment.Column);
            o.Write(",\n");
            Print(assignment.Value);
            o.Write("\n");
            depth--;
            o.WriteIndent(depth);
            o.Write(")");
        }
        public void VisitBinary(Binary binary)
        {
            o.WriteIndent(depth);
            o.Write($"new {nameof(Binary)}(\n");
            depth++;
            Print(binary.Left);
            o.Write(",\n");
            o.WriteIndent(depth);
            o.Write($"{nameof(OperatorOfType)}.{binary.Operator}");
            o.Write(",\n");
            Print(binary.Right);
            o.Write("\n");
            depth--;
            o.WriteIndent(depth);
            o.Write($")");
        }
        public void VisitParenthesis(Parenthesis parenthesis)
        {
            o.WriteIndent(depth);
            o.Write($"new {nameof(Parenthesis)}(\n");
            depth++;
            Print(parenthesis.Child);
            o.Write("\n");
            depth--;
            o.WriteIndent(depth);
            o.Write(")");
        }
        public void VisitNumber(Number number)
        {
            o.WriteIndent(depth);
            o.Write($"new {nameof(Number)}(\"{number.Lexeme}\")");
        }
        public void VisitIdentifier(Identifier identifier)
        {
            o.WriteIndent(depth);
            o.Write($"new {nameof(Identifier)}(\"{identifier.Name}\")");
        }
    }
    static class TextWriterExtensions
    {
        public static void WriteIndent(this TextWriter o, int depth)
        {
            o.Write(new string(' ', depth * 2));
        }
    }
}
