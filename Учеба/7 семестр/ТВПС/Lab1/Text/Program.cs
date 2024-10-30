using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace Lab1
{
    class Program
    {
        static string EscapeCsvValue(string s) => @"""" + s.Replace(@"""", @"""""") + @"""";
        static void Main(string[] args)
        {
            int k = 0;
            var s = File.ReadAllText(@"..\..\Regex.txt");
            var p = File.ReadAllText(@"..\..\Text.txt");
            List<string> output = new List<string>();
            output.Add(EscapeCsvValue(@"Номер") + @";"
                + EscapeCsvValue(@"Группа 1") + @";"
                + EscapeCsvValue(@"Группа 2") + @";"
                + EscapeCsvValue(@"Группа 3") + @";"
                + EscapeCsvValue(@"Группа 4") + @";"
                + EscapeCsvValue(@"Группа 5"));
            var rx = new Regex(s);
            foreach (Match match in rx.Matches(p))
            {
                k++;
                output.Add(EscapeCsvValue(@"строка ") + k + @";" +
                     EscapeCsvValue(match.Groups[1].Value) + @";" +
                     EscapeCsvValue(match.Groups[2].Value) + @";" +
                     EscapeCsvValue(match.Groups[3].Value) + @";" +
                     EscapeCsvValue(match.Groups[4].Value) + @";" +
                     EscapeCsvValue(match.Groups[5].Value) + @";");
            }
            File.WriteAllLines(@"..\..\Output.csv", output, Encoding.Default);
        }
    }
}