using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_3
{
    class Program
    {
        static void Main(string[] args)
        {
            var source = "UPDATE t1 SET col1 = (col1 + 2) * 3, col2 = (col2 - 4) / 5 WHERE col3 + 6 * 7 > 5";
            var tree = new Parser(source).ParseUpdateStmt();
            Console.WriteLine(tree.ToFormattedString());
            Console.WriteLine(tree.ToDebugString());
        }
        static void Main2(string[] args)
        {
            new UpdateStmt(
     new Identifier("t1"),
     new Assignment[] {
         new Assignment(
new Identifier("col1"),
      new Binary(
                new Parenthesis(
          new Binary(
            new Identifier("col1"),
            OperatorOfType.Add,
            new Number("2")
            )
          ),
        OperatorOfType.Multiply,
        new Number("3")
        )
    ),
         new Assignment(
new Identifier("col2"),
      new Binary(
                new Parenthesis(
          new Binary(
            new Identifier("col2"),
            OperatorOfType.Subtract,
            new Number("4")
            )
          ),
        OperatorOfType.Divide,
        new Number("5")
        )
    )
     },
     new Binary(
           new Binary(
         new Identifier("col3"),
         OperatorOfType.Add,
             new Binary(
         new Number("6"),
         OperatorOfType.Multiply,
         new Number("7")
         )
         ),
       OperatorOfType.Greater,
       new Number("5")
       )
   )
;
        }
    }
}