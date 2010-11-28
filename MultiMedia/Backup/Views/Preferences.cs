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
			
		}
		
		void LinkLabel1LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			MainForm.Dark=checkBox1.Checked;
			MainForm.alternating=checkBox2.Checked;
			MainForm.PlaylistColors=checkBox3.Checked;
			MainForm.FadeOddEntries=checkBox4.Checked;

			MainForm.PrimaryColor=MainForm.FadeColor(0.5f,colorChooser1.Value);
			
			MainForm.customBgColor=bgColor.BackColor;
			MainForm.customFgColor=fgColor.BackColor;
			MainForm.customHColor=hColor.BackColor;
			MainForm.customAlternatingColor=altColor.BackColor;
			MainForm.customToolColor=tColor.BackColor;
			MainForm.CustomColors=checkBox5.Checked;
			MainForm.customToolFColor=tfColor.BackColor;
			Host.Sidebar=checkBox6.Checked;
			
			
			Host.SaveSettings();
	
			MainForm.Colorize(Host,MainForm.CustomColors ?MainForm.customBgColor : MainForm.PrimaryColor);
			this.ForeColor=MainForm.customToolFColor;
		}
		
		void BgColorDoubleClick(object sender, EventArgs e)
		{
		
		}
		
		void FgColorDoubleClick(object sender, EventArgs e)
		{
			PictureBox D = (PictureBox)sender;
			if(colorDialog1.ShowDialog()==DialogResult.OK)
			{
				D.BackColor=colorDialog1.Color;
			}
		}
		
		void Panel1Paint(object sender, PaintEventArgs e)
		{
			
		}
		
		void SettingsVisibleChanged(object sender, EventArgs e)
		{
			if(this.Visible)
			{
				if(!MainForm.CustomColors)
				{
					bgColor.BackColor = MainForm.ListBackground();
					fgColor.BackColor=MainForm.ListForeground();
					hColor.BackColor=MainForm.PrimaryColor;
					tColor.BackColor=MainForm.ToolbarBackground();
					altColor.BackColor=MainForm.AlternateRowColor();
					this.ForeColor=MainForm.customToolFColor;
				}
			
				bgColor.BackColor=MainForm.customBgColor;
				fgColor.BackColor=MainForm.customFgColor;
				hColor.BackColor=MainForm.customHColor;
				altColor.BackColor=MainForm.customAlternatingColor;
				tColor.BackColor=MainForm.customToolColor;
				checkBox5.Checked = MainForm.CustomColors;
				checkBox6.Checked = Host.Sidebar;
			}
		}
	}
}
