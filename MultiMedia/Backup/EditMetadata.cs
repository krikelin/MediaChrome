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
			lTitle.Text = CurrentSong.Title;
			lArtist.Text = CurrentSong.Artist;
			lAlbum.Text = CurrentSong.Album;
			lFeaturing.Text = CurrentSong.Feature;
			lContributing.Text = CurrentSong.Contributing;
			lComposer.Text = CurrentSong.Composer;
			lVersion.Text = CurrentSong.Version;
			
		}
		
		void Button2Click(object sender, EventArgs e)
		{
			SQLiteConnection Conn = CDON.MainForm.MakeConnection();
			Conn.Open();
			SQLiteCommand D = new SQLiteCommand(String.Format("UPDATE song SET name=\"{0}\", artist=\"{1}\",album=\"{2}\",feature=\"{3}\",coartist=\"{4}\",version_=\"{5}\",composer=\"{6}\" WHERE path=\""+CurrentSong.Path+"\"",lTitle.Text,lArtist.Text,lAlbum.Text,lFeaturing.Text,lContributing.Text,lVersion.Text,lComposer.Text),Conn);
            D.ExecuteNonQuery();
            CurrentSong.Title = lTitle.Text;
			CurrentSong.Artist= lArtist.Text ;
			CurrentSong.Album = lAlbum.Text;
			CurrentSong.Feature = lFeaturing.Text;
			CurrentSong.Contributing = lContributing.Text;
			CurrentSong.Composer = lComposer.Text;
			CurrentSong.Version = lVersion.Text;
            Close();
            
		}
		
		void Label4Click(object sender, EventArgs e)
		{
			
		}
		
		void TextBox5TextChanged(object sender, EventArgs e)
		{
			
		}
		
		void Label7Click(object sender, EventArgs e)
		{
			
		}
	}
}
