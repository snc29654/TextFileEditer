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


namespace TextFileEditer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            richTextBox1.Font = new System.Drawing.Font("ＭＳ ゴシック", 14,
            System.Drawing.FontStyle.Bold,
            System.Drawing.GraphicsUnit.Point, 128);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                //ファイルパスをテキストボックスに入れる
                textBox1.Text = openFileDialog1.FileName;
                StreamReader ro = new StreamReader(textBox1.Text, Encoding.GetEncoding("utf-8"));
                //テキストファイルを読みこむ
                string text = ro.ReadToEnd();
                //リッチテキストへ表示
                richTextBox1.Text = text;
                ro.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //格納するファイルパスを記憶
            string filePath = textBox1.Text;
            //格納するテキストを記憶
            string text = richTextBox1.Text;
            StreamWriter wo = new StreamWriter(filePath, false, Encoding.GetEncoding("utf-8"));
            //テキストを書き込む
            wo.Write(text);
            wo.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                //ファイルパスをテキストボックスに入れる
                StreamReader ro = new StreamReader(openFileDialog1.FileName, Encoding.GetEncoding("utf-8"));

                string text;

                while (ro.Peek() != -1)
                {
                    text = ro.ReadToEnd();
                    //リッチテキストへ表示
                    richTextBox1.Text = text;
                }

                ro.Close();

                ro.Close();
            }

        }
    }
}
