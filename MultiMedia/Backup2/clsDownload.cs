/*
 * Created by SharpDevelop.
 * User: Alex
 * Date: 2010-10-27
 * Time: 19:59
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

using Id3Tag.HighLevel;

namespace MediaChrome
{

	/// <summary>
	/// Description of clsDownload.
	/// </summary>
	public class FileDownload
	{
		public ucStore Host {get;set;}
		public bool Testing {get;set;}
		public WebBrowser Client
		{
			get;set;
		}
		WebClient FX;
		public FileDownload(WebBrowser Cls,String Url,ucStore host,bool Testing){
			this.Url =new Uri(Url);
			Host=host;
			Client = Cls;
			this.Testing=Testing;
			FX = new WebClient();
			StartDownload();
		}
		String Folder="";
		String FileName="";
		String PartFile="";
		String Store="";
		public void StartDownload(){
			if(Testing)
			{
				FX.OpenReadCompleted+= new OpenReadCompletedEventHandler(FX_OpenReadCompleted);
				FX.OpenReadAsync(Url);
				return;
			}
			FX.DownloadFileAsync(Url,MainForm.DownloadDir+"\\"+Url.Segments[Url.Segments.Length-1]+"");
			PartFile=MainForm.DownloadDir+"\\"+Url.Segments[Url.Segments.Length-1]+"";
			Folder=MainForm.DownloadDir;
			FileName=Url.Segments[Url.Segments.Length-1];
			FX.DownloadProgressChanged += new DownloadProgressChangedEventHandler(FX_DownloadProgressChanged);
			FX.DownloadFileCompleted+= new AsyncCompletedEventHandler(FX_DownloadFileCompleted);
			
			Store = Url.Host;
		}

		void FX_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
		{
		
		}

		void FX_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
		{
			try
			{
				id3.MP3 D;
				try
				{
							
							D = new id3.MP3(Folder,FileName);
							
							id3.FileCommands.readMP3Tag(ref D);
							
							File.Move(Folder+"\\"+FileName,Folder+"\\"+FileName+".mp3");
							FileName=FileName+"mp3";
							
							SQLiteConnection CP = MainForm.MakeConnection();
							CP.Open();
							String P = "INSERT INTO song(name,artist,album,path) VALUES (\""+D.id3Title.Replace("\0","")+"\" ,'"+D.id3Artist.Replace("\0","")+"','"+D.id3Album.Replace("\0","")+"','"+PartFile+"')";
							SQLiteCommand C = new SQLiteCommand(P,CP);
							C.ExecuteNonQuery();
							String Ps = "INSERT INTO purchase(song_id,store) VALUES(last_insert_rowid(),'"+Store+"')";
							 C = new SQLiteCommand(Ps,CP);
							C.ExecuteNonQuery();
							CP.Close();
							
				}
				catch
				{
						
							id3.FileCommands.oFileStream.Close();
							
							
							String FileFolder=FileName.Replace(".zip","");
					
							if(!Directory.Exists(Folder+"\\"+FileFolder.Replace("%20"," ")))
							{
								Directory.CreateDirectory(Folder+"\\"+FileFolder.Replace("%20"," "));	
							}
							String DS = MainForm.GetAppPath()+"unzip";
							
							Process sD = new Process();
						
							sD.Exited+= new EventHandler(D_Exited);
							ProcessStartInfo XP = new ProcessStartInfo();
							sD.StartInfo= XP;
							XP.CreateNoWindow=false;
							XP.UseShellExecute=false;
							sD.EnableRaisingEvents=true;
							
							XP.FileName=(DS);
							XP.Arguments =(" \""+Folder+"\\"+FileName+"\" -d \""+Folder+"\\"+FileName.Replace(".zip","")+"\"");
							
							sD.Start();
						
						
					
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		
		}

		void D_Exited(object sender, EventArgs e)
		{
			MainForm.Import(Folder+"\\"+FileName.Replace(".zip",""));
			
		}
		public int Progress{get;set;}
		void FX_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
		{
			Progress=e.ProgressPercentage;
		} 
		
			
		public Uri Url
		{
			get;set;
		}
		private void OnDownloadComplete(){
			
		}
		
		public Thread Downloader
		{
			get;set;
		}
	}
}
