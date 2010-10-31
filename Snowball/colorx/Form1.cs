using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Snowball;
using System.IO;
namespace colorx
{
    public partial class Form1 : Form
    {
        private Song CurrentSong;
        private List<Collection> collections;
        public List<Collection> Collections
        {
            get
            {
                return collections;
            }
            set
            {
                collections = value;
            }
        }
        
        public void LoadCollection(string fileName)
        {
            this.collections.Clear();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(fileName);
            if (xmlDoc.DocumentElement.Name == "collection")
            {
                Collection _Collection = new Collection();
                _Collection.Name = xmlDoc.GetElementsByTagName("name")[0].InnerText;
                XmlNodeList xnlArtists = xmlDoc.GetElementsByTagName("artist");
              
                foreach (XmlElement Artist in xnlArtists)
                {
                    Artist _Artist = new Artist();
                    _Artist.Name = Artist.GetAttribute("name");
                    XmlNodeList xnlAlbums = Artist.GetElementsByTagName("album");
                    foreach (XmlElement xeAlbum in xnlAlbums)
                    {
                        Album _Album = new Album();
                        _Album.Name = xeAlbum.GetAttribute("name");
                        XmlNodeList xnlSongs = xeAlbum.GetElementsByTagName("song");
                        foreach (XmlElement XeSong in xnlSongs)
                        {
                            Song R = new Song();
                            R.Name = XeSong.GetAttribute("name");
                            R.Artist = XeSong.GetAttribute("artist");
                            R.File = XeSong.GetAttribute("path");
                            R.Type = XeSong.GetAttribute("type");
                            try
                            {
                                R.Number = int.Parse(XeSong.GetAttribute("number"));
                            }
                            catch
                            {
                                R.Number = 0;
                            }
                            _Album.Songs.Add(R);
                        }
                        _Artist.Albums.Add(_Album);
                    }
                    _Collection.Artists.Add(_Artist);
                }
                collections.Add(_Collection);
                List();
            }
            else if (xmlDoc.DocumentElement.Name == "rss")
            {
                Collection SR = new Collection();
                SR.Name = xmlDoc.GetElementsByTagName("title")[0].InnerText;
                XmlNodeList Items = xmlDoc.GetElementsByTagName("item");
                string Author = xmlDoc.GetElementsByTagName("copyright")[0].InnerText;
                Artist X = new Artist();
                X.Name = Author;
                SR.Artists.Add(X);
                Album _Album = new Album();
                _Album.Name = SR.Name;
                X.Albums.Add(_Album);
                int i = 0;
                foreach (XmlElement Item in Items)
                {
                    XmlNode Enclosure = Item.GetElementsByTagName("enclosure")[0];
                    Song S = new Song();
                    S.Name = Item.GetElementsByTagName("title")[0].InnerText;
                    S.Artist = Author;
                    S.File = Enclosure.Attributes["url"].InnerText;
                    S.Number = i;
                    S.Type = "application/mp3";
                    _Album.Songs.Add(S);
                    i++;
                }
                Collections.Add(SR);
            }
            List();
            
        }
        private Song GetSong(string Name, string Artist)
        {
            foreach (Collection _Collection in Collections)
            {
                foreach (Artist _Artist in _Collection.Artists)
                {
                    foreach (Album _Album in _Artist.Albums)
                    {
                        foreach (Song _Song in _Album.Songs)
                        {
                            if (Name == _Song.Name && Artist == _Song.Artist)
                            {
                                return _Song;
                            }
                        }
                    }
                }
            }
            return null;
        }
        public void Mark()
        {
            int i=0;
            foreach (ListViewItem X in listView1.Items)
            {
                if (Properties.Settings.Default.wmp10)
                    if (((i % 2) == 1))
                    {
                        X.BackColor = ColorTranslator.FromHtml("#EEEEFF");
                    }
                    else
                    {
                        X.BackColor = XColors.Transgen(Properties.Settings.Default.LastColor, Color.White, 211, 100, 100);
                    }
                else
                    X.BackColor = BackColor;
                if(CurrentSong!=null)
                    if (CurrentSong.Name == X.SubItems[1].Text && CurrentSong.Artist == X.SubItems[2].Text)
                    {
                        X.BackColor = SelectedColor;
                        X.ForeColor = Color.LightGreen;
                    }
                    else
                    {
                        if ((i % 2) == 1)
                        {
                            X.BackColor=AlternateColor;
                        }
                      
                    }
                i++;
            }
        }
        public void List()
        {
            listView1.Items.Clear();
            int i = 0;
            foreach (Collection _Collection in Collections)
            {
                foreach (Artist _Artist in _Collection.Artists)
                {
                    foreach (Album _Album in _Artist.Albums)
                    {
                        foreach (Song _Song in _Album.Songs)
                        {
                            var x = listView1.Items.Add(_Song.Number.ToString());
                            x.SubItems.Add(_Song.Name);
                            x.SubItems.Add(_Song.Artist);
                            x.SubItems.Add(_Album.Name);
                            x.SubItems.Add(_Collection.Name);
                            if(Properties.Settings.Default.wmp10)
                                if ((i % 2) == 1)
                                {
                                    x.BackColor = AlternateColor;
                                }

                            i++;
                        }
                    }
                }
            }
        }

