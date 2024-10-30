namespace Lab3_4
{
    interface INodeVisitor<T>
    {
        T VisitUpdateStmt(UpdateStmt updateStmt);
        T VisitAssignment(Assignment assignment);
        T VisitBinary(Binary binary);
        T VisitParenthesis(Parenthesis parenthesis);
        T VisitNumber(Number number);
        T VisitIdentifier(Identifier identifier);
    }
    interface INodeVisitor
    {
        void VisitUpdateStmt(UpdateStmt updateStmt);
        void VisitAssignment(Assignment assignment);
        void VisitBinary(Binary binary);
        void VisitParenthesis(Parenthesis parenthesis);
        void VisitNumber(Number number);
        void VisitIdentifier(Identifier identifier);
    }
}
