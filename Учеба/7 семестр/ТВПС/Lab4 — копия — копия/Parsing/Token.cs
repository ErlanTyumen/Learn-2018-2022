using System.Numerics;
namespace Lab4.Parsing {
	sealed class Token {
		public readonly BigInteger Position;
		public readonly TokenType Type;
		public readonly string Lexeme;
		public Token(BigInteger position, TokenType type, string lexeme) {
			Regexes.Instance.CheckToken(type, lexeme);
			Position = position;
			Type = type;
			Lexeme = lexeme;
		}
		public override string ToString() => $"{Type} \"{Lexeme}\"";
	}
}
