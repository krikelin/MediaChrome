/*
 * Created by SharpDevelop.
 * User: Alex
 * Date: 2010-10-28
 * Time: 12:39
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace CDON
{
	partial class Settings
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
			this.colorDialog1 = new System.Windows.Forms.ColorDialog();
			this.colorDialog2 = new System.Windows.Forms.ColorDialog();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.checkBox3 = new System.Windows.Forms.CheckBox();
			this.checkBox5 = new System.Windows.Forms.CheckBox();
			this.colorChooser1 = new Snowball.colorChooser();
			this.checkBox4 = new System.Windows.Forms.CheckBox();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.bgColor = new System.Windows.Forms.PictureBox();
			this.fgColor = new System.Windows.Forms.PictureBox();
			this.altColor = new System.Windows.Forms.PictureBox();
			this.tColor = new System.Windows.Forms.PictureBox();
			this.hColor = new System.Windows.Forms.PictureBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label2 = new System.Windows.Forms.Label();
			this.tfColor = new System.Windows.Forms.PictureBox();
			this.checkBox6 = new System.Windows.Forms.CheckBox();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.bgColor)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fgColor)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.altColor)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tColor)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.hColor)).BeginInit();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tfColor)).BeginInit();
			this.SuspendLayout();
			// 
			// checkBox1
			// 
			this.checkBox1.Location = new System.Drawing.Point(437, 68);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(104, 21);
			this.checkBox1.TabIndex = 2;
			this.checkBox1.Text = "Dark theme";
			this.checkBox1.UseVisualStyleBackColor = true;
			this.checkBox1.CheckedChanged += new System.EventHandler(this.CheckBox1CheckedChanged);
			// 
			// checkBox2
			// 
			this.checkBox2.Location = new System.Drawing.Point(437, 184);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(231, 21);
			this.checkBox2.TabIndex = 3;
			this.checkBox2.Text = "Alternate rows in lists";
			this.checkBox2.UseVisualStyleBackColor = true;
			this.checkBox2.CheckedChanged += new System.EventHandler(this.CheckBox2CheckedChanged);
			// 
			// checkBox3
			// 
			this.checkBox3.Location = new System.Drawing.Point(437, 144);
			this.checkBox3.Name = "checkBox3";
			this.checkBox3.Size = new System.Drawing.Size(191, 21);
			this.checkBox3.TabIndex = 4;
			this.checkBox3.Text = "Diffrent playlist colour";
			this.checkBox3.UseVisualStyleBackColor = true;
			this.checkBox3.CheckedChanged += new System.EventHandler(this.CheckBox3CheckedChanged);
			// 
			// checkBox5
			// 
			this.checkBox5.Location = new System.Drawing.Point(4, 3);
			this.checkBox5.Name = "checkBox5";
			this.checkBox5.Size = new System.Drawing.Size(191, 21);
			this.checkBox5.TabIndex = 4;
			this.checkBox5.Text = "Custom Colors";
			this.checkBox5.UseVisualStyleBackColor = true;
			this.checkBox5.CheckedChanged += new System.EventHandler(this.CheckBox5CheckedChanged);
			// 
			// colorChooser1
			// 
			this.colorChooser1.Brightness = 50;
			this.colorChooser1.Hue = 0;
			this.colorChooser1.Location = new System.Drawing.Point(12, 59);
			this.colorChooser1.Name = "colorChooser1";
			this.colorChooser1.Saturation = 100;
			this.colorChooser1.Size = new System.Drawing.Size(406, 234);
			this.colorChooser1.TabIndex = 10;
			this.colorChooser1.Value = System.Drawing.Color.Red;
			// 
			// checkBox4
			// 
			this.checkBox4.Location = new System.Drawing.Point(437, 105);
			this.checkBox4.Name = "checkBox4";
			this.checkBox4.Size = new System.Drawing.Size(191, 21);
			this.checkBox4.TabIndex = 5;
			this.checkBox4.Text = "Fade contributions";
			this.checkBox4.UseVisualStyleBackColor = true;
			this.checkBox4.CheckedChanged += new System.EventHandler(this.CheckBox4CheckedChanged);
			// 
			// linkLabel1
			// 
			this.linkLabel1.LinkColor = System.Drawing.Color.Turquoise;
			this.linkLabel1.Location = new System.Drawing.Point(25, 296);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(103, 14);
			this.linkLabel1.TabIndex = 13;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "Apply";
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel1LinkClicked);
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.panel2.BackColor = System.Drawing.Color.Gray;
			this.panel2.Controls.Add(this.checkBox5);
			this.panel2.Location = new System.Drawing.Point(0, 344);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(683, 27);
			this.panel2.TabIndex = 14;
			// 
			// panel3
			// 
			this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.panel3.BackColor = System.Drawing.Color.Silver;
			this.panel3.Controls.Add(this.label1);
			this.panel3.Location = new System.Drawing.Point(-1, 20);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(683, 27);
			this.panel3.TabIndex = 14;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.Black;
			this.label1.Location = new System.Drawing.Point(5, 4);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 20);
			this.label1.TabIndex = 0;
			this.label1.Text = "Appearance";
			// 
			// bgColor
			// 
			this.bgColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.bgColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.bgColor.Location = new System.Drawing.Point(59, 417);
			this.bgColor.Name = "bgColor";
			this.bgColor.Size = new System.Drawing.Size(25, 23);
			this.bgColor.TabIndex = 15;
			this.bgColor.TabStop = false;
			this.bgColor.DoubleClick += new System.EventHandler(this.FgColorDoubleClick);
			// 
			// fgColor
			// 
			this.fgColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.fgColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.fgColor.Location = new System.Drawing.Point(59, 446);
			this.fgColor.Name = "fgColor";
			this.fgColor.Size = new System.Drawing.Size(25, 23);
			this.fgColor.TabIndex = 15;
			this.fgColor.TabStop = false;
			this.fgColor.DoubleClick += new System.EventHandler(this.FgColorDoubleClick);
			// 
			// altColor
			// 
			this.altColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.altColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.altColor.Location = new System.Drawing.Point(196, 415);
			this.altColor.Name = "altColor";
			this.altColor.Size = new System.Drawing.Size(25, 23);
			this.altColor.TabIndex = 15;
			this.altColor.TabStop = false;
			this.altColor.DoubleClick += new System.EventHandler(this.FgColorDoubleClick);
			// 
			// tColor
			// 
			this.tColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.tColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tColor.Location = new System.Drawing.Point(355, 415);
			this.tColor.Name = "tColor";
			this.tColor.Size = new System.Drawing.Size(25, 23);
			this.tColor.TabIndex = 15;
			this.tColor.TabStop = false;
			this.tColor.DoubleClick += new System.EventHandler(this.FgColorDoubleClick);
			// 
			// hColor
			// 
			this.hColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.hColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.hColor.Location = new System.Drawing.Point(196, 444);
			this.hColor.Name = "hColor";
			this.hColor.Size = new System.Drawing.Size(25, 23);
			this.hColor.TabIndex = 15;
			this.hColor.TabStop = false;
			this.hColor.DoubleClick += new System.EventHandler(this.FgColorDoubleClick);
			// 
			// label3
			// 
			this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label3.Location = new System.Drawing.Point(90, 415);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 18);
			this.label3.TabIndex = 16;
			this.label3.Text = "Background";
			// 
			// label4
			// 
			this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label4.Location = new System.Drawing.Point(90, 446);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 18);
			this.label4.TabIndex = 16;
			this.label4.Text = "Foreground";
			// 
			// label5
			// 
			this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label5.Location = new System.Drawing.Point(239, 420);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(100, 18);
			this.label5.TabIndex = 16;
			this.label5.Text = "Alt background";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(386, 420);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(100, 18);
			this.label7.TabIndex = 16;
			this.label7.Text = "Toolbar color";
			// 
			// label6
			// 
			this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label6.Location = new System.Drawing.Point(239, 446);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(100, 18);
			this.label6.TabIndex = 16;
			this.label6.Text = "Header tint";
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.panel1.Controls.Add(this.label6);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label7);
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.hColor);
			this.panel1.Controls.Add(this.tfColor);
			this.panel1.Controls.Add(this.tColor);
			this.panel1.Controls.Add(this.altColor);
			this.panel1.Controls.Add(this.fgColor);
			this.panel1.Controls.Add(this.bgColor);
			this.panel1.Controls.Add(this.panel3);
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Controls.Add(this.linkLabel1);
			this.panel1.Controls.Add(this.checkBox4);
			this.panel1.Controls.Add(this.colorChooser1);
			this.panel1.Controls.Add(this.checkBox3);
			this.panel1.Controls.Add(this.checkBox6);
			this.panel1.Controls.Add(this.checkBox2);
			this.panel1.Controls.Add(this.checkBox1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.ForeColor = System.Drawing.Color.White;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(683, 696);
			this.panel1.TabIndex = 11;
			this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel1Paint);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(386, 451);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(182, 18);
			this.label2.TabIndex = 16;
			this.label2.Text = "Toolbar foreground color";
			// 
			// tfColor
			// 
			this.tfColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.tfColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tfColor.Location = new System.Drawing.Point(355, 446);
			this.tfColor.Name = "tfColor";
			this.tfColor.Size = new System.Drawing.Size(25, 23);
			this.tfColor.TabIndex = 15;
			this.tfColor.TabStop = false;
			this.tfColor.DoubleClick += new System.EventHandler(this.FgColorDoubleClick);
			// 
			// checkBox6
			// 
			this.checkBox6.Location = new System.Drawing.Point(437, 221);
			this.checkBox6.Name = "checkBox6";
			this.checkBox6.Size = new System.Drawing.Size(231, 21);
			this.checkBox6.TabIndex = 3;
			this.checkBox6.Text = "Windows Media Player 9 Style";
			this.checkBox6.UseVisualStyleBackColor = true;
			this.checkBox6.CheckedChanged += new System.EventHandler(this.CheckBox2CheckedChanged);
			// 
			// Settings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add(this.panel1);
			this.Name = "Settings";
			this.Size = new System.Drawing.Size(683, 696);
			this.Load += new System.EventHandler(this.PreferencesLoad);
			this.VisibleChanged += new System.EventHandler(this.SettingsVisibleChanged);
			this.panel2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.bgColor)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fgColor)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.altColor)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tColor)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.hColor)).EndInit();
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.tfColor)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.CheckBox checkBox6;
		private System.Windows.Forms.PictureBox tfColor;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.PictureBox hColor;
		private System.Windows.Forms.PictureBox tColor;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.PictureBox fgColor;
		private System.Windows.Forms.PictureBox bgColor;
		private System.Windows.Forms.PictureBox altColor;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private System.Windows.Forms.Panel panel1;
		private Snowball.colorChooser colorChooser1;
		private System.Windows.Forms.ColorDialog colorDialog2;
		private System.Windows.Forms.CheckBox checkBox5;
		private System.Windows.Forms.CheckBox checkBox4;
		private System.Windows.Forms.CheckBox checkBox3;
		private System.Windows.Forms.CheckBox checkBox2;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.ColorDialog colorDialog1;
	}
}
