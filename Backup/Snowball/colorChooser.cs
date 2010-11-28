/**
 * +------------------------------------------------------------------------+
 * |Snowball-komponenent: ColorChooser v.1                                  |
 * +------------------------------------------------------------------------+
 * | Snowball C# Library Copyright 2008 Alexander Forselius.                |
 * | Detta är ett klassbibliotek med användbara klasser för olika ändamål,  |
 * | som jag skrivit i C#                                                   |
 * +------------------------------------------------------------------------+
 * |Info                                                                    |
 * +------------------------------------------------------------------------+
 * |Den här komponenten är en färgväljare och använder sig av den statiska  |
 * |klassens XColors HSB->RGB omvandlingsfunktioner. Den kan kombineras med |
 * |Settings och X-kontrollerna för att ge användarna möjligt att välja eget|
 * |färgschema på programmet. Den kan även användas i andra syften.         |
 * +-------------+-----------------------------+----------------------------+
 * |Version: 1.0 | Ramverk: .NET FRAMEWORK 2.2 | Namnrymd: Snowball         |
 * +-------------+-----------------------------+----------------------------+
 *
 * */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Snowball
{
    public partial class colorChooser : UserControl
    {
        public delegate void ChangeEvent();
        public event ChangeEvent Change;
        public Color BackLight
        {
            get
            {
                int r;
                int g;
                int b;
                int a=255;
                Color Col = XColors.HSBToRGB(this.tbHue.Value, this.tbSat.Value, this.tbBright.Value);
                r=Col.R;
                g=Col.G;
                b=Col.B;
                a = Col.A;
                decimal r1 = 0, g1 = 0, b1 = 0;
                r1 = 255-(g*0.15M);
                g1 = 255-(b*0.15M);
                b1 = 255-(g*0.15M);
                int r2, g2, b2;
                r2 = 255 - (int)r1;
                g2 = 255 - (int)g1;
                b2 = 255 - (int)b1;
                return Color.FromArgb((int)r1,(int)g1,(int)b1);
            }
        }
        public Color SecValue
        {
            get
            {
                return XColors.HSBToRGB(this.tbHue.Value + 100, this.tbSat.Value, this.tbBright.Value);
            }
        }
        public Color Value
        {
            get
            {
                return pnlColor.BackColor;
            }
            set
            {
                pnlColor.BackColor = value;
            }
        }
        public colorChooser()
        {
            InitializeComponent();
        }
        public int Hue
        {
            get
            {
                return this.tbHue.Value;
            }
            set
            {
                this.tbHue.Value = value;
            }
        }
        public int Saturation
        {
            get
            {
                return this.tbSat.Value;
            }
            set
            {
                tbSat.Value = value;
            }
        }
        public int Brightness
        {
            get
            {
                return this.tbBright.Value;
            }
            set
            {
                tbBright.Value = value;
            }
        }
        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            Value = XColors.HSBToRGB(tbHue.Value, tbBright.Value, tbSat.Value);
             if(Change!=null)
            Change();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            Value = XColors.HSBToRGB(tbHue.Value, tbBright.Value, tbSat.Value);
            if(Change!=null)
            Change();
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            Value = XColors.HSBToRGB(tbHue.Value, tbBright.Value, tbSat.Value);
             if(Change!=null)
            Change();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void colorChooser_Load(object sender, EventArgs e)
        {

        }
    }

}
