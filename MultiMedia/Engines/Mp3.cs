/*
 * Created by SharpDevelop.
 * User: Alex
 * Date: 2010-10-31
 * Time: 10:57
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Sql;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;
using CDON;

using WMPLib;
namespace MultiMedia
{
	/// <summary>
	/// Description of Mp3.
	/// </summary>
	public class MP3Player : IPlayEngine
	{
		public String Title
		{
			get
			{
				return "Local Files";
			}
		}
		public String Namespace
		{
			get
			{
				return "mp3";
			}
		}
		public bool RawFind(Song D)
		{
			SQLiteConnection Conn = MainForm.MakeConnection();
			SQLiteCommand Command = new SQLiteCommand("SELECT path FROM song WHERE name = '"+D.Title+"' AND artist = '"+D.Artist+"'",Conn);
			SQLiteDataReader Reader = Command.ExecuteReader();
			if(Reader.HasRows)
			{
				Reader.Read();
				player.launchURL(Reader.GetString(0));
				return true;
				
			}
			else
			{
				return false;
			}
		}
	
		public Control MediaControl
		{
			get
			{
				return new Panel();
			}
			
			
		}
		public MainForm Host {get;set;}
		public List<Song> Find(String Query)
		{
			List<Song> Songs = new List<Song>();
			SQLiteConnection Conn = MainForm.MakeConnection();
			Conn.Open();
			SQLiteCommand Command = new SQLiteCommand("SELECT name,artist,album,path,store,engine FROM song WHERE name LIKE '%"+Query+"%' OR artist LIKE '%"+Query+"%' OR album LIKE '%"+Query+"%' ",Conn);
			SQLiteDataReader  DR = Command.ExecuteReader();
			while(DR.Read())
			{
				
				Song D = new Song();
				try{
				D.Title = DR.GetString(0);
				D.Artist = DR.GetString(1);
				D.Album = DR.GetString(2);
				D.Path=DR.GetString(3);
				D.Store=DR.GetString(4);
				D.Engine=DR.GetString(5);
				}catch{}
				Songs.Add(D);
			}
			return Songs;
			
		}
		
		public bool Ready {get;set;}
		public int FilesCompleted {get;set;}
		public int TotalFiles {get;set;}
		private WMPLib.WindowsMediaPlayerClass player;
		
		public void ImportEx(SQLiteConnection Conn,string RootDir){
			
			DirectoryInfo DI = new DirectoryInfo(RootDir);
				
			FileInfo[] D = DI.GetFiles("*.mp3");
			foreach(FileInfo X in D){
				TotalFiles++;
			}
			DirectoryInfo[] Directories = DI.GetDirectories();
			foreach(DirectoryInfo R in Directories){
				ImportEx(Conn,R.FullName);
			}
		}
		public void ImportData(SQLiteConnection Conn,string RootDir){
			DirectoryInfo DI = new DirectoryInfo(RootDir);
				
			FileInfo[] D = DI.GetFiles("*.mp3");
			foreach(FileInfo X in D){
				try{ 
					id3.MP3 Dw = new id3.MP3(X.DirectoryName,X.Name);
					id3.FileCommands.readMP3Tag(ref Dw);
					SQLiteConnection CP = Conn;
					CP.Open();
					
					String P = "INSERT INTO song(name,artist,album,path,no,composer,store) VALUES (\""+Dw.id3Title.Replace("\0","").Replace("\"","'")+"\" ,\""+Dw.id3Artist.Replace("\0","").Replace("\"","'")+"\",\""+Dw.id3Album.Replace("\0","").Replace("\"","'")+"\",\"mp3:"+X.FullName+"\","+Dw.id3TrackNumber+",\"Other\",\"Local Files\")";
					SQLiteCommand C = new SQLiteCommand(P,CP);
					C.ExecuteNonQuery();
					FilesCompleted++;
					CP.Close();
				}catch(Exception e){
					System.Windows.Forms.MessageBox.Show(e.Message);
				}
				
			}
			DirectoryInfo[] Directories = DI.GetDirectories();
			foreach(DirectoryInfo R in Directories){
				ImportData(Conn,R.FullName);
			}
		}
		public void Import(SQLiteConnection Conn,string RootDir){
			Ready=false;
			ImportData(Conn,RootDir);
			Ready=true;
			
		}
		
		public List<Song> Search()
		{
			return new List<Song>();
		}
		public MP3Player()
		{
			Ready=true;
			player = new WMPLib.WindowsMediaPlayerClass();
		
			
			
		}
			
			

		

		void player_OpenStateChange(int NewState)
		{
			
		}

		void player_PositionChange(double oldPosition, double newPosition)
		{
			if(newPosition >= player.currentMedia.duration-3)
			{
				player.stop();
				MainForm.NextSong();
			}
		}
		public void Play()
		{
			player.play();
		}
		public void Pause()
		{
			player.pause();
		}
		public void Stop()
		{
			player.stop();
		}
		public void Seek()
		{
			
		}
		public void Load(String URL)
		{
			player.URL = ("file:///"+URL.ToString());
		}
		public double Duration 
		{
			get { return player.currentItem.duration; }
		}
		public String Length
		{
			get { return player.currentItem.durationString; }
		}
		
		
		
		public void Seek(int pos)
		{
		
		}
		
		public void Unload()
		{
		
		}
	}

}
