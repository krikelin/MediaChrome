/*
 * Created by SharpDevelop.
 * User: Alex
 * Date: 2010-10-27
 * Time: 22:41
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
 using System.Threading;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MediaChrome.Views;
using Skybound.Gecko;

namespace MediaChrome
{
	/// <summary>
	/// Description of Library.
	/// </summary>
	/// 
	
	public partial class Library : UserControl
	{
        public Artist currentInfoView;
		public static string QUERY = "SELECT DISTINCT nam e,artist,album,composer,path,store,feature,version_,coartist FROM song ";
		Dictionary<String,Artist> infoViews ;
		public Library()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			this.geckoWebBrowser1.Navigating+= new GeckoNavigatingEventHandler(Library_Navigating);
			this.VisibleChanged+= new EventHandler(Library_VisibleChanged);
		//	this.cTreeView1.DragEnter+= new DragEventHandler(Library_DragEnter);
			//this.cTreeView1.DragDrop+= new DragEventHandler(TreeView_DragDrop);
			this.splitContainer1.BackColor = MainForm.ToolbarBackground();
			this.splitContainer1.DragDrop+= new DragEventHandler(Library_DragDrop);
			this.cListView1.ItemDrag+=new ItemDragEventHandler(Library_ItemDrag);
	//		this.cTreeView1.AfterSelect+= new TreeViewEventHandler(CTreeView1AfterSelect);
			SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
			this.cListView1.ColumnClick+= new ColumnClickEventHandler(Library_ColumnClick);
			this.cListView1.SelectedIndexChanged+= new EventHandler(Library_SelectedIndexChanged);
		    infoViews=new Dictionary<String,Artist>();
			this.cListView1.Columns.Add(new ColumnHeader(){ Text ="Title",Width=160});
            this.cListView1.Columns.Add(new ColumnHeader() { Text = "Version", Width = 60 });
            this.cListView1.Columns.Add(new ColumnHeader() { Text = "Artist", Width = 160 });
            this.cListView1.Columns.Add(new ColumnHeader() { Text = "Album", Width = 160 });
            this.cListView1.Columns.Add(new ColumnHeader() { Text = "Popularity", Width = 160 });
            this.cListView1.Columns.Add(new ColumnHeader() { Text = "Featuring", Width = 160 });
            this.cListView1.Columns.Add(new ColumnHeader() { Text = "Store", Width = 160 });
            this.cListView2.Columns.Add(new ColumnHeader() { Text = "Menu", Width = 160 });
            cListView1.DoubleClick+=new EventHandler(cListView1_DoubleClick);
            this.cListView2.AddItem("Home");
            this.cListView2.AlternateRows = false;
            this.cListView2.AddItem("Radio");
            cListView1.UniDraw+=new CListView.DrawItemX(cListView1_UniDraw);
            this.cListView2.AddItem("Search");

            cListView1.EngineImages = new Dictionary<string, Image>();
            foreach (IPlayEngine Engine in Program.MediaEngines.Values)
            {
                cListView1.EngineImages.Add(Engine.Namespace, Bitmap.FromFile(Engine.Image));
            }
            cListView1.ScrollEnded += new EventHandler(cListView1_ScrollEnded);
		}

        void cListView1_ScrollEnded(object sender, EventArgs e)
        {
            if (cListView1.SelectedIndices.Count > 0)
            {
                if (cListView1.SelectedIndices[0] >= cListView1.Items.Count - 1)
                {
                    rowsAppended = 0;
                    while (Result.Count > 0 && rowsAppended < this.MAX_ITEMS_AT_START)
                    {

                        Song D = Result.Dequeue();
                        ListViewItem Item = cListView1.AddItem(MainForm.SongToItem(D));

                        rowsAppended++;
                    }
                }
            }
        }

		void Library_SelectedIndexChanged(object sender, EventArgs e)
		{
			
		}
		
		void Library_ColumnClick(object sender, ColumnClickEventArgs e)
		{
			
		}
		public  Dictionary<String,String> Substitutions = new Dictionary<String, String>();
		void Library_Navigating(object sender, GeckoNavigatingEventArgs e)
		{
			Skybound.Gecko.GeckoWebBrowser geckoWebBrowser1 = (Skybound.Gecko.GeckoWebBrowser)sender;
			
			string newLocation = e.Uri.ToString().Replace("file:///","").Replace(".html",".htm");
			if(e.Uri.ToString().Contains(".html"))
			{
		
				string URL = e.Uri.ToString();
				using(StreamReader SR = new StreamReader(URL.Replace("file:///",""))){
					String D = SR.ReadToEnd();
					D=D.Replace("${BackColor}",ColorTranslator.ToHtml(MainForm.ListBackground()));
					D=D.Replace("${ForeColor}",ColorTranslator.ToHtml(MainForm.ListForeground()));
					foreach(KeyValuePair<String, String> Sub in Substitutions)
					{
						D=D.Replace("${"+Sub.Key+"}",Sub.Value);
					}
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

		void Library_ItemDrag(object sender, ItemDragEventArgs e)
		{
			if(MouseButtons == MouseButtons.Left)
			{
				if(cListView1.SelectedItems.Count>0)
				{
					dragItems = cListView1.SelectedItems;
					cListView1.DoDragDrop(dragItems, DragDropEffects.Copy);
				}
			}
		}

		void TreeView_DragDrop(object sender, DragEventArgs e)
		{
			if(dragItems!=null)
			{
				SQLiteConnection Conn = MainForm.MakeConnection();
				Conn.Open();
				foreach(ListViewItem Item in dragItems)
				{
					Song _Song = (MediaChrome.Song)Item.Tag;
					 String Query = (string)((MediaChrome.Song)Item.Tag).Path;
					
					
					SQLiteCommand Command = new SQLiteCommand("SELECT count(*) FROM song WHERE path='"+Query+"'",Conn);
					SQLiteDataReader DR = Command.ExecuteReader();   
					DR.Read();
					if(DR.GetInt32(0)==0)
					{
						Query = "INSERT INTO song(name,artist,album,path,store,engine) VALUES(\""+Item.Text+"\",\""+Item.SubItems[1].Text+"\",\""+Item.SubItems[2].Text+"\",\""+Query+"\",\""+Item.SubItems[3].Text+"\",\""+Item.SubItems[4].Text+"\")";
						SQLiteCommand Comm = new SQLiteCommand(Query,Conn);
						Comm.ExecuteNonQuery();
					}
					try
					{
						
					
				//		TreeNode x = cTreeView1.Nodes["Library"].Nodes["Artists"].Nodes["_"+Item.Text+""].Nodes[_Song.Title];
					}
					catch
					{
						try
						{
						//	TreeNode x = cTreeView1.Nodes["Library"].Nodes["Artists"].Nodes["_"+Item.Text+""].Nodes.Add(_Song.Title);
						}
						catch
						{
						//	TreeNode x = cTreeView1.Nodes["Library"].Nodes["Artists"].Nodes.Add(""+_Song.Artist+"");
							/*x.Name = "_"+_Song.Artist;
							
							TreeNode _Album = x.Nodes.Add(_Song.Album);
							_Album.Tag=(Object)QUERY+" WHERE album='"+_Album.Text+"'";
							x.Tag=(Object)QUERY+" WHERE artist='"+x.Text+"'";*/
						}
					}
				}
				Conn.Close();
			}
			
		}

		void Library_DragDrop(object sender, DragEventArgs e)
		{
			
		}
		
		void Library_DragEnter(object sender, DragEventArgs e)
		{
			if(dragItems!=null)
			{
				e.Effect = DragDropEffects.Copy;
				
			}
		}

		void Library_VisibleChanged(object sender, EventArgs e)
		{
			foreach(ColumnHeader I in cListView1.Columns){
				I.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
				
			}
			
		}
		
		void UcToolbar1Load(object sender, EventArgs e)
		{
			
		}
		public static Song GetSongFromQury(SQLiteDataReader D)
		{
			
			Song _Song = new Song();
			_Song.Title=(String)D["name"];
			_Song.Artist = (String)D["artist"];
			_Song.Album = (String)D["album"];
			_Song.Composer =(String)D["composer"];
			_Song.Path =(String)D["path"];
			_Song.Store = (String)D["store"];
			_Song.Feature = (String)D["feature"];
			_Song.Version = (String)D["version_"];
			_Song.Contributing = (String)D["coartist"];
				
				
		
			return _Song;
			
		}
		public static void CleanMusicList(ref CListView D)
		{
			List<String> Tracks = new List<string>();
			List<ListViewItem> itemsToRemove = new List<ListViewItem>();
			foreach(ListViewItem X in D.Items)
			{
				Song _Song = MainForm.ItemToSong(X);
				if(Tracks.LastIndexOf(_Song.Title.ToLower()+" - "+_Song.Artist.ToLower())>-1)
				{
					itemsToRemove.Add(X);
				}
				else
				{
					Tracks.Add(_Song.Title.ToLower() + " - "+_Song.Artist.ToLower());
				}
			}
			foreach(ListViewItem R in itemsToRemove)
			{
				D.Items.Remove(R);
			}
		}
		public static void DefaultSortMusicView(ref ListView D)
		{
			
		}
		void LibraryVisibleChanged(object sender, EventArgs e)
		{
		
		}
        public void ListAttributeX(string Attrib, TreeNode Source, SQLiteConnection CS)
        {
            TreeNode TND = Source;
            TND.Nodes.Clear();
            SQLiteCommand GetArtists = new SQLiteCommand("SELECT DISTINCT " + Attrib + ", " + Attrib + " FROM song WHERE engine IN " + Program.KeyQuery<IPlayEngine>(Program.MediaEngines, ',') + "", CS);
            SQLiteDataReader SQLDR = GetArtists.ExecuteReader();
            while (SQLDR.Read())
            {
                try
                {
                    TreeNode F = TND.Nodes.Add(SQLDR.GetString(0) == "" ? "(Unknown)" : SQLDR.GetString(0));
                    F.Tag = (object)Attrib.ToLower() +":" + SQLDR["artist"];
                }
                catch
                {

                }
            }
        }
		public void ListAttribute(string Attrib,TreeNode Source,SQLiteConnection CS)
		{
			TreeNode TND = Source;
			TND.Nodes.Clear();
			SQLiteCommand GetArtists = new SQLiteCommand("SELECT DISTINCT "+Attrib+", "+Attrib+" FROM song WHERE engine IN "+Program.KeyQuery<IPlayEngine>(Program.MediaEngines,',')+"",CS);
			SQLiteDataReader SQLDR = GetArtists.ExecuteReader();
			while(SQLDR.Read())
			{
				try
				{
					TreeNode F = TND.Nodes.Add(SQLDR.GetString(0) == "" ? "(Unknown)" : SQLDR.GetString(0) );
					F.Tag = (object)QUERY+" WHERE engine IN "+Program.KeyQuery<IPlayEngine>(Program.MediaEngines,',')+" AND "+Attrib+"=\""+SQLDR.GetString(0)+"\"   ORDER BY artist,album,name ASC";
				}catch{
					
				}
			}
		}
		
		public void ListAttribute(string Attrib,TreeNode Source,SQLiteConnection CS,String AdditionalConditions)
		{
			TreeNode TND = Source;
			TND.Nodes.Clear();
			SQLiteCommand GetArtists = new SQLiteCommand("SELECT DISTINCT "+Attrib+", "+Attrib+" FROM song WHERE engine IN "+Program.KeyQuery<IPlayEngine>(Program.MediaEngines,',')+"",CS);
			SQLiteDataReader SQLDR = GetArtists.ExecuteReader();
			TND.Name=Attrib;
			while(SQLDR.Read()){
				try{
					TreeNode F = TND.Nodes.Add(SQLDR.GetString(0) == "" ? "(Unknown)" : SQLDR.GetString(0) );
					F.Tag = (object)QUERY+" WHERE engine IN "+Program.KeyQuery<IPlayEngine>(Program.MediaEngines,',')+" AND "+Attrib+"=\""+SQLDR.GetString(0)+"\"  "+AdditionalConditions+"  ORDER BY artist,album,name ASC";
					F.Name=SQLDR.GetString(0);
					/*
				 * try
					{
						SQLiteCommand D = new SQLiteCommand("SELECT DISTINCT name,artist,album,path,store,engine FROM song WHERE engine IN "+Program.KeyQuery<IPlayEngine>(Program.MediaEngines,',')+" AND "+Attrib+"=\""+SQLDR.GetString(0)+"\"  "+AdditionalConditions+" AND "+Attrib+"='"+F.Text+"' ORDER BY artist,album,name ASC",CS);
						SQLiteDataReader SQDR = D.ExecuteReader();
						if(SQDR.HasRows)
						{
							ListAttribute(Attrib,F,CS,AdditionalConditions+" AND "+Attrib+"='"+F.Text+"' ");
						}
					}
					catch
					{
						
					}*/
				}catch{
					
				}
			}
		}
		/// <summary>
		/// Boolean indicates if the search is complete
		/// </summary>
		bool findCompleted=false;
		/// <summary>
		/// Queue of newly found elements
		/// </summary>
		public System.Collections.Generic.Queue<Song> Result = new System.Collections.Generic.Queue<Song>();
		/// <summary>
		/// Timer checksi df findtracks is complete
		/// </summary>
		System.Windows.Forms.Timer tMr;
	
		String currentQuery="";
		public void FindTracks(string Query)
		{
			rowsAppended=0;
			Result.Clear();
			cListView1.Items.Clear();
			tMr = new System.Windows.Forms.Timer();
			tMr.Tick+= new EventHandler(tMr_Tick);
			tMr.Start();
			currentQuery=Query;
			System.Threading.Thread D = new System.Threading.Thread(FindTracksEx);
			D.Start();
			inSearch=true;
		}
		int rowsAppended=0;
		bool suai=false;
		bool inSearch=false;
		int MAX_ITEMS_AT_START=40;
		void tMr_Tick(object sender, EventArgs e)
		{
			if(findCompleted)
			{
				
				if(suai)
				{
					foreach(ColumnHeader I in cListView1.Columns){
						I.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
						
					}
					tMr.Stop();
					suai=false;
			//		CleanMusicList(ref cListView1);
				}
				
				
			}
			
			while(Result.Count>0&&rowsAppended < this.MAX_ITEMS_AT_START)
			{
				
				suai=true;
				Song D = Result.Dequeue();
				ListViewItem Item = cListView1.AddItem(MainForm.SongToItem(D));
				
				rowsAppended++;
			}
			
		}
		public void FindTracksEx()
		{
			String Query = currentQuery;
			foreach(IPlayEngine F in Program.MediaEngines.Values)
			{
				List<Song> D = F.Find(Query);
				foreach(Song Item in D)
				{
					Result.Enqueue(Item);
				}
			}
			findCompleted=true;
		}
		public void Import(){
			SQLiteConnection CS = MainForm.MakeConnection();
			CS.Open();
		//	cTreeView1.ForeColor = MainForm.ListForeground();
			//cListView1.Items.Clear();
			//TreeNode Lib = cTreeView1.Nodes.Add("Library");
		//	Lib.Tag=(Object)"Library";
			/*SQLiteCommand CSM = new SQLiteCommand("SELECT name,artist,album,path FROM song ORDER BY artist,album,name ASC",CS);
			SQLiteDataReader DR = CSM.ExecuteReader();
			while(DR.Read())
			{
				var item = cListView1.AddItem(DR.GetString(0));
				item.SubItems.Add(DR.GetString(1));
				item.SubItems.Add(DR.GetString(2));
		
				item.Tag = (object)DR.GetString(3);
			}*/
		//	Query("SELECT name,artist,album,path,store,engine FROM song ORDER BY artist,album,name ASC");
			
/*			ListAttribute("Artist",cTreeView1.Nodes["Library"].Nodes["Artists"],CS);
            
			foreach(TreeNode R in cTreeView1.Nodes["Library"].Nodes["Artists"].Nodes)
			{
				SQLiteCommand Dfs = new SQLiteCommand("SELECT DISTINCT album FROM song WHERE engine IN "+Program.KeyQuery<IPlayEngine>(Program.MediaEngines,',')+" AND artist=\""+R.Text+"\"",CS);
				SQLiteDataReader SQLRs = Dfs.ExecuteReader();
				int i=0;
				while(SQLRs.Read())
				{
					TreeNode Dn = R.Nodes.Add(SQLRs.GetString(0));
					Dn.Name=SQLRs.GetString(0);
					Dn.Tag = (object)QUERY+" WHERE engine IN "+Program.KeyQuery<IPlayEngine>(Program.MediaEngines,',')+" AND album=\""+Dn.Text+"\"";
					Dn.Name = "_"+R.Text+"_";
					i++;
				}
			}
			ListAttribute("Album",cTreeView1.Nodes["Library"].Nodes.Add("Albums"),CS);
			ListAttribute("genre",cTreeView1.Nodes["Library"].Nodes.Add("Genre"),CS);
			ListAttribute("store",cTreeView1.Nodes["Library"].Nodes.Add("Store"),CS);

			//ListAttribute("Purchased",cTreeView1.Nodes["Library"].Nodes["Purchased"],CS,"store","store");
		/*	SQLiteCommand Df = new SQLiteCommand("SELECT name,title FROM engine",CS);
			SQLiteDataReader SQLR = Df.ExecuteReader();
			while(SQLR.Read())
			{
				TreeNode Dn = cTreeView1.Nodes["Library"].Nodes.Add(SQLR.GetString(1));
				ImportConditional(" engine=\""+SQLR.GetString(0)+"\"",Dn,CS);
				
			}*/
           /* TreeNode Plsts = cTreeView1.Nodes["Library"].Nodes.Add("Playlists");

            foreach (IPlayEngine Engine in Program.MediaEngines.Values)
            {
                TreeNode Dff = Plsts.Nodes.Add(Engine.Title);
                List<MediaChrome.Views.Playlist> Playlists = Engine.Playlists;
                if (Playlists != null)
                {
                    foreach (Playlist Ds in Playlists)
                    {
                        TreeNode Playlist = Dff.Nodes.Add(Ds.Title + "(" + Engine.Title + ")");
                        Playlist.Tag = (Object)("playlist:" + Engine.Namespace+ ":" + Ds.ID);

                    }
                }
            }
			CS.Close();*/
		}
		public void ImportConditional(String Conditions,TreeNode Section,SQLiteConnection CS)
		{
			
			
				
			
			ListAttribute("artist",Section.Nodes.Add("Artist"),CS,Conditions);
			ListAttribute("album",Section.Nodes.Add("Album"),CS,Conditions);
			ListAttribute("genre",Section.Nodes.Add("Genre"),CS,Conditions);
			
			
		
		}
		public void TreeImport(){
		/*	cTreeView1.ForeColor = MainForm.ListForeground();
			cListView1.Items.Clear();
			cTreeView1.Nodes.Clear();
			TreeNode D = cTreeView1.Nodes.Add("Library");
			D.Name="Library";
			D.Tag = (Object)QUERY+" WHERE engine IN "+Program.KeyQuery<IPlayEngine>(Program.MediaEngines,',')+" ";
			TreeNode tArtists = D.Nodes.Add("Artists");
			tArtists.Name = "Artists";
			TreeNode tAlbums = D.Nodes.Add("Albums");
			tAlbums.Name = "Albums";
			SQLiteConnection CS = MainForm.MakeConnection();
			CS.Open();
			/*SQLiteCommand CSM = new SQLiteCommand("SELECT name,artist,album,path FROM song ORDER BY artist,album,name ASC",CS);
			SQLiteDataReader DR = CSM.ExecuteReader();
			while(DR.Read())
			{
				var item = cListView1.AddItem(DR.GetString(0));
				item.SubItems.Add(DR.GetString(1));
				item.SubItems.Add(DR.GetString(2));
		
				item.Tag = (object)DR.GetString(3);
			}*/
		//	Query("SELECT name,artist,album,path,store,engine FROM song ORDER BY artist,album,name ASC");
			
		/*	ListAttribute("Artist",cTreeView1.Nodes["Library"].Nodes["Artists"],CS);
			foreach(TreeNode R in cTreeView1.Nodes["Library"].Nodes["Artists"].Nodes)
			{
				SQLiteCommand Dfs = new SQLiteCommand("SELECT DISTINCT album FROM song WHERE engine IN "+Program.KeyQuery<IPlayEngine>(Program.MediaEngines,',')+" AND artist=\""+R.Text+"\"",CS);
				SQLiteDataReader SQLRs = Dfs.ExecuteReader();
				int i=0;
				while(SQLRs.Read())
				{
					TreeNode Dn = R.Nodes.Add(SQLRs.GetString(0));
				
					Dn.Tag = (object)QUERY+" FROM  song WHERE engine IN "+Program.KeyQuery<IPlayEngine>(Program.MediaEngines,',')+" AND album=\""+Dn.Text+"\"";
					Dn.Name = "_"+R.Text+"_";
					i++;
				}
			}
			ListAttribute("Album",cTreeView1.Nodes["Library"].Nodes["Albums"],CS);
			ListAttribute("genre",cTreeView1.Nodes["Library"].Nodes["Genres"],CS);
			ListAttribute("store",cTreeView1.Nodes["Library"].Nodes["Purchased"],CS);
			ListAttribute("engine",cTreeView1.Nodes["Library"].Nodes["Provider"],CS);
			//ListAttribute("Purchased",cTreeView1.Nodes["Library"].Nodes["Purchased"],CS,"store","store");
			SQLiteCommand Df = new SQLiteCommand("SELECT DISTINCT store FROM purchase",CS);
			SQLiteDataReader SQLR = Df.ExecuteReader();
           
			CS.Close();*/
		}

        public Playlist CurrentPlaylist {get;set;}
		
	
		public void Query(String Query){
			
			cListView1.Items.Clear();
			SQLiteConnection CS = MainForm.MakeConnection();
			CS.Open();
           
            if(Query.StartsWith("artist:"))
            {
               string Artist_ =  Query.Replace("artist:","");
                if(infoViews.ContainsKey(Artist_))
                {
                    currentInfoView = infoViews[Artist_];
                }
                else
                {
                    currentInfoView = new Artist();
                    infoViews.Add(Artist_,currentInfoView);

                    currentInfoView.Tag = (object)Artist_;
                    currentInfoView.Loaded += new EventHandler(currentInfoView_Loaded);
                    currentInfoView.LoadPage("http://mediachrome.krakelin.com/artist.php?q=" + Artist_);
                }
                this.cListView1.Hide();

                this.splitContainer1.Panel2.Controls.Add(currentInfoView);
                currentInfoView.BringToFront();
                currentInfoView.Show();
                currentInfoView.Dock = DockStyle.Fill;
                currentInfoView.ItemClicked += new Artist.ItemClick(currentInfoView_ItemClicked);
                return;
            }
            else
            {
                this.cListView1.Show();
                foreach (Artist d in infoViews.Values)
                {
                    d.Hide();
                }
                if (currentInfoView != null) 
                 currentInfoView.Hide();
            }
			if(Query.StartsWith("playlist:"))
			{

               
               

                String Engine = Query.Split(':')[1];
                IPlayEngine PlayEngine = Program.MediaEngines[Engine];
                MediaChrome.Views.Playlist D = null;
                foreach (Playlist d in PlayEngine.Playlists)
                {
                    if (d.ID == Query.Replace("playlist:" + PlayEngine.Namespace + ":", ""))
                    {
                        D = d;
                    }
                }
                D.Engine = PlayEngine;
                CurrentPlaylist = D;
                this.cListView1.Items.Clear();
           
		  
				CS.Close();
				return;
			}
			
			SQLiteCommand CSM = new SQLiteCommand(Query,CS);
			SQLiteDataReader DR = CSM.ExecuteReader();
			String PrevArtist="";
			String PrevTitle="";
			while(DR.Read())
			{
				
				var item = cListView1.AddItem((String)DR["name"]);
				
			
				Song R = GetSongFromQury(DR);
                try
                {
                    R.Engine = (string)DR["engine"];
                }
                catch
                {
                }
				item.Tag = (Object)R;
	//			UpdateListItem(R,ref item);
                /*		if(cTreeView1.SelectedNode!=null)
                        {
                            /*	string Artist = cTreeView1.SelectedNode.Name.StartsWith("_") ? cTreeView1.SelectedNode.Name.Replace(":","") : "";
                                if(Artist != "" || ((Song)item.Tag).Artist == "")
                                {
                                    if(!Artist.Contains(((Song)item.Tag).Artist)||item.SubItems[1].Text == "")
                                    {
                                        if(!Dark)
                                        {
                                            if(MainForm.FadeOddEntries)
                                                item.ForeColor=MainForm.OddEntry();
                                        }
                                    }
						
                                }
                            if(PrevTitle == item.Text && PrevArtist == item.SubItems[1].Text)
                            {
                                PrevTitle=item.Text;
                                PrevArtist=item.SubItems[1].Text;
                                    item.Remove();
                            }
                            PrevTitle=item.Text;
                            PrevArtist=item.SubItems[1].Text;
					
                            /// <summary>
                            /// If a encoder doesn't exist for the media mark it
                            /// </summary>
                            /// 
                            Song D = ((Song)item.Tag);
                            String Encd = D.Path.Split(':')[0];
                            if(!Program.MediaEngines.ContainsKey(Encd))
                            {
                                if(MainForm.Dark)
                                {
                                    item.ForeColor=Color.FromArgb(255,100,100);
                                }
                                else
                                {
                                    item.ForeColor=Color.FromArgb(100,0,0);	
                                }
                            }
                        }*/
                if ((item.Index % 2) == 1 && MainForm.alternating)
				{
	        		item.BackColor = MainForm.AlternateRowColor();
				}
			}
			CS.Close();
			foreach(ColumnHeader I in cListView1.Columns){
				I.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
				
			}
			Substitutions.Clear();
			Substitutions.Add("MediaName","Test");
			//		geckoWebBrowser1.Navigate(MainForm.GetAppPath()+"\\paged\\info.html");
		
		}

        void currentInfoView_ItemClicked(object Sender, string Url)
        {
            MainForm.PlayItem(Url);
        }

        void currentInfoView_Loaded(object sender, EventArgs e)
        {
            String Artist_ = (string)((Artist)sender).Tag;
            SQLiteConnection CS = MainForm.MakeConnection();
            CS.Open();  
            MediaChrome.Element Section = new MediaChrome.Element();
            Section.Attributes.Add(new MediaChrome.Attribute() { name = "text", value = "Local contents" });
            Section.Type = "sp:section";
            currentInfoView.CurrentView.View.Sections[0].Elements.Add(Section);
            SQLiteCommand CSM1 = new SQLiteCommand("SELECT name,artist,album,path FROM song WHERE artist='"+Artist_.Replace("'","")+"' ORDER BY album ASC", CS);
            SQLiteDataReader DR2 = CSM1.ExecuteReader();
             MediaChrome.Element Space = new MediaChrome.Element();
             Space.Attributes.Add(new MediaChrome.Attribute() { name = "distance", value="150" });
             currentInfoView.CurrentView.View.Sections[0].Elements.Add(Space);
             string diffName = "%%";
             int countTracks = 10;
             bool first = true;
            while (DR2.Read())
            {
                int num = 0;  
                if(diffName != (string)DR2["album"])
                {
                    if (num < countTracks && !first)
                    {
                        MediaChrome.Element Space12 = new MediaChrome.Element();
                        Space12.Type = "sp:space";
                        Space12.Attributes.Add(new MediaChrome.Attribute() { name = "distance", value = ((countTracks - num) * 8).ToString() });
                        currentInfoView.CurrentView.View.Sections[0].Elements.Add(Space12);
                    }
                    if (!first)
                    {
                        MediaChrome.Element Divider = new MediaChrome.Element();
                        Divider.Type = "sp:divider";
                        currentInfoView.CurrentView.View.Sections[0].Elements.Add(Divider);
                        first = false;
                    }
                    
                    num = 0;

                    MediaChrome.Element Title = new MediaChrome.Element();
                    Title.Type = "sp:header";
                    Title.Attributes.Add(new MediaChrome.Attribute() { name = "title", value = (string)DR2["album"] });
                    currentInfoView.CurrentView.View.Sections[0].Elements.Add(Title);
                }
                MediaChrome.Element Track = new MediaChrome.Element();
                Track.Type = "sp:entry";
                Track.Attributes.Add(new MediaChrome.Attribute() { name = "title", value = (string)DR2["name"] });
                Track.Attributes.Add(new MediaChrome.Attribute() { name = "author", value = (string)DR2["artist"] });
                Track.Attributes.Add(new MediaChrome.Attribute() { name = "collection", value = (string)DR2["album"] });
                Track.Attributes.Add(new MediaChrome.Attribute() { name = "href", value = (string)DR2["path"] });
                currentInfoView.CurrentView.View.Sections[0].Elements.Add(Track);
                diffName = (String)DR2["album"];
                first = false;
            }
        }
	
		public static bool Dark=false;
	
		void cListView1_DoubleClick(object sender, EventArgs e)
		{
			if(cListView1.SelectedItems.Count > 0){
				foreach(ListViewItem X in cListView1.Items)
				{
					X.BackColor= X.Index % 2 == 1 ? MainForm.AlternateRowColor() : MainForm.ListBackground();
					X.ForeColor = MainForm.ListForeground();
					try{
                        /*         string Artist = cTreeView1.SelectedNode.Name.StartsWith("_") ? cTreeView1.SelectedNode.Name.Replace(":", "") : "";
                                 if (Artist != "" || ((Song)X.Tag).Artist == "")
                                 {
                                     if (!Artist.Contains(((Song)X.Tag).Artist) || X.SubItems[1].Text == "")
                                     {
                                         if (!Dark)
                                         {
                                             if (MainForm.FadeOddEntries)
                                                 X.ForeColor=MainForm.OddEntry();
                                         }
                                     }
                             */
                    }
                    catch{}
                    
				}
				Song _Song = (Song)cListView1.SelectedItems[0].Tag;
				string path = _Song.Path;
				MainForm.PlayItem(path);
		
				MainForm.currentTrack=_Song;
				cListView1.SelectedItems[0].BackColor=Color.FromArgb(50,50,50);
				cListView1.SelectedItems[0].ForeColor=Color.LightGreen;
				
				// Clear the playlist
				MainForm.playlist.Clear();
				// Build a new playlist starting from the position of the current song
				for(int i=cListView1.SelectedItems[0].Index ; i < cListView1.Items.Count;i++)
				{
					ListViewItem I = cListView1.Items[i];
					Song D = MainForm.ItemToSong(I);
					MainForm.playlist.Enqueue(D);
					
					
				}
				Program.Host.CreateCurrentPlaylist();
				cListView1.SelectedItems.Clear();
			}
		}
		
		void CListView1SelectedIndexChanged(object sender, EventArgs e)
		{
			
		}
		
		void UcButton1Click(object sender, EventArgs e)
		{
			ImportLibrary D = new ImportLibrary(this);
			D.ShowDialog();
			
		}
		
		void CTreeView1AfterSelect(object sender, TreeViewEventArgs e)
		{
			
			try
			{
                if (((string)e.Node.Tag).StartsWith("SELECT ") || ((string)e.Node.Tag).StartsWith("playlist:") || ((string)e.Node.Tag).StartsWith("artist:"))
				{
				
					Query((string)e.Node.Tag);
					currentQuery=(string)e.Node.Tag;
				}
			
			}
			catch
			{
				
			}
		}
		
		void UcButton2Load(object sender, EventArgs e)
		{
			
		}
		
		void UcButton2Click(object sender, EventArgs e)
		{
			FindTracks(textBox1.Text);
		}
		ListView.SelectedListViewItemCollection dragItems ;
		void CListView1ItemDrag(object sender, ItemDragEventArgs e)
		{
			dragItems = cListView1.SelectedItems;
			
		}
		
		void CListView1MouseMove(object sender, MouseEventArgs e)
		{
			
			
		}
		
		void SplitContainer1SplitterMoved(object sender, SplitterEventArgs e)
		{
			
		}
		public static void UpdateListItem(Song R,ref ListViewItem item)
		{
			item.SubItems.Clear();
			item.Text = R.Title;
			
			item.SubItems.Add(R.Version);
			item.SubItems.Add(R.Artist);
			item.SubItems.Add(R.Album);
			item.SubItems.Add(R.Feature);
		
			item.SubItems.Add(R.Contributing);
			item.SubItems.Add(R.Store);
			item.SubItems.Add(R.Composer);
		}
		public string CurrentQuery {get;set;}
		void EditMetadataToolStripMenuItemClick(object sender, EventArgs e)
		{
			if(cListView1.SelectedItems.Count>0)
			{
				Song D = MainForm.ItemToSong(cListView1.SelectedItems[0]);
				MediaChrome.EditMetadata Editor = new MediaChrome.EditMetadata(D);
				if(Editor.ShowDialog()==DialogResult.OK)
				{
					ListViewItem Dm = cListView1.SelectedItems[0];
					UpdateListItem(Editor.CurrentSong,ref Dm);	
					
				}
			}
		}
		void RemoveSelectedEntries()
		{
			if(MessageBox.Show("Do you want to remove all items from the database (will not be removed from the computer","Warning",MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
				
					// Create list for items to remove
					List<ListViewItem> Items = new List<ListViewItem>();
					
					// Iterate through the selected items
					
					foreach(ListViewItem R in this.cListView1.SelectedItems)
					{
						SQLiteConnection Conn = MainForm.MakeConnection();
						Conn.Open();
						SQLiteCommand Command = new SQLiteCommand("DELETE FROM song WHERE path='"+(String)((Song)R.Tag).Path+"' ",Conn);
						Command.ExecuteNonQuery();
						Conn.Close();
						Items.Add(R);
						
						
					}
					
					// Remove all items from the view 
					
					foreach(ListViewItem Item in Items)
					{
						cListView1.Items.Remove(Item);
					}
				}
		}
		void CListView1KeyPress(object sender, KeyPressEventArgs e)
		{
			if(e.KeyChar == '\b')
			{
			
				RemoveSelectedEntries();
			}
		}
		
		void RemoevToolStripMenuItemClick(object sender, EventArgs e)
		{
			RemoveSelectedEntries();
		}

        private void cListView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void geckoWebBrowser1_Click(object sender, EventArgs e)
        {
             
        }

        private void ucToolbar1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CurrentPlaylist != null)
            {
                if (cListView1.Items.Count == 0)
                {
                    foreach (Song d in CurrentPlaylist.Songs)
                    {
                        ListViewItem DX = MainForm.SongToItem(d);
                        
                        cListView1.Items.Add(DX);
                        if (DX.Index % 2 == 1)
                        {
                            DX.BackColor = MainForm.AlternateRowColor();
                        }
                    }
                }
               
            }
        }

        private void cListView1_UniDraw(object sender, Graphics g, ListViewItem Item)
        {
       
           
            Song D = (Song)Item.Tag;
            if (D.SubSongs.Count > 0)
            {
                cListView1.DrawImage(g, Item,  MediaChrome.Resources.opner, "Title", true);
            }
            if(cListView1.EngineImages != null && D.Engine != null)
                cListView1.DrawImage(g, Item, cListView1.EngineImages[D.Engine], "Version",true,18);
         //   cListView1.DrawProgressBar(g, Item, D.Popularity, "Popularity");
           
        }
	}
}
