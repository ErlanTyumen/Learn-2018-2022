using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace CIAKOD_Kursach
{
    public partial class Form1 : Form
    {
        public LinkedList<int> mainList;
        public Form1()
        {
            InitializeComponent();
            mainList = new LinkedList<int>();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mainList = ReadToList();
            textBox2.Text = ListToString(mainList);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            DialogResult dr = sfd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                FileStream fs = new FileStream(sfd.FileName, FileMode.Create);
                StreamWriter sw = new StreamWriter(fs);
                string result = "";
                for (LinkedListNode<int> node = mainList.First; node != null; node = node.Next)
                {
                    result += node.Value.ToString();
                    if (node.Next != null) result += " ";
                }
                sw.WriteLine(result);
                sw.Close();
                fs.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Stopwatch timer = new Stopwatch();
            LinkedList<int> tempList = CopyList(mainList);
            timer.Start();
            HZSDRadixSort(tempList);
            timer.Stop();
            textBox3.Text = ListToString(tempList);
            textBox4.Text = $"{timer.Elapsed.TotalMilliseconds} мс.";
            timer.Reset();
            tempList = CopyList(mainList);
            timer.Start();
            BubbleSort(tempList);
            timer.Stop();
            textBox5.Text = $"{timer.Elapsed.TotalMilliseconds} мс.";
            timer.Reset();
            tempList = CopyList(mainList);
            timer.Start();
            OddEvenSort(tempList);
            timer.Stop();
            textBox6.Text = $"{timer.Elapsed.TotalMilliseconds} мс.";
        }
        static void HZSDRadixSort(LinkedList<int> list)
        {
            LinkedList<int>[] numbers = new LinkedList<int>[20];
            bool isExit = false;
            for (int i = 0; i < numbers.Length; i++) numbers[i] = new LinkedList<int>();
            numbers[10] = list;
            int k = 0;
            LinkedList<int> tempPos;
            LinkedList<int> tempNeg;
            while (!isExit)
            {
                isExit = true;
                for (int i = 0; i < numbers.Length; i++)
                {
                    tempPos = new LinkedList<int>();
                    tempNeg = new LinkedList<int>();
                    for (LinkedListNode<int> node = numbers[i].First; node != null;)
                    {
                        int val = node.Value % (int)Math.Pow(10, k + 1);
                        int ind = val / (int)Math.Pow(10, k);
                        LinkedListNode<int> nextNode = node.Next;
                        if (node.Value < 0)
                        {
                            if (-ind == i)
                            {
                                int res = node.Value;
                                numbers[i].Remove(res);
                                tempNeg.AddLast(res);
                            }
                            else
                            {
                                int res = node.Value;
                                numbers[i].Remove(res);
                                numbers[-ind].AddLast(res);
                            }
                        }
                        else
                        {
                            if (ind + 10 == i)
                            {
                                int res = node.Value;
                                numbers[i].Remove(res);
                                tempPos.AddLast(res);
                            }
                            else
                            {
                                int res = node.Value;
                                numbers[i].Remove(res);
                                numbers[ind + 10].AddLast(res);
                            }
                        }
                        node = nextNode;
                    }
                    for (LinkedListNode<int> node = tempNeg.First; node != null; node = node.Next)
                    {
                        numbers[i].AddLast(node.Value);
                    }
                    for (LinkedListNode<int> node = tempPos.Last; node != null; node = node.Previous)
                    {
                        numbers[i].AddFirst(node.Value);
                    }
                }
                for (int j = 0; j < numbers.Length; j++)
                {
                    if (j == 10 || j == 0) continue;
                    if (numbers[j].Count != 0) isExit = false;
                }
                k++;
            }
            for (LinkedListNode<int> node = numbers[0].First; node != null; node = node.Next)
            {
                numbers[10].AddFirst(node.Value);
            }
        }

        static void BubbleSort(LinkedList<int> list)
        {
            bool isExit = false;
            while (!isExit)
            {
                isExit = true;
                for (LinkedListNode<int> node = list.First; node.Next != null; node = node.Next)
                {
                    if (node.Next.Value < node.Value)
                    {
                        int temp = node.Value;
                        node.Value = node.Next.Value;
                        node.Next.Value = temp;
                        isExit = false;
                    }
                }
            }
        }

        static void OddEvenSort(LinkedList<int> list)
        {
            bool isExit = false;
            while (!isExit)
            {
                isExit = true;
                for (LinkedListNode<int> node = list.First.Next; node != null && node.Next != null; node = node.Next.Next)
                {
                    if (node.Next.Value < node.Value)
                    {
                        int temp = node.Value;
                        node.Value = node.Next.Value;
                        node.Next.Value = temp;
                        isExit = false;
                    }
                }
                for (LinkedListNode<int> node = list.First; node != null && node.Next != null; node = node.Next.Next)
                {
                    if (node.Next.Value < node.Value)
                    {
                        int temp = node.Value;
                        node.Value = node.Next.Value;
                        node.Next.Value = temp;
                        isExit = false;
                    }
                }
            }
        }

        static LinkedList<int> ReadToList()
        {
            LinkedList<int> result = new LinkedList<int>();
            OpenFileDialog ofd = new OpenFileDialog();
            DialogResult dr = ofd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                FileStream fs = new FileStream(ofd.FileName, FileMode.Open);
                StreamReader sr = new StreamReader(fs);
                string[] elements = sr.ReadLine().Split(' ');
                sr.Close();
                fs.Close();
                try
                {
                    foreach (string el in elements)
                    {
                        result.AddLast(int.Parse(el));
                    }
                }
                catch
                {
                    MessageBox.Show("Неверные входные данные!", "ВНИМАНИЕ!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return result;
        }

        static LinkedList<int> CopyList(LinkedList<int> list)
        {
            LinkedList<int> result = new LinkedList<int>();
            for (LinkedListNode<int> node = list.First; node != null; node = node.Next)
            {
                result.AddLast(node.Value);
            }
            return result;
        }

        static string ListToString(LinkedList<int> list)
        {
            string result = "";
            for (LinkedListNode<int> node = list.First; node != null; node = node.Next)
            {
                result += "{" + node.Value.ToString() + "}";
                if (node.Next != null) result += " ";
            }
            return result;
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            try
            {
                mainList.AddLast(int.Parse(textBox1.Text));
                textBox2.Text = ListToString(mainList);
                textBox1.Text = "";
            }
            catch
            {
                MessageBox.Show("Некорректный ввод!", "ВНИМАНИЕ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            mainList = new LinkedList<int>();
            textBox2.Text = ListToString(mainList);
        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    mainList.AddLast(int.Parse(textBox1.Text));
                    textBox2.Text = ListToString(mainList);
                    textBox1.Text = "";
                }
                catch
                {
                    MessageBox.Show("Некорректный ввод!", "ВНИМАНИЕ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Random rnd = new Random();
            for (int i = 0; i < 1000; i++)
            {
                mainList.AddLast(rnd.Next(10000));
            }
            textBox2.Text = ListToString(mainList);
            textBox1.Text = "";
        }

    }
}
