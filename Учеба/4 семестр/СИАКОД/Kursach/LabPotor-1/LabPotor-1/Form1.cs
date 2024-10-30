using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace LabPotor_1
{
    public partial class Form1 : Form
    {
        static Random rnd = new Random();
        static bool StopTh = false;
        static bool tp1 = false;
        static bool tp2 = false;
        static bool tp3 = false;
        static bool tp4 = false;
        static bool tp5 = false;
        static Graphics g1;
        static Graphics g2;
        static Graphics g3;
        static Graphics g4;
        static Graphics g5;

        public Form1()
        {
            InitializeComponent();
            g1 = pictureBox1.CreateGraphics();
            g2 = pictureBox1.CreateGraphics();
            g3 = pictureBox1.CreateGraphics();
            g4 = pictureBox1.CreateGraphics();
            g5 = pictureBox1.CreateGraphics();
            Thread t1 = new Thread(() => Number(ref tp1, Brushes.Red, g1));
            t1.Start();
            Thread t2 = new Thread(() => Number(ref tp2, Brushes.Orange, g2));
            t2.Start();
            Thread t3 = new Thread(() => Number(ref tp3, Brushes.Yellow, g3));
            t3.Start();
            Thread t4 = new Thread(() => Number(ref tp4, Brushes.Green, g4));
            t4.Start();
            Thread t5 = new Thread(() => Number(ref tp5, Brushes.Blue, g5));
            t5.Start();
        }
        private void button_Click(object sender, EventArgs e)
        {
            switch ((sender as Button).Text)
            {
                case "Остановить 1-й поток":
                    tp1 = true;
                    break;
                case "Остановить 2-й поток":
                    tp2 = true;
                    break;
                case "Остановить 3-й поток":
                    tp3 = true;
                    break;
                case "Остановить 4-й поток":
                    tp4 = true;
                    break;
                case "Остановить 5-й поток":
                    tp5 = true;
                    break;
                default:
                    tp1 = true;
                    tp2 = true;
                    tp3 = true;
                    tp4 = true;
                    tp5 = true;
                    pictureBox1.CreateGraphics().Clear(Color.White);
                    break;
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopTh = true;
        }
        static void Number(ref bool tp, Brush br, Graphics g)
        {
            while (!StopTh)
            {
                if (tp)
                {
                    Thread.Sleep(5000);
                    tp = false;
                }
                g.FillRectangle(br, rnd.Next(0, 64) * 5, rnd.Next(0, 64) * 5, 5, 5);
                Thread.Sleep(0);
            }
        }
    }
}
