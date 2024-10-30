using System.Numerics;
namespace Lab4.Ast.Expressions {
	sealed class Parentheses : IExpression {
		public BigInteger Position { get; }
		public readonly IExpression Expr;
		public Parentheses(BigInteger position, IExpression expr) {
			Position = position;
			Expr = expr;
		}
		public string FormattedString => $"({Expr.FormattedString})";
		public void Accept(IExpressionVisitor visitor) => visitor.VisitParentheses(this);
		public T Accept<T>(IExpressionVisitor<T> visitor) => visitor.VisitParentheses(this);
	}
}
