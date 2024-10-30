using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_7
{
    class System
    {
        public double FirstFunction(double x, double y)
        {
            //return ((3 * x * x) / (y * y)) + ((6 * y) / x) - (8 / (x * y * y));
            //return (y * y * y) / 3 - (2 * y * y * y) / (x * x) + 8 / (3 * x * x);
            //return (9 * y - 2) / Math.Pow(x, 3);
            return (10 * Math.Sin(x + y) + 1) / 15;
        }
        public double SecondFunction(double x, double y)
        {
            //return (Math.Pow(x, 4) + 2) / 9;
            //return Math.Sqrt(3 * x + 6 * Math.Pow(y, 3) / Math.Pow(x, 2) - 8 / (x * x));
            return (1 - x * x) / y;
        }
        public double FullFirstFunction(double x, double y)
        {
            return 10 * Math.Sin(x + y) - 15 * x + 1;
        }
        public double FullSecondFunction(double x, double y)
        {
            return x * x + y * y - 1;
        }
        public double FirstDx(double x, double y)
        {
            return 10 * Math.Cos(x + y) - 15;
        }
        public double FirstDy(double x, double y)
        {
            return 10 * Math.Cos(x + y);
        }
        public double SecondDx(double x, double y)
        {
            return 2 * x;
        }
        public double SecondDy(double x, double y)
        {
            return 2 * y;
        }
        public double Diff(double x, double y)
        {
            return 2 * Math.Cos(x + y) / 3;
        }
    }
}
