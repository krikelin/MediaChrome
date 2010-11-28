/*
 * Created by SharpDevelop.
 * User: Alex
 * Date: 2010-10-27
 * Time: 19:05
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace CDON
{
	partial class ucStore
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the control.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.ucToolbar1 = new CDON.ucToolbar();
			this.webBrowser1 = new System.Windows.Forms.WebBrowser();
			this.ucButton1 = new CDON.ucButton();
			this.ucButton2 = new CDON.ucButton();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.ucButton3 = new CDON.ucButton();
			this.ucButton4 = new CDON.ucButton();
			this.SuspendLayout();
			// 
			// ucToolbar1
			// 
			this.ucToolbar1.Dock = System.Windows.Forms.DockStyle.Top;
			this.ucToolbar1.Location = new System.Drawing.Point(0, 0);
			this.ucToolbar1.Name = "ucToolbar1";
			this.ucToolbar1.Size = new System.Drawing.Size(647, 32);
			this.ucToolbar1.TabIndex = 5;
			// 
			// webBrowser1
			// 
			this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.webBrowser1.IsWebBrowserContextMenuEnabled = false;
			this.webBrowser1.Location = new System.Drawing.Point(0, 32);
			this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
			this.webBrowser1.Name = "webBrowser1";
			this.webBrowser1.Size = new System.Drawing.Size(647, 479);
			this.webBrowser1.TabIndex = 6;
			this.webBrowser1.Url = new System.Uri("http://downloads.cdon.com", System.UriKind.Absolute);
			this.webBrowser1.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.WebBrowser1Navigating);
			this.webBrowser1.FileDownload += new System.EventHandler(this.WebBrowser1FileDownload);
			this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.WebBrowser1DocumentCompleted);
			this.webBrowser1.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.WebBrowser1Navigated);
			// 
			// ucButton1
			// 
			this.ucButton1.Icon = null;
			this.ucButton1.Label = "Back";
			this.ucButton1.Location = new System.Drawing.Point(55, 3);
			this.ucButton1.Name = "ucButton1";
			this.ucButton1.Size = new System.Drawing.Size(68, 22);
			this.ucButton1.TabIndex = 7;
			// 
			// ucButton2
			// 
			this.ucButton2.Icon = null;
			this.ucButton2.Label = "Forward";
			this.ucButton2.Location = new System.Drawing.Point(129, 3);
			this.ucButton2.Name = "ucButton2";
			this.ucButton2.Size = new System.Drawing.Size(74, 22);
			this.ucButton2.TabIndex = 7;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(214, 5);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(333, 20);
			this.textBox1.TabIndex = 8;
			// 
			// ucButton3
			// 
			this.ucButton3.Icon = null;
			this.ucButton3.Label = "Back";
			this.ucButton3.Location = new System.Drawing.Point(3, 3);
			this.ucButton3.Name = "ucButton3";
			this.ucButton3.Size = new System.Drawing.Size(25, 22);
			this.ucButton3.TabIndex = 7;
			// 
			// ucButton4
			// 
			this.ucButton4.Icon = null;
			this.ucButton4.Label = "Go";
			this.ucButton4.Location = new System.Drawing.Point(556, 4);
			this.ucButton4.Name = "ucButton4";
			this.ucButton4.Size = new System.Drawing.Size(74, 22);
			this.ucButton4.TabIndex = 7;
			this.ucButton4.Click += new System.EventHandler(this.UcButton4Click);
			// 
			// ucStore
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.ucButton4);
			this.Controls.Add(this.ucButton2);
			this.Controls.Add(this.ucButton3);
			this.Controls.Add(this.ucButton1);
			this.Controls.Add(this.webBrowser1);
			this.Controls.Add(this.ucToolbar1);
			this.Name = "ucStore";
			this.Size = new System.Drawing.Size(647, 511);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private CDON.ucButton ucButton4;
		private CDON.ucButton ucButton3;
		private System.Windows.Forms.TextBox textBox1;
		private CDON.ucButton ucButton2;
		private CDON.ucButton ucButton1;
		private CDON.ucToolbar ucToolbar1;
		private  System.Windows.Forms.WebBrowser webBrowser1;
	}
}
