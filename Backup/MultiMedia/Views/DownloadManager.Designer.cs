/*
 * Created by SharpDevelop.
 * User: Alex
 * Date: 2010-10-27
 * Time: 20:17
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace MediaChrome
{
	partial class DownloadManager
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
			this.ucToolbar1 = new MediaChrome.ucToolbar();
			this.cListView1 = new MediaChrome.CListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
			this.ucButton1 = new MediaChrome.ucButton();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.ucToolbar2 = new MediaChrome.ucToolbar();
			this.SuspendLayout();
			// 
			// ucToolbar1
			// 
			this.ucToolbar1.Dock = System.Windows.Forms.DockStyle.Top;
			this.ucToolbar1.Location = new System.Drawing.Point(0, 0);
			this.ucToolbar1.Name = "ucToolbar1";
			this.ucToolbar1.Size = new System.Drawing.Size(452, 32);
			this.ucToolbar1.TabIndex = 5;
			// 
			// cListView1
			// 
			this.cListView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.cListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.columnHeader1,
									this.columnHeader2,
									this.columnHeader3,
									this.columnHeader4,
									this.columnHeader5});
			this.cListView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cListView1.FullRowSelect = true;
			this.cListView1.Location = new System.Drawing.Point(0, 32);
			this.cListView1.Name = "cListView1";
			this.cListView1.Size = new System.Drawing.Size(452, 491);
			this.cListView1.TabIndex = 6;
	//		this.cListView1.UseCompatibleStateImageBehavior = false;
		//	this.cListView1.View = System.Windows.Forms.View.Details;
			this.cListView1.SelectedIndexChanged += new System.EventHandler(this.CListView1SelectedIndexChanged);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "File";
			this.columnHeader1.Width = 94;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Author";
			this.columnHeader2.Width = 184;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Compilation";
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Type";
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "Proces";
			// 
			// ucButton1
			// 
			this.ucButton1.Icon = null;
			this.ucButton1.Label = "Restartr";
			this.ucButton1.Location = new System.Drawing.Point(18, 4);
			this.ucButton1.Name = "ucButton1";
			this.ucButton1.Size = new System.Drawing.Size(164, 22);
			this.ucButton1.TabIndex = 7;
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 1000;
			this.timer1.Tick += new System.EventHandler(this.Timer1Tick);
			// 
			// ucToolbar2
			// 
			this.ucToolbar2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.ucToolbar2.Location = new System.Drawing.Point(0, 491);
			this.ucToolbar2.Name = "ucToolbar2";
			this.ucToolbar2.Size = new System.Drawing.Size(452, 32);
			this.ucToolbar2.TabIndex = 8;
			// 
			// DownloadManager
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.ucToolbar2);
			this.Controls.Add(this.ucButton1);
			this.Controls.Add(this.cListView1);
			this.Controls.Add(this.ucToolbar1);
			this.Name = "DownloadManager";
			this.Size = new System.Drawing.Size(452, 523);
			this.ResumeLayout(false);
		}
		private MediaChrome.ucToolbar ucToolbar2;
		private System.Windows.Forms.Timer timer1;
		private MediaChrome.ucButton ucButton1;
		private MediaChrome.ucToolbar ucToolbar1;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private MediaChrome.CListView cListView1;
	}
}
