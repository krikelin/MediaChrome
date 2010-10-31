namespace colorx
{
    partial class frmColorChooser
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel2 = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.colorChooser1 = new Snowball.colorChooser();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = global::colorx.Properties.Settings.Default.LastColor;
            this.panel2.Controls.Add(this.checkBox1);
            this.panel2.Controls.Add(this.colorChooser1);
            this.panel2.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::colorx.Properties.Settings.Default, "LastColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.ForeColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(443, 311);
            this.panel2.TabIndex = 12;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(20, 19);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(65, 17);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "WMP10";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // colorChooser1
            // 
            this.colorChooser1.Brightness = 50;
            this.colorChooser1.Hue = 0;
            this.colorChooser1.Location = new System.Drawing.Point(20, 55);
            this.colorChooser1.Name = "colorChooser1";
            this.colorChooser1.Saturation = 100;
            this.colorChooser1.Size = new System.Drawing.Size(396, 234);
            this.colorChooser1.TabIndex = 1;
            this.colorChooser1.Value = System.Drawing.Color.Red;
            this.colorChooser1.Change += new Snowball.colorChooser.ChangeEvent(this.colorChooser1_Change);
            // 
            // frmColorChooser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 311);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmColorChooser";
            this.Text = "Color Mixer";
            this.Load += new System.EventHandler(this.frmColorChooser_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox checkBox1;
        private Snowball.colorChooser colorChooser1;
    }
}