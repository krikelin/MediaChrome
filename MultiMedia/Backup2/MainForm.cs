/*
 * Created by SharpDevelop.
 * User: Alex
 * Date: 2010-10-27
 * Time: 19:03
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

using MediaChrome;

namespace MediaChrome
{
   
    
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
    {
        public static String findVersion(String text)
        {
            bool inVersion = false;
            String ver = "";
            foreach (Char d in text)
            {
                if (inVersion)
                    ver += d;
                if (d == ')')
                {
                    inVersion = false;
                    continue;
                }
                if (d == '(')
                {
                    inVersion = true;
                    continue;
                }
            }
            return ver;
        }
        public static String findCommit(String text)
        {
            bool inVersion = false;
            String ver = "";
            foreach (Char d in text)
            {
                
                if (d == ']')
                {
                    inVersion = false;
                    continue;
                }
                if (d == '[')
                {
                    inVersion = true;
                    continue;
                }
                if (inVersion)
                    ver += d;
            }
            return ver;
        }
        public static String GetURIFromSong(Song _Song)
        {
            String Version = MainForm.findVersion(_Song.Title);
            String Commit = MainForm.findCommit(_Song.Title);
               
            String Path = "music://t/" + _Song.Artist + "/" + _Song.Title.Replace("(" + Version + ")", "").Replace("[" + Commit + "]", "") + "/" + _Song.Album + (Version != "" ? "/" + Version : " ") + (Commit != "" ? "/" + Commit : "") + "?a=b" + (_Song.Engine != null || _Song.Engine != "" ? "&service=" + _Song.Engine : "") + ( _Song.ID != null ? "&id="+_Song.ID : "");
            Path = Path.Replace("'", "").Replace("[", "").Replace("]", "").Replace("(", "").Replace(")", "");
            return Path;
        }
        public static Song GetSongFromURI(String D)
        {
            Song P = new Song();



            P.Version = MainForm.findVersion(D);
            P.Contributing = MainForm.findCommit(D);
            Uri Url = new System.Uri(D.Replace("(" + P.Version + ")", "").Replace("[" + P.Contributing + "]", "").Replace("{", "").Replace("}", ""));


            P.Artist = Url.Segments[1].Replace("/", "").Replace("%20", " ");//Url.Host.Replace("_"," ");
            P.Title = Url.Segments[2].Replace("/", "").Replace("%20", " ");



            P.Album = Url.Segments[3].Replace("/", "").Replace("%20", " ");
            try
            {
         	   P.ProposedEngine = UriHelper.Querystrings(Url)["service"];
            }
            catch
            {
            	
            }
            P.Path = D;
            try
            {
            P.ID = UriHelper.Querystrings(Url)["id"];
            }catch{
            
            }
            return P;
        }
       
        public static String GetSongByEngine(Song _Song,String _Engine)
        {
           
            String Query = _Song.Path;
           /* Uri d = new System.Uri(Query.Replace("music:", "http:").Replace("song:", "http:"));
            _Song.Title = d.Segments[2].Replace("%20", " ").Replace("/", "");
            _Song.Artist = d.Segments[1].Replace("%20", " ").Replace("/", "");
            _Song.Album = d.Segments[3].Replace("%20", " ").Replace("/","");*/

            try
            {
                IPlayEngine Engine = Program.MediaEngines[_Engine];

                {
                    Song f = Engine.RawFind(_Song);
                    if ((f) != null)
                    {

                        return f.Path;

                    }

                }
            }
            catch
            {
            }
            return null;


           
        }
		bool replaceCompleted=false;
       
		public void Gogo()
		{
			replaceCompleted=false;
			
		}
        public static Color HighlightText()
        {
            return Color.Black;
        }
        public static Color Highlight()
        {
            return customHColor;
        }
		public static Song ItemToSong(ListViewItem I)
		{
			
			
			return (Song)I.Tag;
		}
		public static ListViewItem SongToItem(Song I)
		{
			
			ListViewItem D = new ListViewItem(I.Title);
            D.SubItems.Add("");
			D.SubItems.Add(I.Artist);
			D.SubItems.Add(I.Album);
			D.SubItems.Add(I.Store);
			D.SubItems.Add(I.Engine);
			D.Tag=(object)I;
			return D;
		}
		public void CreateCurrentPlaylist()
		{
			
			cListView1.Items.Clear();
			foreach(Song i in playlist)
			{
				ListViewItem D = SongToItem(i);
				D.Tag=(Object)i;
				cListView1.Items.Add(D);
			}
			cListView1.Items[0].BackColor=Color.FromArgb(50,50,50);
			cListView1.Items[0].ForeColor=Color.LightGreen;
			foreach(ColumnHeader Dfs in cListView1.Columns)
			{
				Dfs.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
			}
		}
		/// <summary>
		/// Media player engine decides by the first URI system ([player]:query)
		/// </summary>
		/// <summary>
		/// Current media engine.
		/// </summary>
		public static IPlayEngine currentPlayer;
		/// <summary>
		/// When a media file is begin to play, it decides the player engine to use by the parameter a:
		/// </summary>
		/// <param name="Query"></param>
		/// 
	
		public static bool PlayItem(String Query){
        /*    if (ResolvingSongThread != null)
                return false;*/
			/// <summary>
			/// Stop the current player to play the media, but first
			/// be sure that there is a current instance of a class witihn the IMediaEngine
			/// </summary>
			if(currentPlayer!=null){
				currentPlayer.Stop();
				foreach(Control d in Program.Host.Playboard.Controls)
				{
					if(d.GetType() == currentPlayer.MediaControl.GetType())
					{
						d.Hide();
					}
				}
			}
			/// <summary>
			/// Get the engine namespace from the query passed
			/// </summary>
			string engine = Query.Split(':')[0];
			try
			{
				Song _Song = GetSongFromURI(Query);
				if(_Song.ID != null && _Song.ID != "" && _Song.ProposedEngine != "" && _Song.ProposedEngine != null)
				{
					try
					{
						IPlayEngine Df = Program.MediaEngines[_Song.ProposedEngine];
						MainForm.currentPlayer = Df;
						MainForm.currentPlayer.Load(Df.Namespace+":"+_Song.ID);
						MainForm.currentTrack = _Song;
						return true;
					}
					catch
					{
						
					}
					
				}
			}
			catch
			{
				
			}
		
			IPlayEngine D = null;
			if(Query.StartsWith("music:")||Query.StartsWith("song:"))
			{

                Song _Song = GetSongFromURI(Query);
				Uri d = new System.Uri(Query.Replace("music:","http:").Replace("song:","http:"));
				if(_Song.ID != null && _Song.ID != "" && _Song.ProposedEngine != "" && _Song.ProposedEngine != null)
				{
					try
					{
						IPlayEngine Df = Program.MediaEngines[_Song.ProposedEngine];
						MainForm.currentPlayer = Df;
						MainForm.currentPlayer.Load(Df.Namespace+":"+_Song.ID);
						MainForm.currentTrack = _Song;
						return true;
					}
					catch
					{
						
					}
					
				}
                ResolvingSongThread = new Thread(MainForm._ResolveSong);
                ResolvingSongThread.Start((object)_Song);
                /***
                 * If a default service is assigned, try the service
                 * before attempting to find it on other service
                 * */


              Querys  = UriHelper.Querystrings(d);

                
				
				
				return true;
			}
			else
			{
				/// <summary>
				/// Get the player from the list
				/// </summary>
				/// 
				if(Program.MediaEngines.ContainsKey(engine))
				{
					D = Program.MediaEngines[engine];
				}
				
			}
			if(D!=null)
			{
			
				D.MediaControl.Dock = DockStyle.Fill;
				D.MediaControl.Show();
				D.MediaControl.Enabled=true;
				/// <summary>
				/// Remove the engine specification of the Query URI
				/// </summary>
				String Path = Query.Replace(engine+":","");
				/// <summary>
				/// Send it to the media player
				/// </summary>
				D.Load((Path));
				/// <summary>
				/// Play the media
				/// </summary>
				D.Play();
				currentPlayer=D;
				
				
			}
			else
			{
				MessageBox.Show("There is no media handler for the media");
			}
            return true;
		}
        public static Song GetSongFromQury(SQLiteDataReader D)
        {

            Song _Song = new Song();
            _Song.Title = (String)D["name"];
            _Song.Artist = (String)D["artist"];
            _Song.Album = (String)D["album"];
            _Song.Composer = (String)D["composer"];
            _Song.Path = (String)D["path"];
            _Song.Store = (String)D["store"];
            _Song.Feature = (String)D["feature"];
            _Song.Version = (String)D["version_"];
            _Song.Contributing = (String)D["coartist"];



            return _Song;

        }
        public static Song watchSong;
        public static Dictionary<String, String> Querys;
        public static bool resolvingSong = false;
        public static Thread ResolvingSongThread;
        static void _ResolveSong(Object dr)
        {
            resolvingSong = true;
            
            Song _Song = (Song)dr;

            if(Querys != null)
            if (Querys.ContainsKey("service"))
            {
                if (Program.MediaEngines.ContainsKey(Querys["service"]))
                {
                    IPlayEngine Engine = Program.MediaEngines[Querys["service"]];
                    MainForm.Engine = Engine;
                    MainForm.watchSong = Engine.RawFind(_Song);
                    resolvingSong = false;
                    return;
                   /* */
                }
            }

            /**
             * Elsewhere, iterate through installed music services
             * and check if there is a matching track to play the song on
             * */
            foreach (IPlayEngine Engine in Program.MediaEngines.Values)
            {
               
             Song f  = Engine.RawFind(_Song);
             
                if (f != null)
                {
                    MainForm.Engine = Engine;
                     resolvingSong = false;
                     MainForm.watchSong = f;
                    return;
                }

                   
                  /*  currentTrack = f;

                    currentPlayer = Engine;
                    Engine.Load((currentTrack.Path));
                    currentTrack = _Song;
                    Engine.Play();
*/
                 

            }
            resolvingSong = false;
            MainForm.ResolvingSongThread = null;
            ShowMessage("There was no service found for the song");
        	}
        public static bool Song_Exists(Song _Song)
        {
            

           

            if (Querys != null)
                if (Querys.ContainsKey("service"))
                {
                    if (Program.MediaEngines.ContainsKey(Querys["service"]))
                    {
                        IPlayEngine Engine = Program.MediaEngines[Querys["service"]];
                        MainForm.Engine = Engine;
                        MainForm.watchSong = Engine.RawFind(_Song);
                        _Song.Checked = true;
                        return true;
                        /* */
                    }
                }

            /**
             * Elsewhere, iterate through installed music services
             * and check if there is a matching track to play the song on
             * */
            foreach (IPlayEngine Engine in Program.MediaEngines.Values)
            {

                Song f = Engine.RawFind(_Song);

                if (f != null)
                {
                    MainForm.Engine = Engine;
                    _Song.Checked = true;
                    MainForm.watchSong = f;
                    return true;
                }


                /*  currentTrack = f;

                  currentPlayer = Engine;
                  Engine.Load((currentTrack.Path));
                  currentTrack = _Song;
                  Engine.Play();
*/


            }
            return false;
        }
        public static void ShowMessage(String MSG)
        {
        }
		public static string playQuery="";
		public static Queue<Song> playlist = new Queue<Song>();
		public static string currentQuery="";
		public static bool alternating=false;
		public static Song currentTrack;
		public void Colorize(){
			geckoWebBrowser1.Navigate("file://"+GetAppPath()+"/paged/top.html");
			geckoWebBrowser2.Navigate("file://"+GetAppPath()+"/paged/bottom.html");
			if(Sidebar)
			geckoWebBrowser3.Navigate("file://"+GetAppPath()+"/paged/left.html");
			foreach(UserControl i in Views.Values){
                if (i.GetType() == typeof(Settings))
                {
                    continue;
                }
				i.ResetBackColor();
				i.ResetForeColor();
				UpdateControls(i);
				if(i.GetType() == typeof(Library)){
					Library D = (Library)i;
					//D.Import();
				}
			}
			
			foreach(Control i in this.Controls){
               
                if (i.Tag == "%PERSISTANT")
                    continue;
                if (i.GetType() == typeof(Settings))
                {  
                    continue;
                }
				if(i.GetType() == typeof(Settings))
				{
					continue;
				}
				if(i.GetType() == typeof(PictureBox))
				{
					continue;
				}
				if(i.GetType() == typeof(CPlaylistView))
				{
					i.BackColor = MainForm.PlaylistBackground();
					i.ForeColor=MainForm.PlaylistForeColor();
				}
				i.BackColor = i.BackColor;
				i.ResetBackColor();
				i.ResetForeColor();
				if(i.GetType() == typeof(CListView) && i.GetType() != typeof(CPlaylistView))
				{
                    if (i.Tag == "%LIGHTER")
                    {
                        i.BackColor = MainForm.Dark ? MainForm.FadeColor(0.080f, MainForm.ListBackground()) : MainForm.FadeColor(0.08f, MainForm.ListBackground());
                    }
					CListView C = (CListView)i;
					foreach(ListViewItem Ds in C.Items)
					{
						if(Ds.Tag != currentTrack)
						{
							Ds.BackColor = i.BackColor;
							
							if((Ds.Index % 2) == 1){
								i.BackColor = MainForm.AlternateRowColor();
							}
							
						
						}
					}
				}
				if(i.GetType() == typeof(CTreeView))
				{
					TreeView D = (TreeView)i;
					D.BackColor = MainForm.ListBackground();
					D.ForeColor=MainForm.ListForeground();
				}
				if(i.GetType() == typeof(SplitContainer))
				{
					i.BackColor = MainForm.ToolbarBackground();
				}
				UpdateControls(i);
				
			}
			
		}
		
		public static void NextSong()
		{
			Song D = playlist.Dequeue();
			CListView X = Program.Host.cListView1;
			for(int i=0; i < X.Items.Count; i++)
			{
				if(X.Items[i].BackColor != PlaylistBackground())
				{
					X.Items[i].BackColor = PlaylistBackground();
					X.Items[i+1].BackColor = Color.Black;
					X.Items[i+1].ForeColor=Color.LightGreen;
				}
			}
			PlayItem(D.Path);
		}
		public static Color customToolFColor;
		public static Color customToolColor;
		public static Color customAlternatingColor;
		public static Color AlternateRowColor()
		{
			if(CustomColors)
			{
				return customAlternatingColor;
			}
			
			if(alternating)
			{
               if(!Dark)
                    {
                        return MainForm.FadeColor(-0.025f,MainForm.ListBackground());
                   }
                    else
                    {
                        return MainForm.FadeColor(-0.085f, MainForm.ListBackground());
                    }
            }
			else{
				return MainForm.ListBackground();
			}
		}
		public static bool PlaylistColors=true;
		public static Color PlaylistForeColor()
		{
			
			if(PlaylistColors)
			{
				return Color.White;
			}
			else
			{
				return ListForeground();
			}
		}
		public static Color PlaylistBackground()
		{
			
			if(PlaylistColors)
			{
				if(!Dark)
				{
					return MainForm.FadeColor(-0.30f,PrimaryColor);
				}
				else
				{
					return MainForm.FadeColor(-0.35f,PrimaryColor);
				}
			}
			else
			{
				return MainForm.ListBackground();
			}
			
		}
		public static void UpdateControls(Control D)
		{
			
			foreach(Control i in D.Controls)
            {
                if (i.Tag == "%PERSISTANT")
                    continue;
                if (i.GetType() == typeof(Settings))
                {
                    continue;
                }
				if(i.GetType() == typeof(CListView) && i.GetType() != typeof(CPlaylistView))
				{
                    if (i.Tag == "%LIGHTER")
                    {
                      i.BackColor = MainForm.Dark ? MainForm.FadeColor(0.080f, MainForm.ListBackground()) : MainForm.FadeColor(0.08f, MainForm.ListBackground());
                    }
					CListView C = (CListView)i;
					foreach(ListViewItem Ds in C.Items)
					{
						if(Ds.Tag != currentTrack)
						{
							Ds.BackColor = i.BackColor;
							
							if((Ds.Index % 2) == 1){
								i.BackColor = MainForm.AlternateRowColor();
							}
							
						
						}
					}
				}
				if(i.GetType() == typeof(CTreeView))
				{
					TreeView Ds = (TreeView)i;
					i.ResetForeColor();
					
					if(i.GetType() != typeof(CPlaylistView))
					{
						foreach(TreeNode Dss in Ds.Nodes)
						{
							RefreshItem(Dss);
						}
					}
				}
				
				if(i.GetType() == typeof(SplitContainer))
				{
					i.BackColor = MainForm.ToolbarBackground();
					i.ForeColor=MainForm.customToolFColor;
				}
				UpdateControls(i);
				
				if( i.GetType() == typeof(MediaChrome.Settings))
					continue;
				else
					i.ResetBackColor();
				i.ResetForeColor();
				
				if(i.GetType() == typeof(Settings))
				{
					continue;
				}
				if(i.GetType() == typeof(PictureBox))
				{
					continue;
				}
					if(i.GetType() == typeof(CPlaylistView))
				{
					i.ResetBackColor();
					i.BackColor = MainForm.PlaylistBackground();
					i.ForeColor=MainForm.PlaylistForeColor();
					foreach(ListViewItem Item in ((CPlaylistView)i).Items)
					{
						Item.BackColor=i.BackColor;
					}
					i.Refresh();
					
				} 
				
			}
			
		}
		public static void RefreshItem(TreeNode Node){
			Node.ForeColor=MainForm.ListForeground();
			foreach(TreeNode F in Node.Nodes)
			{
				RefreshItem(F);
			}
		}
		public static void Colorize(MainForm d,Color C){
			MainForm.PrimaryColor=C;
			d.Colorize();
			
			
			
		}
		public static IPlayEngine D {
			get {return currentPlayer;}
		}
		
		public static  SQLiteConnection MakeConnection(){
			SQLiteConnection D = new SQLiteConnection("Data Source=db.sqlite");
			return D;
		}
		public static int Fade(float amount,int value){
			float c = 0;
			if(amount<0){
				c=value+((value)*amount);
			}
			if(amount>0){
				c=value+((255-value)*amount);
			}
				
			return (int)Math.Round(c);
		}
		public static Color FadeColor(float amount,Color D){
			int R = Fade(amount,D.R);
			int G = Fade(amount,D.G);
			int B = Fade(amount,D.B);
			return Color.FromArgb(R,G,B);
		}
		public UserControl Playboard
		{
			get
			{
				return this.nowPlaying;
			}
		}
		public static String DownloadDir = "C:\\Downloads";
		public void SaveSettings(){
			using(StreamWriter SW = new StreamWriter("settings")){
				SW.WriteLine(ColorTranslator.ToHtml(PrimaryColor));
				SW.WriteLine(DownloadDir);
				SW.WriteLine(Dark.ToString());
				SW.WriteLine(alternating.ToString());
				SW.WriteLine(FadeOddEntries.ToString());
				SW.WriteLine(MainForm.CustomColors.ToString());
				if(MainForm.CustomColors)
				{
					SW.WriteLine(ColorTranslator.ToHtml(customBgColor));
					SW.WriteLine(ColorTranslator.ToHtml(customFgColor));
					SW.WriteLine(ColorTranslator.ToHtml(customAlternatingColor));
					SW.WriteLine(ColorTranslator.ToHtml(customToolColor));
					SW.WriteLine(ColorTranslator.ToHtml(customHColor));
					SW.WriteLine(ColorTranslator.ToHtml(customToolFColor));
				}
				SW.WriteLine(Sidebar.ToString());
				SW.Close();
			}
		}
		public static Color customBgColor=Color.FromArgb(233,233,255);
		public static Color customFgColor=Color.FromArgb(233,233,255);
		public static Color customHColor=Color.FromArgb(0,211,255);
		public void ReadSettings(){
			if(!File.Exists("settings")){
				using(StreamWriter SW = new StreamWriter("settings")){
					SW.WriteLine("#ccffcc");
					SW.WriteLine("C:\\Downloads");
					SW.WriteLine("true");
					SW.WriteLine("true");
					SW.WriteLine("true");
					SW.WriteLine("true");
					SW.WriteLine("false");
					SW.Close();
				}
			}
			using(StreamReader SR = new StreamReader("settings")){
				MainForm.PrimaryColor = ColorTranslator.FromHtml(SR.ReadLine());
			
				DownloadDir = SR.ReadLine();
				Dark =bool.Parse(SR.ReadLine());
				alternating=bool.Parse(SR.ReadLine());
				FadeOddEntries=bool.Parse(SR.ReadLine());
				CustomColors=bool.Parse(SR.ReadLine());
				if(CustomColors)
				{
					customBgColor = ColorTranslator.FromHtml(SR.ReadLine());
					customFgColor = ColorTranslator.FromHtml(SR.ReadLine());
					customAlternatingColor = ColorTranslator.FromHtml(SR.ReadLine());
					customToolColor=ColorTranslator.FromHtml(SR.ReadLine());
					customHColor=ColorTranslator.FromHtml(SR.ReadLine());
					customToolFColor=ColorTranslator.FromHtml(SR.ReadLine());
				}
				Sidebar = bool.Parse(SR.ReadLine());
				
			}
			if(!Directory.Exists(Environment.SpecialFolder.MyMusic+"\\Downloads\\")){
				Directory.CreateDirectory(Environment.SpecialFolder.MyMusic+"\\Downloads\\");
			}
		}
		public static String MediaDirectory = Environment.SpecialFolder.MyMusic+"\\Downloads\\";
		public Library Library {get;set;}
		public void ActivateView(String View) 
		{
			
			foreach(KeyValuePair<String, UserControl> i in Views){
				i.Value.Hide();
			}
			Views[View].Show();
			Views[View].Dock = DockStyle.None;
			Views[View].Dock = DockStyle.Fill;
			CurrentView=Views[View];
			CurrentView.BringToFront();
			CurrentViewName = View;
		}
		public static bool Dark=false;
		public static Color ListBackground(){
			if(CustomColors)
			{
				return customBgColor;
			}
			if(Dark){
				return MainForm.FadeColor(-0.5f,MainForm.PrimaryColor);
				
			}else{
				return MainForm.FadeColor(0.8f,MainForm.PrimaryColor);
				
			}
			}
		
		public static Color ListForeground(){
			if(CustomColors)
			{
				return customFgColor;
			}
			if(Dark){
				return Color.White;
				
			}else{
				return MainForm.FadeColor(-0.4f,MainForm.PrimaryColor);
				
			}
		}
		public NowPlaying nowPlaying;
		public Settings Settings;
		public string CurrentViewName {get;set;}
		public static Color PrimaryColor=ColorTranslator.FromHtml("#ccffcc");
		public static Dictionary<String,String> TrackServiceTokens = new Dictionary<String,String>();
		public static Dictionary<String, String> AlbumServiceTokens = new Dictionary<String, String>();
		public MainForm()
		{
			SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
			Skybound.Gecko.Xpcom.Initialize("xulrunner");
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			/// <summary>
			/// Read settings
			/// </summary>
			/// <returns></returns>
		
		
			/// Define views
            Items = new Queue<ListViewItem>();
			Views = new Dictionary<String,UserControl>();
			DM = new DownloadManager();
			Store = new ucStore(this);
			nowPlaying = new MediaChrome.NowPlaying();
			Library = new Library();
				Settings = new Settings(this);
			this.panel1.Controls.Add(Settings);
			this.panel1.Controls.Add(DM);
			this.panel1.Controls.Add(Store);
			this.panel1.Controls.Add(Library);
			this.panel1.Controls.Add(nowPlaying);
			/// <summary>
			///  Add the panes to the player
			/// </summary>
			
			
			Store.Manager=DM;
			Views.Add("NowPlaying",nowPlaying);
			Views.Add("Downloads",DM);
			Views.Add("Settings",Settings);
			Views.Add("Store",Store);
			Views.Add("Library",Library);
            Library.Host = this;
			nowPlaying.Show();
		
			ActivateView("Library");
			// This is a service token for the swedish service 'CDON.com'
			TrackServiceTokens.Add("dle.247.base.com","tomcat");
			AlbumServiceTokens.Add("downloads.cdon.com","getDlFile.phtml");
            this.geckoWebBrowser2.Navigating += new Skybound.Gecko.GeckoNavigatingEventHandler(geckoWebBrowser2_Navigating);
			/// <summary>
			/// Set built-in media engines
			/// </summary>
			/// <returns></returns>
			
			
			//
			// TODO: Add additional engine loading here
			//
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
            ReadSettings();
		}

        void geckoWebBrowser2_Navigating(object sender, Skybound.Gecko.GeckoNavigatingEventArgs e)
        {
            Skybound.Gecko.GeckoWebBrowser geckoWebBrowser1 = (Skybound.Gecko.GeckoWebBrowser)sender;
            /*if (e.Uri.ToString().StartsWith("http://go.go/"))
            {
                ActivateView(e.Uri.ToString().Replace("http://go.go/", ""));
                e.Cancel = true;
            }*/
            string newLocation = e.Uri.ToString().Replace("file:///", "").Replace(".html", ".htm");
            if (e.Uri.ToString().Contains(".html"))
            {

                string URL = e.Uri.ToString();
                using (StreamReader SR = new StreamReader(URL.Replace("file:///", "")))
                {
                    String D = SR.ReadToEnd();
                    String PColor = MainForm.CustomColors ? ColorTranslator.ToHtml(customHColor) : ColorTranslator.ToHtml(PrimaryColor);
                    D = D.Replace("${Color}", PColor);
                    D = D.Replace("${C}", CurrentViewName);
                    using (StreamWriter SW = new StreamWriter(newLocation))
                    {
                        SW.Write(D);
                        SW.Close(   );
                    }
                    SR.Close();
                }

                geckoWebBrowser1.Navigate(("file:///" + newLocation));
                e.Cancel = true;
            }
            String F = e.Uri.ToString();
            if(F.StartsWith("http://go.go/?seek="))
            {
                try
                {
                    MainForm.currentPlayer.Seek(double.Parse(F.Replace("http://go.go/?seek=", "")) / 100 * MainForm.currentPlayer.Position);
                }
                catch
                {
                }
                e.Cancel = true;
            }
        }
		public string[] GetVersion(String Name)
		{
			String v = Name.Substring(Name.IndexOf("(")+1,Name.IndexOf(")")-Name.IndexOf("("));
			String NewName = Name.Replace("("+Name+")","");
			return new String[]{v,NewName};
		}
		public static bool CustomColors=false;
		public static Color ToolbarBackground(){
			return MainForm.FadeColor(-0.2f,MainForm.PrimaryColor);
		}
		public static void Import(string RootDir){
			
			DirectoryInfo DI = new DirectoryInfo(RootDir);
				
			FileInfo[] D = DI.GetFiles("*.mp3");
			foreach(FileInfo X in D){
				try{
					id3.MP3 Dw = new id3.MP3(X.DirectoryName,X.Name);
					id3.FileCommands.readMP3Tag(ref Dw);
					SQLiteConnection CP = MainForm.MakeConnection();
					CP.Open();
					String P = "INSERT INTO song(name,artist,album,path) VALUES (\""+Dw.id3Title.Replace("\0","")+"\" ,'"+Dw.id3Artist.Replace("\0","")+"','"+Dw.id3Album.Replace("\0","")+"','mp3:"+X.FullName+"')";
					SQLiteCommand C = new SQLiteCommand(P,CP);
					C.ExecuteNonQuery();
					
					CP.Close();
				}catch(Exception e){
					
				}
				
			}
			DirectoryInfo[] Directories = DI.GetDirectories();
			foreach(DirectoryInfo R in Directories){
				Import(R.FullName);
			}
			
		}
		public static bool FadeOddEntries=false;
		public static Color OddEntry()
		{
			if(Dark)
			{
				return Color.LightGray;
			}
			else
			{
				return Color.FromArgb(130,130,130);
			}
		}
		public UserControl CurrentView {get;set;}
		public Dictionary<String,UserControl> Views {get;set;}
		DownloadManager DM {get;set;}
		ucStore Store {get;set;}
		
		public static String GetAppPath(){
			string D = Application.ExecutablePath.Replace(Application.ExecutablePath.Split('\\')[Application.ExecutablePath.Split('\\').Length-1],"");
			return D;
		}
		void MainFormLoad(object sender, EventArgs e)
		{
			
			geckoWebBrowser1.Navigate("file://"+GetAppPath()+"/paged/top.html");
			geckoWebBrowser2.Navigate("file://"+GetAppPath()+"/paged/bottom.html");
			if(Sidebar)
				geckoWebBrowser3.Navigate("file://"+GetAppPath()+"/paged/left.html");
            this.Colorize();
		}
		
		void WebBrowser1Navigating(object sender, WebBrowserNavigatingEventArgs e)
		{
			
		}
		private bool sidebar;
        public static IPlayEngine Engine;
		public bool Sidebar
		{
			get
			{
				return sidebar;
			}
			set
			{
				sidebar=value;
				if(sidebar)
				{
					this.geckoWebBrowser1.Height=10;
					this.geckoWebBrowser3.Visible=true;
					
				}
				else
				{
					this.geckoWebBrowser1.Height=72;
					this.geckoWebBrowser3.Visible=false;
				}
				
			}
		}
		void GeckoWebBrowser1Navigating(object sender, Skybound.Gecko.GeckoNavigatingEventArgs e)
		{
			Skybound.Gecko.GeckoWebBrowser geckoWebBrowser1 = (Skybound.Gecko.GeckoWebBrowser)sender;
			if(e.Uri.ToString().StartsWith("http://go.go/")){
				ActivateView(e.Uri.ToString().Replace("http://go.go/",""));
				e.Cancel=true;
			}
			string newLocation = e.Uri.ToString().Replace("file:///","").Replace(".html",".htm");
				if(e.Uri.ToString().Contains(".html")){
			
				string URL = e.Uri.ToString();
				using(StreamReader SR = new StreamReader(URL.Replace("file:///",""))){
					String D = SR.ReadToEnd();
					String PColor = MainForm.CustomColors ? ColorTranslator.ToHtml(customHColor) : ColorTranslator.ToHtml(PrimaryColor);
					D=D.Replace("${Color}",PColor);
					D=D.Replace("${C}",CurrentViewName);
					using(StreamWriter SW = new StreamWriter(newLocation))
					{
						SW.Write(D);
						SW.Close();
					}
					SR.Close();
				}
				
				geckoWebBrowser1.Navigate(("file:///"+newLocation));
				e.Cancel=true;
			}
		}
		
		void Panel1Paint(object sender, PaintEventArgs e)
		{
			
		}
		
		void CListView1DragEnter(object sender, DragEventArgs e)
		{
			e.Effect = DragDropEffects.Copy;
		}
		
		void CListView1DragDrop(object sender, DragEventArgs e)
		{
			
		}
		protected override void NotifyInvalidate(Rectangle invalidatedArea)
		{
			
		}
		void MainFormPaint(object sender, PaintEventArgs e)
		{
			
		}
		public void ServicePattern(String Service)
		{
			
		}
		void CListView1MouseDoubleClick(object sender, MouseEventArgs e)
		{
			 
		}
		
		void GeckoWebBrowser2Click(object sender, EventArgs e)
		{
			
		}
		
		void CListView1DoubleClick(object sender, EventArgs e)
		{
            if (cListView1.SelectedItems.Count < 1)
                return;
			foreach(ListViewItem D in cListView1.Items)
			{
				if(D.ForeColor == Color.LightGreen)
				{
					D.BackColor=PlaylistBackground();
					D.ForeColor=PlaylistForeColor();
                    D.ImageIndex = 0;
				}
			}

            cListView1.SelectedItems[0].ImageIndex = 1;
			Song _Song = (Song)cListView1.SelectedItems[0].Tag;
			
			cListView1.SelectedItems[0].BackColor=Color.Black;
			cListView1.SelectedItems[0].ForeColor=Color.LightGreen;
			
			PlayItem(_Song.Path);
			currentTrack=_Song;
			
		}

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (currentPlayer != null)
                {
                    pictureBox1.BackgroundImage = Bitmap.FromFile(currentPlayer.Image);
                    lArtist.Text = currentPlayer.Status;

                }
            } 
            catch
            {
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
       /*     if(Items != null)
            {
                
                while(Items.Count>0)
                {
                    ListViewItem ds = Items.Dequeue();
                    ds.ImageIndex = 4;

                    ds.ForeColor = (MainForm.Dark) ? Color.FromArgb(255,100,0,0) : Color.DarkRed;
                }
            }
            Thread d =     new Thread(CheckSongs);
            d.Start();*/
        }
        public void CheckSongs()
        {
            /*if (Items == null)
                return;
            foreach (ListViewItem d in this.cListView1.Items)
            {
                if(!Song_Exists((Song)d.Tag))
                {
                    Items.Enqueue(d);
                }
            }*/
        }
        public Queue<ListViewItem> Items;
	}
    
    public static class UriHelper
    {
        public static Dictionary<String, String> Querystrings(Uri d)
        {
            Dictionary<String, String> QueryList = new Dictionary<string, string>();

            String[] Queries = d.Query.Split('&');
            if (d.Query == "")
                return new Dictionary<string, string>();
            foreach (String query in Queries)
            {
                try
                {
                    string[] pair = query.Split('=');
                    QueryList.Add(pair[0].Replace("?", ""), pair[1]);
                }
                catch
                {
                }
            }
            return QueryList;
        }
    }
}
 