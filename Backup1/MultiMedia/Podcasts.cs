/*
 * Created by SharpDevelop.
 * User: Alex
 * Date: 2010-10-29
 * Time: 19:48
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
	public class EpisodeDownload
	{
		public Uri URL {get;set;}
		public String Title {get;set;}
		public String Artist {get;set;}
	}
	
	/// <summary>
	/// Description of Podcasts.
	/// </summary>
	public partial class Podcasts : UserControl
	{
		public Podcasts()
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
	}
}
