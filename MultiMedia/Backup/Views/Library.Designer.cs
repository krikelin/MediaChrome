/*
 * Created by SharpDevelop.
 * User: Alex
 * Date: 2010-10-27
 * Time: 22:41
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace CDON
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
			System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Artists");
			System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Album");
			System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Purchases");
			System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Library", new System.Windows.Forms.TreeNode[] {
									treeNode1,
									treeNode2,
									treeNode3});
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.cTreeView1 = new CDON.CTreeView();
			this.panel1 = new System.Windows.Forms.Panel();
			this.ucToolbar4 = new CDON.ucToolbar();
			this.ucToolbar2 = new CDON.ucToolbar();
			this.cListView1 = new CDON.CListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.playToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editMetadataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.remoevToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.collaborationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.panel2 = new System.Windows.Forms.Panel();
			this.geckoWebBrowser1 = new Skybound.Gecko.GeckoWebBrowser();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.ucToolbar3 = new CDON.ucToolbar();
			this.ucButton2 = new CDON.ucButton();
			this.ucButton1 = new CDON.ucButton();
			this.ucToolbar1 = new CDON.ucToolbar();
			this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.contextMenuStrip1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.cTreeView1);
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
			this.splitContainer1.TabIndex = 0;
			this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.SplitContainer1SplitterMoved);
			// 
			// cTreeView1
			// 
			this.cTreeView1.AllowDrop = true;
			this.cTreeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.cTreeView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cTreeView1.Location = new System.Drawing.Point(0, 32);
			this.cTreeView1.Name = "cTreeView1";
			treeNode1.Name = "Artists";
			treeNode1.Text = "Artists";
			treeNode2.Name = "Albums";
			treeNode2.Text = "Album";
			treeNode3.Name = "Node3";
			treeNode3.Text = "Purchases";
			treeNode4.Name = "Library";
			treeNode4.Text = "Library";
			this.cTreeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
									treeNode4});
			this.cTreeView1.Size = new System.Drawing.Size(107, 402);
			this.cTreeView1.TabIndex = 13;
			this.cTreeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.CTreeView1AfterSelect);
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
			this.cListView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.cListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.columnHeader1,
									this.columnHeader2,
									this.columnHeader3,
									this.columnHeader4,
									this.columnHeader6,
									this.columnHeader7,
									this.columnHeader8});
			this.cListView1.ContextMenuStrip = this.contextMenuStrip1;
			this.cListView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cListView1.FullRowSelect = true;
			this.cListView1.Location = new System.Drawing.Point(0, 185);
			this.cListView1.Name = "cListView1";
			this.cListView1.Size = new System.Drawing.Size(541, 399);
			this.cListView1.TabIndex = 13;
			this.cListView1.UseCompatibleStateImageBehavior = false;
			this.cListView1.View = System.Windows.Forms.View.Details;
			this.cListView1.DoubleClick += new System.EventHandler(this.CListView1DoubleClick);
			this.cListView1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CListView1KeyPress);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Titel";
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Track Version";
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Artist";
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Album";
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "Featuring";
			// 
			// columnHeader7
			// 
			this.columnHeader7.Text = "Contributing";
			// 
			// columnHeader8
			// 
			this.columnHeader8.Text = "Store";
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.playToolStripMenuItem,
									this.editMetadataToolStripMenuItem,
									this.remoevToolStripMenuItem,
									this.toolStripMenuItem1,
									this.collaborationsToolStripMenuItem,
									this.toolStripMenuItem2,
									this.exitToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(148, 126);
			// 
			// playToolStripMenuItem
			// 
			this.playToolStripMenuItem.Name = "playToolStripMenuItem";
			this.playToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
			this.playToolStripMenuItem.Text = "Play";
			// 
			// editMetadataToolStripMenuItem
			// 
			this.editMetadataToolStripMenuItem.Name = "editMetadataToolStripMenuItem";
			this.editMetadataToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
			this.editMetadataToolStripMenuItem.Text = "Edit Metadata";
			this.editMetadataToolStripMenuItem.Click += new System.EventHandler(this.EditMetadataToolStripMenuItemClick);
			// 
			// remoevToolStripMenuItem
			// 
			this.remoevToolStripMenuItem.Name = "remoevToolStripMenuItem";
			this.remoevToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
			this.remoevToolStripMenuItem.Text = "Remove";
			this.remoevToolStripMenuItem.Click += new System.EventHandler(this.RemoevToolStripMenuItemClick);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(144, 6);
			// 
			// collaborationsToolStripMenuItem
			// 
			this.collaborationsToolStripMenuItem.Name = "collaborationsToolStripMenuItem";
			this.collaborationsToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
			this.collaborationsToolStripMenuItem.Text = "Share";
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(144, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.geckoWebBrowser1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 32);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(541, 153);
			this.panel2.TabIndex = 12;
			this.panel2.Visible = false;
			// 
			// geckoWebBrowser1
			// 
			this.geckoWebBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.geckoWebBrowser1.Location = new System.Drawing.Point(0, 0);
			this.geckoWebBrowser1.Name = "geckoWebBrowser1";
			this.geckoWebBrowser1.Size = new System.Drawing.Size(541, 153);
			this.geckoWebBrowser1.TabIndex = 1;
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
			this.ucToolbar3.Size = new System.Drawing.Size(541, 32);
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
			this.ucToolbar1.Size = new System.Drawing.Size(541, 32);
			this.ucToolbar1.TabIndex = 5;
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
		private System.Windows.Forms.ColumnHeader columnHeader8;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem collaborationsToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem remoevToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editMetadataToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem playToolStripMenuItem;
		private Skybound.Gecko.GeckoWebBrowser geckoWebBrowser1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel1;
		private CDON.ucButton ucButton2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private CDON.ucToolbar ucToolbar3;
		private CDON.ucToolbar ucToolbar4;
		private CDON.CTreeView cTreeView1;
		private CDON.ucToolbar ucToolbar2;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private CDON.ucButton ucButton1;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private CDON.CListView cListView1;
		private CDON.ucToolbar ucToolbar1;
	}
}
