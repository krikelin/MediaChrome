/*
 * Created by SharpDevelop.
 * User: Alex
 * Date: 2010-10-27
 * Time: 19:45
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
namespace CDON
{
	
	/// <summary>
	/// Description of CListView.
	/// </summary>
	public class CListView : ListView
	{
		
		public class ItemsAddedArgs : EventArgs
		{
		    public ItemsAddedArgs(ListViewItem item)
		    {
		        Item = item;
		    }
		
		    public object Item { get; set; }
		}
		
		protected override void OnInvalidated(InvalidateEventArgs e)
		{
			base.OnInvalidated(e);
		
		}
		protected override void OnDrawItem(DrawListViewItemEventArgs e)
		{
			base.OnDrawItem(e);
			if(((string)e.Item.Tag) == MainForm.currentTrack)
			{
				e.Item.BackColor=Color.Black;
				e.Item.ForeColor=Color.Blue;
			}
			else
			{
				if((e.Item.Index % 2)==1)
				{
					e.Item.BackColor=MainForm.AlternateRowColor();
					
				}
				else
				{
					e.Item.BackColor=MainForm.ListBackground();
				}
				e.Item.ForeColor = MainForm.ListForeground();
			}
		}
		public override Color BackColor
		{
			get
			{
				return MainForm.ListBackground();
		
			}
		}
		public override Color ForeColor
		{
			get
			{
				return MainForm.ListForeground();
			}
		}
		public override void ResetBackColor()
		{
			base.ResetBackColor();
			
			this.BackColor = MainForm.ListBackground();
			foreach(ListViewItem item in Items)
			{
				if(item.Index % 2 == 1){
	        		item.BackColor = MainForm.AlternateRowColor();
				}
			}
		}
		public override void ResetForeColor()
		{
			base.ResetBackColor();
			this.BackColor = MainForm.ListForeground();
		}
		public ListViewItem AddItem(String Title)
	    {
	        ListViewItem item = Items.Add(Title);
	        if (ItemAdded != null)
	            ItemAdded.Invoke(this, new ItemsAddedArgs(item));
	    
		        if(item.Index % 2 == 1){
	        	item.BackColor = MainForm.AlternateRowColor();
		        }
	      
	        return item;
	    }
		public CListView(){
			this.FullRowSelect=true;
		SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
		lvwColumnSorter = new MultiMedia.ListViewColumnSorter();
		this.ListViewItemSorter = lvwColumnSorter;
		
		}
		private MultiMedia.ListViewColumnSorter lvwColumnSorter ;
		protected override void OnColumnClick(ColumnClickEventArgs e)
		{
			/// <summary>
			/// From http://support.microsoft.com/kb/319401
			/// </summary>
					// Determine if clicked column is already the column that is being sorted.
			if ( e.Column == lvwColumnSorter.SortColumn )
			{
				// Reverse the current sort direction for this column.
				if (lvwColumnSorter.Order == SortOrder.Ascending)
				{
					lvwColumnSorter.Order = SortOrder.Descending;
					this.Sorting= SortOrder.Descending;
				}
				else
				{
					lvwColumnSorter.Order = SortOrder.Ascending;
					this.Sorting= SortOrder.Ascending;
				}
				
			}
			else
			{
				// Set the column number that is to be sorted; default to ascending.
				lvwColumnSorter.SortColumn = e.Column;
				lvwColumnSorter.Order = SortOrder.Ascending;
			}
			
			// Perform the sort with these new sort options.
			this.Sort();
			foreach(ListViewItem X in this.Items)
			{
				X.BackColor = (X.Index) % 2 == 1 && MainForm.alternating ? MainForm.AlternateRowColor() : MainForm.ListBackground();
				
			}
		}
   		 public EventHandler<ItemsAddedArgs> ItemAdded;
	}
	public class TrackListView :CListView
	{
		public MultiMedia.ListViewColumnSorter Sorter;
		public TrackListView()
		{
			Sorter = new MultiMedia.ListViewColumnSorter();
			this.ListViewItemSorter = Sorter;
		}
		public void DefaultSort()
		{
			Sorter.Order = SortOrder.Ascending;
			Sorter.SortColumn=1;
			this.Sorting= SortOrder.Ascending;
			
			Sorter.SortColumn=2;
			this.Sort();
			Sorter.SortColumn=3;
			this.Sort();
		}
	}
}
