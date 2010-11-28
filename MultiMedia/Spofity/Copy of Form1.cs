using System;
using System.Xml;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.Windows.Forms;

namespace Spofity
{
    public partial class SegorifyView : UserControl
    {
       /* public class Element
        {
            private short type;
            public short Type
            {
                get
                {
                    return type;
                }
                set
                {
                    type = value;
                }
            }

            private string title;
            public string Title
            {
                get
                {
                    return title;
                }
                set
                {
                    title = value;
                }
            }
            private string text;
            public string Text
            {
                get
                {
                    return text;
                }
                set
                {
                    text = value;
                }
            }
            private List<Element> children;
            public List<Element> Children
            {
                get
                {
                    return children;
                }
                set
                {
                    children = value;
                }
            }

        }*/
        private Stack<Element> remaining;
         public string Artist
        {
            get
            {
                return artist;
            }
            set
            {
                artist = value;
                LoadLibrary(URI, artist);
            }
        }
        /* public void LoadPage(Stream Bytes)
         {
             BinaryReader R = new BinaryReader(Bytes);
             short count = R.ReadInt16();
             for (int i = 0; i < count; i++)
             {
                 Element _Element = new Element();
                 _Element.Type = R.ReadInt16();
                 _Element.Title = R.ReadString();
                 _Element.Text = R.ReadString();
                 
             }
         }*/

         private int top;
         public void LoadLibrary(string URI, string Filter)
         {
             top = 0;

             folder = URI;
             if (Filter == "")
             {
                 DirectoryInfo R = new DirectoryInfo(URI);
                 Filter = R.GetFiles("*.artist")[0].Name.Replace(".artist", "");
              //   this.comboBox1.Items.Clear();
                 foreach (FileInfo Art in R.GetFiles("*.artist"))
                 {
                //     this.comboBox1.Items.Add((string)Art.Name.Replace(".artist", ""));
                 }
             }
             artist = Filter.Replace(".artist", "");
             this.ContentPanel.Controls.Clear();
             top += 10;
             if (URI.EndsWith(".album"))
             {
                 folder = GetFolder(URI);
                 AddAlbum(URI);
             }
             else
             {


                 AddReleaseSection("Album", artist);
                 AddReleaseSection("Single", artist);
             }

         }
        public List<spotiEntry> Entries
        {
            get
            {
                List<spotiEntry> entries = new List<spotiEntry>();
                foreach (Control entry in this.ContentPanel.Controls)
                {
                    if (entry.GetType() == typeof(spotiEntry))
                    {
                        entries.Add((spotiEntry)entry);
                    }
                }
                return entries;
            }
        }
        int oldSelectedIndex = 0;
        int selectedIndex = 0;
        public int SelectedIndex
        {
            get
            {
                return selectedIndex;
            }
            set
            {
                selectedIndex = value;
            }
        }
        public int OldSelectedIndex
        {
            get
            {
                return oldSelectedIndex;
            }
            set
            {
                oldSelectedIndex = value;
            }
        }
        public List<spotiEntry> selectedItems
        {
            get
            {
                List<spotiEntry> entries = new List<spotiEntry>();
                foreach (Control i in this.ContentPanel.Controls)
                {
                    if (i.GetType() == typeof(spotiEntry))
                    {
                        if (((spotiEntry)i).Selected)
                            Entries.Add((spotiEntry)i);
                    }
                }
                return entries;
            }
        }
        public Panel ContentPanel
        {
            get
            {
                return contentPanel;
            }
        }
        public string GetFolder(string URI)
        {
            string[] fr = URI.Split('\\');
            string d ="";
            for (var i = 0; i < fr.Length - 1; i++)
            {
                d += fr[i] + "\\";
            }
            return d;
        }
        string folder;
        string artist;
        
        public SegorifyView(string URI)
        {
            InitializeComponent();
            Content = new Spofity(URI);
            Content.BeginLoading += new Spofity.ActionEvent(Content_BeginLoading);
            Content.FinishedLoading += new Spofity.ActionEvent(FinishedLoad);
            Content.LoadData();
            timer2.Start();
        }
        public List<spotiEntry> SelectedNodes
        {
           
            get
            {
                List<spotiEntry> nodes = new List<spotiEntry>();
                foreach (spotiEntry a in this.panel1.Controls)
                {
                    if(a.Selected)
                        nodes.Add(a);
                }
                return nodes;
            }
        }
       
       
        public void ClearSelected()
        {
            foreach (spotiEntry a in this.panel1.Controls)
            {
                a.Selected = false;
            }
        }

        public void GetSelectedNodes(bool multiple,int y)
        {
           
            if (multiple)
            {
                int i = 0;
                foreach (spotiEntry a in this.panel1.Controls)
                {
                    if (i >= selectedIndex && y < a.Top+a.Bottom)
                    {
                        a.Selected = true;
                    }
                }
            }
            else
            {
                 int j = 0;
                foreach (spotiEntry entry in panel1.Controls)
                {
                    if (y > entry.Top && y < entry.Bottom)
                    {
                        entry.Selected = true;
                        selectedIndex = j;
                        break;
                    }
                    j++;
                }
            }

        }
        
