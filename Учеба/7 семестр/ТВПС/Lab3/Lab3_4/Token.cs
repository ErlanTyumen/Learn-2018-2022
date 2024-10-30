using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;
using System.Linq;

namespace Lab3_4
{
    public enum TokenType
    {
        Identifier,
        Spaces,
        Punctuator,
        NumberLiteral,
        StringLiteral,
        End,
    }
    class Token
    {
        public readonly TokenType Type;
        public readonly string Lexeme;
        public Token(TokenType type, string lexeme)
        {
            Type = type;
            Lexeme = lexeme;
        }
        public static IEnumerable<Token> GetTokens(string text)
        {
            var regex = new Regex(@"
                (?<StringLiteral>@""(""""|[^""])*"") |
                (?<Identifier>[a-zA-Z][a-zA-Z0-9]*) |  
                (?<Punctuator>\.|\,|\(|\)|\=|\+|\-|\*|\/|\>|\<|\$) |
                (?<NumberLiteral>[0-9]+) |
                (?<Spaces>[ \n\t\r]+|/\*(.|\n)*\*/)
                ", RegexOptions.IgnorePatternWhitespace);
            int index = 0;
            foreach (Match match in regex.Matches(text))
            {
                var lexeme = match.Value;
                if (match.Index != index)
                {
                    throw new Exception(@"Error: " + index);
                }
                index = match.Index + match.Length;
                if (match.Groups[@"Identifier"].Success)
                {
                    yield return new Token(TokenType.Identifier, lexeme);
                }
                else if (match.Groups[@"Spaces"].Success)
                {
                    yield return new Token(TokenType.Spaces, lexeme);
                }
                else if (match.Groups[@"Punctuator"].Success)
                {
                    yield return new Token(TokenType.Punctuator, lexeme);
                }
                else if (match.Groups[@"NumberLiteral"].Success)
                {
                    yield return new Token(TokenType.NumberLiteral, lexeme);
                }
                else if (match.Groups[@"StringLiteral"].Success)
                {
                    yield return new Token(TokenType.StringLiteral, lexeme);
                }
            }
            if (text.Length != index)
            {
                throw new Exception(@"Error: " + index);
            }
        }
        public static IEnumerable<Token> RemoveSpaces(IEnumerable<Token> tokens)
        {
            foreach (var token in tokens)
            {
                if (token.Type != TokenType.Spaces)
                {
                    yield return token;
                }
            }
        }
    }
}

