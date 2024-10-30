using Lab4.Ast.Expressions;
namespace Lab4.Ast.Statements {
	sealed class ArrayAssignment : IStatement {
		public readonly ElementAccess Left;
		public readonly IExpression Expr;
		public string FormattedString => $"{Left.FormattedString} = {Expr.FormattedString};\n";
		public ArrayAssignment(ElementAccess left, IExpression expr) {
			Left = left;
			Expr = expr;
		}
		public void Accept(IStatementVisitor visitor) => visitor.VisitArrayAssignment(this);
		public T Accept<T>(IStatementVisitor<T> visitor) => visitor.VisitArrayAssignment(this);
	}
}
