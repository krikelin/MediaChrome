/*
 * Created by SharpDevelop.
 * User: Alex
 * Date: 2010-10-30
 * Time: 11:59
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.Xml;
using System.Net;
using CDON;
namespace MultiMedia
{
	/// <summary>
	/// Description of Youtube.
	/// </summary>
	public class Youtube : CDON.IPlayEngine
	{
		public String Title
		{
			get
			{
				return "You Tube";
			}
		}
		public String Namespace
		{
			get
			{
				return "youtube";
			}
		}
		public MainForm Host{get;set;}
		WebBrowser YouPlayer;
		public bool RawFind(CDON.Song _Song)
		{
			return false;
		}
		public Youtube()
		{
			YouPlayer=new WebBrowser();
		}
		public Control MediaControl
		{
			get
			{
				return YouPlayer;
			}
		
		}
		public bool Ready {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}
		
		public int FilesCompleted {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}
		
		public int TotalFiles {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}
		
		public string Length {
			get {
				throw new NotImplementedException();
			}
		}
		
		public System.Collections.Generic.List<CDON.Song> Find(string Query)
		{
			WebClient CN = new WebClient();
			
			List<Song> songs = new List<Song>();
			XmlDocument D = new XmlDocument();
			
			D.Load("http://gdata.youtube.com/feeds/api/videos?q="+Query.Replace(" ","+")+"&v=1");
			var Items =  D.GetElementsByTagName("entry");
			foreach(XmlElement Item in Items)
			{
				CDON.Song _Song = new CDON.Song();
				String Name = Item.GetElementsByTagName("title")[0].InnerText;
				_Song.Title=Name;
				_Song.Artist="Youtube";
				if(Name.Contains("-"))
				{
					String[] markup = Name.Split('-');
					_Song.Title = markup[1].Trim(' ');
					_Song.Artist = markup[0].Trim(' ');
					
				}
				_Song.Path="youtube:"+((XmlElement)Item.GetElementsByTagName("link")[0]).GetAttribute("href");
				_Song.Engine="youtube";
				_Song.Store="Youtube";
				songs.Add(_Song);
					
			}
			return songs;

			
		}
		
		public void Play()
		{
			
		}
		
		public void Pause()
		{
			YouPlayer.Navigate("about:blank");
		}
		
		public void Stop()
		{
			YouPlayer.Navigate("about:blank");
		}
		
		public void Seek(int pos)
		{
			
		}
		
		public void Load(string Content)
		{
			if(YouPlayer==null)
			{
				
	
				YouPlayer.Show();
				
			}
			YouPlayer.Navigate(Content);
		}
		
		public void ImportEx(System.Data.SQLite.SQLiteConnection Conn, string RootDir)
		{
			throw new NotImplementedException();
		}
		
		public void Import(System.Data.SQLite.SQLiteConnection Conn, string RootDir)
		{
			throw new NotImplementedException();
		}
		
		public void Unload()
		{
			throw new NotImplementedException();
		}
		
		public System.Collections.Generic.List<CDON.Song> Search()
		{
			return new List<CDON.Song>();
		}
		
	
	}
}
