/**
 * +------------------------------------------------------------------------+
 * | Snowball C# Library Copyright 2008 Alexander Forselius.                |
 * | Detta är ett klassbibliotek med användbara klasser för olika ändamål,  |
 * | som jag skrivit i C#                                                   |
 * | Funktioner just nu:                                                    |
 * |  * Färgväljare                                                         |  
 * |  * Färgningsbara paneler                                               |
 * |  * Länkade listor med strängjämförelse                                 |
 * |  * XCompare, kraftfull strängjämförare som ger ett procentvärde i hur  |
 * |  - lika posterna är.                                                   |
 * | Funktioner att implementera (TODO)                                     |
 * |  * Snyggare knappar                                                    |
 * | Utvecklat med Visual C# Express, otroligt kraftfull måste jag säga, för|
 * | att vara en gratis men avskalad version av Visual Studio för hem/studen|
 * | tbruk. Microsoft vill förmodligen varva utvecklare.                    |
 * | Klasser:                                                               |
 * |                                                                        |
 * |    XPanel : Panel                                                      |
 * |    ==================================================================  |
 * |    XPanel är ett arv av Microsofts Panel klass, och introducerar nya fu|
 * |    nktioner till sitt utseende. Har två färgegenskaper, utöver orginale|
 * |    ts BackColor egenskap.                                              |
 * |    XButton : Button [ej påbörjad]                                      |
 * |    ====================================================================|
 * |    Den här klassen är ett arv av Button, och skall när den är färdig   |
 * |    vara en stiligare variant av den klassiska "Button". Istället för   |
 * |    datorns tema, skall knappen istället kunna färgas enligt egna önskem|
 * |    ål.                                                                 |
 * |    ColorChooser : UserControl                                          |
 * |    ====================================================================|
 * |    Se följande dokumentation                                           |
 * +------------------------------------------------------------------------+
 * 
 * */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.IO;

namespace Snowball
{
    
    #region ExtendedControls
    public enum ColorStyle
    {
        CSFull, CSWhite
    }
    public enum PBrushStyle
    {
        PBSPlain,PBSNew
    }
    public class XPanel : Panel
    {

        private Color PC1;
        private Color PC2;
        private ColorStyle CS = ColorStyle.CSFull;
        private PBrushStyle BT = PBrushStyle.PBSPlain;
        public ColorStyle ColorStyle
        {
            get
            {
                return CS;
            }
            set
            {
                CS = value;
            }
        }
        public PBrushStyle BrushType
        {
            get
            {
                return BT;
            }
            set
            {
                BT = value;
            }
        }
        public Color PrimaryColor
        {
            get
            {
                return PC1;
            }
            set
            {
                PC1 = value;
            }
        }
        public Color SecondaryColor
        {
            get
            {
                return PC2;
            }
            set
            {
                PC2 = value;
            }
        }
        public XPanel()
        {
            PC1 = Color.White;
            PC2 = SystemColors.ButtonFace;
            this.CS = ColorStyle.CSFull;   
            this.Paint += new PaintEventHandler(XPanel_Paint);
           
        }
        private void XPanel_Paint(Object Sender, PaintEventArgs e)
        {
            Point Style = new Point(0,0);
            if (BT == PBrushStyle.PBSPlain)
            {
                Style = new Point(0, this.Height);
            }
            else if (BT == PBrushStyle.PBSNew)
            {
                Style = new Point(this.Width, this.Height);
            }

            LinearGradientBrush Brush = new LinearGradientBrush(new Point(0,0),new Point(1,1),Color.White,Color.White);
            if (CS == ColorStyle.CSFull)
            {
                Brush = new LinearGradientBrush(new Point(0, 0), Style, PC1, PC2);
            }
            else if(CS == ColorStyle.CSWhite)
            {
                Brush = new LinearGradientBrush(new Point(0, 0), Style, Color.White, PC1);
            }
            e.Graphics.FillRectangle(Brush, 0, 0, this.Width, this.Height);
        }
    }
    public class Buttox : Button
    {

        public Buttox()
        {

        }
        public override string Text
        {
            get
            {
                try
                {
                    return Settings.StrRepository.getNodeByName(this.Name).ToString();
                }
                catch
                {
                    return this.Name;
                }

            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

        }
    }
    public class Labelx : Label
    {

