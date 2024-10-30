using System.Numerics;
namespace Lab4.Ast.Expressions {
	sealed class Number : IExpression {
		public BigInteger Position { get; }
		public readonly string Lexeme;
		public Number(BigInteger position, string lexeme) {
			Position = position;
			Lexeme = lexeme;
		}
		public string FormattedString => Lexeme;
		public void Accept(IExpressionVisitor visitor) => visitor.VisitNumber(this);
		public T Accept<T>(IExpressionVisitor<T> visitor) => visitor.VisitNumber(this);
	}
}
