/*
 * Created by SharpDevelop.
 * User: Alex
 * Date: 2010-10-27
 * Time: 19:45
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;
using System.Drawing;
namespace CDON
{
	/// <summary>
	/// Description of CListView.
	/// </summary>
	/// 
	public class CPlaylistView : CListView
	{
		public override Color BackColor
		{
			get
			{
				return MainForm.PlaylistBackground();
		
			}
		}
		public override Color ForeColor
		{
			get
			{
				return MainForm.PlaylistForeColor();
			}
		}
	}
	public class CTreeView : TreeView
	{
		public CTreeView()
		{
			SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
		}
		protected override void OnPaintBackground(PaintEventArgs e)
		{
			BufferedGraphicsContext D=  new BufferedGraphicsContext();
			BufferedGraphics C = D.Allocate(e.Graphics,e.ClipRectangle);
		
			base.OnPaintBackground(new PaintEventArgs(C.Graphics,e.ClipRectangle));
			C.Render();
		}
		protected override void OnPaint(PaintEventArgs e)
		{
			BufferedGraphicsContext D=  new BufferedGraphicsContext();
			BufferedGraphics C = D.Allocate(e.Graphics,e.ClipRectangle);
		
			base.OnPaint(new PaintEventArgs(C.Graphics,e.ClipRectangle));
			C.Render();
		}
		public override bool PreProcessMessage(ref Message msg)
		{
			if(msg.Msg == 0x000F)
			{
				Bitmap A = new Bitmap(this.Bounds.Width,this.Bounds.Height);
				this.DrawToBitmap(A,this.Bounds);
				Graphics X = this.CreateGraphics();
				X.DrawImage(A,new Point(0,0));
			}
			return base.PreProcessMessage(ref msg);
		}
		public override Color BackColor
		{
			get
			{
				return MainForm.ListBackground();
		
			}
		}
		
		public override void ResetBackColor()
		{
			base.ResetBackColor();
			this.BackColor = MainForm.ListBackground();
		}
		public override void ResetForeColor()
		{
			base.ResetBackColor();
			this.BackColor = MainForm.ListForeground();
		}
		public override Color ForeColor
		{
			get
			{
				return MainForm.ListForeground();
			}
		}
		
		
   	
	}
}
