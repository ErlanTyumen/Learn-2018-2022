using System.Numerics;
namespace Lab4.Ast {
	interface IExpression : INode {
		BigInteger Position { get; }
		void Accept(IExpressionVisitor visitor);
		T Accept<T>(IExpressionVisitor<T> visitor);
	}
}