        public Labelx()
        {

        }
        public override string Text
        {
            get
            {
                try
                {
                    return Settings.StrRepository.getNodeByName(this.Name).ToString();
                }
                catch
                {
                    return this.Name;
                }

            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

        }
    }
    #endregion
    #region Tools
    /**
     * This is a handy toolset 
     * */
    public static class XTools
    {
        public static decimal XCompare(String Str1, String Str2, int spawn)
        {
            List x = new List(new Node(""));
            for (int i = 0; i < Str1.Length/spawn; i++)
            {
                x.addNode(new Node(Str1.Substring(spawn * i, spawn)));
            }
            int r = 0;
            Node f = x.Tail;
            Node g = new Node(new Node(""));
            for(int i = 0 ; i < spawn ; i++)
            {
                if (Str2.Contains(f.nodeValue.ToString()))
                {
                    r++;
                }
                f = f.nextNode;
                
            }
            decimal amount = (decimal)r / (decimal)Str1.Length;
            return amount;
        }// End XCompare
    }
    #endregion
    #region LinkedLists
    public class List
    {
        public List(Node Nod)
        {
            this.Tail = Nod;
            this.Head = Nod;
        }
        public Node Tail;
        public Node Head;
        public Object getNodeByName(String Name)
        {
            Node Nod = this.Tail;
            while (Nod.nextNode != null)
            {
                if (Nod.nodeName == Name)
                {
                    break;
                }
                else
                {
                    Nod = Nod.nextNode;
                }
            }
            return Nod.nodeValue;
        }
        public Object getNodeValueAt(int id)
        {
            Node Nod = this.Tail;
            for (int i = 0; i < id; i++)
            {
                if (Nod.nextNode != null)
                {
                    Nod = Nod.nextNode;
                }
            }
            return Nod.nodeValue;
        }
        public Object getNodeValueBackWardsAt(int id)
        {
            Node Nod = this.Head;
            for (int i = 0; i < id; i++)
            {
                Nod = Nod.PreviousNode;
            }
            return Nod.nodeValue;
        }
        public void addNodeAt(Node Nodx, int ID)
        {
            Node Nod = this.Tail;
            Node Nad = new Node("");
            Node Ned = new Node("");
            for (int i = 0; i <= ID + 1; i++)
            {
                if (i == ID)
                {
                    Nodx.nextNode = Nad;
                }
                else if (i == ID - 1)
                {
                    Nad = Nod.nextNode;

                    Nod.nextNode = Nodx;
                    Nodx.PreviousNode = Nod;
                    Nad.PreviousNode = Nodx;

                }
                else if (i == ID + 1)
                {
                    Nod.PreviousNode = Nodx;
                }
                else
                { 
                    Nod = Nod.nextNode;
                }
            }
        }
        public void addNodeBackwardsAt(Node Nodx, int ID)
        {
            Node Nod = this.Head;
            Node Nad = new Node("");
            Node Ned = new Node("");
            for (int i = 0; i >= ID; i++)
            {
                if (i == ID)
                {
                    Nodx.PreviousNode = Nad;
                }
                else if (i == ID - 1)
                {
                    Nad = Nod.PreviousNode;

                    Nod.PreviousNode = Nodx;
                    Nodx.nextNode = Nod;
                    Nad.nextNode = Nodx;

                }
                else if (i == ID + 1)
                {
                    Nod.nextNode = Nodx;
                }
                else
                {
                    Nod = Nod.PreviousNode;
                }
            }
        }
        public void addNode(Node Nodx)
        {
            Node Nod = this.Tail;
            while (Nod.nextNode != null)
            {
                Nod = Nod.nextNode;
            }
            this.Head = Nodx;
            Nod.nextNode = Nodx;
            Nodx.PreviousNode = Nod;
        }
        public void deleteNode(int id)
        {
            Node Nod = this.Tail;
            Node XNod;
            for (int i = 0; i <= id; i++)
            {
                if (i == id)
                {
                    XNod = Nod.nextNode;
                    Nod.nextNode = Nod.nextNode.nextNode;
                    XNod = null;
                }
                else
                {
                    Nod = Nod.nextNode;
                }

            }

        }
    }
    public class Node
    {
        public Object nodeValue;
        public Node PreviousNode;
        public Node nextNode;
        public String nodeName = "";
        public List subNodes;
        public void addNode(Node node)
        {
            Node Nodx = this;
            while (Nodx.nextNode != null)
            {
                Nodx = Nodx.nextNode;
            }
            Nodx.nextNode = node;
            node.PreviousNode = Nodx;

        }
        public Node(Object value)
        {
            this.nodeValue = value;
        }
        public Node(Object value, String Name)
        {
            this.nodeValue = value;
            this.nodeName = Name;
        }
        public Object getNodeAt(int id)
        {
            Node nod = this;
            for (int i = 0; i
                < id; i++)
            {
                nod = nod.nextNode;
            }
            return nod.nodeValue;
        }
        public void removeNodeAt(int id)
        {
            Node Nod = this;
            for (int i = 0; i < id; id++)
            {
                Nod = Nod.nextNode;
            }
            Nod = null;
        }

    }
    #endregion
    public static class Settings
    {
        public static List StrRepository;
        public static string Language;
        public static void reset()
        {
            FileStream FS = new FileStream("config.dat", FileMode.OpenOrCreate);
            BinaryWriter BW = new BinaryWriter(FS);
            BW.Write((string)"swedish.lang");
        }
        public static void load()
        {
            FileStream FS = new FileStream("config.dat", FileMode.OpenOrCreate);
            BinaryReader BR = new BinaryReader(FS);
            Settings.Language = BR.ReadString();
            loadLanguage(Settings.Language);
        }

