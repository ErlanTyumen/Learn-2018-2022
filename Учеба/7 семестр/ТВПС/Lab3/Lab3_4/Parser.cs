
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_4
{
    class Parser
    {
        readonly Token[] tokens;
        int pos = 0;
        public Parser(string source)
        {
            tokens = GetTokens(source);
        }
        Token[] GetTokens(string source)
        {
            return Token.RemoveSpaces(Token.GetTokens(source)).Append(new Token(TokenType.End, "")).ToArray();
        }
        bool CurrentIs(string lexeme)
        {
            return tokens[pos].Lexeme == lexeme;
        }
        void Skip()
        {
            pos++;
        }
        bool SkipIf(string lexeme)
        {
            if (tokens[pos].Type != TokenType.End && CurrentIs(lexeme))
            {
                pos++;
                return true;
            }
            return false;   
        }
        void Expect(string lexeme)
        {
            if (!SkipIf(lexeme))
            {
                throw new Exception($"Error {lexeme}");
            }
        }
        public UpdateStmt ParseUpdateStmt()
        {
            Expect("UPDATE");
            var identifier = ParseIdentifier();
            Expect("SET");
            var assignments = ParseAssignments();
            Expect("WHERE");
            var condition = ParseExpression();
            if (tokens[pos].Type != TokenType.End)
            {
                throw new Exception("Error");
            }
            return new UpdateStmt(identifier, assignments, condition);
        }
        public List<Assignment> ParseAssignments()
        {
            var assignments = new List<Assignment>();
            while (true)
            {
                assignments.Add(ParseAssignment());
                if (!SkipIf(","))
                {
                    break;
                }
            }
            return assignments;
        }
        Assignment ParseAssignment()
        {
            var Column = ParseIdentifier();
            Expect("=");
            var Value = ParseExpression();
            return new Assignment(Column, Value);
        }
        IExpression ParseExpression()
        {
            return ParseInequality();
        }
        IExpression ParseInequality()
        {
            var left = ParseAdditive();
            while (true)
            {
                OperatorOfType operation;
                if (SkipIf(">"))
                {
                    operation = OperatorOfType.Greater;
                }
                else if (SkipIf("<"))
                {
                    operation = OperatorOfType.Less;
                }
                else
                {
                    break;
                }
                var right = ParseAdditive();
                left = new Binary(left, operation, right);
            }
            return left;
        }
        IExpression ParseAdditive()
        {
            var left = ParseMultiplicative();
            while (true)
            {
                OperatorOfType operation;
                if (SkipIf("+"))
                {
                    operation = OperatorOfType.Add;
                }
                else if (SkipIf("-"))
                {
                    operation = OperatorOfType.Subtract;
                }
                else
                {
                    break;
                }
                var right = ParseMultiplicative();
                left = new Binary(left, operation, right);
            }
            return left;
        }
        IExpression ParseMultiplicative()
        {
            var left = ParsePrimary();
            while (true)
            {
                OperatorOfType operation;
                if (SkipIf("*"))
                {
                    operation = OperatorOfType.Multiply;
                }
                else if (SkipIf("/"))
                {
                    operation = OperatorOfType.Divide;
                }
                else
                {
                    break;
                }
                var right = ParsePrimary();
                left = new Binary(left, operation, right);
            }
            return left;
        }
        IExpression ParsePrimary()
        {
            if (tokens[pos].Type == TokenType.Identifier)
            {
                return ParseIdentifier();
            }
            if (tokens[pos].Type == TokenType.NumberLiteral)
            {
                return ParseNumber();
            }
            return ParseParentheses();
        }
        Identifier ParseIdentifier()
        {
            if (tokens[pos].Type == TokenType.Identifier)
            {
                Skip();
                return new Identifier(tokens[pos - 1].Lexeme);
            }
            throw new Exception($"Ожидали {TokenType.Identifier}, получили {tokens[pos].Type}");
        }
        Number ParseNumber()
        {
            if (tokens[pos].Type == TokenType.NumberLiteral)
            {
                Skip();
                return new Number(tokens[pos - 1].Lexeme);
            }
            throw new Exception($"Ожидали {TokenType.NumberLiteral}, получили {tokens[pos].Type}");
        }
        Parenthesis ParseParentheses()
        {
            Expect("(");
            var expr = ParseExpression();
            Expect(")");
            return new Parenthesis(expr);
        }
    }
}