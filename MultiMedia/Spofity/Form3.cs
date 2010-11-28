using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace Spofity
{
    public partial class Form3 : Form
    {
        private string fileName;
        public Form3()
        {
            InitializeComponent();
        }
        public Form3(string FileName)
        {
            InitializeComponent();
            using (StreamReader SR = new StreamReader(FileName))
            {
                textBox1.Text = SR.ReadToEnd();
            }
            fileName = FileName;
        }
        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (StreamWriter SW = new StreamWriter(fileName, false))
            {
                SW.Write(textBox1.Text);
            }

        }
    }
}
