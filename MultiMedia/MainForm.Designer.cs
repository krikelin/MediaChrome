/*
 * Created by SharpDevelop.
 * User: Alex
 * Date: 2010-10-27
 * Time: 19:03
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace CDON
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
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
			this.geckoWebBrowser1 = new Skybound.Gecko.GeckoWebBrowser();
			this.geckoWebBrowser2 = new Skybound.Gecko.GeckoWebBrowser();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.panel1 = new System.Windows.Forms.Panel();
			this.cListView1 = new CDON.CPlaylistView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.ucToolbar2 = new CDON.ucToolbar();
			this.ucToolbar1 = new CDON.ucToolbar();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// geckoWebBrowser1
			// 
			this.geckoWebBrowser1.Dock = System.Windows.Forms.DockStyle.Top;
			this.geckoWebBrowser1.Location = new System.Drawing.Point(0, 0);
			this.geckoWebBrowser1.Name = "geckoWebBrowser1";
			this.geckoWebBrowser1.Size = new System.Drawing.Size(676, 72);
			this.geckoWebBrowser1.TabIndex = 3;
			this.geckoWebBrowser1.Navigating += new Skybound.Gecko.GeckoNavigatingEventHandler(this.GeckoWebBrowser1Navigating);
			// 
			// geckoWebBrowser2
			// 
			this.geckoWebBrowser2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.geckoWebBrowser2.Location = new System.Drawing.Point(0, 325);
			this.geckoWebBrowser2.Name = "geckoWebBrowser2";
			this.geckoWebBrowser2.Size = new System.Drawing.Size(676, 72);
			this.geckoWebBrowser2.TabIndex = 5;
			this.geckoWebBrowser2.Click += new System.EventHandler(this.GeckoWebBrowser2Click);
			this.geckoWebBrowser2.Navigating += new Skybound.Gecko.GeckoNavigatingEventHandler(this.GeckoWebBrowser1Navigating);
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.splitContainer1.Location = new System.Drawing.Point(0, 72);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.panel1);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.cListView1);
			this.splitContainer1.Panel2.Controls.Add(this.ucToolbar2);
			this.splitContainer1.Panel2.Controls.Add(this.ucToolbar1);
			this.splitContainer1.Size = new System.Drawing.Size(676, 253);
			this.splitContainer1.SplitterDistance = 511;
			this.splitContainer1.TabIndex = 6;
			// 
			// panel1
			// 
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(511, 253);
			this.panel1.TabIndex = 8;
			this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel1Paint);
			// 
			// cListView1
			// 
			this.cListView1.AllowDrop = true;
			this.cListView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.cListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.columnHeader1,
									this.columnHeader2});
			this.cListView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cListView1.FullRowSelect = true;
			this.cListView1.Location = new System.Drawing.Point(0, 32);
			this.cListView1.Name = "cListView1";
			this.cListView1.Size = new System.Drawing.Size(161, 189);
			this.cListView1.TabIndex = 3;
			this.cListView1.UseCompatibleStateImageBehavior = false;
			this.cListView1.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Title";
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Artist";
			// 
			// ucToolbar2
			// 
			this.ucToolbar2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.ucToolbar2.Location = new System.Drawing.Point(0, 221);
			this.ucToolbar2.Name = "ucToolbar2";
			this.ucToolbar2.Size = new System.Drawing.Size(161, 32);
			this.ucToolbar2.TabIndex = 2;
			// 
			// ucToolbar1
			// 
			this.ucToolbar1.Dock = System.Windows.Forms.DockStyle.Top;
			this.ucToolbar1.Location = new System.Drawing.Point(0, 0);
			this.ucToolbar1.Name = "ucToolbar1";
			this.ucToolbar1.Size = new System.Drawing.Size(161, 32);
			this.ucToolbar1.TabIndex = 0;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(255)))), ((int)(((byte)(200)))));
			this.ClientSize = new System.Drawing.Size(676, 397);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.geckoWebBrowser2);
			this.Controls.Add(this.geckoWebBrowser1);
			this.Name = "MainForm";
			this.Text = "WebMedia Player";
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainFormPaint);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private CDON.ucToolbar ucToolbar2;
		private CDON.ucToolbar ucToolbar1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private CDON.CPlaylistView cListView1;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private Skybound.Gecko.GeckoWebBrowser geckoWebBrowser2;
		private Skybound.Gecko.GeckoWebBrowser geckoWebBrowser1;
		private System.Windows.Forms.Panel panel1;
	}
}
