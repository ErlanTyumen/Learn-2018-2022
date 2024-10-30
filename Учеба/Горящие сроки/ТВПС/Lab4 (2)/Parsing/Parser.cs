using Lab4.Ast;
using Lab4.Ast.Expressions;
using Lab4.Ast.Statements;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Lab4.Parsing {
	sealed class Parser {
		readonly SourceFile sourceFile;
		readonly IReadOnlyList<Token> tokens;
		int tokenIndex = 0;
		Token CurrentToken => tokens[tokenIndex];
		int CurrentPosition => CurrentToken.Position;
		Parser(SourceFile sourceFile, IReadOnlyList<Token> tokens) {
			this.sourceFile = sourceFile;
			this.tokens = tokens;
		}
		#region stuff
		string[] DebugCurrentPosition => sourceFile.FormatLines(CurrentPosition,
			inlinePointer: true,
			pointer: " <|> "
			).ToArray();
		string DebugCurrentLine => string.Join("", sourceFile.FormatLines(CurrentPosition,
			linesAround: 0,
			inlinePointer: true,
			pointer: " <|> "
			).ToArray());
		static bool IsNotWhitespace(Token t) {
			switch (t.Type) {
				case TokenType.Whitespaces:
				case TokenType.SingleLineComment:
				case TokenType.MultiLineComment:
					return false;
				default:
					return true;
			}
		}
		void ExpectEof() {
			if (CurrentToken.Type != TokenType.EnfOfFile) {
				throw MakeError($"Не допарсили до конца, остался {CurrentToken}");
			}
		}
		void ReadNextToken() {
			tokenIndex += 1;
		}
		void Reset() {
			tokenIndex = 0;
		}
		Exception MakeError(string message) {
			return new Exception(sourceFile.MakeErrorMessage(CurrentPosition, message));
		}
		bool SkipIf(string s) {
			if (CurrentToken.Lexeme == s) {
				ReadNextToken();
				return true;
			}
			return false;
		}
		void Expect(string s) {
			if (!SkipIf(s)) {
				throw MakeError($"Ожидали \"{s}\", получили {CurrentToken}");
			}
		}
		#endregion
		public static ProgramNode Parse(SourceFile sourceFile) {
			var eof = new Token(sourceFile.Text.Length, TokenType.EnfOfFile, "");
			var tokens = Lexer.GetTokens(sourceFile).Concat(new[] { eof }).Where(IsNotWhitespace).ToList();
			var parser = new Parser(sourceFile, tokens);
			return parser.ParseProgram();
		}
		ProgramNode ParseProgram() {
			Reset();
			var statements = new List<IStatement>();
			while (CurrentToken.Type != TokenType.EnfOfFile) {
				statements.Add(ParseStatement());
			}
			var result = new ProgramNode(sourceFile, statements);
			ExpectEof();
			return result;
		}
		Block ParseBlock() {
			throw new NotImplementedException();
		}
		IStatement ParseStatement() {
			if (SkipIf("if")) {
				Expect("(");
				var condition = ParseExpression();
				Expect(")");
				var block = ParseBlock();
				return new If(condition, block);
			}
			if (SkipIf("while")) {
				Expect("(");
				var condition = ParseExpression();
				Expect(")");
				var block = ParseBlock();
				return new While(condition, block);
			}
			if (SkipIf("var")) {
				var variable = ParseIdentifier();
				Expect("=");
				var expression = ParseExpression();
				Expect(";");
				return new VariableDeclaration(variable, expression);
			}
			var leftExpression = ParseExpression();
			if (SkipIf("=")) {
				if (!(leftExpression is Identifier identifier)) {
					throw MakeError("Присваивание не в переменную");
				}
				var rightExpression = ParseExpression();
				Expect(";");
				return new VariableAssignment(identifier.Name, rightExpression);
			}
			else {
				Expect(";");
				return new ExpressionStatement(leftExpression);
			}
		}
		string ParseIdentifier() {
			if (CurrentToken.Type != TokenType.Identifier) {
				throw MakeError($"Ожидали идентификатор, получили {CurrentToken}");
			}
			var lexeme = CurrentToken.Lexeme;
			ReadNextToken();
			return lexeme;
		}
		#region expressions
		IExpression ParseExpression() {
			return ParseEqualityExpression();
		}
		IExpression ParseEqualityExpression() {
			throw new NotImplementedException();
		}
		IExpression ParseRelationalExpression() {
			throw new NotImplementedException();
		}
		IExpression ParseAdditiveExpression() {
			throw new NotImplementedException();
		}
		IExpression ParseMultiplicativeExpression() {
			var left = ParsePrimary();
			while (true) {
				var pos = CurrentPosition;
				if (SkipIf("*")) {
					var right = ParsePrimary();
					left = new Binary(pos, left, BinaryOperator.Multiplication, right);
				}
				else if (SkipIf("/")) {
					var right = ParsePrimary();
					left = new Binary(pos, left, BinaryOperator.Division, right);
				}
				else if (SkipIf("%")) {
					var right = ParsePrimary();
					left = new Binary(pos, left, BinaryOperator.Remainder, right);
				}
				else {
					break;
				}
			}
			return left;
		}
		IExpression ParsePrimary() {
			var expression = ParsePrimitive();
			while (true) {
				int pos = CurrentPosition;
				if (SkipIf("(")) {
					var arguments = new List<IExpression>();
					if (!SkipIf(")")) {
						arguments.Add(ParseExpression());
						while (SkipIf(",")) {
							arguments.Add(ParseExpression());
						}
						Expect(")");
					}
					expression = new Call(pos, expression, arguments);
				}
				else if (SkipIf(".")) {
					var member = ParseIdentifier();
					expression = new MemberAccess(pos, expression, member);
				}
				else {
					break;
				}
			}
			return expression;
		}
		IExpression ParsePrimitive() {
			var pos = CurrentPosition;
			if (CurrentToken.Type == TokenType.NumberLiteral) {
				var lexeme = CurrentToken.Lexeme;
				ReadNextToken();
				return new Number(pos, lexeme);
			}
			if (CurrentToken.Type == TokenType.Identifier) {
				var lexeme = CurrentToken.Lexeme;
				ReadNextToken();
				return new Identifier(pos, lexeme);
			}
			if (SkipIf("(")) {
				var parentheses = new Parentheses(pos, ParseExpression());
				Expect(")");
				return parentheses;
			}
			throw MakeError($"Ожидали идентификатор, число или открывающую скобку, получили {CurrentToken}");
		}
		#endregion
	}
}
