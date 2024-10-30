using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;
using System.Linq;

namespace Lab3_4
{
    interface INode
    {
        T Visitor<T>(INodeVisitor<T> visitor);
        void Visitor(INodeVisitor visitor);
    }
    interface IExpression : INode { }   
    class UpdateStmt : INode
    {
        public readonly Identifier TableName;
        public readonly IReadOnlyList<Assignment> Assignments;
        public IExpression WhereCondition;
        public UpdateStmt(Identifier tableName, IReadOnlyList<Assignment> assignments, IExpression whereCondition)
        {
            TableName = tableName;
            Assignments = assignments;
            WhereCondition = whereCondition;
        }
        public T Visitor<T>(INodeVisitor<T> visitor)
        {
            return visitor.VisitUpdateStmt(this);
        }
        public void Visitor(INodeVisitor visitor)
        {
            visitor.VisitUpdateStmt(this);
        }
    }
    sealed class Assignment : INode
    {
        public readonly Identifier Column;
        public readonly IExpression Value;
        public Assignment(Identifier column, IExpression value)
        {
            Column = column;
            Value = value;
        }
        public T Visitor<T>(INodeVisitor<T> visitor)
        {
            return visitor.VisitAssignment(this);
        }
        public void Visitor(INodeVisitor visitor)
        {
            visitor.VisitAssignment(this);
        }
    }
    sealed class Binary : IExpression
    {
        public readonly IExpression Left;
        public readonly OperatorOfType Operator;
        public readonly IExpression Right;
        public Binary(IExpression left, OperatorOfType oper, IExpression right)
        {
            Left = left;
            Operator = oper;
            Right = right;
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
        public T Visitor<T>(INodeVisitor<T> visitor)
        {
            return visitor.VisitBinary(this);
        }
        public void Visitor(INodeVisitor visitor)
        {
            visitor.VisitBinary(this);
        }
    }
    class Identifier : IExpression
    {
        public readonly string Name;

        public Identifier(string identifier)
        {
            Name = identifier;
        }
        public T Visitor<T>(INodeVisitor<T> visitor)
        {
            return visitor.VisitIdentifier(this);
        }
        public void Visitor(INodeVisitor visitor)
        {
            visitor.VisitIdentifier(this);
        }
    }
    class Number : IExpression
    {
        public readonly string Lexeme;
        public Number(string lexeme)
        {
            Lexeme = lexeme;
        }
        public T Visitor<T>(INodeVisitor<T> visitor)
        {
            return visitor.VisitNumber(this);
        }
        public void Visitor(INodeVisitor visitor)
        {
            visitor.VisitNumber(this);
        }
    }
    enum OperatorOfType
    {
        Add,
        Subtract,
        Multiply,
        Divide,
        Greater,
        Less,
        Equal,
    }

    class Parenthesis : IExpression
    {
        public readonly IExpression Child;
        public Parenthesis(IExpression child)
        {
            Child = child;
        }
        public T Visitor<T>(INodeVisitor<T> visitor)
        {
            return visitor.VisitParenthesis(this);
        }
        public void Visitor(INodeVisitor visitor)
        {
            visitor.VisitParenthesis(this);
        }
    }
}
