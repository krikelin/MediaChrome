using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;
namespace snowball
{

    class XTSC : ToolStripContainer
    {
        private int HHue;
        
        public int Hue
        {
            get
            {
                return HHue;
            }
            set
            {
                HHue = value;
            }
        }
               
        private void XTSP_Paint(Object Sender, PaintEventArgs e)
        {
            LinearGradientBrush GD1 = new LinearGradientBrush(new Point(0, 0), new Point(this.Width, 0), Snowball.XColors.HSBToRGB(this.Hue, 50, 100), Snowball.XColors.HSBToRGB(this.Hue + 100, 50, 100));
            e.Graphics.FillRectangle(GD1, 0, 0, this.Width, this.Height);
        }
        public XTSC()
        {
            this.HHue = 845;
            this.Paint += new PaintEventHandler(XTSP_Paint);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

        }
    }
     class XTS: ToolStrip
    {
        private int HHue;
        
        public int Hue
        {
            get
            {
                return HHue;
            }
            set
            {
                HHue = value;
            }
        }
        public Color Color
        {
            get
            {
                return Snowball.XColors.HSBToRGB(this.Hue, 50, 100);
            }
        }
        public Color Color2
        {
            get
            {
                return Snowball.XColors.HSBToRGB(this.Hue+100, 50, 100);
            }
        }
        private void XTSP_Paint(Object Sender, PaintEventArgs e)
        {
           
            LinearGradientBrush GD1 = new LinearGradientBrush(new Point(0, 0), new Point(0, this.Height/2), this.Color,this.Color2);
            e.Graphics.FillRectangle(GD1, 0, 0, this.Width, this.Height);
             e.Graphics.FillRectangle(new SolidBrush(this.Color2),new Rectangle(0,this.Height/2,this.Width,this.Height/2));
        }
        public XTS()
        {
            this.HHue = 845;
            this.Paint += new PaintEventHandler(XTSP_Paint);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

        }
    }
}
