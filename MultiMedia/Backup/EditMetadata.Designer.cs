/*
 * Created by SharpDevelop.
 * User: Alex
 * Date: 2010-10-31
 * Time: 11:32
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace MultiMedia
{
	partial class EditMetadata
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
			this.lTitle = new System.Windows.Forms.TextBox();
			this.lArtist = new System.Windows.Forms.TextBox();
			this.lAlbum = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.lFeaturing = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.lVersion = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.lComposer = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.lContributing = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// lTitle
			// 
			this.lTitle.Location = new System.Drawing.Point(10, 35);
			this.lTitle.Name = "lTitle";
			this.lTitle.Size = new System.Drawing.Size(197, 20);
			this.lTitle.TabIndex = 0;
			// 
			// lArtist
			// 
			this.lArtist.Location = new System.Drawing.Point(10, 91);
			this.lArtist.Name = "lArtist";
			this.lArtist.Size = new System.Drawing.Size(197, 20);
			this.lArtist.TabIndex = 0;
			// 
			// lAlbum
			// 
			this.lAlbum.Location = new System.Drawing.Point(10, 199);
			this.lAlbum.Name = "lAlbum";
			this.lAlbum.Size = new System.Drawing.Size(333, 20);
			this.lAlbum.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(10, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 20);
			this.label1.TabIndex = 1;
			this.label1.Text = "Title";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(10, 68);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 20);
			this.label2.TabIndex = 1;
			this.label2.Text = "Artist";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(10, 176);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 20);
			this.label3.TabIndex = 1;
			this.label3.Text = "Album";
			// 
			// button1
			// 
			this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.button1.Location = new System.Drawing.Point(268, 236);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 2;
			this.button1.Text = "Cancel";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// button2
			// 
			this.button2.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.button2.Location = new System.Drawing.Point(187, 236);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 3;
			this.button2.Text = "OK";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.Button2Click);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(225, 9);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 20);
			this.label4.TabIndex = 1;
			this.label4.Text = "Track version";
			this.label4.Click += new System.EventHandler(this.Label4Click);
			// 
			// lFeaturing
			// 
			this.lFeaturing.Location = new System.Drawing.Point(225, 91);
			this.lFeaturing.Name = "lFeaturing";
			this.lFeaturing.Size = new System.Drawing.Size(118, 20);
			this.lFeaturing.TabIndex = 4;
			this.lFeaturing.TextChanged += new System.EventHandler(this.TextBox5TextChanged);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(225, 68);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(100, 20);
			this.label5.TabIndex = 1;
			this.label5.Text = "Featuring";
			// 
			// lVersion
			// 
			this.lVersion.FormattingEnabled = true;
			this.lVersion.Items.AddRange(new object[] {
									"",
									"Radio",
									"Extended",
									"Original",
									"Remix",
									"Studio"});
			this.lVersion.Location = new System.Drawing.Point(225, 32);
			this.lVersion.Name = "lVersion";
			this.lVersion.Size = new System.Drawing.Size(118, 21);
			this.lVersion.TabIndex = 5;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(10, 124);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(100, 20);
			this.label6.TabIndex = 1;
			this.label6.Text = "Composer";
			// 
			// lComposer
			// 
			this.lComposer.Location = new System.Drawing.Point(12, 147);
			this.lComposer.Name = "lComposer";
			this.lComposer.Size = new System.Drawing.Size(195, 20);
			this.lComposer.TabIndex = 0;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(225, 124);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(100, 20);
			this.label7.TabIndex = 1;
			this.label7.Text = "Contributing Artist";
			this.label7.Click += new System.EventHandler(this.Label7Click);
			// 
			// lContributing
			// 
			this.lContributing.Location = new System.Drawing.Point(225, 147);
			this.lContributing.Name = "lContributing";
			this.lContributing.Size = new System.Drawing.Size(118, 20);
			this.lContributing.TabIndex = 4;
			this.lContributing.TextChanged += new System.EventHandler(this.TextBox5TextChanged);
			// 
			// EditMetadata
			// 
			this.AcceptButton = this.button2;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.button1;
			this.ClientSize = new System.Drawing.Size(360, 280);
			this.Controls.Add(this.lVersion);
			this.Controls.Add(this.lContributing);
			this.Controls.Add(this.lFeaturing);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lAlbum);
			this.Controls.Add(this.lComposer);
			this.Controls.Add(this.lArtist);
			this.Controls.Add(this.lTitle);
			this.Name = "EditMetadata";
			this.Text = "EditMetadata";
			this.Load += new System.EventHandler(this.EditMetadataLoad);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.ComboBox lVersion;
		private System.Windows.Forms.TextBox lComposer;
		private System.Windows.Forms.TextBox lContributing;
		private System.Windows.Forms.TextBox lTitle;
		private System.Windows.Forms.TextBox lArtist;
		private System.Windows.Forms.TextBox lAlbum;
		private System.Windows.Forms.TextBox lFeaturing;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
	}
}
