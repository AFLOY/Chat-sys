using System;
using System.Collections.Generic;//https://github.com/AFLOY/Chat-sys/blob/master/Chat%20sys/Form1.cs
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Chat_sys
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Timer timer = new Timer();
        public void Form1_Load(object sender, EventArgs e)
        {
            textBox3.ScrollBars = ScrollBars.Vertical;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            button1.Text = "送信";
            button2.Text = "受信開始";
            listBox1.Items.Add("山");
            listBox1.Items.Add("一");
            textBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(textBox2_KeyDown);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = 1000;
            timer.Enabled = false;
        }

        string idf;//送信元（名）
        string idt;//送信先（名）
        string t;//送信文
        string path = "chatdata.txt";//チャット保存ファイル名
        string Cpath;//チャット保存ファイルの絶対パス
        string CF; //チャットフォルダーのパス
        public void Selectsender()//送信元・送信先の確認
        {
            if (textBox1.Text == "0")
            {
                idf = "山";
            }
            if (textBox1.Text == "1")
            {
                idf = "一";
            }
            if (listBox1.SelectedIndex == 0)
            {
                idt = "山";
            }
            if (listBox1.SelectedIndex == 1)//"一"選択中
            {
                idt = "一";
            }
        }
        public void DirectoryD()//ユーザー間のチャットフォルダーの決定・
        {
            if (idf + idt == "山一" || idf + idt == "一山")
            {
                CF = "F:/山-一/";
            }

            else
            {
                Environment.Exit(0);
            }
        }

        public void DataWriter()//受信フォルダの作成&受信ファイルへの書き込み
        {
            t = textBox2.Text;
            if (Directory.Exists(CF) == false)
            {
                Directory.CreateDirectory(CF);
            }
            File.AppendAllText(Cpath, "from:" + idf + " " + t + Environment.NewLine);
            textBox2.Text = "";
        }

        public void ChatRecieve()//受信動作
        {
            Selectsender();
            DirectoryD();
            Cpath = CF + path;
            if (File.Exists(Cpath) == false)
            {
                Directory.CreateDirectory(CF);
                File.CreateText(Cpath);
            }
            StreamReader sr = new StreamReader(Cpath, Encoding.GetEncoding("UTF-8"));
            string str = sr.ReadToEnd();
            sr.Close();
            textBox3.Text = str;
            textBox3.SelectionStart = textBox3.TextLength;
            textBox3.ScrollToCaret();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            Selectsender();
            DirectoryD();
            if (e.KeyCode == Keys.Enter)
            {
                Cpath = CF + path;
                DataWriter();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Selectsender();
            DirectoryD();
            Cpath = CF + path;
            DataWriter();
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            ChatRecieve();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer.Enabled = true;
        }
    }
}

