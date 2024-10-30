using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_2
{
    interface IExpression : INode { }
    interface Assignments : INode { }
    class UpdateStmt : INode
    {
        public readonly Identifier TableName;
        public readonly IReadOnlyList<Binary> Assignments;
        public IExpression WhereCondition;
        public UpdateStmt(Identifier tableName, IReadOnlyList<Binary> assignments, IExpression whereCondition)
        {
            TableName = tableName;
            Assignments = assignments;
            WhereCondition = whereCondition;
        }
        public string ToFormattedString() =>
            $"UPDATE {TableName.ToFormattedString()} SET {string.Join(", ", Assignments.Select(expr => expr.ToFormattedString()))}, WHERE {WhereCondition.ToFormattedString()}";
        public void DebugPrint(TextWriter o, int depth)
        {
            o.WriteIndent(depth);
            o.Write($"new {nameof(UpdateStmt)}(\n");
            o.WriteIndent(depth + 1);
            TableName.DebugPrint(o, depth + 1);
            o.Write(",\n");
            o.WriteIndent(depth + 1);
            o.Write($"new {nameof(Binary)}[]{{\n");
            for (int i = 0; i < Assignments.Count; i++)
            {
                if (i != 0)
                {
                    o.Write(",\n");
                }
                o.WriteIndent(depth + 1);
                Assignments[i].DebugPrint(o, depth + 2);
            }
            o.WriteIndent(depth);
            o.Write("\n");
            o.WriteIndent(depth+1);
            o.Write("},\n");
            WhereCondition.DebugPrint(o, depth + 1);
            o.WriteIndent(depth);
            o.Write("\n)");
        }
    }
    static class TextWriterExtensions
    {
        public static void WriteIndent(this TextWriter o, int depth)
        {
            o.Write(new string(' ', depth * 2));
        }
    }
    interface INode
    {
        string ToFormattedString();
        void DebugPrint(TextWriter o, int depth);
    }
    class Identifier : IExpression
    {
        public readonly string Name;

        public Identifier(string identifier)
        {
            Name = identifier;
        }
        public string ToFormattedString()
        {
            return $"{Name}";
        }
        public void DebugPrint(TextWriter o, int depth)
        {
            o.Write($"new {nameof(Identifier)}(\"{Name}\")");
        }
    }
    class Number : IExpression
    {
        public readonly string Lexeme;
        public Number(string lexeme)
        {
            Lexeme = lexeme;
        }
        public string ToFormattedString()
        {
            return $"{Lexeme}";
        }
        public void DebugPrint(TextWriter o, int depth)
        {
            o.Write($"new {nameof(Number)}(\"{Lexeme}\")");
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
        public string ToFormattedString()
        {
            return $"{Left.ToFormattedString()} {GetOperator(Operator)} {Right.ToFormattedString()}";
        }
        public void DebugPrint(TextWriter o, int depth)
        {
            o.WriteIndent(depth);
            o.Write($"new {nameof(Binary)}(\n");
            o.WriteIndent(depth + 1);
            Left.DebugPrint(o, depth + 1);
            o.Write(",\n");
            o.WriteIndent(depth + 1);
            o.Write($"{nameof(OperatorOfType)}.{Operator}");
            o.Write(",\n");
            o.WriteIndent(depth + 1);
            Right.DebugPrint(o, depth);
            o.Write("\n");
            o.WriteIndent(depth + 1);
            o.Write($")");
        }
    }
    class Parenthesis : IExpression
    {
        public readonly IExpression Child;
        public Parenthesis(IExpression child)
        {
            Child = child;
        }

        public string ToFormattedString()
        {
            return $"({Child.ToFormattedString()})";
        }

        public void DebugPrint(TextWriter o, int depth)
        {
            o.WriteIndent(depth);
            o.Write($"new {nameof(Parenthesis)}(\n");
            Child.DebugPrint(o, depth + 1);
            o.Write("\n");
            o.WriteIndent(depth + 1);
            o.Write(")");
        }
    }
    static class NodeExtensions
    {
        public static string ToDebugString(this INode node)
        {
            using (var o = new StringWriter())
            {
                node.DebugPrint(o, 0);
                o.Write("\n");
                return o.ToString();
            }
        }
    }

    static class Program
    {
        static void Main()
        {
            //UPDATE t1 SET col1 = (col1 + 2) * 3, col2 = (col2 - 4) / 5 WHERE col3 + 6 * 7 > 5
            var tree = new UpdateStmt(
                new Identifier("t1"),
                new Binary[] {
                    new Binary(
                        new Identifier("col1"),
                        OperatorOfType.Equal,
                        new Binary(
                            new Parenthesis(
                                new Binary(
                                    new Identifier("col1"),
                                    OperatorOfType.Add,
                                    new Number("2")
                                )
                            ),
                            OperatorOfType.Multiply,
                            new Number("3")
                            )
                        ),
                        new Binary(
                        new Identifier("col2"),
                        OperatorOfType.Equal,
                        new Binary(
                            new Parenthesis(
                                new Binary(
                                    new Identifier("col2"),
                                    OperatorOfType.Subtract,
                                    new Number("4")
                                )
                            ),
                            OperatorOfType.Divide,
                            new Number("5")
                            )
                        )
                    },
                    new Binary(
                        new Binary(
                            new Binary(
                                new Identifier("col3"),
                                OperatorOfType.Add,
                                new Number("6")
                                ),
                            OperatorOfType.Multiply,
                            new Number("7")
                            ),
                        OperatorOfType.Greater,
                        new Number("5")
                        )
                    );

            Console.WriteLine(tree.ToFormattedString());
            Console.WriteLine(tree.ToDebugString());
        }
    }
}