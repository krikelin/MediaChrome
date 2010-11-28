/*
 * Created by SharpDevelop.
 * User: Alex
 * Date: 2010-10-27
 * Time: 20:22
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace MediaChrome
{
	partial class ucButton
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
			this.SuspendLayout();
			// 
			// ucButton
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Name = "ucButton";
			this.Load += new System.EventHandler(this.UcButtonLoad);
			this.MouseLeave += new System.EventHandler(this.UcButtonMouseLeave);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.UcButtonPaint);
			this.Click += new System.EventHandler(this.UcButtonClick);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UcButtonMouseMove);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UcButtonMouseDown);
			this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.UcButtonMouseUp);
			this.MouseEnter += new System.EventHandler(this.UcButtonMouseEnter);
			this.ResumeLayout(false);
		}
	}
}
