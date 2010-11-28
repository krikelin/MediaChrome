/*
 * Created by SharpDevelop.
 * User: Alex
 * Date: 2010-11-02
 * Time: 14:13
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using CDON;

namespace MultiMedia.Views
{
	/// <summary>
	/// Description of Playlist.
	/// </summary>
	public partial class Playlist : UserControl
	{
		public String Title {get;set;}
		public IPlayEngine Engine {get;set;}
		public String ID {get;set;}
		public MainForm Host {get;set;}
		public Playlist(IPlayEngine Engine,String ID,MainForm host)
		{
			this.Host=host;
			this.Engine=Engine;
				//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			this.ID=ID;
			Thread D = new Thread(RetrieveData);
			D.Start();
			timer1.Start();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			
		}
		List<Song> Songs;
		public bool Loaded {get;set;}
		public void RetrieveData()
		{
			Songs = Engine.ViewPlaylist(this.ID);
			Loaded=true;
		}
		public Playlist()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void UcToolbar1Load(object sender, EventArgs e)
		{
			
		}
		Song DragSong;
		void Timer1Tick(object sender, EventArgs e)
		{
			if(Songs==null)
				return;
			if(Loaded)
			{
				foreach(Song D in Songs)
				{
					ListViewItem _item = cListView1.AddItem(D.Title);
					Library.UpdateListItem(D,ref _item );
				}
			}
		}
		int moalIndex=0;
		List<ListViewItem> DragItems;
		void CListView1MouseDown(object sender, MouseEventArgs e)
		{
			if(cListView1.SelectedItems.Count>0)
			{
				moalIndex=cListView1.SelectedItems[0].Index;
				foreach(ListViewItem X in cListView1.SelectedItems)
				{
					
					DragItems.Add(X);
				}
			}
		}
		
		void CListView1MouseUp(object sender, MouseEventArgs e)
		{
			int newIndex = cListView1.GetItemAt(e.X,e.Y).Index;
			foreach(ListViewItem dragItem in DragItems)
			{
				dragItem.Remove();
			}
			for (int i=0; i < DragItems.Count; i++)
			{
				cListView1.Items.Insert(moalIndex+i,DragItems[i]);
			}
			Engine.MoveSongPlaylist(ID,moalIndex,newIndex);
		}
	} 
}
