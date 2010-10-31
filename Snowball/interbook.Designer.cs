namespace Snowball
{
    partial class interbook
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
            this.xPanel1 = new Snowball.XPanel();
            this.lnkNext = new System.Windows.Forms.LinkLabel();
            this.lnkPrevious = new System.Windows.Forms.LinkLabel();
            this.display = new Snowball.XPanel();
            this.xPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // xPanel1
            // 
            this.xPanel1.BrushType = Snowball.PBrushStyle.PBSPlain;
            this.xPanel1.ColorStyle = Snowball.ColorStyle.CSFull;
            this.xPanel1.Controls.Add(this.lnkNext);
            this.xPanel1.Controls.Add(this.lnkPrevious);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel1.Location = new System.Drawing.Point(0, 0);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.PrimaryColor = System.Drawing.Color.White;
            this.xPanel1.SecondaryColor = System.Drawing.SystemColors.ButtonFace;
            this.xPanel1.Size = new System.Drawing.Size(454, 25);
            this.xPanel1.TabIndex = 0;
            this.xPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.xPanel1_Paint);
            // 
            // lnkNext
            // 
            this.lnkNext.AutoSize = true;
            this.lnkNext.BackColor = System.Drawing.Color.Transparent;
            this.lnkNext.Location = new System.Drawing.Point(26, 6);
            this.lnkNext.Name = "lnkNext";
            this.lnkNext.Size = new System.Drawing.Size(16, 13);
            this.lnkNext.TabIndex = 0;
            this.lnkNext.TabStop = true;
            this.lnkNext.Text = "->";
            this.lnkNext.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkNext_LinkClicked);
            // 
            // lnkPrevious
            // 
            this.lnkPrevious.AutoSize = true;
            this.lnkPrevious.BackColor = System.Drawing.Color.Transparent;
            this.lnkPrevious.Location = new System.Drawing.Point(4, 6);
            this.lnkPrevious.Name = "lnkPrevious";
            this.lnkPrevious.Size = new System.Drawing.Size(16, 13);
            this.lnkPrevious.TabIndex = 0;
            this.lnkPrevious.TabStop = true;
            this.lnkPrevious.Text = "<-";
            this.lnkPrevious.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkPrevious_LinkClicked);
            // 
            // display
            // 
            this.display.BrushType = Snowball.PBrushStyle.PBSPlain;
            this.display.ColorStyle = Snowball.ColorStyle.CSFull;
            this.display.Dock = System.Windows.Forms.DockStyle.Fill;
            this.display.Location = new System.Drawing.Point(0, 25);
            this.display.Name = "display";
            this.display.PrimaryColor = System.Drawing.Color.White;
            this.display.SecondaryColor = System.Drawing.SystemColors.ButtonFace;
            this.display.Size = new System.Drawing.Size(454, 210);
            this.display.TabIndex = 1;
            this.display.Paint += new System.Windows.Forms.PaintEventHandler(this.display_Paint);
            // 
            // interbook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.display);
            this.Controls.Add(this.xPanel1);
            this.Name = "interbook";
            this.Size = new System.Drawing.Size(454, 235);
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private XPanel xPanel1;
        public XPanel display;
        private System.Windows.Forms.LinkLabel lnkNext;
        private System.Windows.Forms.LinkLabel lnkPrevious;
    }
}
