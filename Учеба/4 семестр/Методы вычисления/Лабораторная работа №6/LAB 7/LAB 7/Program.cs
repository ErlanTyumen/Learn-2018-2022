using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_7
{
    class Program
    {
        static void Main(string[] args)
        {
            System system = new System();
            double[] epsilon = { 0.001, 0.00001, 0.00000001 };
            Console.WriteLine("Условие сходимости: " + Math.Abs(system.Diff(0.7,0.6)) +" < 1");
            foreach(double eps in epsilon)
            {
                Method.IterationMethod(eps).Print("Итерации");
                Method.NewtonMethod(eps).Print("Ньютон  ");
            }
            //Method.IterationMethod(epsilon[2]).Print("Итерации");
            Console.ReadKey();
        }
    }
}
