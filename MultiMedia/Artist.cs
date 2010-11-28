using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MultiMedia
{
    public partial class Artist : Form
    {
        public Artist()
        {
            InitializeComponent();
        }

        Views.Artist D;
        private void Artist_Load(object sender, EventArgs e)
        {
            D = new Views.Artist();
            D.LoadPage("http://mediachrome.krakelin.com/artist.php");
            this.Controls.Add(D);
            this.D.Dock = DockStyle.Fill;
        }
    }
}
