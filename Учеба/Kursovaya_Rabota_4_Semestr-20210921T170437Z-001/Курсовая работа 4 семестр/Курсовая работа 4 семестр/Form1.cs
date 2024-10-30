using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
using System.Reflection;
using Office = Microsoft.Office.Core;


namespace Курсовая_работа_4_семестр
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();
        }

        Word.Application app;
        Word.Document doc;
        Word.Table t;
        List<question> l = new List<question>();
        private void tabPage1_Click(object sender, EventArgs e)
        {
            Object missingObj = System.Reflection.Missing.Value;
            Object trueObj = true;
            Object falseObj = false;
            object file = @"C:\Users\Gaukhar Kanapyanova\Desktop\Курсовая работа 4 семестр\Курсовая работа 4 семестр\bin\Debug\shablon.doc";
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //DocToTxt();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView2.DefaultCellStyle.WrapMode =
            DataGridViewTriState.True;
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            object filename = openFileDialog1.FileName;
            Word.Application app = new Word.Application();
            Word.Document doc = app.Documents.Add(filename);
            Word.Range r = doc.Range();
            for (int i = 1; i < r.Paragraphs.Count; ++i)
            {


                dataGridView2.Rows.Add($"{r.Paragraphs[i].Range.Text}");


            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                button2.Enabled = true;
            }
            if (!checkBox1.Checked)
            {
                button2.Enabled = false;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.DefaultCellStyle.WrapMode =
            DataGridViewTriState.True;
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            object filename = openFileDialog1.FileName;
            Word.Application app = new Word.Application();
            Word.Document doc = app.Documents.Add(filename);
            Word.Range r = doc.Range();
            for(int i = 1; i < r.Paragraphs.Count ; ++i)
            {


                dataGridView1.Rows.Add($"{r.Paragraphs[i].Range.Text}");
                

            }


        }

        

       

        Thread th;


        private void button3_Click(object sender, EventArgs e)
        {
            th = new Thread(new ThreadStart(Method));
            th.Start();

        }
      
        public void Method()
        {
            Dictionary<int, List<question>> dic = new Dictionary<int, List<question>>();
            Dictionary<int, List<question>> dic2 = new Dictionary<int, List<question>>();
            Backpack bp = new Backpack((int)numericUpDown2.Value, (int)numericUpDown1.Value); ;



            for (int i = 1; i <= numericUpDown3.Value; i++)
            {


                this.Text = "Processing:" + Convert.ToString(100 * i / (int)numericUpDown3.Value);
                Object missingObj = Missing.Value;
                Object trueObj = true;
                Object falseObj = false;
                object file = @"C:\Users\Gaukhar Kanapyanova\Desktop\Курсовая работа 4 семестр\Курсовая работа 4 семестр\bin\Debug\shablon.doc";
                app = new Word.Application();
                doc = app.Documents.Add(ref file);
                Word.Range r = doc.Range();

                t = doc.Tables[1];
                t.Range.Paragraphs[14].Range.Text = textBox1.Text + "\n";
                t.Range.Paragraphs[14].Range.Text = textBox2.Text + "\n";
                t.Range.Paragraphs[17].Range.Text = textBox3.Text + "\n";
                t.Range.Paragraphs[19].Range.Text = $"Экзаменационной билет №{i}\n";
                t.Range.Paragraphs[19].Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                
                if (checkBox1.Checked)
                {
                    bp = new Backpack((int)numericUpDown2.Value , (int)numericUpDown1.Value);
                }
                else
                {
                    bp = new Backpack((int)numericUpDown2.Value, (int)numericUpDown1.Value);
                }
                Random rnd = new Random();
                if (dic.Count == 0 )
                {
                    dic = new Dictionary<int, List<question>>();
                    int g = dataGridView1.RowCount - 1;
                    for (int ii = 0; ii < g; ii++)
                    {
                        


                        if (dic.ContainsKey(Convert.ToInt32(dataGridView1[1, ii].Value)))
                        {
                            dic[Convert.ToInt32(dataGridView1[1, ii].Value)].Add(new question(dataGridView1[0, ii].Value.ToString(), Convert.ToInt32(dataGridView1[1, ii].Value), 1));
                        }
                        else
                        {
                            List<question> newlist = new List<question>();
                            newlist.Add(new question(dataGridView1[0, ii].Value.ToString(), Convert.ToInt32(dataGridView1[1, ii].Value), 1));
                            dic.Add(Convert.ToInt32(dataGridView1[1, ii].Value), newlist);
                        }


                    }
                }


                if (checkBox1.Checked && dic2.Values.Count == 0)
                {
                    dic2 = new Dictionary<int, List<question>>();
                    for (int ii = 0; ii < dataGridView2.Rows.Count - 1; ++ii)
                    {



                        if (dic2.ContainsKey(Convert.ToInt32(dataGridView2[1, ii].Value)))
                        {
                            dic2[Convert.ToInt32(dataGridView2[1, ii].Value)].Add(new question(dataGridView2[0, ii].Value.ToString(), Convert.ToInt32(dataGridView2[1, ii].Value), 1, 1));
                        }
                        else
                        {
                            List<question> newlist = new List<question>();
                            newlist.Add(new question(dataGridView2[0, ii].Value.ToString(), Convert.ToInt32(dataGridView2[1, ii].Value), 1, 1));
                            dic2.Add(Convert.ToInt32(dataGridView2[1, ii].Value), newlist);
                        }


                    }

                }


                bp.q = dic2;
                bp.Count = (int)numericUpDown1.Value;
                if (checkBox1.Checked)
                {
                    int med = 0;
                    int c = 0;
                        for (int d = 0; d < dataGridView2.Rows.Count - 1; d++)
                        {

                            med += Convert.ToInt32(dataGridView2[1, d].Value);
                            
                        c++;
                        }

                    med = med / c;
                    
                    bp.Complexity = (int)numericUpDown2.Value - med;
                    
                }
                else
                {
                    bp.Complexity = (int)numericUpDown2.Value;
                }
                bp.Sort(ref dic);                
                for (int j = 0; j < bp.list.Count; j++)
                {

                    t.Range.Paragraphs[21 + j].Range.Text = $"{j + 1}. " + bp.list[j].text;


                    t.Range.Paragraphs[21 + j].Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                    t.Range.Paragraphs[21 + j].CharacterUnitLeftIndent = 2f;
                    t.Range.InsertParagraphAfter();



                }
                t.Range.InsertAfter($"{bp.COM()}");


                doc.SaveAs($@"C:\Users\Gaukhar Kanapyanova\Desktop\Курсовая работа 4 семестр\all\Билет-{i}.docx");
                doc.Close();
                app.Quit();
                app = null;
                doc = null;









            }

            if (checkBox3.Checked)
            {





                string[] filePaths = Directory.GetFiles(@"C:\Users\Gaukhar Kanapyanova\Desktop\Курсовая работа 4 семестр\all", "*.docx", SearchOption.AllDirectories);

                string[] documentsToMerge = filePaths;
                string outputPath = String.Format(@"C:\Users\Gaukhar Kanapyanova\Desktop\Билеты.docx");

                MsWord.Merge(documentsToMerge, outputPath, true, @"C:\Users\Gaukhar Kanapyanova\Desktop\shablon.doc");
                MessageBox.Show("Файл был сохранен на рабочем столе");
                try
                {
                    foreach (string files in documentsToMerge)
                    {
                        File.Delete(files);
                    }
                }
                catch
                {

                }
            }
            this.Text = "Конструктор экзаменационных билетов";
            Thread.Sleep(50);    
        
    }
        

    }
    
}
