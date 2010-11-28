/*
 * Created by SharpDevelop.
 * User: Alex
 * Date: 2010-10-27
 * Time: 20:22
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MediaChrome
{
	/// <summary>
	/// Description of ucButton.
	/// </summary>
	/// 
	
	public partial class ucButton : UserControl
	{
		public Bitmap Icon{get;set;}
		public ucButton()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		public override Color BackColor{
			get{
				return Dark;
			}
		}
		public Color Light{
			get{
				return MainForm.FadeColor(0.2f,MainForm.PrimaryColor);
			}
		}
		public Color Dark{
			get{
				return MainForm.FadeColor(-0.2f,MainForm.PrimaryColor);
			}
		}
		public Color ExtraDark{
			get{
				return MainForm.FadeColor(-0.5f,MainForm.PrimaryColor);
			}
		}
		public Color ExtraLight{
			get{
				return Color.White;
			}
		}
		public Color HoverD{
			get{
				 return MainForm.FadeColor(-0.5f,MainForm.PrimaryColor);
		
			}
		}
		public Color ClickD{
			get{
				return Color.FromArgb(MainForm.PrimaryColor.R-15,MainForm.PrimaryColor.G-15,MainForm.PrimaryColor.B-15);
		
			}
		}
	
		void UcButtonClick(object sender, EventArgs e)
		{
			if(OnClick!=null)
			OnClick(sender,e);	
		}
		public event EventHandler OnClick;
		public String Label{
			get{
				return base.Text;
			}
			set{
				base.Text=value;
			}
		}
		void UcButtonLoad(object sender, EventArgs e)
		{
			Graphics D = this.CreateGraphics();
			D.FillRectangle(new SolidBrush(Dark),new Rectangle(0,0,this.Width,this.Height));
			D.DrawString(Text,new Font("MS Sans Serif",8),new SolidBrush(Color.Black),new Point(34,2));
			if(Icon!=null){
				D.DrawImage(Icon,1,2);
			}
		}
		void UcButtonMouseDown(object sender, MouseEventArgs e)
		{
			Graphics D = this.CreateGraphics();
			D.FillRectangle(new SolidBrush(ExtraDark),new Rectangle(0,0,this.Width,this.Height));
			if(Icon!=null){
				D.DrawImage(Icon,2,4);
			}
			D.DrawLine(new Pen(Dark),0,0,this.Width-1,0);
			D.DrawLine(new Pen(Dark),0,0,0,this.Height-1);
			D.DrawLine(new Pen(ExtraLight),this.Width-1,this.Height-1,this.Width-1,0);
			D.DrawLine(new Pen(ExtraLight),0,this.Height-1,this.Width-1,this.Height-1); 
			D.DrawString(Text,new Font("MS Sans Serif",8),new SolidBrush(Color.White),new Point(38,4));
		}
		
		void UcButtonMouseEnter(object sender, EventArgs e)
		{
			Graphics D = this.CreateGraphics();
			
			if(MouseButtons == MouseButtons.Left ){
				D.FillRectangle(new SolidBrush(ExtraDark),new Rectangle(0,0,this.Width,this.Height));
				if(Icon!=null){
					D.DrawImage(Icon,2,4);
				}
				D.DrawLine(new Pen(Dark),0,0,this.Width-1,0);
				D.DrawLine(new Pen(Dark),0,0,0,this.Height-1);
				D.DrawLine(new Pen(ExtraLight),this.Width-1,this.Height-1,this.Width-1,0);
				D.DrawLine(new Pen(ExtraLight),0,this.Height-1,this.Width-1,this.Height-1); 
				D.DrawString(Text,new Font("MS Sans Serif",8),new SolidBrush(Color.White),new Point(38,4));
					return;
			}
			D.FillRectangle(new SolidBrush(MainForm.FadeColor(0.15f,MainForm.PrimaryColor)),new Rectangle(0,0,this.Width,this.Height));
			if(Icon!=null){
				D.DrawImage(Icon,1,2);
			}
			D.DrawLine(new Pen(ExtraLight),0,0,this.Width-1,0);
			D.DrawLine(new Pen(ExtraLight),0,0,0,this.Height-1);
			D.DrawLine(new Pen(ExtraDark),this.Width-1,this.Height-1,this.Width-1,0);
			D.DrawLine(new Pen(ExtraDark),0,this.Height-1,this.Width-2,this.Height-1); 
			D.DrawString(Text,new Font("MS Sans Serif",8),new SolidBrush(Color.Black),new Point(34,2));
			
		}
		
		void UcButtonMouseMove(object sender, MouseEventArgs e)
		{
			
		}
		
		void UcButtonMouseLeave(object sender, EventArgs e)
		{
			Graphics D = this.CreateGraphics();	
			
			if(Icon!=null){
				D.DrawImage(Icon,1,2);
			}
	
			D.FillRectangle(new SolidBrush(Dark),new Rectangle(0,0,this.Width,this.Height));
			D.DrawString(Text,new Font("MS Sans Serif",8),new SolidBrush(Color.Black),new Point(34,2));
		}
		
		void UcButtonMouseUp(object sender, MouseEventArgs e)
		{
			Graphics D = this.CreateGraphics();	
			
			D.FillRectangle(new SolidBrush(MainForm.FadeColor(0.15f,MainForm.PrimaryColor)),new Rectangle(0,0,this.Width,this.Height));
			if(Icon!=null){
				D.DrawImage(Icon,1,2);
			}
			D.DrawLine(new Pen(ExtraLight),0,0,this.Width-1,0);
			D.DrawLine(new Pen(ExtraLight),0,0,0,this.Height-1);
			D.DrawLine(new Pen(ExtraDark),this.Width-1,this.Height-1,this.Width-1,0);
			D.DrawLine(new Pen(ExtraDark),0,this.Height-1,this.Width-2,this.Height-1); 
			D.DrawString(Text,new Font("MS Sans Serif",8),new SolidBrush(Color.Black),new Point(34,2));
			
	
		}
		
		void UcButtonPaint(object sender, PaintEventArgs e)
		{
			Graphics D = e.Graphics;
			if(Icon!=null){
				D.DrawImage(Icon,1,2);
			}
			D.DrawString(Text,new Font("MS Sans Serif",8),new SolidBrush(Color.White),new Point(34,2));

		}
	}
}
