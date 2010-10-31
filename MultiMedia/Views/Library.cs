/*
 * Created by SharpDevelop.
 * User: Alex
 * Date: 2010-10-27
 * Time: 22:41
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using Skybound.Gecko;

namespace CDON
{
	/// <summary>
	/// Description of Library.
	/// </summary>
	/// 
	
	public partial class Library : UserControl
	{
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
					Import();
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
					String Query = (string)Item.Tag;
					
					SQLiteCommand Command = new SQLiteCommand("SELECT count(*) FROM song WHERE path='"+Query+"'",Conn);
					SQLiteDataReader DR = Command.ExecuteReader();
					DR.Read();
					if(DR.GetInt32(0)==0)
					{
						Query = "INSERT INTO song(name,artist,album,path,store,engine) VALUES(\""+Item.Text+"\",\""+Item.SubItems[1].Text+"\",\""+Item.SubItems[2].Text+"\",\""+Query+"\",\""+Item.SubItems[3].Text+"\",\""+Item.SubItems[4].Text+"\")";
						SQLiteCommand Comm = new SQLiteCommand(Query,Conn);
						Comm.ExecuteNonQuery();
					}
					
				}
				Conn.Close();
			}
			this.Import();
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
			while(SQLDR.Read()){
				try{
					TreeNode F = TND.Nodes.Add(SQLDR.GetString(0) == "" ? "(Unknown)" : SQLDR.GetString(0) );
					F.Tag = (object)"SELECT DISTINCT name,artist,album,path,store,engine FROM song WHERE engine IN "+Program.KeyQuery<IPlayEngine>(Program.MediaEngines,',')+" AND "+Attrib+"=\""+SQLDR.GetString(0)+"\"   ORDER BY artist,album,name ASC";
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
			while(SQLDR.Read()){
				try{
					TreeNode F = TND.Nodes.Add(SQLDR.GetString(0) == "" ? "(Unknown)" : SQLDR.GetString(0) );
					F.Tag = (object)"SELECT DISTINCT name,artist,album,path,store,engine FROM song WHERE engine IN "+Program.KeyQuery<IPlayEngine>(Program.MediaEngines,',')+" AND "+Attrib+"=\""+SQLDR.GetString(0)+"\"  "+AdditionalConditions+"  ORDER BY artist,album,name ASC";
				/*	try
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
		Timer tMr;
	
		String currentQuery="";
		public void FindTracks(string Query)
		{
			
			Result.Clear();
			cListView1.Items.Clear();
			tMr = new Timer();
			tMr.Tick+= new EventHandler(tMr_Tick);
			tMr.Start();
			currentQuery=Query;
			System.Threading.Thread D = new System.Threading.Thread(FindTracksEx);
			D.Start();
		}
		bool suai=false;
		void tMr_Tick(object sender, EventArgs e)
		{
			if(findCompleted)
			{
				
				if(Result.Count<1&&suai)
				{
					foreach(ColumnHeader I in cListView1.Columns){
						I.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
						
					}
					tMr.Stop();
					suai=false;
					CleanMusicList(ref cListView1);
				}
				
				
			}
			while(Result.Count>0)
			{
				suai=true;
				Song D = Result.Dequeue();
				ListViewItem Item = cListView1.AddItem(D.Title);
				Item.Tag = (object)D.Path;
				Item.SubItems.Add(D.Artist);
				Item.SubItems.Add(D.Album);
				Item.SubItems.Add(D.Store);
				Item.SubItems.Add(D.Engine);
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
				
					Dn.Tag = (object)"SELECT DISTINCT  name,artist,album,path,store,engine FROM song WHERE engine IN "+Program.KeyQuery<IPlayEngine>(Program.MediaEngines,',')+" AND album=\""+Dn.Text+"\"";
					Dn.Name = "_"+R.Text+"_"+i;
					i++;
				}
			}
			ListAttribute("Album",cTreeView1.Nodes["Library"].Nodes.Add("Albums"),CS);
			ListAttribute("genre",cTreeView1.Nodes["Library"].Nodes.Add("Genre"),CS);
			ListAttribute("store",cTreeView1.Nodes["Library"].Nodes.Add("Store"),CS);

			//ListAttribute("Purchased",cTreeView1.Nodes["Library"].Nodes["Purchased"],CS,"store","store");
			SQLiteCommand Df = new SQLiteCommand("SELECT name,title FROM engine",CS);
			SQLiteDataReader SQLR = Df.ExecuteReader();
			while(SQLR.Read())
			{
				TreeNode Dn = cTreeView1.Nodes["Library"].Nodes.Add(SQLR.GetString(1));
				ImportConditional(" engine=\""+SQLR.GetString(0)+"\"",Dn,CS);
				
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
			D.Tag = (Object)"SELECT name,artist,album,path,store FROM  song WHERE engine IN "+Program.KeyQuery<IPlayEngine>(Program.MediaEngines,',')+" ";
			TreeNode tArtists = D.Nodes.Add("Artists");
			tArtists.Name = "Artists";
			TreeNode tAlbums = D.Nodes.Add("Albums");
			tAlbums.Name = "Albums";
			TreeNode E = cTreeView1.Nodes["Library"].Nodes.Add("Store");
			E.Name="Purchased";
			E.Tag = (object)"SELECT name,artist,album,path,store,engine FROM purchased,song WHERE engine IN "+Program.KeyQuery<IPlayEngine>(Program.MediaEngines,',')+" AND song.songID=purchased.song_id ORDER BY purchased.time DESC";
			
			TreeNode F = cTreeView1.Nodes["Library"].Nodes.Add("Genre");
			F.Name="Genres";
			F.Tag = (object)"";
			TreeNode G = cTreeView1.Nodes["Library"].Nodes.Add("Provider");
			G.Name="Provider";
			G.Tag = (object)"";
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
				
					Dn.Tag = (object)"SELECT DISTINCT name,artist,album,path,store,engine FROM  song WHERE engine IN "+Program.KeyQuery<IPlayEngine>(Program.MediaEngines,',')+" AND album=\""+Dn.Text+"\"";
					Dn.Name = "_"+R.Text+"_"+i;
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
			while(SQLR.Read())
			{
				TreeNode Dn = cTreeView1.Nodes["Library"].Nodes["Purchased"].Nodes.Add(SQLR.GetString(0));
				Dn.Tag = (object)"SELECT DISTINCT name, name,artist,album,path,store,engine FROM purchase,song WHERE song.id=purchase.song_id AND engine IN "+Program.KeyQuery<IPlayEngine>(Program.MediaEngines,',')+" AND store=\""+SQLR.GetString(0)+"\" ORDER BY artist,album,name ASC";
				
			}
			CS.Close();
		}
		
		public void Query(String Query){
			cListView1.Items.Clear();
			SQLiteConnection CS = MainForm.MakeConnection();
			CS.Open();
			SQLiteCommand CSM = new SQLiteCommand(Query,CS);
			SQLiteDataReader DR = CSM.ExecuteReader();
			String PrevArtist="";
			String PrevTitle="";
			while(DR.Read())
			{
				
				var item = cListView1.AddItem(DR.GetString(0));
				item.SubItems.Add(DR.GetString(1));
				item.SubItems.Add(DR.GetString(2));
				item.SubItems.Add(DR.GetString(4));
				item.SubItems.Add(DR.GetString(5));
				
				item.Tag = (object)DR.GetString(3);
				
				if(((string)item.Tag) == MainForm.currentTrack)
				{
					item.BackColor=Color.FromArgb(50,50,50);
					item.ForeColor=Color.LightGreen;
				}
				if(cTreeView1.SelectedNode!=null)
				{
					string Artist = cTreeView1.SelectedNode.Name.StartsWith("_") ? cTreeView1.SelectedNode.Name.Replace(":","") : "";
					if(Artist != "" || item.SubItems[1].Text == "")
					{
						if(!Artist.Contains(item.SubItems[1].Text)||item.SubItems[1].Text == "")
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
					String Encd = ((string)item.Tag).Split(':')[0];
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
			}
			CS.Close();
			foreach(ColumnHeader I in cListView1.Columns){
				I.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
				
			}
			Substitutions.Clear();
			Substitutions.Add("MediaName","Test");
					geckoWebBrowser1.Navigate(MainForm.GetAppPath()+"\\paged\\info.html");
		
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
				
				string path = (String)cListView1.SelectedItems[0].Tag;
				MainForm.PlayItem(path);
		
				MainForm.currentTrack=path;
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
				if(((string)e.Node.Tag).StartsWith("SELECT "))
				{
				
					Query((string)e.Node.Tag);
					currentQuery=(string)e.Node.Tag;
				}
			}
			catch(Exception ex)
			{
			//	MessageBox.Show(ex.Message);
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
		public string CurrentQuery {get;set;}
		void EditMetadataToolStripMenuItemClick(object sender, EventArgs e)
		{
			if(cListView1.SelectedItems.Count>0)
			{
				Song D = MainForm.ItemToSong(cListView1.Items[0]);
				MultiMedia.EditMetadata Editor = new MultiMedia.EditMetadata(D);
				if(Editor.ShowDialog()==DialogResult.OK)
				{
					cListView1.Items[0].Text=Editor.Title;
					cListView1.Items[1].Text=Editor.Artist;
					cListView1.Items[2].Text=Editor.Album;
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
						SQLiteCommand Command = new SQLiteCommand("DELETE FROM song WHERE path='"+(String)R.Tag+"' ");
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
