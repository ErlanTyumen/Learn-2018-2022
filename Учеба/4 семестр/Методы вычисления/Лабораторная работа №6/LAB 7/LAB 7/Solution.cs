using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_7
{
    class Solution
    {
        public Solution(double x, double y, int count, double eps)
        {
            X = x;
            Y = y;
            Count = count;
            Epsilon = eps;
        }
        public double X { get; set; }
        public double Y { get; set; }
        public int Count { get; set; }
        public double Epsilon { get; set; }
        public void Print(string c)
        {
            Console.WriteLine($"{c} X = {X:f9} Y = {Y:f9} Iterations = {Count,2} Epsilon = {Epsilon}");
        }
    }
}
