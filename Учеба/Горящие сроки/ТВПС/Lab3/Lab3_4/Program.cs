using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_4
{
    class Program
    {
		static void Main()
		{
			var source = "UPDATE t1 SET col1 = (col1 + (((1)))/2) * 3 WHERE 1 > 5 < 2";
			var tree = new Parser(source).ParseUpdateStmt();
            tree = new UpdateStmt(
  new Identifier("t1"),
  new Assignment[]{
    new Assignment(
      new Identifier("col1"),
      new Binary(
        new Parenthesis(
          new Binary(
            new Identifier("col1"),
            OperatorOfType.Add,
            new Binary(
              new Parenthesis(
                new Parenthesis(
                  new Parenthesis(
                    new Number("1")
                  )
                )
              ),
              OperatorOfType.Divide,
              new Number("2")
            )
          )
        ),
        OperatorOfType.Multiply,
        new Number("3")
      )
    )
  },
  new Binary(
    new Binary(
      new Number("1"),
      OperatorOfType.Greater,
      new Number("5")
    ),
    OperatorOfType.Less,
    new Number("2")
  )
);
            Console.WriteLine(tree.Visitor(new NodeStringifier()));
			tree.Visitor(new DebugNodePrinter(Console.Out));
		}
	}
}
