/*
 * Created by SharpDevelop.
 * User: Alex
 * Date: 2010-11-02
 * Time: 14:13
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace MultiMedia.Views
{
	partial class Playlist
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
			this.ucToolbar1 = new CDON.ucToolbar();
			this.cListView1 = new CDON.CListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// ucToolbar1
			// 
			this.ucToolbar1.Dock = System.Windows.Forms.DockStyle.Top;
			this.ucToolbar1.Location = new System.Drawing.Point(0, 0);
			this.ucToolbar1.Name = "ucToolbar1";
			this.ucToolbar1.Size = new System.Drawing.Size(435, 27);
			this.ucToolbar1.TabIndex = 0;
			this.ucToolbar1.Load += new System.EventHandler(this.UcToolbar1Load);
			// 
			// cListView1
			// 
			this.cListView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.cListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.columnHeader1,
									this.columnHeader2,
									this.columnHeader3});
			this.cListView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cListView1.FullRowSelect = true;
			this.cListView1.Location = new System.Drawing.Point(0, 27);
			this.cListView1.Name = "cListView1";
			this.cListView1.Size = new System.Drawing.Size(435, 358);
			this.cListView1.TabIndex = 1;
			this.cListView1.UseCompatibleStateImageBehavior = false;
			this.cListView1.View = System.Windows.Forms.View.Details;
			this.cListView1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CListView1MouseUp);
			this.cListView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CListView1MouseDown);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Title";
			this.columnHeader1.Width = 98;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Artist";
			this.columnHeader2.Width = 90;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Album";
			// 
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.Timer1Tick);
			// 
			// Playlist
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.cListView1);
			this.Controls.Add(this.ucToolbar1);
			this.Name = "Playlist";
			this.Size = new System.Drawing.Size(435, 385);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private CDON.CListView cListView1;
		private CDON.ucToolbar ucToolbar1;
	}
}
