using Lab4.Ast.Expressions;
namespace Lab4.Ast {
	interface IExpressionVisitor {
		void VisitBinary(Binary binary);
		void VisitCall(Call call);
		void VisitArrayCreation(ArrayLiteral arrayCreation);
		void VisitParentheses(Parentheses parentheses);
		void VisitNumber(Number number);
		void VisitIdentifier(Identifier identifier);
		void VisitMemberAccess(MemberAccess memberAccess);
		void VisitElementAccess(ElementAccess elementAccess);
	}
	interface IExpressionVisitor<T> {
		T VisitBinary(Binary binary);
		T VisitCall(Call call);
		T VisitArrayCreation(ArrayLiteral arrayCreation);
		T VisitParentheses(Parentheses parentheses);
		T VisitNumber(Number number);
		T VisitIdentifier(Identifier identifier);
		T VisitMemberAccess(MemberAccess memberAccess);
		T VisitElementAccess(ElementAccess elementAccess);
	}
}
