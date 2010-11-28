/*
 * Created by SharpDevelop.
 * User: Alex
 * Date: 2010-10-27
 * Time: 22:41
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace MediaChrome
{
	partial class Library
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cListView2 = new MediaChrome.CListView();
            this.ucToolbar4 = new MediaChrome.ucToolbar();
            this.ucToolbar2 = new MediaChrome.ucToolbar();
            this.cListView1 = new MediaChrome.CListView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editMetadataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.remoevToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.collaborationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.geckoWebBrowser1 = new Skybound.Gecko.GeckoWebBrowser();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ucToolbar3 = new MediaChrome.ucToolbar();
            this.ucButton2 = new MediaChrome.ucButton();
            this.ucButton1 = new MediaChrome.ucButton();
            this.ucToolbar1 = new MediaChrome.ucToolbar();
            this.playToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.artist1 = new MediaChrome.Views.Artist();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 434);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(107, 150);
            this.panel1.TabIndex = 12;
            this.panel1.Visible = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.cListView2);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1.Controls.Add(this.ucToolbar4);
            this.splitContainer1.Panel1.Controls.Add(this.ucToolbar2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.cListView1);
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Panel2.Controls.Add(this.textBox1);
            this.splitContainer1.Panel2.Controls.Add(this.ucToolbar3);
            this.splitContainer1.Panel2.Controls.Add(this.ucButton2);
            this.splitContainer1.Panel2.Controls.Add(this.ucButton1);
            this.splitContainer1.Panel2.Controls.Add(this.ucToolbar1);
            this.splitContainer1.Size = new System.Drawing.Size(652, 616);
            this.splitContainer1.SplitterDistance = 107;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.SplitContainer1SplitterMoved);
            // 
            // cListView2
            // 
            this.cListView2.AlternateRows = true;
            this.cListView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cListView2.EngineImages = null;
            this.cListView2.FullRowSelect = true;
            this.cListView2.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(211)))), ((int)(((byte)(255)))));
            this.cListView2.HighlightText = System.Drawing.Color.Black;
            this.cListView2.ItemHeight = 18;
            this.cListView2.ListViewItemSorter = null;
            this.cListView2.Location = new System.Drawing.Point(0, 32);
            this.cListView2.Name = "cListView2";
            this.cListView2.ScrollY = 0;
            this.cListView2.Size = new System.Drawing.Size(107, 402);
            this.cListView2.Sorting = System.Windows.Forms.SortOrder.None;
            this.cListView2.TabIndex = 13;
            // 
            // ucToolbar4
            // 
            this.ucToolbar4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucToolbar4.Location = new System.Drawing.Point(0, 584);
            this.ucToolbar4.Name = "ucToolbar4";
            this.ucToolbar4.Size = new System.Drawing.Size(107, 32);
            this.ucToolbar4.TabIndex = 10;
            // 
            // ucToolbar2
            // 
            this.ucToolbar2.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucToolbar2.Location = new System.Drawing.Point(0, 0);
            this.ucToolbar2.Name = "ucToolbar2";
            this.ucToolbar2.Size = new System.Drawing.Size(107, 32);
            this.ucToolbar2.TabIndex = 6;
            // 
            // cListView1
            // 
            this.cListView1.AllowDrop = true;
            this.cListView1.AlternateRows = true;
            this.cListView1.ContextMenuStrip = this.contextMenuStrip1;
            this.cListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cListView1.EngineImages = null;
            this.cListView1.FullRowSelect = true;
            this.cListView1.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(211)))), ((int)(((byte)(255)))));
            this.cListView1.HighlightText = System.Drawing.Color.Black;
            this.cListView1.ItemHeight = 18;
            this.cListView1.ListViewItemSorter = null;
            this.cListView1.Location = new System.Drawing.Point(0, 185);
            this.cListView1.Name = "cListView1";
            this.cListView1.ScrollY = 0;
            this.cListView1.Size = new System.Drawing.Size(544, 399);
            this.cListView1.Sorting = System.Windows.Forms.SortOrder.None;
            this.cListView1.TabIndex = 13;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editMetadataToolStripMenuItem,
            this.remoevToolStripMenuItem,
            this.toolStripMenuItem1,
            this.collaborationsToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(142, 76);
            // 
            // editMetadataToolStripMenuItem
            // 
            this.editMetadataToolStripMenuItem.Name = "editMetadataToolStripMenuItem";
            this.editMetadataToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.editMetadataToolStripMenuItem.Text = "Edit Metadata";
            this.editMetadataToolStripMenuItem.Click += new System.EventHandler(this.EditMetadataToolStripMenuItemClick);
            // 
            // remoevToolStripMenuItem
            // 
            this.remoevToolStripMenuItem.Name = "remoevToolStripMenuItem";
            this.remoevToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.remoevToolStripMenuItem.Text = "Remove";
            this.remoevToolStripMenuItem.Click += new System.EventHandler(this.RemoevToolStripMenuItemClick);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(138, 6);
            // 
            // collaborationsToolStripMenuItem
            // 
            this.collaborationsToolStripMenuItem.Name = "collaborationsToolStripMenuItem";
            this.collaborationsToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.collaborationsToolStripMenuItem.Text = "Share";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.geckoWebBrowser1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 32);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(544, 153);
            this.panel2.TabIndex = 12;
            this.panel2.Visible = false;
            // 
            // geckoWebBrowser1
            // 
            this.geckoWebBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.geckoWebBrowser1.Location = new System.Drawing.Point(0, 0);
            this.geckoWebBrowser1.Name = "geckoWebBrowser1";
            this.geckoWebBrowser1.Size = new System.Drawing.Size(544, 153);
            this.geckoWebBrowser1.TabIndex = 1;
            this.geckoWebBrowser1.Click += new System.EventHandler(this.geckoWebBrowser1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(227, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 10;
            // 
            // ucToolbar3
            // 
            this.ucToolbar3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucToolbar3.Location = new System.Drawing.Point(0, 584);
            this.ucToolbar3.Name = "ucToolbar3";
            this.ucToolbar3.Size = new System.Drawing.Size(544, 32);
            this.ucToolbar3.TabIndex = 8;
            // 
            // ucButton2
            // 
            this.ucButton2.Icon = null;
            this.ucButton2.Label = "Find";
            this.ucButton2.Location = new System.Drawing.Point(344, 6);
            this.ucButton2.Name = "ucButton2";
            this.ucButton2.Size = new System.Drawing.Size(68, 20);
            this.ucButton2.TabIndex = 7;
            this.ucButton2.Load += new System.EventHandler(this.UcButton2Load);
            this.ucButton2.Click += new System.EventHandler(this.UcButton2Click);
            // 
            // ucButton1
            // 
            this.ucButton1.Icon = null;
            this.ucButton1.Label = "Import from computer";
            this.ucButton1.Location = new System.Drawing.Point(7, 6);
            this.ucButton1.Name = "ucButton1";
            this.ucButton1.Size = new System.Drawing.Size(143, 20);
            this.ucButton1.TabIndex = 7;
            this.ucButton1.Click += new System.EventHandler(this.UcButton1Click);
            // 
            // ucToolbar1
            // 
            this.ucToolbar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucToolbar1.Location = new System.Drawing.Point(0, 0);
            this.ucToolbar1.Name = "ucToolbar1";
            this.ucToolbar1.Size = new System.Drawing.Size(544, 32);
            this.ucToolbar1.TabIndex = 5;
            this.ucToolbar1.Load += new System.EventHandler(this.ucToolbar1_Load);
            // 
            // playToolStripMenuItem
            // 
            this.playToolStripMenuItem.Name = "playToolStripMenuItem";
            this.playToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.playToolStripMenuItem.Text = "Play";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(138, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Track Version";
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Titel";
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Contributing";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // artist1
            // 
            this.artist1.AllowDrop = true;
            this.artist1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(255)))), ((int)(((byte)(245)))));
            this.artist1.CurrentView = null;
            this.artist1.History = null;
            this.artist1.Location = new System.Drawing.Point(0, 0);
            this.artist1.Name = "artist1";
            this.artist1.Post = null;
            this.artist1.Size = new System.Drawing.Size(934, 779);
            this.artist1.TabIndex = 0;
            // 
            // Library
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "Library";
            this.Size = new System.Drawing.Size(652, 616);
            this.VisibleChanged += new System.EventHandler(this.LibraryVisibleChanged);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private ucToolbar ucToolbar1;
        private ucButton ucButton1;
        private ucButton ucButton2;
        private ucToolbar ucToolbar3;
        private ucToolbar ucToolbar2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private ucToolbar ucToolbar4;
        private CListView cListView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editMetadataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem remoevToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem collaborationsToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private Skybound.Gecko.GeckoWebBrowser geckoWebBrowser1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolStripMenuItem playToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Timer timer1;
        private MediaChrome.Views.Artist artist1;
        private CListView cListView2;
	}
}
