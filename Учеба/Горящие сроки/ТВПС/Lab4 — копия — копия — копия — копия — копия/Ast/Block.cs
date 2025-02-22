﻿using System.Collections.Generic;
using System.Linq;
namespace Lab4.Ast {
	sealed class Block : INode {
		public readonly IReadOnlyList<IStatement> Statements;
		public Block(IReadOnlyList<IStatement> statements) {
			Statements = statements;
		}
		public string FormattedString => "{\n" + string.Join("", Statements.Select(x => x.FormattedString)) + "}\n";
	}
}
