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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Library));
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "tes",
            "test"}, -1);
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.geckoWebBrowser1 = new Skybound.Gecko.GeckoWebBrowser();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.playToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.cListView2 = new MediaChrome.CListView();
            this.ucToolbar4 = new MediaChrome.ucToolbar();
            this.ucToolbar2 = new MediaChrome.ucToolbar();
            this.cListView1 = new MediaChrome.CListView();
            this.ucToolbar3 = new MediaChrome.ucToolbar();
            this.ucButton2 = new MediaChrome.ucButton();
            this.ucButton1 = new MediaChrome.ucButton();
            this.ucToolbar1 = new MediaChrome.ucToolbar();
            this.artist1 = new MediaChrome.Views.Artist();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 349);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(209, 150);
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
            this.splitContainer1.Panel1.Controls.Add(this.comboBox1);
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
            this.splitContainer1.Size = new System.Drawing.Size(874, 531);
            this.splitContainer1.SplitterDistance = 209;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.SplitContainer1SplitterMoved);
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(3, 5);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(201, 21);
            this.comboBox1.TabIndex = 14;
            this.comboBox1.SelectedValueChanged += new System.EventHandler(this.comboBox1_SelectedValueChanged);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "playlist16.png");
            this.imageList1.Images.SetKeyName(1, "new_playlist16.png");
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "star_off.png");
            this.imageList2.Images.SetKeyName(1, "speaker_green.png");
            this.imageList2.Images.SetKeyName(2, "star_on.png");
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.geckoWebBrowser1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 32);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(664, 153);
            this.panel2.TabIndex = 12;
            this.panel2.Visible = false;
            // 
            // geckoWebBrowser1
            // 
            this.geckoWebBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.geckoWebBrowser1.Location = new System.Drawing.Point(0, 0);
            this.geckoWebBrowser1.Name = "geckoWebBrowser1";
            this.geckoWebBrowser1.Size = new System.Drawing.Size(664, 153);
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
            // contextMenu1
            // 
            this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem2,
            this.menuItem3});
            this.contextMenu1.Popup += new System.EventHandler(this.contextMenu1_Popup);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.Tag = "Playback";
            this.menuItem1.Text = "Play";
            this.menuItem1.Popup += new System.EventHandler(this.menuItem1_Popup);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 1;
            this.menuItem2.Text = "-";
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 2;
            this.menuItem3.Text = "Properties";
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // cListView2
            // 
            this.cListView2.AllowDrop = true;
            this.cListView2.AlternateRows = true;
            this.cListView2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.cListView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cListView2.FullRowSelect = true;
            this.cListView2.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(211)))), ((int)(((byte)(255)))));
            this.cListView2.HighlightText = System.Drawing.Color.Black;
            this.cListView2.ItemHeight = 18;
            this.cListView2.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.cListView2.LargeImageList = this.imageList1;
            this.cListView2.Location = new System.Drawing.Point(0, 32);
            this.cListView2.Name = "cListView2";
            this.cListView2.ScrollX = 0;
            this.cListView2.ScrollY = 0;
            this.cListView2.Size = new System.Drawing.Size(209, 317);
            this.cListView2.SmallImageList = this.imageList1;
            this.cListView2.TabIndex = 13;
            this.cListView2.Tag = "%LIGHTER";
            this.cListView2.UseCompatibleStateImageBehavior = false;
            this.cListView2.View = System.Windows.Forms.View.Details;
            this.cListView2.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.cListView2_AfterLabelEdit);
            this.cListView2.BeforeLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.cListView2_BeforeLabelEdit);
            this.cListView2.SelectedIndexChanged += new System.EventHandler(this.cListView2_SelectedIndexChanged);
            this.cListView2.DragDrop += new System.Windows.Forms.DragEventHandler(this.cListView2_DragDrop);
            this.cListView2.DragEnter += new System.Windows.Forms.DragEventHandler(this.cListView2_DragEnter);
            this.cListView2.DragOver += new System.Windows.Forms.DragEventHandler(this.cListView2_DragOver);
            this.cListView2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cListView2_MouseDown);
            this.cListView2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cListView2_MouseDown);
            this.cListView2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.cListView2_MouseUp);
            // 
            // ucToolbar4
            // 
            this.ucToolbar4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucToolbar4.Location = new System.Drawing.Point(0, 499);
            this.ucToolbar4.Name = "ucToolbar4";
            this.ucToolbar4.Size = new System.Drawing.Size(209, 32);
            this.ucToolbar4.TabIndex = 10;
            // 
            // ucToolbar2
            // 
            this.ucToolbar2.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucToolbar2.Location = new System.Drawing.Point(0, 0);
            this.ucToolbar2.Name = "ucToolbar2";
            this.ucToolbar2.Size = new System.Drawing.Size(209, 32);
            this.ucToolbar2.TabIndex = 6;
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
            this.cListView1.Location = new System.Drawing.Point(0, 185);
            this.cListView1.Name = "cListView1";
            this.cListView1.ScrollX = 0;
            this.cListView1.ScrollY = 0;
            this.cListView1.Size = new System.Drawing.Size(664, 314);
            this.cListView1.SmallImageList = this.imageList2;
            this.cListView1.TabIndex = 13;
            this.cListView1.UseCompatibleStateImageBehavior = false;
            this.cListView1.View = System.Windows.Forms.View.Details;
            this.cListView1.SelectedIndexChanged += new System.EventHandler(this.cListView1_SelectedIndexChanged_1);
            this.cListView1.DoubleClick += new System.EventHandler(this.cListView1_DoubleClick);
            this.cListView1.MouseDown +=new System.Windows.Forms.MouseEventHandler(Library_MouseDown);
            this.cListView1.MouseUp +=new System.Windows.Forms.MouseEventHandler(Library_MouseDown);
            
            // 
            // ucToolbar3
            // 
            this.ucToolbar3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucToolbar3.Location = new System.Drawing.Point(0, 499);
            this.ucToolbar3.Name = "ucToolbar3";
            this.ucToolbar3.Size = new System.Drawing.Size(664, 32);
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
            this.ucButton1.Load += new System.EventHandler(this.ucButton1_Load);
            this.ucButton1.Click += new System.EventHandler(this.UcButton1Click);
            // 
            // ucToolbar1
            // 
            this.ucToolbar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucToolbar1.Location = new System.Drawing.Point(0, 0);
            this.ucToolbar1.Name = "ucToolbar1";
            this.ucToolbar1.Size = new System.Drawing.Size(664, 32);
            this.ucToolbar1.TabIndex = 5;
            this.ucToolbar1.Load += new System.EventHandler(this.ucToolbar1_Load);
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
            this.Size = new System.Drawing.Size(874, 531);
            this.Load += new System.EventHandler(this.Library_Load);
            this.VisibleChanged += new System.EventHandler(this.LibraryVisibleChanged);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

		void Library_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			try
			{
			tMr.Stop();
			timer2.Stop();
			timer1.Stop();
			
			}
			catch
			{
			
			}
		}
		void Library_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			try
			{
				tMr.Start();
				timer2.Start();
				timer1.Start();
			}
			catch
			{
			}
			
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
        private System.Windows.Forms.ContextMenu contextMenu1;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.Timer timer2;
	}
}
