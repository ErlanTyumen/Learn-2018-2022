using System.Collections.Generic;
using System.Linq;
namespace Lab4.Ast.Expressions {
	sealed class ArrayLiteral : IExpression {
		public int Position { get; }
		public readonly IReadOnlyList<IExpression> Items;
		public string FormattedString => $"[{string.Join(", ", Items.Select(x => x.FormattedString))}]";
		public ArrayLiteral(int position, IReadOnlyList<IExpression> items) {
			Position = position;
			Items = items;
		}
		public void Accept(IExpressionVisitor visitor) => visitor.VisitArrayCreation(this);
		public T Accept<T>(IExpressionVisitor<T> visitor) => visitor.VisitArrayCreation(this);
	}
}
