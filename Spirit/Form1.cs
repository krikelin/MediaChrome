using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Spirit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
Board D ;
        private void Form1_Load(object sender, EventArgs e)
        {
        	D = new Board();
        	this.Controls.Add(D);
        	D.LoadContent("http://mediachrome.krakelin.com/artist.php?q=drsounds");
        	D.Dock = DockStyle.Fill;
        }
    }
}