        void Content_BeginLoading()
        {
            this.label1.Text = "Loading page";

        }
        void FinishedLoad()
        {
            this.label1.Text = "Finished";
            for (int i = Content.View.Sections.Count - 1; i >= 0; i--)
            {
                Section d = Content.View.Sections[i];
                pane D = new pane();
                D.Label = d.Name;
                D.Show();
                D.Dock = DockStyle.Left;
                D.Width = 75;
                D.Height = this.panel1.Height;
                D.Sect = new Panel();
                panel1.Controls.Add(D);
                D.panel1 = this.panel1;
                this.contentPanel.Controls.Add(D.Sect);
                D.Sect.Dock = DockStyle.Fill;
                D.S ect.Show();
                
                if (i == 0)
                {
                    D.Sect.Visible = true;
                }
                foreach (Element a in d.Elements)
                {
                    Control Ds = new Control();
                    switch (a.Type)
                    {
                        case "sp:group":
                            spotifyPanel sp = new spotifyPanel();
                            sp.Label = a.GetAttribute("label");
                            sp.Width = int.Parse(a.GetAttribute("width"));
                            sp.Height = int.Parse(a.GetAttribute("height"));
                            sp.Left = int.Parse(a.GetAttribute("x"));
                            sp.Top = int.Parse(a.GetAttribute("y"));
                            D.Sect.Controls.Add(sp);
                            sp.Show();
                            Ds = sp;
                            break;
                        case "sp:label":
                            Label spx = new Label();
                            if (a.GetAttribute("autoSize") != "")
                            {
                                spx.AutoSize = bool.Parse(a.GetAttribute("autoSize"));

                            }

                            spx.Text = a.GetAttribute("label");
                            spx.Width = int.Parse(a.GetAttribute("width"));
                            spx.Height = int.Parse(a.GetAttribute("height"));
                            spx.Left = int.Parse(a.GetAttribute("x"));
                            spx.Top = int.Parse(a.GetAttribute("y"));

                            spx.ForeColor = Color.Gray;
                            spx.BackColor = Color.Transparent;



                            D.Sect.Controls.Add(spx);
                            spx.Show();
                            Ds = spx;
                            break;

                        default:
                            break;
                    }
                    top += Ds.Height;

                }

                if (i == 0)
                {
                    D.label1_MouseDown((object)D, new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
                }
                foreach (Control spx in D.Sect.Controls)
                {
                    if (spx.GetType() == typeof(Label))
                        foreach (Control Cont in D.Sect.Controls)
                        {
                            if (Cont.GetType() == typeof(spotifyPanel))
                            {

                                spotifyPanel SD = (spotifyPanel)Cont;
                                if (spx.Left > SD.Left && spx.Top > SD.Top && spx.Left < SD.Width + SD.Left && spx.Top < SD.Height + SD.Top)

                                    spx.ForeColor = Color.Black;
                                spx.BackColor = Color.FromArgb(104, 104, 104);


                            }
                        }
                }
            }
        }
        void D_MouseDown(object sender, MouseEventArgs e)
        {

            

        }
        
        private Spofity content;
        public Spofity Content
        {
            get
            {
                return content;
            }
            set
            {
                content = value;
            }
        }
        private string uri = "";
        public string URI
        {
            get
            {
                return uri;
            }
            set
            {
                uri = value;
            }
        }
        
        public void LoadContent()
        {
            XmlDocument R = new XmlDocument();
         
            R.GetElementsByTagName("section");

        }
       /* public Form1(string URL)
        {
            InitializeComponent();
            uri = URL;
            Thread A = new Thread(LoadContent);
            A.Start();
        }*/

        public SegorifyView()
        {
            InitializeComponent();
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {

       /*    
            DwmSetWindowAttribute(Spotify, (uint)DWMWINDOWATTRIBUTE.DWMWA_NCRENDERING_ENABLED, (IntPtr)Spotify, (IntPtr)sizeof(int));
            DwmSetWindowAttribute(Spotify, (uint)DWMWINDOWATTRIBUTE.DWMWA_ALLOW_NCPAINT, IntPtr.Zero,IntPtr.Zero);
            */
       

         //   Form Ds = (Form)Form.FromHandle(Spotify);
           
            
            /*
            VistaControls.Dwm.Margins D =  new   VistaControls.Dwm.Margins() { Bottom = -1, Left = -1, Top = -1, Right = -1 };
            
            VistaControls.Dwm.DwmManager.EnableGlassSheet(Spotify);
           
            {
             //   MessageBox.Show(a.ToString());
            }*/

            
          
        }
        bool s = false;
        private AxWMPLib.AxWindowsMediaPlayer player;
        public AxWMPLib.AxWindowsMediaPlayer Player
        {
            get
            {
                return player;
            }
        }
        private bool shift;
        public bool Shift
        {
            get
            {
                return shift;
            }
            set
            {
                shift = value;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
        public void AddReleaseSection(string name, string Filter)
        {
            DirectoryInfo DI = new DirectoryInfo(folder);
            DirectoryInfo DI2 = new DirectoryInfo(folder + "\\Release");
            if (DI2.GetFiles("*." + name.ToLower()).Length > 0)
            {
                AddSection(name + "s");
            }
            var c = DI2.GetFiles("*." + name.ToLower());
       
            for (int x = 0; x < c.Length; x++)
            {

                AddAlbum(c[x].FullName);

            }
        }
        public void AddAlbum(string name)
        {
        }
        public void AddSection(string name)
        {
        }
        private void contentPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (Content.loadThread.ThreadState == System.Threading.ThreadState.Stopped)
            {
                FinishedLoad();
                timer2.Stop();
            }
         
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {

        }
        
        private void timer3_Tick(object sender, EventArgs e)
        {
            try
            {
                Element Control = remaining.Pop();

                switch (Control.Type)
                {
                    case "Section":
                        Section D = new Section();
                        D.Name = Control.GetAttribute("name");
                        this.Content.View.Sections.Add(D);
                        break;
                    case "sp:entry":
                        spotiEntry entry = new spotiEntry();
                        entry.Title = Control.GetAttribute("name");
                        ContentPanel.Controls.Add(entry);
                        entry.Tag = Control.GetAttribute("tag");

                        break;
                }
            }
            catch
            {
            }

        }
    }
}
