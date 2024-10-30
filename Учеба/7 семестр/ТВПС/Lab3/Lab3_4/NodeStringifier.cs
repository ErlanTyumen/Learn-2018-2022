using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_4
{
    class NodeStringifier : INodeVisitor<string>
    {
        string ToString(INode node)
        {
            return node.Visitor(this);
        }
        public string VisitUpdateStmt(UpdateStmt updateStmt)
        {
            return $"UPDATE {ToString(updateStmt.TableName)} SET {string.Join(", ", updateStmt.Assignments.Select(x => ToString(x)))} WHERE {ToString(updateStmt.WhereCondition)}";
        }
        public string VisitAssignment(Assignment assignment)
        {
            return $"{ToString(assignment.Column)} = {ToString(assignment.Value)}";
        }
        public string VisitBinary(Binary binary)
        {
            return $"{ToString(binary.Left)} {GetOperator(binary.Operator)} {ToString(binary.Right)}";
        }
        public static string GetOperator(OperatorOfType oper)
        {
            switch (oper)
            {
                case OperatorOfType.Equal:
                    return "=";
                case OperatorOfType.Greater:
                    return ">";
                case OperatorOfType.Less:
                    return "<";
                case OperatorOfType.Add:
                    return "+";
                case OperatorOfType.Subtract:
                    return "-";
                case OperatorOfType.Multiply:
                    return "*";
                case OperatorOfType.Divide:
                    return "/";
                default:
                    throw new InvalidOperationException();
            }
        }
        public string VisitParenthesis(Parenthesis parenthesis)
        {
            return $"({ToString(parenthesis.Child)})";
        }
        public string VisitNumber(Number number)
        {
            return $"{number.Lexeme}";
        }
        public string VisitIdentifier(Identifier identifier)
        {
            return $"{identifier.Name}";
        }
    }
}
