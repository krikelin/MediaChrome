/*
 * Created by SharpDevelop.
 * User: Alex
 * Date: 2010-10-29
 * Time: 19:48
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace MediaChrome
{
	partial class Podcasts
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
			System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Podcasts");
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.ucToolbar1 = new MediaChrome.ucToolbar();
			this.ucToolbar2 = new MediaChrome.ucToolbar();
			this.ucToolbar3 = new MediaChrome.ucToolbar();
			this.ucToolbar4 = new MediaChrome.ucToolbar();
			this.cTreeView1 = new MediaChrome.CTreeView();
			this.cListView1 = new MediaChrome.CListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
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
			this.splitContainer1.Panel1.Controls.Add(this.ucToolbar4);
			this.splitContainer1.Panel1.Controls.Add(this.ucToolbar3);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.cListView1);
			this.splitContainer1.Panel2.Controls.Add(this.ucToolbar2);
			this.splitContainer1.Panel2.Controls.Add(this.ucToolbar1);
			this.splitContainer1.Size = new System.Drawing.Size(460, 455);
			this.splitContainer1.SplitterDistance = 153;
			this.splitContainer1.TabIndex = 0;
			// 
			// ucToolbar1
			// 
			this.ucToolbar1.Dock = System.Windows.Forms.DockStyle.Top;
			this.ucToolbar1.Location = new System.Drawing.Point(0, 0);
			this.ucToolbar1.Name = "ucToolbar1";
			this.ucToolbar1.Size = new System.Drawing.Size(303, 32);
			this.ucToolbar1.TabIndex = 1;
			// 
			// ucToolbar2
			// 
			this.ucToolbar2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.ucToolbar2.Location = new System.Drawing.Point(0, 423);
			this.ucToolbar2.Name = "ucToolbar2";
			this.ucToolbar2.Size = new System.Drawing.Size(303, 32);
			this.ucToolbar2.TabIndex = 2;
			// 
			// ucToolbar3
			// 
			this.ucToolbar3.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.ucToolbar3.Location = new System.Drawing.Point(0, 423);
			this.ucToolbar3.Name = "ucToolbar3";
			this.ucToolbar3.Size = new System.Drawing.Size(153, 32);
			this.ucToolbar3.TabIndex = 3;
			// 
			// ucToolbar4
			// 
			this.ucToolbar4.Dock = System.Windows.Forms.DockStyle.Top;
			this.ucToolbar4.Location = new System.Drawing.Point(0, 0);
			this.ucToolbar4.Name = "ucToolbar4";
			this.ucToolbar4.Size = new System.Drawing.Size(153, 32);
			this.ucToolbar4.TabIndex = 4;
			// 
			// cTreeView1
			// 
			this.cTreeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.cTreeView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cTreeView1.Location = new System.Drawing.Point(0, 32);
			this.cTreeView1.Name = "cTreeView1";
			treeNode2.Name = "Node0";
			treeNode2.Text = "Podcasts";
			this.cTreeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
									treeNode2});
			this.cTreeView1.Size = new System.Drawing.Size(153, 391);
			this.cTreeView1.TabIndex = 5;
			// 
			// cListView1
			// 
			this.cListView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.cListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.columnHeader1,
									this.columnHeader2});
			this.cListView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cListView1.FullRowSelect = true;
			this.cListView1.Location = new System.Drawing.Point(0, 32);
			this.cListView1.Name = "cListView1";
			this.cListView1.Size = new System.Drawing.Size(303, 391);
			this.cListView1.TabIndex = 3;
	//		this.cListView1.UseCompatibleStateImageBehavior = false;
		//	this.cListView1.View = System.Windows.Forms.View.Details;
			this.cListView1.SelectedIndexChanged += new System.EventHandler(this.CListView1SelectedIndexChanged);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Title";
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Airdate";
			// 
			// Podcasts
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.splitContainer1);
			this.Name = "Podcasts";
			this.Size = new System.Drawing.Size(460, 455);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private MediaChrome.ucToolbar ucToolbar1;
		private MediaChrome.ucToolbar ucToolbar2;
		private MediaChrome.CListView cListView1;
		private MediaChrome.ucToolbar ucToolbar3;
		private MediaChrome.ucToolbar ucToolbar4;
		private MediaChrome.CTreeView cTreeView1;
		private System.Windows.Forms.SplitContainer splitContainer1;
	}
}
