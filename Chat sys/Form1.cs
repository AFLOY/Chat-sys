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

namespace Chat_sys
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.Items.Add("山田");
            listBox1.Items.Add("一井");
            textBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(textBox2_KeyDown);
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (textBox1.Text == "0")
            {
                string id = "山田";
                if (listBox1.SelectedIndex == 0 && e.KeyCode == Keys.Enter)//"山田"選択中
                {
                string t = textBox2.Text;
                if (File.Exists(@"F:\chatdata.txt"))
                {
                        File.AppendAllText(@"F:\chatdata.txt", "from:" + id + t + Environment.NewLine);
                    textBox2.Text = "";
                }
                    File.AppendAllText(@"F:\chatdata.txt","from:" + id + t + Environment.NewLine);
                    textBox2.Text = "";
            }
                if (listBox1.SelectedIndex == 1)//"一井"選択中
            {
                
            }
        }
    }
}
}
