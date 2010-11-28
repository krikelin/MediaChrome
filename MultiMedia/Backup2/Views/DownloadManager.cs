/*
 * Created by SharpDevelop.
 * User: Alex
 * Date: 2010-10-27
 * Time: 20:17
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MediaChrome
{
	/// <summary>
	/// Description of DownloadManager.
	/// </summary>
	
	public partial class DownloadManager : UserControl
	{
		public void UpdateView(){
			foreach(ListViewItem Item in this.cListView1.Items){
				if(Item.Tag.GetType() == typeof(FileDownload)){
					FileDownload D = (FileDownload)Item.Tag;
					Item.SubItems[3].Text=D.Progress.ToString()+"%";
				}
			}
		}
		public CListView DownloadList
		{
			get
			{
				return this.cListView1;
			}
			set{
				this.cListView1=value;
			}
		}
		public DownloadManager()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void CListView1SelectedIndexChanged(object sender, EventArgs e)
		{
			
		}
		
		void Timer1Tick(object sender, EventArgs e)
		{
			UpdateView();
		}
	}
}
