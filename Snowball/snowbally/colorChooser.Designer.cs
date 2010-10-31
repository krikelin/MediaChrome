namespace Snowball
{
    partial class colorChooser
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbHue = new System.Windows.Forms.TrackBar();
            this.tbSat = new System.Windows.Forms.TrackBar();
            this.tbBright = new System.Windows.Forms.TrackBar();
            this.pnlColor = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.tbHue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBright)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbHue
            // 
            this.tbHue.Location = new System.Drawing.Point(20, 63);
            this.tbHue.Maximum = 1530;
            this.tbHue.Name = "tbHue";
            this.tbHue.Size = new System.Drawing.Size(351, 45);
            this.tbHue.TabIndex = 0;
            this.tbHue.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbHue.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // tbSat
            // 
            this.tbSat.Location = new System.Drawing.Point(20, 179);
            this.tbSat.Maximum = 100;
            this.tbSat.Name = "tbSat";
            this.tbSat.Size = new System.Drawing.Size(355, 45);
            this.tbSat.TabIndex = 0;
            this.tbSat.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbSat.Value = 100;
            this.tbSat.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            // 
            // tbBright
            // 
            this.tbBright.Location = new System.Drawing.Point(23, 128);
            this.tbBright.Maximum = 100;
            this.tbBright.Name = "tbBright";
            this.tbBright.Size = new System.Drawing.Size(352, 45);
            this.tbBright.TabIndex = 0;
            this.tbBright.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbBright.Value = 50;
            this.tbBright.Scroll += new System.EventHandler(this.trackBar3_Scroll);
            // 
            // pnlColor
            // 
            this.pnlColor.BackColor = System.Drawing.Color.Red;
            this.pnlColor.Location = new System.Drawing.Point(20, 17);
            this.pnlColor.Name = "pnlColor";
            this.pnlColor.Size = new System.Drawing.Size(355, 15);
            this.pnlColor.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Hue";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Saturation";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Brightness";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Snowball.Properties.Resources.colorband;
            this.pictureBox1.Location = new System.Drawing.Point(28, 98);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(343, 11);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // colorChooser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlColor);
            this.Controls.Add(this.tbBright);
            this.Controls.Add(this.tbSat);
            this.Controls.Add(this.tbHue);
            this.Name = "colorChooser";
            this.Size = new System.Drawing.Size(396, 234);
            this.Load += new System.EventHandler(this.colorChooser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbHue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBright)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar tbHue;
        private System.Windows.Forms.TrackBar tbSat;
        private System.Windows.Forms.TrackBar tbBright;
        private System.Windows.Forms.Panel pnlColor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
