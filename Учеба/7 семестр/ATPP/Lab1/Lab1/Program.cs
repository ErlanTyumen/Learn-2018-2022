using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Lab1
{
    class Program
    {
        static void Work(string s)
        {
            double x = 1.0;
            for (int i=0; i < 5000; i++)
                for (int j =0; j < 5000; j++)
                {
                    x = Math.Sqrt(x);
                    x = x + 0.000000001;
                    x = Math.Pow(x, 2);
                }
            Console.WriteLine("{0}: x = {1}", s, x);
        }
        static void Main(string[] args)
        {
            DateTime to = DateTime.Now;

            Work("A");
            Work("B");
            Work("C");
            Work("D");
            Work("E");
            Work("F");
            Work("G");
            Work("h");

            double dt = (DateTime.Now - to).TotalMilliseconds;
            Console.WriteLine("Single : {0} ms -> {1}", dt, dt / 8);

            //var th1 = new Thread(_ => Work("A"));
            //var th2 = new Thread(_ => Work("B"));
            //var th3 = new Thread(_ => Work("C"));
            //var th4 = new Thread(_ => Work("D"));
            //var th5 = new Thread(_ => Work("E"));
            //var th6 = new Thread(_ => Work("F"));
            //var th7 = new Thread(_ => Work("G"));
            //var th8 = new Thread(_ => Work("H"));

            //th1.Start();
            //th2.Start();
            //th3.Start();
            //th4.Start();
            //th5.Start();
            //th6.Start();
            //th7.Start();
            //th8.Start();

            //th1.Join();
            //th2.Join();
            //th3.Join();
            //th4.Join();
            //th5.Join();
            //th6.Join();
            //th7.Join();
            //th8.Join();

            //double dt = (DateTime.Now - to).TotalMilliseconds;

            //Console.WriteLine("Parall : {0} ms -> {1} ms ", dt, dt / 8);

            //var th1 = new Thread(_ => Work("A"));
            //var th2 = new Thread(_ => Work("B"));
            //var th3 = new Thread(_ => Work("C"));
            //var th4 = new Thread(_ => Work("D"));
            //var th5 = new Thread(_ => Work("E"));
            //var th6 = new Thread(_ => Work("F"));
            //var th7 = new Thread(_ => Work("G"));
            //var th8 = new Thread(_ => Work("H"));

            //th1.Priority = ThreadPriority.Highest;
            //th2.Priority = ThreadPriority.Highest;
            //th3.Priority = ThreadPriority.Highest;
            //th4.Priority = ThreadPriority.Highest;
            //th5.Priority = ThreadPriority.Highest;
            //th6.Priority = ThreadPriority.Highest;
            //th7.Priority = ThreadPriority.Highest;
            //th8.Priority = ThreadPriority.Highest;

            //th1.Start();
            //th2.Start();
            //th3.Start();
            //th4.Start();
            //th5.Start();
            //th6.Start();
            //th7.Start();
            //th8.Start();

            //th1.Join();
            //th2.Join();
            //th3.Join();
            //th4.Join();
            //th5.Join();
            //th6.Join();
            //th7.Join();
            //th8.Join();

            //double dt = (DateTime.Now - to).TotalMilliseconds;

            //Console.WriteLine("Parall : {0} ms -> {1} ms ", dt, dt / 8);
        }
    }
}
