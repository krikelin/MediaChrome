/*
 * Created by SharpDevelop.
 * User: Alex
 * Date: 2010-10-31
 * Time: 11:32
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SQLite;
namespace MultiMedia
{
	/// <summary>
	/// Description of EditMetadata.
	/// </summary>
	/// 
	
	public partial class EditMetadata : Form
	{
		public CDON.Song CurrentSong
		{
			get;set;
		}
		public EditMetadata()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		public String Title
		{
			get
			{
				return textBox1.Text;
			}
		}
		public String Artist
		{
			get
			{
				return textBox2.Text;
			}
		}
		public String Album
		{
			get
			{
				return textBox3.Text;
			}
		}
		public EditMetadata(CDON.Song EdSong)
		{
			CurrentSong=EdSong;
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			
		}
		
		void EditMetadataLoad(object sender, EventArgs e)
		{
			textBox1.Text = CurrentSong.Title;
			textBox2.Text = CurrentSong.Artist;
			textBox3.Text = CurrentSong.Album;
		}
		
		void Button2Click(object sender, EventArgs e)
		{
			SQLiteConnection Conn = CDON.MainForm.MakeConnection();
			Conn.Open();
			SQLiteCommand D = new SQLiteCommand(String.Format("UPDATE song SET name=\"{0}\", artist=\"{1}\",album=\"{2}\" WHERE path=\""+CurrentSong.Path+"\"",textBox1.Text,textBox2.Text,textBox3.Text),Conn);
            D.ExecuteNonQuery();
            Close();
		}
	}
}
