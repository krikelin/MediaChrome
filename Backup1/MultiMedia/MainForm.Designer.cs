/*
 * Created by SharpDevelop.
 * User: Alex
 * Date: 2010-10-27
 * Time: 19:03
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace MediaChrome
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
            this.components = new System.ComponentModel.Container();
            this.geckoWebBrowser1 = new Skybound.Gecko.GeckoWebBrowser();
            this.geckoWebBrowser2 = new Skybound.Gecko.GeckoWebBrowser();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lAlbum = new System.Windows.Forms.Label();
            this.lArtist = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.geckoWebBrowser3 = new Skybound.Gecko.GeckoWebBrowser();
            this.ucToolbar2 = new MediaChrome.ucToolbar();
            this.ucToolbar1 = new MediaChrome.ucToolbar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.cListView1 = new MediaChrome.CPlaylistView();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.geckoWebBrowser2.Navigating += new Skybound.Gecko.GeckoNavigatingEventHandler(this.geckoWebBrowser2_Navigating);
            this.geckoWebBrowser2.Click += new System.EventHandler(this.GeckoWebBrowser2Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Title";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Artist";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.lAlbum);
            this.panel2.Controls.Add(this.lArtist);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 286);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(676, 39);
            this.panel2.TabIndex = 7;
            this.panel2.Tag = "%PERSISTANT";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(34, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(26, 24);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // lAlbum
            // 
            this.lAlbum.AutoSize = true;
            this.lAlbum.ForeColor = System.Drawing.Color.Olive;
            this.lAlbum.Location = new System.Drawing.Point(66, 19);
            this.lAlbum.Name = "lAlbum";
            this.lAlbum.Size = new System.Drawing.Size(27, 13);
            this.lAlbum.TabIndex = 0;
            this.lAlbum.Text = "Title";
            // 
            // lArtist
            // 
            this.lArtist.AutoSize = true;
            this.lArtist.ForeColor = System.Drawing.Color.Lime;
            this.lArtist.Location = new System.Drawing.Point(66, 6);
            this.lArtist.Name = "lArtist";
            this.lArtist.Size = new System.Drawing.Size(27, 13);
            this.lArtist.TabIndex = 0;
            this.lArtist.Text = "Title";
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
            this.splitContainer1.Size = new System.Drawing.Size(676, 214);
            this.splitContainer1.SplitterDistance = 511;
            this.splitContainer1.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.geckoWebBrowser3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(511, 214);
            this.panel1.TabIndex = 8;
            // 
            // geckoWebBrowser3
            // 
            this.geckoWebBrowser3.Dock = System.Windows.Forms.DockStyle.Left;
            this.geckoWebBrowser3.Location = new System.Drawing.Point(0, 0);
            this.geckoWebBrowser3.Name = "geckoWebBrowser3";
            this.geckoWebBrowser3.Size = new System.Drawing.Size(122, 214);
            this.geckoWebBrowser3.TabIndex = 0;
            this.geckoWebBrowser3.Visible = false;
            // 
            // ucToolbar2
            // 
            this.ucToolbar2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucToolbar2.Location = new System.Drawing.Point(0, 182);
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
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // cListView1
            // 
            this.cListView1.AllowDrop = true;
            this.cListView1.AlternateRows = true;
            this.cListView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.cListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cListView1.FullRowSelect = true;
            this.cListView1.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(211)))), ((int)(((byte)(255)))));
            this.cListView1.HighlightText = System.Drawing.Color.Black;
            this.cListView1.ItemHeight = 18;
            this.cListView1.Location = new System.Drawing.Point(0, 32);
            this.cListView1.Name = "cListView1";
            this.cListView1.ScrollX = 0;
            this.cListView1.ScrollY = 0;
            this.cListView1.Size = new System.Drawing.Size(161, 150);
            this.cListView1.TabIndex = 3;
            this.cListView1.UseCompatibleStateImageBehavior = false;
            this.cListView1.View = System.Windows.Forms.View.Details;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(255)))), ((int)(((byte)(200)))));
            this.ClientSize = new System.Drawing.Size(676, 397);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.geckoWebBrowser2);
            this.Controls.Add(this.geckoWebBrowser1);
            this.Name = "MainForm";
            this.Text = "Media Chrome Alpha 0.2.1";
            this.Load += new System.EventHandler(this.MainFormLoad);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainFormPaint);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
       
		private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
		public Skybound.Gecko.GeckoWebBrowser geckoWebBrowser2;
        public Skybound.Gecko.GeckoWebBrowser geckoWebBrowser1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lArtist;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private Skybound.Gecko.GeckoWebBrowser geckoWebBrowser3;
        private CPlaylistView cListView1;
        private ucToolbar ucToolbar2;
        private ucToolbar ucToolbar1;
        private System.Windows.Forms.Label lAlbum;
        private System.Windows.Forms.Timer timer1;
	}
}