        public Form1()
        {
            InitializeComponent();
            X = new BufferedGraphicsContext();
            G = new Bitmap("test.png");
            collections = new List<Collection>();
            Podcasts = new List<Podcast>();
            fCC = new frmColorChooser(this);
        }
        private System.Drawing.BufferedGraphicsContext X;
        private BufferedGraphics BE;
        private Image bg;
        public Image Bg
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
        Bitmap F;
        Bitmap G;
        private void Meshis(int manhue)
        {
            /*
            if (Bg != null)
            {
                F = new Bitmap(Bg, panel1.Width, panel1.Height);
                BE = X.Allocate(panel1.CreateGraphics(), new Rectangle(0, 0, panel1.Width, panel1.Height));

                for (int i = 0; i < F.Width; i++)
                {
                    for (int j = 0; j < F.Height; j++)
                    {
                        Color s = F.GetPixel(i, j);
                        float f = (s.R + s.G + s.B) / 3;

                        double r = f * (manhue % (255 * 2));
                        int p = (int)r;

                        float x = (f / 255) * 100;
                        Color y = XColors.HSBToRGB((manhue) + (int)f, 100, (int)x);

                        F.SetPixel(i, j, y);
                    }
                }
                BE.Graphics.DrawImage(F, new Point(0, 0));
                BE.Render();
            }*/
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {

         
        }

        private void Form1_Move(object sender, EventArgs e)
        {
            Meshis(320);
        }
        private void SearchX(string startingDirectory,Album _Album)
        {
            
            DirectoryInfo X = new DirectoryInfo(startingDirectory);
            try
            {
                foreach (FileInfo File in X.GetFiles())
                {
                    if (File.FullName.EndsWith(".mp3"))
                    {
                        TagLib.Mpeg.File Sn = new TagLib.Mpeg.File(File.FullName);

                            Song _Song = new Song();
                            _Song.Name = Sn.Tag.Title;
                            _Song.Artist = Sn.Tag.Artists[0];
                            _Album.Songs.Add(_Song);
                            _Song.Type = "application/mp3";
                            _Song.File = File.FullName;


                        

                    }
                    else if (File.FullName.EndsWith(".txt"))
                    {

                        {
                            Song _Song = new Song();
                            _Song.Name = File.Name;
                            _Song.Artist = "Unknown";
                            _Album.Songs.Add(_Song);
                            _Song.Type = "text";
                            _Song.File = File.FullName;
                        }
                    }
                }
            

                foreach (DirectoryInfo Dir in X.GetDirectories())
                {
                    SearchX(Dir.FullName, _Album);
                }
                }
            catch
            {
            }
        }

        private void Search(string startingDirectory)
        {
            DirectoryInfo X = new DirectoryInfo(startingDirectory);
            Collection _Collection = new Collection();
            Artist _Artist = new Artist();
            Album _Album = new Album();
            _Collection.Artists.Add(_Artist);
            _Artist.Albums.Add(_Album);
            Collections.Add(_Collection);
            try
            {
                foreach (FileInfo _File in X.GetFiles())
                {
                    if (_File.FullName.EndsWith(".mp3"))
                    {
                        TagLib.Mpeg.File Sn = new TagLib.Mpeg.File(_File.FullName);

                        Song _Song = new Song();
                        _Song.Name = Sn.Tag.Title;
                        _Song.Artist = Sn.Tag.Artists[0];
                        _Album.Songs.Add(_Song);
                        _Song.Type = "application/mp3";
                        _Song.File = _File.FullName;
                        
                    }
                    else if (_File.FullName.EndsWith(".txt"))
                    {

                        {
                            Song _Song = new Song();
                            _Song.Name = _File.Name;
                            _Song.Artist = _File.DirectoryName;
                          
                            _Album.Songs.Add(_Song);
                            _Song.Type = "text";
                            _Song.File = _File.FullName;
                        }
                    }
                    else if (_File.Extension == "exe")
                    {
                        Song _Song = new Song();
                        _Song.Artist = (_File.DirectoryName);
                        _Song.Name = _File.Name;
                        _Song.Type="application/exe";
                        _Album.Songs.Add(_Song);
                    }
                }


                foreach (DirectoryInfo Dir in X.GetDirectories())
                {
                    SearchX(Dir.FullName, _Album);
                }
            }
            catch
            {
            }
            List();
        }
        List<Podcast> Podcasts;
        frmColorChooser fCC;
        private void Form1_Load(object sender, EventArgs e)
        {
            fCC.Show();
            LoadPodcasts();
            Tree();
        }
        private void LoadPodcasts()
        {
            XmlDocument R = new XmlDocument();
            R.Load("podcasts.xml");
            XmlNodeList Podcasts = R.GetElementsByTagName("podcast");
            foreach (XmlElement Podcast in Podcasts)
            {
                Podcast X = new Podcast();
                X.Title = Podcast.GetAttribute("title");
                X.URL = Podcast.GetAttribute("url");
                this.Podcasts.Add(X);
            }
        }
        private void Tree()
        {
            var x = treeView1.Nodes[0].Nodes[3];
            x.Nodes.Clear();
            foreach (Podcast R in Podcasts)
            {
                var y = x.Nodes.Add(R.Title);
                
            }
        }
        private Podcast GetPodcast(string title)
        {
            foreach (Podcast R in Podcasts)
            {
                if (R.Title == title)
                {
                    return R;
                }
            }
            return null;
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
           
        }

        private void ultraPanel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void colorChooser1_Load(object sender, EventArgs e)
        {

        }

        private void colorChooser1_Change()
        {
             Mark();
         /*   ultraPanel1.Meshis(ultraPanel1.CreateGraphics(), ultraPanel1.Hue, ultraPanel1.Saturation, ultraPanel1.Brightness);*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Collections.Clear();
            LoadCollection(textBox1.Text);
            List();
        }
        public Color FirstColor
        {
            get
            {
                return Properties.Settings.Default.FirstColor;
            }
            set
            {
                Properties.Settings.Default.FirstColor = value;
            }
        }
        public Color BackColor
        {
            get
            {
                if (Properties.Settings.Default.wmp10)
                    return XColors.Transgen(Properties.Settings.Default.LastColor, Color.White, Strength, 100, 100);
                else
                    return XColors.Transgen(Properties.Settings.Default.LastColor, Color.Black, Strength, 100, 100);
            }
            set
            {
                Properties.Settings.Default.LastColor = value;
            }
        }
        public Color AlternateColor
        {
            get
            {
                if (Properties.Settings.Default.wmp10)
                    return Color.White;
                else
                    return XColors.Transgen(Properties.Settings.Default.LastColor, Color.Black, Strength, 100, 100);
            }
        }
        public bool WMP10
        {
            get
            {
                return Properties.Settings.Default.wmp10;
            }
            set
            {
                Properties.Settings.Default.wmp10 = value;
            }
        }
        public int Strength
        {
            get
            {
                return Properties.Settings.Default.fadeA;
            }
            set
            {
                Properties.Settings.Default.fadeA = value;
            }
        }
        public Color SelectedColor
        {
            get
            {
                return Color.Black;
            }
        }
        
        public Color ForeColor
        {
            get
            {
                if (Properties.Settings.Default.wmp10)
                    return listView1.ForeColor = Properties.Settings.Default.FirstColor;
                else
                    return Color.White;
            }
            set
            {
                Properties.Settings.Default.LastColor = value;
            }
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
                listView1.BackColor = BackColor;
                treeView1.BackColor = BackColor;

                treeView1.ForeColor = ForeColor;
                listView1.ForeColor = ForeColor;
            
            
        }
       
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
          
            if (listView1.SelectedItems != null)
            {
                Song F = GetSong(listView1.SelectedItems[0].SubItems[1].Text, listView1.SelectedItems[0].SubItems[2].Text);
                if (F != null)
                {

                    CurrentSong = F;
                }
                Mark();
            }
            listView1.SelectedItems.Clear();
            if (CurrentSong.Type == "application/mp3")
            {
                player.URL = CurrentSong.File;

                player.Ctlcontrols.play();
            }
            else if(CurrentSong.Type == "text")
            {
                using(StreamReader SR = new StreamReader(CurrentSong.File))
                {
                    richTextBox1.Text = SR.ReadToEnd();
                    SR.Close();
                }
            }
            // trackBar1.Maximum = (int)player.currentMedia.duration;


        }

        private void trackBar1_Scroll_1(object sender, EventArgs e)
        {
            
            this.Invalidate();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //trackBar1.Value = (int)player.Ctlcontrols.currentPosition;
        }

        private void trackBar1_MouseUp(object sender, MouseEventArgs e)
        {
            timer1.Enabled = true;
        }
        private void SaveXML(string fileName)
        {
            XmlDocument X = new XmlDocument();
            XmlElement SR = X.CreateElement("collection");
            foreach (Collection _Coll in this.collections)
            {
                foreach (Artist _Artist in _Coll.Artists)
                {
                    XmlElement Artist = X.CreateElement("artist");
                   
                    Artist.SetAttribute("name",_Artist.Name);
                    foreach (Album _Album in _Artist.Albums)
                    {
                        XmlElement Album = X.CreateElement("album");
                        Album.SetAttribute("name", _Album.Name);
                        foreach (Song _Song in _Album.Songs)
                        {
                            XmlElement Song = X.CreateElement("song");
                            Song.SetAttribute("path", _Song.File);
                            Song.SetAttribute("type", _Song.Type);
                            Song.SetAttribute("artist", _Song.Artist);
                            Song.SetAttribute("name", _Song.Name);
                            Album.AppendChild(Song);
                        }
                        Artist.AppendChild(Album);
                    }
                    SR.AppendChild(Artist);
                }
            }
            X.AppendChild(SR);
            X.Save(fileName);
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (!File.Exists("library.xml"))
            {
                this.Search(Environment.ExpandEnvironmentVariables("%HOMEPATH%\\Music") + "");
                SaveXML("library.xml");
            }
            else
                LoadCollection("library.xml");
        }

        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            
            if (treeView1.SelectedNode != null)
            {
                if (treeView1.SelectedNode.Parent.Text == "Podcasts")
                {
                    Podcast Open = GetPodcast(treeView1.SelectedNode.Text);
                    if (Open != null)
                    {
                        listView1.Items.Clear();
                        LoadCollection(Open.URL);
                    }
                }
            }
        }

        private void colorChooser1_Load_1(object sender, EventArgs e)
        {

        }

        private void colorChooser1_Change_1()
        {
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           
            this.Invalidate();
        }

        private void colorChooser1_Change_2()
        {
        }
    }
   
}
