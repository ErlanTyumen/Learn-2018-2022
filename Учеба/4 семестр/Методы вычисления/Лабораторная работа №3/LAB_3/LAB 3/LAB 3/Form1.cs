using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB_3
{
    public partial class Form1 : Form
    {
        public double[,] A;
        public double[] B;
        public Form1()
        {
            InitializeComponent();
            A = new double[4, 4];
            B = new double[4];
            A[0, 0] = Convert.ToDouble(a11.Text);
            A[0, 1] = Convert.ToDouble(a12.Text);
            A[0, 2] = Convert.ToDouble(a13.Text);
            A[0, 3] = Convert.ToDouble(a14.Text);
            B[0] = Convert.ToDouble(b11.Text);

            A[1, 0] = Convert.ToDouble(a21.Text);
            A[1, 1] = Convert.ToDouble(a22.Text);
            A[1, 2] = Convert.ToDouble(a23.Text);
            A[1, 3] = Convert.ToDouble(a24.Text);
            B[1] = Convert.ToDouble(b21.Text);

            A[2, 0] = Convert.ToDouble(a31.Text);
            A[2, 1] = Convert.ToDouble(a32.Text);
            A[2, 2] = Convert.ToDouble(a33.Text);
            A[2, 3] = Convert.ToDouble(a34.Text);
            B[2] = Convert.ToDouble(b31.Text);

            A[3, 0] = Convert.ToDouble(a41.Text);
            A[3, 1] = Convert.ToDouble(a42.Text);
            A[3, 2] = Convert.ToDouble(a43.Text);
            A[3, 3] = Convert.ToDouble(a44.Text);
            B[3] = Convert.ToDouble(b41.Text);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            MPI(A, B);
            Zeydel(A, B);
        }
        public void MPI(double[,] AA, double[] BB)
        {
            //Метод простых итераций
            double[,] A = new double[AA.GetLength(0), AA.GetLength(0)];
            double[] B = new double[BB.GetLength(0)];
            double[] X = new double[4];
            double[] X1 = new double[4];
            double[] S = new double[4];
            double eps = Convert.ToDouble(textBox1.Text);
            double max = 0;
            int k = 0;

            for (int i = 0; i < A.GetLength(0); i++)
                for (int j = 0; j < A.GetLength(0); j++)
                {
                    A[i, j] = AA[i, j];
                }

            for (int i = 0; i < A.GetLength(0); i++)
            {
                B[i] = BB[i];
            }

            double[,] alpha = new double[A.GetLength(0), A.GetLength(0)];
            double[] beta = new double[A.GetLength(0)];
            for (int i = 0; i < alpha.GetLength(0); i++)
                for (int j = 0; j < alpha.GetLength(0); j++)
                {
                    alpha[i, j] = -A[i, j] / A[i, i];
                }
            for (int i = 0; i < alpha.GetLength(0); i++)
            {
                alpha[i, i] = 0;
                beta[i] = B[i] / A[i, i];
            }

            double normalph = 0;
            double temp = 0;
            for (int i = 0; i < alpha.GetLength(0); i++)
            {

                temp = 0;
                for (int j = 0; j < alpha.GetLength(0); j++)
                {
                    temp = temp + Math.Abs(alpha[j, i]);
                }
                if (normalph < temp) normalph = temp;
            }
            if (normalph < 1)
            {
                for (int i = 0; i < alpha.GetLength(0); i++)
                {
                    X[i] = beta[i];
                }

                do
                {
                    k++;
                    for (int i = 0; i < A.GetLength(0); i++)
                    {
                        S[i] = 0;
                        for (int j = 0; j < A.GetLength(0); j++)
                        {
                            S[i] += alpha[i, j] * X[j];
                            //k++;
                        }
                        X1[i] = S[i] + beta[i];
                    }
                    max = Math.Abs(X1[0] - X[0]);
                    for (int i = 1; i < A.GetLength(0); i++)
                    {
                        if (Math.Abs(X1[i] - X[i]) > max)
                        {
                            max = Math.Abs(X1[i] - X[i]);
                            //k++;
                        }
                    }
                    for (int i = 0; i < A.GetLength(0); i++)
                    {
                        X[i] = X1[i];
                    }
                } while (max > eps * (1 - normalph) / normalph);

                i1.Text = X[0].ToString("E10");
                i2.Text = X[1].ToString("E10");
                i3.Text = X[2].ToString("E10");
                i4.Text = X[3].ToString("E10");
                i5.Text = normalph.ToString("E10");
                i6.Text = k.ToString();
            }
        }

        public void Zeydel(double[,] AA, double[] BB)
        {
            double[,] A = new double[AA.GetLength(0), AA.GetLength(0)];
            double[] B = new double[BB.GetLength(0)];
            double[] X = new double[4];
            double[] X1 = new double[4];
            double[] S = new double[4];
            double eps = Convert.ToDouble(textBox1.Text);
            double max = 0;
            int k = 0;

            for (int i = 0; i < A.GetLength(0); i++)
                for (int j = 0; j < A.GetLength(0); j++)
                {
                    A[i, j] = AA[i, j];
                }

            for (int i = 0; i < A.GetLength(0); i++)
            {
                B[i] = BB[i];
            }

            double[,] alpha = new double[A.GetLength(0), A.GetLength(0)];
            double[] beta = new double[A.GetLength(0)];
            for (int i = 0; i < alpha.GetLength(0); i++)
                for (int j = 0; j < alpha.GetLength(0); j++)
                {
                    alpha[i, j] = -A[i, j] / A[i, i];
                }
            for (int i = 0; i < alpha.GetLength(0); i++)
            {
                alpha[i, i] = 0;
                beta[i] = B[i] / A[i, i];
            }

            double u = 0;
            double temp1 = 0;
            double temp2 = 0;
            for (int i = 0; i < alpha.GetLength(0); i++)
            {
                temp1 = 0;
                temp2 = 0;
                for (int j = i; j < alpha.GetLength(0); j++)
                {
                    temp1 = temp1 + Math.Abs(alpha[i, j]);
                }
                for (int j = 0; j < i; j++)
                {
                    temp2 = temp2 + Math.Abs(alpha[i, j]);
                }
                temp1 = temp1 / (1 - temp2);
                if (u < temp1) u = temp1;
            }
            if (u < 1)
            {
                for (int i = 0; i < alpha.GetLength(0); i++)
                {
                    X[i] = beta[i];
                }
                do
                {
                    k++;
                    for (int i = 0; i < A.GetLength(0); i++)
                    {
                        //k++;
                        S[i] = 0;
                        for (int j = 0; j < i; j++)
                            S[i] += alpha[i, j] * X1[j];
                        for (int j = i; j < A.GetLength(0); j++)
                            S[i] += alpha[i, j] * X[j];
                        X1[i] = S[i] + beta[i];
                    }
                    max = Math.Abs(X1[0] - X[0]);
                    for (int i = 1; i < A.GetLength(0); i++)
                    {
                        if (Math.Abs(X1[i] - X[i]) > max)
                        {
                            max = Math.Abs(X1[i] - X[i]);
                            //++;
                        }
                    }
                    for (int i = 0; i < A.GetLength(0); i++)
                        X[i] = X1[i];
                } while (max > eps * (1 - u) / u);

                z1.Text = X[0].ToString("E10");
                z2.Text = X[1].ToString("E10");
                z3.Text = X[2].ToString("E10");
                z4.Text = X[3].ToString("E10");
                z5.Text = u.ToString("E10");
                z6.Text = k.ToString();
            }
        }
    }
}
