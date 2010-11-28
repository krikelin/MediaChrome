/*
 * Created by SharpDevelop.
 * User: Alex
 * Date: 2010-10-28
 * Time: 13:11
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CDON
{
	/// <summary>
	/// Description of Config.
	/// </summary>
	public partial class Config : UserControl
	{
		public Config()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		public MainForm Host {get;set;}
		public Config(MainForm src)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			Host=src;
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			if(colorDialog1.ShowDialog() == DialogResult.OK)
			{
				MainForm.Colorize(Host,colorDialog1.Color);
				Host.SaveSettings();
			}
		}
	}
}
