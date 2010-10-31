using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
namespace Snowball
{
    public class UltraPanel : Panel
    {
        public UltraPanel()
        {
            X = new BufferedGraphicsContext();
            this.Paint += new PaintEventHandler(UltraPanel_Paint);
            firstColor = ColorTranslator.FromHtml("#0077FF");
            lastColor = ColorTranslator.FromHtml("#00FFFF");
            
        }
        private System.Drawing.BufferedGraphicsContext X;
        private BufferedGraphics BE;
        Bitmap F;
        private Bitmap bg;
        public Bitmap Bg
        {
            get
            {
                return bg;
            }
            set
            {
                bg = value;
            }
        }
        private List<Color> colors;
        public List<Color> Colors
        {
            get
            {
                return colors;
            }
            set
            {
                colors = value;
            }
        }
        public void Meshis(Graphics Graphic,int manhue,int sat, int bright)
        {
            if (Bg!=null)
            {
                F = new Bitmap(Bg, Bg.Width, Bg.Height);
                BE = X.Allocate(Graphic, new Rectangle(0, 0, this.Width, this.Height));

                for (int i = 0; i < F.Width; i++)
                {
                    for (int j = 0; j < F.Height; j++)
                    {
                        Color s = F.GetPixel(i, j);
                        float f = (s.R + s.G + s.B) / 3;




                        float x = (f / 255) * 100;
             //           double rr = Math.Sin(127+manhue/(Math.PI/(255*2))) * f;
                        int sp = bright >= 100 ? sp = bright - 100 : sp = 100;
                       // Color y = XColors.HSBToRGB((manhue) - (int)((int)f), sat, (int)bright);
                        Color y = XColors.Transgen( firstColor, lastColor, manhue + (int)((float)f*2.5f), saturation, brightness);
                       
                        /*
                        if ( f>=127)
                        {
                            int sr = sat ;
                            
                            float frr = XColors.Diff(y.R, 255) ;
                            float frg = XColors.Diff(y.G, 255) ;
                            float frb = XColors.Diff(y.B, 255) ;
                            float ar=frr*(sat/100);
                            float ag = frg * (sat / 100);
                            float ab = frb * (sat / 100);
                            Color r = Color.FromArgb(y.R + (int)ar, y.G + (int)ag, y.B + (int)ab);
                            y = r;
                        }
                         */
                        F.SetPixel(i, j, y);
                    }
                }
                int r = this.Width / Bg.Width;
                for (int i = 0; i < this.Width; i++)
                {
                    BE.Graphics.DrawImage(F, new Point(i*Bg.Width, 0));
                }
                BE.Render();
            }
        }
        private Color firstColor;
        public Color FirstColor
        {
            get
            {
                return firstColor;
            }
            set
            {
                firstColor = value;
            }
        }
        private Color lastColor;
        public Color LastColor
        {
            get
            {
                return lastColor;
            }
            set
            {
                lastColor = value;
            }
        }
        private int brightness;
        public int Brightness
        {
            get
            {
                return brightness;
            }
            set
            {
                brightness = value;
            }
        }
        void UltraPanel_Paint(object sender, PaintEventArgs e)
        {
            Meshis(e.Graphics,this.hue, this.saturation, this.brightness);
            
        }
        private int hue;
      
        private int saturation=100;
        public int Hue
        {
            get
            {
                return hue;
            }
            set
            {
                hue = value;
            }
        }
        public int Saturation
        {
            get
            {
                return saturation;
            }
            set
            {
                saturation = value;
            }
        }
      

    }
}
