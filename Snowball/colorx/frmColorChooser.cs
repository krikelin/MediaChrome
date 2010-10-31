using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Snowball;
namespace colorx
{
    public partial class frmColorChooser : Form
    {
        public frmColorChooser()
        {
            InitializeComponent();
        }
        public frmColorChooser(Form1 X)
        {
            InitializeComponent();
            Frm = X;
        }
        public Form1 Frm;
        private void frmColorChooser_Load(object sender, EventArgs e)
        {

        }

        private void colorChooser1_Change()
        {
            Frm.ForeColor = XColors.HSBToRGB(colorChooser1.Hue, colorChooser1.Saturation, colorChooser1.Brightness);
            Frm.Strength = colorChooser1.Brightness;
            Frm.WMP10 = checkBox1.Checked;
            Frm.FirstColor = XColors.Transgen(XColors.HSBToRGB(colorChooser1.Hue, colorChooser1.Saturation, colorChooser1.Brightness),Color.Black,21,100,100);
            Frm.Invalidate();
            Frm.Mark();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Frm.ForeColor = XColors.HSBToRGB(colorChooser1.Hue, colorChooser1.Saturation, colorChooser1.Brightness);
            Frm.Strength = colorChooser1.Brightness;
            Frm.WMP10 = checkBox1.Checked;
            Frm.FirstColor = XColors.Transgen(XColors.HSBToRGB(colorChooser1.Hue, colorChooser1.Saturation, colorChooser1.Brightness), Color.Black, 21, 100, 100);
            Frm.Invalidate();

            Frm.Mark();
        }
    }
}