        static void loadLanguage(String Path)
        {

            Settings.StrRepository = new List(new Node(""));
            StreamReader BR = File.OpenText(Path);
            String x;
            while ((x = BR.ReadLine()) != null)
            {
                String[] f = x.Split('=');
                Settings.StrRepository.addNode(new Node(f[1], f[0]));
            }

        }
    }
    public  static partial class XColors
    {

        #region ColorUlities
        public static int desaturate(int r, int saturation, int Brightness)
        {

            
            return r;
        }
        
        public static Color HSBToRGB(int H, int Saturation, int Brightness)
        {
            int r = 0;
            int b = 0;
            int g = 0;
            decimal f = Saturation / 100;

            if (H <= 255)
            {
                int x = H;
                r = 255;
                g = x;
                b = 1;

            }
            else if (H > 255 && H < 255 * 2)
            {
                //  MessageBox.Show("A");
                int x = H - 255 * 1;
                r = 255 - x;
                g = 255;
                b = 1;

            }

            else if (H > 255 * 2 - 1 && H < 255 * 3)
            {
                int x = H - 255 * 2;
                r = 1;
                g = 255;
                b = x;
            }
            else if (H > 255 * 3 - 1 && H < 255 * 4)
            {
                int x = H - 255 * 3;
                r = 1;
                g = 255 - x;
                b = 255;
            }
            else if (H > 255 * 4 - 1 && H < 255 * 5)
            {
                int x = H - 255 * 4;
                r = x;
                g = 1;
                b = 255;
            }
            else if (H > 255 * 5 - 1 && H < 255 * 6)
            {
                int x = H - 255 * 5;
                r = 255;
                g = 1;
                b = 255 - x;
            }
            r = desaturate(r, Saturation, Brightness);
            g = desaturate(g, Saturation, Brightness);
            b = desaturate(b, Saturation, Brightness);
            int pr = 255 - r;
            int pg = 255 - g;
            int pb = 255 - b;
            int gr = pr * Saturation / 100;
            int gg = pg * Saturation / 100;
            int gb = pb * Saturation / 100;
            /* r += gr;
             g += gg;
             b += gb;*/
            /* 
              if (r < 127)
              {
                
                  r = r + s;
              }
              if (g > 127)
              {
                  g = g -s;
              }
              if (g < 127)
              {
                  g = g + s;
              }
              if (b > 127)
              {
                  b = b - s;
              }
              if (b < 127)
              {
                  b = b + s ;
              }*/
            return Color.FromArgb(255, r, g, b);
        }

           
            public static int Diff(int x, int y)
            {
                if (x > y)
                {
                    return x - y;
                }
                else
                {
                    return y - x;
                }
                
            }
            public static Color Transgen(Color clFirst,Color clLast, int Hue,int Saturation,int Brightness)
            {
                
                int r = 0;
                int b = 0;
                int g = 0;
                decimal f = Saturation / 100;



                if (Hue < 254)
                {
                    int ph = (Hue);
                    r = Diff(clFirst.R, clLast.R);
                    g = Diff(clFirst.G, clLast.G);
                    b = Diff(clFirst.B, clLast.B);
                    float percent = ((float)ph / 255.0f);
                    int rr = clFirst.R + (int)(r * percent);
                    int gg = clFirst.G + (int)(g * percent); ;
                    int bb = clFirst.B + (int)(b * percent);
                    if (clFirst.R > clLast.R)
                    {
                        rr = clFirst.R - (int)(r * percent);
                    }
                    if (clFirst.G > clLast.G)
                    {
                        gg = clFirst.G - (int)(g * percent);
                    }
                    if (clFirst.B > clLast.B)
                    {
                        bb = clFirst.B - (int)(b * percent);
                    }
                    rr = desaturate(rr, Saturation, Brightness);
                    gg = desaturate(gg, Saturation, Brightness);
                    bb = desaturate(bb, Saturation, Brightness);
                    return Color.FromArgb(255, rr, gg, bb);
                }
                else if (Hue > 254 && Hue < 255*2)
                {
                    r = Diff(clLast.R, 255);
                    g = Diff(clLast.G, 255);
                    b = Diff(clLast.B, 255);
                    float percent = ((float)Hue - 255.0f) / 255.0f;
                        return Color.FromArgb(255, clLast.R + (int)(r * percent), clLast.G + (int)(g * percent), clLast.B + (int)(b * percent));
                }
                else
                {
                    return Color.White;
                }
                /* 
                  if (r < 127)
                  {
                
                      r = r + s;
                  }
                  if (g > 127)
                  {
                      g = g -s;
                  }
                  if (g < 127)
                  {
                      g = g + s;
                  }
                  if (b > 127)
                  {
                      b = b - s;
                  }
                  if (b < 127)
                  {
                      b = b + s ;
                  }*/
               
            }
    }
    #endregion
    
}
