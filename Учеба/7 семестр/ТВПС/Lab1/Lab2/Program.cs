using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;
using System.Linq;

namespace Lab2
{
    public enum TokenType
    {
        Identifier,
        Spaces,
        Punctuator,
        NumberLiteral,
        StringLiteral
    }
    public class Token
    {
        public readonly TokenType Type;
        public readonly string Lexeme;
        public Token(TokenType type, string lexeme)
        {
            Type = type;
            Lexeme = lexeme;
        }
    }
    class Program
    {
        public static IEnumerable<Token> GetTokens(string text)
        {
            var regex = new Regex(@"
                (?<StringLiteral>@""(""""|[^""])*"") |
                (?<Identifier>[a-zA-Z][a-zA-Z0-9]*) |
                (?<Punctuator>=>|\+\+|!=|[<>{}[\]()=+\.,:;""\\)@]) |
                (?<NumberLiteral>[0-9]+) |
                (?<Spaces>[ \n\r\t]+|/\*.*?\*/)
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
        static void Main(string[] args)
        {
            string input = File.ReadAllText(@"../../../Lab2/Program.cs", Encoding.Default);
            var str = new StringBuilder();
            foreach (var token in GetTokens(input))
            {
                switch (1)
                {
                    case 0:
                        str.Append("/*" + token.Type.ToString() + "*/" + token.Lexeme);
                        break;
                    case 1:
                        str.Append(token.Lexeme).Append(@" ");
                        break;
                    case 2:
                        str.Append(token.Lexeme);
                        break;
                }
            }
            string output = str.ToString();
            File.WriteAllText(@"../../../Lab2Out/Program.cs", output, Encoding.Default);
        }
        static string EscapeCsvValue(string s) => @"""" + s.Replace(@"""", @"""""") + @"""";
        static void Text(string[] args)
        {
            int k = 0;
            var s = File.ReadAllText(@"..\..\Regex.txt");
            var p = File.ReadAllText(@"..\..\Text.txt");
            List<string> output = new List<string>();
            output.Add(EscapeCsvValue(@"Номер") + @";"
                     + EscapeCsvValue(@"Группа 1") + @";"
                     + EscapeCsvValue(@"Группа 2") + @";"
                     + EscapeCsvValue(@"Группа 3") + @";"
                     + EscapeCsvValue(@"Группа 4") + @";"
                     + EscapeCsvValue(@"Группа 5"));
            var rx = new Regex(s);
            foreach (Match match in rx.Matches(p))
            {
                k++;
                output.Add(EscapeCsvValue(@"строка ") + k + @";" +
                           EscapeCsvValue(match.Groups[1].Value) + @";" +
                           EscapeCsvValue(match.Groups[2].Value) + @";" +
                           EscapeCsvValue(match.Groups[3].Value) + @";" +
                           EscapeCsvValue(match.Groups[4].Value) + @";" +
                           EscapeCsvValue(match.Groups[5].Value) + @";");
            }
            File.WriteAllLines(@"..\..\Output.csv", output, Encoding.Default);
        }
    }
}