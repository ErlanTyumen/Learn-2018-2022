using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_7
{
    class Method
    {
       public static Solution IterationMethod(double eps)
        {
            System system = new System();
            double x0 = 0.7;
            double y0 = 0.6;
            double xn = system.FirstFunction(x0, y0);
            double yn = system.SecondFunction(x0, y0);
            int count = 0;
            do
            {
                count++;
                x0 = xn;
                y0 = yn;
                xn = system.FirstFunction(x0, y0);
                yn = system.SecondFunction(x0, y0);
            } while (Math.Abs(xn - x0) > eps && Math.Abs(yn - y0) > eps);
            return new Solution(xn, yn, count, eps);
       }
        public static Solution NewtonMethod(double eps)
        {
            System system = new System();
            double x = 0.7;
            double y = 0.6;
            int count = 0;
            while(Math.Abs(system.FullFirstFunction(x,y)) > eps && Math.Abs(system.FullSecondFunction(x, y)) > eps)
            {
                count++;
                x = x - (1 / Jacobian(x, y) * (system.FullFirstFunction(x, y) * system.SecondDy(x, y) - system.FullSecondFunction(x, y) * system.FirstDy(x, y)));
                y = y - (1 / Jacobian(x, y) * (system.FullSecondFunction(x, y) * system.FirstDx(x, y) - system.FullFirstFunction(x, y) * system.SecondDx(x, y)));
            }
            return new Solution(x, y, count, eps);
        }
        public static double Jacobian(double x, double y)
        {
            System system = new System();
            return system.FirstDx(x, y) * system.SecondDy(x, y) - system.FirstDy(x, y) * system.SecondDx(x, y);
        }
    }
}
