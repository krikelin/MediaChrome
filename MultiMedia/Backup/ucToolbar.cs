/*
 * Created by SharpDevelop.
 * User: Alex
 * Date: 2010-10-27
 * Time: 20:39
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CDON
{
	/// <summary>
	/// Description of ucToolbar.
	/// </summary>
	public partial class ucToolbar : UserControl
	{
		public ucToolbar()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		public override Color BackColor {
			get { 	return MainForm.ToolbarBackground();}
		}
	}
}
