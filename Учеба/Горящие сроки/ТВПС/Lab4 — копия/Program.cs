using Lab4.Ast;
using Lab4.Interpreting;
using Lab4.Interpreting.Values.Functions;
using Lab4.Parsing;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Numerics;
namespace Lab4 {
	sealed class Program {
		static ProgramNode CheckedParse(SourceFile sourceFile) {
			var programNode = Parser.Parse(sourceFile);
			var code2 = programNode.FormattedString;
			var programNode2 = Parser.Parse(SourceFile.FromString(code2));
			var code3 = programNode2.FormattedString;
			if (code2 != code3) {
				Console.WriteLine(code2);
				Console.WriteLine(code3);
				throw new Exception($"Кривой парсер или {nameof(INode.FormattedString)} у узлов");
			}
			return programNode;
		}
		static void Main(string[] args) {
			var interpreter = new Interpreter();
			interpreter.Variables.Add("x", (BigInteger)2);
			interpreter.Variables.Add("y", (BigInteger)10);
			interpreter.Variables.Add("z", (BigInteger)4);
			interpreter.RunProgram(CheckedParse(SourceFile.Read("../../code.txt")));
			interpreter.RunProgram(CheckedParse(SourceFile.FromString("dump(x, y, z);")));
			foreach (var variable in interpreter.Variables.OrderBy(x => x.Key, StringComparer.Ordinal)) {
				Console.WriteLine($" - {variable.Key}: {DumpFunction.ValueToString(variable.Value)}");
			}
		}
	}
}
