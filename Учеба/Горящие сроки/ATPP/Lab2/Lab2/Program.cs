using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Program
    {
        static void Сalculations(int M, int N)
        {
            double[,] a = new double[N, N];
            Queue<double> ariMean = new Queue<double>();
            
            for (int k = 0; k < M; k++)
            {
                DateTime t0 = DateTime.Now;
                for (int i = 0; i < N; i++)
                    for (int j = 0; j < N; j++)
                        a[i, j] = i / (j + 1.0);
                double dt = (DateTime.Now - t0).TotalMilliseconds;
                Console.WriteLine("UL dt={0:f3}", dt);
                double m = ArithmeticMean(a, N);
                ariMean.Enqueue(m);
                

                t0 = DateTime.Now;
                for (int i = 0; i < N; i++)
                    for (int j = N - 1; j >= 0; j--)
                        a[i, j] = i / (j + 1.0);
                dt = (DateTime.Now - t0).TotalMilliseconds;
                Console.WriteLine("UR dt={0:f3}", dt);

                t0 = DateTime.Now;
                for (int i = N - 1; i >= 0; i--)
                    for (int j = 0; j < N; j++)
                        a[i, j] = i / (j + 1.0);
                dt = (DateTime.Now - t0).TotalMilliseconds;
                Console.WriteLine("DL dt={0:f3}", dt);

                t0 = DateTime.Now;
                for (int i = N - 1; i >= 0; i--)
                    for (int j = N - 1; j >= 0; j--)
                        a[i, j] = i / (j + 1.0);
                dt = (DateTime.Now - t0).TotalMilliseconds;
                Console.WriteLine("DR dt={0:f3}", dt);

                t0 = DateTime.Now;
                for (int i = 0; i < N; i++)
                    for (int j = 0; j < N; j++)
                        a[j, i] = i / (j + 1.0);
                dt = (DateTime.Now - t0).TotalMilliseconds;
                Console.WriteLine("LU dt={0:f3}", dt);

                t0 = DateTime.Now;
                for (int i = 0; i < N; i++)
                    for (int j = N - 1; j >= 0; j--)
                        a[j, i] = i / (j + 1.0);
                dt = (DateTime.Now - t0).TotalMilliseconds;
                Console.WriteLine("RU dt={0:f3}", dt);

                t0 = DateTime.Now;
                for (int i = N - 1; i >= 0; i--)
                    for (int j = 0; j < N; j++)
                        a[j, i] = i / (j + 1.0);
                dt = (DateTime.Now - t0).TotalMilliseconds;
                Console.WriteLine("LD dt={0:f3}", dt);

                t0 = DateTime.Now;
                for (int i = N - 1; i >= 0; i--)
                    for (int j = N - 1; j >= 0; j--)
                        a[j, i] = i / (j + 1.0);
                dt = (DateTime.Now - t0).TotalMilliseconds;
                Console.WriteLine("RD dt={0:f3}", dt);

                Console.WriteLine();
            }
        }

        static double ArithmeticMean(double[,] arr, int n)
        {
            double sum = 0;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    sum += arr[i, j];
            return sum/arr.Length;
        }
        static void Main(string[] args)
        {
            

            
        }
    }
}
