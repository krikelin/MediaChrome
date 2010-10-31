/*
 * Created by SharpDevelop.
 * User: Alex
 * Date: 2010-10-28
 * Time: 12:39
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
	/// Description of Preferences.
	/// </summary>
	public partial class Settings : UserControl
	{
		public Settings()
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
		public Settings(MainForm src)
		{
			
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			Host=src;
			this.BackColor = MainForm.ListBackground();
			checkBox1.Checked = MainForm.Dark;
			checkBox2.Checked = MainForm.alternating;
			checkBox3.Checked = MainForm.PlaylistColors;
			checkBox4.Checked = MainForm.FadeOddEntries;
		}
		public static bool customBackColor=false;
		void Button1Click(object sender, EventArgs e)
		{
			
			if(colorDialog1.ShowDialog() == DialogResult.OK)
			{
				
			}
		}
		
		void PreferencesLoad(object sender, EventArgs e)
		{
			colorDialog1.Color = MainForm.PrimaryColor;
		}
		
		void CheckBox1CheckedChanged(object sender, EventArgs e)
		{
			
		}
		
		void CheckBox2CheckedChanged(object sender, EventArgs e)
		{
			
		}
		
		void CheckBox3CheckedChanged(object sender, EventArgs e)
		{
			
			
		}
		
		void CheckBox4CheckedChanged(object sender, EventArgs e)
		{
			
		}
		
		void CheckBox5CheckedChanged(object sender, EventArgs e)
		{
			
		}
		
		void Button3Click(object sender, EventArgs e)
		{
			MainForm.Dark=checkBox1.Checked;
			MainForm.alternating=checkBox2.Checked;
			MainForm.PlaylistColors=checkBox3.Checked;
			MainForm.FadeOddEntries=checkBox4.Checked;
			customBackColor=checkBox4.Checked;
			MainForm.PrimaryColor=colorDialog1.Color;
			MainForm.Colorize(Host,colorDialog1.Color);
			this.BackColor = MainForm.ListBackground();
			Host.SaveSettings();
		}
	}
}
