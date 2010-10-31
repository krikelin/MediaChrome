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
using System.Windows.Forms;

using MultiMedia;

namespace CDON
{
	
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public static Song ItemToSong(ListViewItem I)
		{
			Song D = new Song();
			D.Artist=I.SubItems[1].Text;
			D.Title=I.SubItems[0].Text;
			D.Path=(String)I.Tag;
			D.Album=I.SubItems[2].Text;
			D.Store=I.SubItems[3].Text;
			D.Engine=I.SubItems[4].Text;
			
			return D;
		}
		public static ListViewItem SongToItem(Song I)
		{
			
			ListViewItem D = new ListViewItem(I.Title);
			D.SubItems.Add(I.Artist);
			D.SubItems.Add(I.Album);
			D.SubItems.Add(I.Store);
			D.SubItems.Add(I.Engine);
			D.Tag=(object)I.Path;
			return D;
		}
		public void CreateCurrentPlaylist()
		{
			
			cListView1.Items.Clear();
			foreach(Song i in playlist)
			{
				ListViewItem D = SongToItem(i);
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
		public static void PlayItem(String Query){
			
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
			
		
			IPlayEngine D = null;
			if(Query.StartsWith("music:"))
			{
				Song _Song = new Song();
				Uri d = new System.Uri(Query);
				_Song.Title=d.Segments[3];
				_Song.Artist=d.Segments[1];
				_Song.Album=d.Segments[2];
				
				foreach(IPlayEngine Engine in Program.MediaEngines.Values)
				{
					if(!Engine.RawFind(_Song))
					{
						D=Engine;
						break;
					}
					
				}
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
		}
		
		public static string playQuery="";
		public static Queue<Song> playlist = new Queue<Song>();
		public static string currentQuery="";
		public static bool alternating=false;
		public static string currentTrack="";
		public void Colorize(){
			geckoWebBrowser1.Navigate("file://"+GetAppPath()+"/paged/top.html");
			geckoWebBrowser2.Navigate("file://"+GetAppPath()+"/paged/bottom.html");
			foreach(UserControl i in Views.Values){
				i.ResetBackColor();
				i.ResetForeColor();
				UpdateControls(i);
				if(i.GetType() == typeof(Library)){
					Library D = (Library)i;
					D.Import();
				}
			}
			foreach(Control i in this.Controls){
				i.BackColor = i.BackColor;
				i.ResetBackColor();
				i.ResetForeColor();
				if(i.GetType() == typeof(CListView))
				{
					CListView C = (CListView)i;
					foreach(ListViewItem D in C.Items)
					{
						D.BackColor = i.BackColor;
						if((D.Index % 2) == 1){
							i.BackColor = MainForm.AlternateRowColor();
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
			ListView X = Program.Host.cListView1;
			for(int i=0; i < X.Items.Count; i++)
			{
				if(X.Items[i].BackColor != PlaylistBackground())
				{
					X.Items[i].BackColor = PlaylistBackground();
					X.Items[i+1].BackColor = Color.Black;
					X.Items[i+1].ForeColor=Color.LightGreen;
				}
			}
			PlayItem((string)D.Path);
		}
		public static Color AlternateRowColor()
		{
			if(alternating)
			{
				if(!Dark)
				{
					return MainForm.FadeColor(-0.025f,MainForm.ListBackground());
				}
				else
				{
					return MainForm.FadeColor(+0.05f,MainForm.ListBackground());
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
			foreach(Control i in D.Controls){
				i.ResetBackColor();
				i.ResetForeColor();
				UpdateControls(i);
				if(i.GetType() == typeof(CListView))
				{
					CListView C = (CListView)i;
					foreach(ListViewItem Ds in C.Items)
					{
						Ds.BackColor = i.BackColor;
						if((Ds.Index % 2) == 1){
							i.BackColor = MainForm.AlternateRowColor();
						}
					}
				}
				if(i.GetType() == typeof(CTreeView))
				{
					TreeView Ds = (TreeView)i;
					i.ResetForeColor();
					D.BackColor = MainForm.ListBackground();
					D.ForeColor=MainForm.ListForeground();
					foreach(TreeNode Dss in Ds.Nodes)
					{
						RefreshItem(Dss);
					}
					
				}
				if(i.GetType() == typeof(SplitContainer))
				{
					i.BackColor = MainForm.ToolbarBackground();
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
					customHColor = ColorTranslator.FromHtml(SR.ReadLine());
					
				}
				
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
			if(Dark){
				return MainForm.FadeColor(-0.5f,MainForm.PrimaryColor);
				
			}else{
				return MainForm.FadeColor(0.8f,MainForm.PrimaryColor);
				
			}
			}
		public static Color ListForeground(){
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
			ReadSettings();
		
			/// Define views
		
			Views = new Dictionary<String,UserControl>();
			DM = new DownloadManager();
			Store = new ucStore(this);
			nowPlaying = new MultiMedia.NowPlaying();
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
			nowPlaying.Show();
		
			ActivateView("Library");
			// This is a service token for the swedish service 'CDON.com'
			TrackServiceTokens.Add("dle.247.base.com","tomcat");
			AlbumServiceTokens.Add("downloads.cdon.com","getDlFile.phtml");
			
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
		}
		
		void WebBrowser1Navigating(object sender, WebBrowserNavigatingEventArgs e)
		{
			
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
					D=D.Replace("${Color}",ColorTranslator.ToHtml(PrimaryColor));
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
	}
}
 