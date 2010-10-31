﻿/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 2010-08-20
 * Time: 23:13
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

using Spotify;

namespace SpofityRuntime
{
	/// <summary>
	/// Description of Login.
	/// </summary>
	public partial class Login : Form
	{
		public Login()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			Program.SpotifySession.OnLoginComplete+= new SessionEventHandler(Program_SpotifySession_OnLoginComplete);
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		SpotifyPlayer Program;
		public Login(SpofityRuntime.SpotifyPlayer D)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			Program = D;
			Program.SpotifySession.OnLoginComplete+= new SessionEventHandler(Program_SpotifySession_OnLoginComplete);
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			Program.SpotifySession.LogIn(textBox1.Text,textBox2.Text);
			panel1.Hide();
		}
		public string User
		{
			get{return this.textBox1.Text;}
			
		}
		public string Pass
		{
			get{return this.textBox2.Text;}
		
		}
		void Program_SpotifySession_OnLoginComplete(Session sender, SessionEventArgs e)
		{
			if(e.Status == sp_error.OK)
			{
				this.DialogResult= DialogResult.OK;
				//this.Close();
				
			}
			else
			{
				//label6.Text = e.Status.ToString();
				panel1.Show();
			}
			
		}
		
		void Pane1Paint(object sender, PaintEventArgs e)
		{
			
		}
	}
}
