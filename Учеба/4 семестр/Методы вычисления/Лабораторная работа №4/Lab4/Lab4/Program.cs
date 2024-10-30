using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class Program
    {
        static void Main(string[] args) //
        {
            double e = 0.001, a = 0.01, b = 0.99;
            Tuple<double, int>[] res = new Tuple<double, int>[4];
            res[0] = Function.MethodBisection(equation, a, b, e);
            res[1] = Function.MethodSecant(equation, Derivative2, a, b, e);
            res[2] = Function.MethodNewton(equation, Derivative1, Derivative2, a, b, e);
            res[3] = Function.MethodSecuschih(equation, a, b, e);
            Console.WriteLine("______________________________________________________________________________");
            Console.WriteLine("| Метод         | Начальное приближение | Полученный корень  | Число итераций|");
           Console.WriteLine($"|Метод бисекций | (0 ; 1)               |{res[0].Item1}        |{res[0].Item2}              |");
           Console.WriteLine($"|Метод хорд     | (0 ; 1)               |{res[1].Item1}   |{res[1].Item2}              |");
           Console.WriteLine($"|Метод Ньютона  | (0 ; 1)               |{res[2].Item1}   |{res[2].Item2}              |");
           Console.WriteLine($"|Метод секущих  | (0 ; 1)               |{res[3].Item1}   |{res[3].Item2}              |");
            Console.WriteLine("______________________________________________________________________________");
           Console.ReadKey();
        }
        static double equation(double x) //Функция
        {
            return Math.Exp(x) - Math.Acos(Math.Sqrt(x));
        }
        static double Derivative1(double x) //Производная функция первого порядка
        {
            return Math.Exp(x) + (1 / (2 * Math.Sqrt(x) * Math.Sqrt(1 - x)));
        }
        static double Derivative2(double x) //Производная функция второго порядка
        {
            return Math.Exp(x) + (1 / (4 * Math.Sqrt(x) * Math.Pow((1 - x), 1.5))) - (1 / (4 * Math.Pow(x, 1.5) * Math.Sqrt(1 - x)));
        }
    }
    public static class Function
    {
        static public Tuple<double, int> MethodBisection(F f, double a, double b, double e)
        {
            double x = 0;
            int count = 0;
            while ((b - a) > 2 * e)
            {
                x = (a + b) / 2;
                if (f(x) > 0)
                {
                    if (f(a) < 0)
                        b = x;
                    else
                        a = x;
                }
                else
                {
                    if (f(a) > 0)
                        b = x;
                    else
                        a = x;
                }
                count++;
            }
            return new Tuple<double, int>(x, count);
        }
        static public Tuple<double, int> MethodSecant(F f, F f2, double a, double b, double e)
        {
            double x, x1;
            int count = 0;
            if (f(b) * f2(b) > 0) x1 = a;
            else x1 = b;
            do
            {
                count++;
                x = x1;
                if (f(b) * f2(b) > 0)
                {
                    if (f(b) > 0)
                        x1 = x - f(x) / (f(b) - f(x)) * (b - x);
                    else
                        x1 = x - (-f(x)) / ((-f(b)) - (-f(x))) * (b - x);
                }
                else
                {
                    if (f(a) > 0)
                        x1 = x + f(x) / (f(a) - f(x)) * (a - x);
                    else
                        x1 = x + (-f(x)) / ((-f(a)) - (-f(x))) * (a - x);
                }
            } while (Math.Abs(x1 - x) > e);
            return new Tuple<double, int>(x1, count);
        }
        static public Tuple<double, int> MethodNewton(F f, F f1, F f2, double a, double b, double e)
        {
            double x, x1;
            if (f(a) * f2(a) > 0)
                x1 = a;
            else
                x1 = b;
            int count = 0;
            do
            {
                count++;
                x = x1;
                x1 = x - f(x) / f1(x);
            } while (Math.Abs(x1 - x) > e);
            return new Tuple<double, int>(x1, count);
        }
        public static Tuple<double, int> MethodSecuschih(F f, double x, double x1, double e)
        {
            int count = 0;
            while (Math.Abs(x1 - x) > e)
            {
                count++;
                double temp = x1;
                x1 -= (x1 - x) * f(x1) / (f(x1) - f(x));
                x = temp;
            }
            return new Tuple<double, int>(x1, count);
        }
        public delegate double F(double arg);
    }
}
