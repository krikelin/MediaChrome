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
using MultiMedia.Views;
using Skybound.Gecko;

namespace CDON
{
	/// <summary>
	/// Description of Library.
	/// </summary>
	/// 
	
	public partial class Library : UserControl
	{
		public static string QUERY = "SELECT DISTINCT name,artist,album,composer,path,store,feature,version_,coartist FROM song ";
		
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
			this.cTreeView1.DragEnter+= new DragEventHandler(Library_DragEnter);
			this.cTreeView1.DragDrop+= new DragEventHandler(TreeView_DragDrop);
			this.splitContainer1.BackColor = MainForm.ToolbarBackground();
			this.splitContainer1.DragDrop+= new DragEventHandler(Library_DragDrop);
			this.cListView1.ItemDrag+=new ItemDragEventHandler(Library_ItemDrag);
			this.cTreeView1.AfterSelect+= new TreeViewEventHandler(CTreeView1AfterSelect);
			SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
			this.cListView1.ColumnClick+= new ColumnClickEventHandler(Library_ColumnClick);
			this.cListView1.SelectedIndexChanged+= new EventHandler(Library_SelectedIndexChanged);
		
			Import();
		}

		void Library_SelectedIndexChanged(object sender, EventArgs e)
		{
			if(cListView1.SelectedIndices.Count>0)
			{ 
				if(cListView1.SelectedIndices[0] >= cListView1.Items.Count-1)
				{	
					rowsAppended=0;
					while(Result.Count>0&&rowsAppended < this.MAX_ITEMS_AT_START)
					{
						
						Song D = Result.Dequeue();
						ListViewItem Item = cListView1.AddItem(D.Title);
						Item.Tag = (object)D;
						Item.SubItems.Add(D.Artist);
						Item.SubItems.Add(D.Album);
						Item.SubItems.Add(D.Store);
						Item.SubItems.Add(D.Engine);
						rowsAppended++;
					}
				}
			}
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
					Song _Song = (CDON.Song)Item.Tag;
					 String Query = (string)((CDON.Song)Item.Tag).Path;
					
					
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
						
					
						TreeNode x = cTreeView1.Nodes["Library"].Nodes["Artists"].Nodes["_"+Item.Text+""].Nodes[_Song.Title];
					}
					catch
					{
						try
						{
							TreeNode x = cTreeView1.Nodes["Library"].Nodes["Artists"].Nodes["_"+Item.Text+""].Nodes.Add(_Song.Title);
						}
						catch
						{
							TreeNode x = cTreeView1.Nodes["Library"].Nodes["Artists"].Nodes.Add(""+_Song.Artist+"");
							x.Name = "_"+_Song.Artist;
							
							TreeNode _Album = x.Nodes.Add(_Song.Album);
							_Album.Tag=(Object)QUERY+" WHERE album='"+_Album.Text+"'";
							x.Tag=(Object)QUERY+" WHERE artist='"+x.Text+"'";
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
				ListViewItem Item = cListView1.AddItem(D.Title);
				Item.Tag = (object)D;
				Item.SubItems.Add(D.Artist);
				Item.SubItems.Add(D.Album);
				Item.SubItems.Add(D.Store);
				Item.SubItems.Add(D.Engine);
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
			cTreeView1.ForeColor = MainForm.ListForeground();
			//cListView1.Items.Clear();
			TreeNode Lib = cTreeView1.Nodes.Add("Library");
			Lib.Tag=(Object)"Library";
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
			
			ListAttribute("Artist",cTreeView1.Nodes["Library"].Nodes["Artists"],CS);
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
			TreeNode Plsts = cTreeView1.Nodes["Library"].Nodes.Add("Playlists");
			
			foreach(IPlayEngine Engine in Program.MediaEngines.Values)
			{
				TreeNode D = Plsts.Nodes.Add(Engine.Title);
				List<MultiMedia.Views.Playlist> Playlists = Engine.Playlists;
				if(Playlists!=null)
				{
					foreach(Playlist Ds in Playlists)
					{
						TreeNode Playlist = D.Nodes.Add(Ds.Title);
						Playlist.Tag = (Object)"playlist:"+Ds.ID;
					}
				}
			}
			CS.Close();
		}
		public void ImportConditional(String Conditions,TreeNode Section,SQLiteConnection CS)
		{
			
			
				
			
			ListAttribute("artist",Section.Nodes.Add("Artist"),CS,Conditions);
			ListAttribute("album",Section.Nodes.Add("Album"),CS,Conditions);
			ListAttribute("genre",Section.Nodes.Add("Genre"),CS,Conditions);
			
			
		
		}
		public void TreeImport(){
			cTreeView1.ForeColor = MainForm.ListForeground();
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
			
			ListAttribute("Artist",cTreeView1.Nodes["Library"].Nodes["Artists"],CS);
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
			
			CS.Close();
		}
		
		
		
	
		public void Query(String Query){
			
			cListView1.Items.Clear();
			SQLiteConnection CS = MainForm.MakeConnection();
			CS.Open();
			if(Query.StartsWith("playlist:"))
			{
				
				MultiMedia.Views.Playlist D = new MultiMedia.Views.Playlist();
					
				
				  
		  
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
				item.Tag = (Object)R;
				UpdateListItem(R,ref item);
				if(cTreeView1.SelectedNode!=null)
				{
					string Artist = cTreeView1.SelectedNode.Name.StartsWith("_") ? cTreeView1.SelectedNode.Name.Replace(":","") : "";
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
				}
					if((item.Index % 2) == 1 && MainForm.alternating)
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
	
		public static bool Dark=false;
	
		void CListView1DoubleClick(object sender, EventArgs e)
		{
			if(cListView1.SelectedItems.Count > 0){
				foreach(ListViewItem X in cListView1.Items)
				{
					X.BackColor= X.Index % 2 == 1 ? MainForm.AlternateRowColor() : MainForm.ListBackground();
					X.ForeColor = MainForm.ListForeground();
					try{
					string Artist = cTreeView1.SelectedNode.Name.StartsWith("_") ? cTreeView1.SelectedNode.Name.Replace(":","") : "";
					if(Artist != "" || X.SubItems[1].Text == "")
					{
						if(!Artist.Contains(X.SubItems[1].Text)||X.SubItems[1].Text == "")
						{
							if(!Dark)
							{
								if(MainForm.FadeOddEntries)
									X.ForeColor=MainForm.OddEntry();
							}
						}
					}
					}catch{}
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
				if(((string)e.Node.Tag).StartsWith("SELECT ") || ((string)e.Node.Tag).StartsWith("playlist:"))
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
				MultiMedia.EditMetadata Editor = new MultiMedia.EditMetadata(D);
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
	}
}
