/*
 * Created by SharpDevelop.
 * User: Alex
 * Date: 2010-10-27
 * Time: 19:05
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Net;
namespace MediaChrome
{
	/// <summary>
	/// Description of ucStore.
	/// </summary>
	public partial class ucStore : UserControl
	{
		public MainForm MainF{get;set;}
		public ucStore(MainForm Host){
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			MainF=Host;
		}
	
		public ucStore()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		public String Store {get;set;}
		public DownloadManager Manager{
			get;set;
		}
		Uri NewURI;
		public bool Bounce {get;set;}
		void WebBrowser1Navigating(object sender, WebBrowserNavigatingEventArgs e)
		{
			if(e.Url.ToString().EndsWith(".mp3")||e.Url.ToString().EndsWith(".zip"))
			{
				FileDownload D = new FileDownload(webBrowser1,e.Url.ToString(),this,false);
						
				ListViewItem Item = Manager.DownloadList.AddItem(D.Url.ToString());
				Item.SubItems.Add("");
				Item.SubItems.Add("");
				Item.SubItems.Add("0%");
				Store = e.Url.Host;
				Item.Tag = (Object)D;
				MainF.ActivateView("Downloads");
				e.Cancel=true;
		  	}
			if(MainForm.AlbumServiceTokens.ContainsKey(e.Url.Host))
			{
				if(e.Url.ToString().Contains(MainForm.AlbumServiceTokens[e.Url.Host]))
				{
					FileDownload D = new FileDownload(webBrowser1,e.Url.ToString(),this,false);		
					ListViewItem Item = Manager.DownloadList.AddItem(D.Url.ToString());
					Item.SubItems.Add("");
					Item.SubItems.Add("");
					Item.SubItems.Add("0%");
					Store = e.Url.Host;
					Item.Tag = (Object)D;
					MainF.ActivateView("Downloads");
					e.Cancel=true;
				}
			}
			if(MainForm.TrackServiceTokens.ContainsKey(e.Url.Host))
			{
				if(e.Url.ToString().Contains(MainForm.TrackServiceTokens[e.Url.Host]))
				{
					FileDownload D = new FileDownload(webBrowser1,e.Url.ToString(),this,false);
				
					ListViewItem Item =Manager.DownloadList.AddItem(D.Url.ToString());
					Item.SubItems.Add("");
					Item.SubItems.Add("");
					Item.SubItems.Add("0%");
					Store = e.Url.Host;
					Item.Tag = (Object)D;
					MainF.ActivateView("Downloads");
					e.Cancel=true;
				}
			}
		}	

		void C_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
		{
		
		}
		
		void Panel2Paint(object sender, PaintEventArgs e)
		{
			
		}
		
		void UcButton4Load(object sender, EventArgs e)
		{
			
		}
		
		void UcButton4Click(object sender, EventArgs e)
		{
			webBrowser1.Navigate(textBox1.Text);
		}
		
		void WebBrowser1FileDownload(object sender, EventArgs e)
		{		
			
			
		}
		
		void WebBrowser1Navigated(object sender, WebBrowserNavigatedEventArgs e)
		{
			
		}
		
		void WebBrowser1DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
		{
			
		}
	}
}
