using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace MediaChrome.Views
{
    public partial class Artist : UserControl
    {
        public delegate void ItemClick(object Sender, String Url);
        public event ItemClick ItemClicked;
        public bool Snart =true;
        public Color Section
        {
            get
            {
                return Snart ? MediaChrome.MainForm.FadeColor(-0.1f, MediaChrome.MainForm.ListBackground()) : Color.LightGray;
            }
        }
        public Color SectionText
        {
            get
            {
                return Snart ? MediaChrome.MainForm.FadeColor(-0.8f, MediaChrome.MainForm.ListForeground()) : Color.White;
            }
        }
        public Color Bg
        {
            get
            {
                return Snart ?  MediaChrome.MainForm.ListBackground() : Color.FromArgb(50,50,50);
            }
        }
        public Color Text
        {
            get
            {
                return Snart ? MediaChrome.MainForm.ListForeground() : Color.Gray;
            }
        }
        public Color TextFade
        {
            get
            {
                return Snart ? MediaChrome.MainForm.FadeColor(0.2f,MediaChrome.MainForm.ListForeground()) : MediaChrome.MainForm.FadeColor(-0.1f,Color.Gray);
            }
        }
        public Color Divider
        {
            get
            {
                return Snart ? MediaChrome.MainForm.ListForeground() : Color.Black;
            }
        }
        public Color Fg
        {
            get
            {
                return Snart ? MediaChrome.MainForm.ListForeground() : Color.White;
            }
        }
        public Color Entry
        {
            get
            {
                return Snart ? MediaChrome.MainForm.ListBackground() :  Bg;
            }
        }
        public Color Alt
        {
            get
            {
                return Snart ? MediaChrome.MainForm.AlternateRowColor() : Color.FromArgb(40,40,40);
            }
        }
        public Stack<Spofity> History { get; set; }
        public Stack<Spofity> Post {get;set;}
        public int currentSection = 0;
        public Spofity CurrentView     {         get;        set;      }
        public Artist()
        {
            Post = new Stack<Spofity>(); 
            History = new Stack<Spofity>();
            InitializeComponent();
            Images = new Dictionary<String,Image>();
            
        }
        public event EventHandler Loaded;
        public void LoadPage(string URI)
        {
            Thread D = new Thread(LoadContent);
            D.Start((object)URI);
        }
        public void LoadContent( object Uri)
        {
            String URI = (string)Uri;
           
            if (URI.StartsWith("http://"))
            {
                Spofity D = new Spofity(URI);
                D.FinishedLoading += new Spofity.ActionEvent(D_FinishedLoading);
                if(CurrentView!=null)
                    History.Push(CurrentView);
                CurrentView = D;
            }
            
        }
        public void DownloadImage(object token)
        {
            WebClient X = new WebClient();
            
            Image R = Bitmap.FromStream(X.OpenRead((string)token));
            Images.Add((string)token,R);

        }
        Dictionary<String,Image> Images;
        void D_FinishedLoading()
        {
            foreach (Section d in CurrentView.View.Sections)
            {
                foreach (Element _Elm in d.Elements)
                {
                    if (_Elm.Type == "sp:image")
                    {
                        Image C = null;
                        if (!Images.TryGetValue(_Elm.GetAttribute("src"), out C))
                        {
                            Thread D = new Thread(DownloadImage);
                            D.Start((object)_Elm.GetAttribute("src"));
                        }
                    }
                }
            }

            this.Loaded(this, new EventArgs());
            
        }

        private void Artist_Load(object sender, EventArgs e)
        {

        }
        int LEFT = 140;
        int ROWHEIGHT = 20;
        int scrollX=0;
        int scrollY=0;
        int diffX = 0;
        int diffY = 0;
        BufferedGraphicsContext D;
        private void timer1_Tick(object sender, EventArgs e)
        {

            Draw(this.CreateGraphics());

        }
        public void Draw(Graphics p)
        {
            this.BackColor = Snart ? MediaChrome.MainForm.ListBackground() : Color.FromArgb(50, 50, 50);
            if (CurrentView != null)
            {
                CurrentView.Serialize();
            }

            int entryship = 0;
            int top = 20;
            
            if (D == null)
                D = new BufferedGraphicsContext();
            BufferedGraphics R = D.Allocate(p, this.Bounds);
            Graphics d = R.Graphics;
            d.FillRectangle(new SolidBrush(Bg), this.Bounds);
            try
            {
                foreach (Element _Element in CurrentView.View.Sections[currentSection].Elements)
                {
                    switch (_Element.Type)
                    {

                        case "sp:entry":
                            Color EnTry = (entryship % 2) == 1 ? Entry : Alt;
                            if (_Element.Selected == true)
                            {
                                EnTry = Color.FromArgb(211, 255, 255);
                            }
                            Color ForeGround = MediaChrome.MainForm.FadeColor(-0.2f, Fg);
                            if (_Element.Selected == true)
                            {
                                ForeGround = Color.DarkBlue;
                            }
                            if (_Element.GetAttribute("position") == ("absolute"))
                            {
                                int _left = int.Parse(_Element.GetAttribute("left"));
                                int _top = int.Parse(_Element.GetAttribute("top"));
                                int _width = int.Parse(_Element.GetAttribute("width"));
                                int _height = int.Parse(_Element.GetAttribute("height"));

                                d.FillRectangle(new SolidBrush(EnTry), new Rectangle(_left - scrollX, _top - scrollY, _width, _height));
                                d.DrawString(_Element.GetAttribute("no"), new Font("MS Sans Serif", 8), new SolidBrush(MediaChrome.MainForm.FadeColor(-0.4f, ForeGround)), new Point(_left + 1 - scrollX, _top + 2 - scrollY));

                                d.DrawString(_Element.GetAttribute("title"), new Font("MS Sans Serif", 8), new SolidBrush(ForeGround), new Point(_left + 20 - scrollX, _top + 2 - scrollY));
                                d.DrawString(_Element.GetAttribute("author"), new Font("MS Sans Serif", 8), new SolidBrush(ForeGround), new Point(_left + 320 - scrollX, _top + 2 - scrollY));
                                d.DrawString(_Element.GetAttribute("collection"), new Font("MS Sans Serif", 8), new SolidBrush(ForeGround), new Point(_left + 435 - scrollX, _top + 2 - scrollY));
                                top += ROWHEIGHT;
                                entryship++;
                                break;
                            }
                            d.FillRectangle(new SolidBrush(EnTry), new Rectangle(LEFT - scrollX, top - scrollY, this.Width, ROWHEIGHT));
                            d.DrawString(_Element.GetAttribute("no"), new Font("MS Sans Serif", 8), new SolidBrush(MediaChrome.MainForm.FadeColor(-0.4f, ForeGround)), new Point(LEFT + 1 - scrollX, top + 2 - scrollY));

                            d.DrawString(_Element.GetAttribute("title"), new Font("MS Sans Serif", 8), new SolidBrush(ForeGround), new Point(LEFT + 20 - scrollX, top + 2 - scrollY));
                            d.DrawString(_Element.GetAttribute("author"), new Font("MS Sans Serif", 8), new SolidBrush(ForeGround), new Point(LEFT + 320 - scrollX, top + 2 - scrollY));
                            d.DrawString(_Element.GetAttribute("collection"), new Font("MS Sans Serif", 8), new SolidBrush(ForeGround), new Point(LEFT + 435 - scrollX, top + 2 - scrollY));
                            top += ROWHEIGHT;
                            entryship++;
                            break;


                        case "sp:header":
                            entryship = 0;
                            d.DrawString(_Element.GetAttribute("title"), new Font("MS Sans Serif", 12), new SolidBrush(Fg), new Point(LEFT + 20 - scrollX, top + 2 - scrollY));
                            top += 40;
                            break;
                        case "sp:image":
                            if (_Element.GetAttribute("position") == "absolute")
                            {
                                int x = int.Parse(_Element.GetAttribute("x"));
                                int y = int.Parse(_Element.GetAttribute("y"));
                                int width = int.Parse(_Element.GetAttribute("width"));
                                int height = int.Parse(_Element.GetAttribute("height"));
                                Image Rs = null;
                                Images.TryGetValue(_Element.GetAttribute("src"), out Rs);
                                if (Rs != null)
                                {
                                    d.DrawImage(Rs, new Rectangle(x-scrollX, y-scrollY, width, height));
                                }
                                break;
                            }
                            break;
                        case "sp:label":
                            if (_Element.GetAttribute("position") == "absolute")
                            {
                                int x = int.Parse(_Element.GetAttribute("x"));
                                int y = int.Parse(_Element.GetAttribute("y"));
                                int width = int.Parse(_Element.GetAttribute("width"));
                                int height = int.Parse(_Element.GetAttribute("height"));
                                d.DrawString(_Element.Data, new Font("MS Sans Serif", 8), new SolidBrush(Fg), new RectangleF(x - scrollX, y - scrollY, width, height));
                                break;
                            }
                            d.DrawString(_Element.GetAttribute("text"), new Font("MS Sans Serif", 8), new SolidBrush(Fg), new Point(int.Parse(_Element.GetAttribute("x")) - scrollX, int.Parse(_Element.GetAttribute("y")) - scrollY));
                            break;
                        case "sp:button":
                            break;
                        case "sp:section":
                            d.FillRectangle(new SolidBrush(Section), new Rectangle(0, top - scrollY, this.Width, 30));
                            d.DrawString(_Element.GetAttribute("text"), new Font("Arial Black", 10), new SolidBrush(Fg), new Point(LEFT - scrollX, top + 4 - scrollY));
                            top += 30;
                            break;
                        case "sp:divider":
                            top += 30;
                            d.DrawLine(new Pen(Divider), 0, top - scrollY, this.Width, top - scrollY);
                            top += 30;
                            break;
                        case "sp:space":
                            int dist = 0;
                            if (_Element.GetAttribute("distance") != "")
                            {
                                int.TryParse(_Element.GetAttribute("distance"), out dist);
                                if (dist > 0)
                                {
                                    top += dist;
                                    break;
                                }
                            }
                            top += 30;
                            break;
                    }




                }
            }
            catch
            {
            }
            R.Render();
        }
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            if (e.Delta == -120)
            {
                scrollY += 50;
            }
            if (e.Delta == 120)
            {
                scrollY -= 50;
            }
        }
        protected override void OnScroll(ScrollEventArgs se)
        {
            base.OnScroll(se);
            if (se.ScrollOrientation == ScrollOrientation.VerticalScroll)
            {
                if (se.NewValue - se.OldValue > 0)
                {
                    scrollY += 10;
                }
                if (se.NewValue - se.OldValue < 0)
                {
                    scrollY -= 10;
                }
            }
        }
        public string dragURI = "";
        private void Artist_MouseDown(object sender, MouseEventArgs e)
        {
            masX = e.X;
            masY = e.Y;
            int entryship = 0;
            int top = 20;
            try
            {
                foreach (Element _Elm in CurrentView.View.Sections[currentSection].Elements)
                {
                    _Elm.Selected = false;
                }
                foreach (Element _Element in CurrentView.View.Sections[currentSection].Elements)
                {
                    switch (_Element.Type)
                    {
                        case "sp:entry":
                            if (_Element.GetAttribute("position") == ("absolute"))
                            {
                                int _left = int.Parse(_Element.GetAttribute("left"));
                                int _top = int.Parse(_Element.GetAttribute("top"));
                                int _width = int.Parse(_Element.GetAttribute("width"));
                                int _height = int.Parse(_Element.GetAttribute("height"));
                                if (e.X >= _left - scrollX && e.X <= _left + _width - scrollX && e.Y >= _top - scrollY && e.Y <= _top + _height - scrollY)
                                {
                                    _Element.Selected = true;
                                    dragURI = _Element.GetAttribute("href");
                                }
                                break;
                            }
                            if (e.X >= LEFT - scrollX && e.Y >= top - scrollY && e.Y <= top - scrollY + ROWHEIGHT)
                            {
                                _Element.Selected = true;
                                dragURI = _Element.GetAttribute("href");
                               
                            }
                           
                            top += ROWHEIGHT;

                            break;
                        case "sp:header":
                            top += 40;
                            if (e.X > LEFT + 20 - scrollX && e.Y >= top + 2 - scrollY && e.Y >= top + 2 + 50 - scrollY)
                            {
                                // TODO: Do something
                            }
                            break;
                        case "sp:image":
                            break;
                        case "sp:label":
                            //    d.DrawString(_Element.GetAttribute("text"), new Font("MS Sans Serif", 8), new SolidBrush(Fg), new Point(int.Parse(_Element.GetAttribute("x")) - scrollX, int.Parse(_Element.GetAttribute("y")) - scrollY));
                            break;
                        case "sp:button":
                            break;
                        case "sp:section":
                            // d.FillRectangle(new SolidBrush(Section), new Rectangle(0, top - scrollY, this.Width, ROWHEIGHT));
                            // d.DrawString(_Element.GetAttribute("text"), new Font("MS Sans Serif", 8), new SolidBrush(Fg), new Point(LEFT - scrollX, top + 4 - scrollY));
                            top += 30;
                            break;
                        case "sp:divider":
                            top += 30;
                            //  d.DrawLine(new Pen(Color.Black), 0, top - scrollY, this.Width, top - scrollY);
                            top += 30;
                            break;
                        case "sp:space":
                            int dist = 0;
                            if (_Element.GetAttribute("distance") != "")
                            {
                                int.TryParse(_Element.GetAttribute("distance"), out dist);
                                if (dist > 0)
                                {
                                    top += dist;
                                    break;
                                }
                            }
                            top += 30;
                            break;
                    }




                }
            }
            catch
            {
            }
        }
        int masX;
        int masY;
        private int Diff(int x, int y)
        {
            return x > y ? x - y : y - x;
        }
        private void Artist_MouseMove(object sender, MouseEventArgs e)
        {
            mouseX = e.X;
            mouseY = e.Y;
            timer1.Start();
            if (dragURI != "" && dragURI != null)
            {
                diffX = Diff(e.X,masX);
                diffY = Diff(e.Y, masY);
            }
            if (diffX > 10 || diffY > 10)
            {
                DoDragDrop((object)dragURI, DragDropEffects.Copy);
                dragURI = null;
                diffX = 0;
                diffY = 0;
            }
            int entryship = 0;
            int top = 20;
            this.Cursor = Cursors.Default;
            try
            {
                foreach (Element _Element in CurrentView.View.Sections[currentSection].Elements)
                {
                    switch (_Element.Type)
                    {
                        case "sp:entry":

                            if (e.X >= LEFT - scrollX && e.Y >= top - scrollY && e.Y <= top - scrollY + ROWHEIGHT)
                            {
                            }

                            break;
                        case "sp:header":
                            
                            if (e.Y >= top - scrollY && e.Y <= top  - scrollY + 20 && e.X >= LEFT - scrollY)
                            {
                                this.Cursor = Cursors.Hand;
                            }
                            top += 40;
                            break;
                        case "sp:image":
                            break;
                        case "sp:label":
                            //    d.DrawString(_Element.GetAttribute("text"), new Font("MS Sans Serif", 8), new SolidBrush(Fg), new Point(int.Parse(_Element.GetAttribute("x")) - scrollX, int.Parse(_Element.GetAttribute("y")) - scrollY));
                            break;
                        case "sp:button":
                            break;
                        case "sp:section":
                            // d.FillRectangle(new SolidBrush(Section), new Rectangle(0, top - scrollY, this.Width, ROWHEIGHT));
                            // d.DrawString(_Element.GetAttribute("text"), new Font("MS Sans Serif", 8), new SolidBrush(Fg), new Point(LEFT - scrollX, top + 4 - scrollY));
                            top += 40;
                            break;
                        case "sp:divider":
                            top += 30;
                            //  d.DrawLine(new Pen(Color.Black), 0, top - scrollY, this.Width, top - scrollY);
                            top += 30;
                            break;
                        case "sp:space":
                             int dist = 0;
                            if (_Element.GetAttribute("distance") != "")
                            {
                                int.TryParse(_Element.GetAttribute("distance"), out dist);
                                if (dist > 0)
                                {
                                    top += dist;
                                    break;
                                }
                            }
                            top += 30;
                            break;
                    }




                }
            }
            catch
            {
            }
        }
        int mouseX = 0;
        int mouseY = 0;
        private void Artist_Leave(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void Artist_Enter(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void Artist_Paint(object sender, PaintEventArgs e)
        {
            Draw(e.Graphics);
        }

        private void Artist_MouseLeave(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void Artist_DoubleClick(object sender, EventArgs e)
        {
            timer1.Start();
            
            int entryship = 0;
            int top = 20;
            this.Cursor = Cursors.Default;
            try
            {
                foreach (Element _Element in CurrentView.View.Sections[currentSection].Elements)
                {
                    switch (_Element.Type)
                    {
                        case "sp:entry":
                            if (_Element.GetAttribute("position") == ("absolute"))
                            {
                                int _left = int.Parse(_Element.GetAttribute("left"));
                                int _top = int.Parse(_Element.GetAttribute("top"));
                                int _width = int.Parse(_Element.GetAttribute("width"));
                                int _height = int.Parse(_Element.GetAttribute("height"));
                                if (mouseX >= _left - scrollX && mouseX <= _left + _width - scrollX && mouseY >= _top - scrollY && mouseY <= _top + _height - scrollY)
                                {
                                    if (ItemClicked != null)
                                        ItemClicked(this, _Element.GetAttribute("href"));
                                }
                                break;
                            }
                            if (mouseX >= LEFT - scrollX && mouseY >= top - scrollY && mouseY <= top - scrollY + ROWHEIGHT)
                            {

                                if (ItemClicked != null)
                                    ItemClicked(this, _Element.GetAttribute("href"));
                               
                            }

                            break;
                        case "sp:header":

                            if (mouseY >= top - scrollY && mouseY <= top - scrollY + 20 && mouseX >= LEFT - scrollY)
                            {
                                this.Cursor = Cursors.Hand;
                            }
                            top += 40;
                            break;
                        case "sp:image":
                            break;
                        case "sp:label":
                            //    d.DrawString(_Element.GetAttribute("text"), new Font("MS Sans Serif", 8), new SolidBrush(Fg), new Point(int.Parse(_Element.GetAttribute("x")) - scrollX, int.Parse(_Element.GetAttribute("y")) - scrollY));
                            break;
                        case "sp:button":
                            break;
                        case "sp:section":
                            // d.FillRectangle(new SolidBrush(Section), new Rectangle(0, top - scrollY, this.Width, ROWHEIGHT));
                            // d.DrawString(_Element.GetAttribute("text"), new Font("MS Sans Serif", 8), new SolidBrush(Fg), new Point(LEFT - scrollX, top + 4 - scrollY));
                            top += 40;
                            break;
                        case "sp:divider":
                            top += 30;
                            //  d.DrawLine(new Pen(Color.Black), 0, top - scrollY, this.Width, top - scrollY);
                            top += 30;
                            break;
                        case "sp:space":
                            int dist = 0;
                            if (_Element.GetAttribute("distance") != "")
                            {
                                int.TryParse(_Element.GetAttribute("distance"), out dist);
                                if (dist > 0)
                                {
                                    top += dist;
                                    break;
                                }
                            }
                            top += 30;
                            break;
                    }




                }
            }
            catch
            {
            }
        }
    
    }
}
