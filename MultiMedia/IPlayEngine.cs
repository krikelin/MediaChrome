/*
 * Created by SharpDevelop.
 * User: Alex
 * Date: 2010-10-29
 * Time: 15:02
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

using AxWMPLib;

namespace CDON
{

	
	
	/*public interface IImportEngine 
	{
		bool Ready {get;set;}
		int FilesCompleted {get;set;}
		int TotalFiles {get;set;}
		void Import(SQLiteConnection Conn, String rootDir );
		void ImportEx(SQLiteConnection Conn,String rootDir );
	}*/
	
	/// <summary>
	/// Description of IPlayEngine.
	/// </summary>
	/// 
	
	public interface ILibraryManager : ILibraryManager1
	{
		string Name {get;set;}
		string Namespace {get;set;}
		
		void Import();
		void Query(string Query);
	}
	public class Song{
		public string Title{get;set;}
		public string Artist{get;set;}
		public string Album {get;set;}
		public string Path {get;set;}
		public string Engine {get;set;}
		public string Store {get;set;}
		public string Version {get;set;}
	}
	public interface IPlayEngine
	{
		Control MediaControl {get;}
		bool Ready {get;set;}
		int FilesCompleted {get;set;}
		string Namespace {get;}
		string Title {get;}
		int TotalFiles {get;set;}
		List<Song> Find(String Query);
		void Play();
		void Pause();
		void Stop();
		void Seek(int pos);
		void Load(String Content);
		void Import(SQLiteConnection Conn,string RootDir);
		MainForm Host{get;set;}
		void Unload();
		List<Song> Search();
		bool RawFind(Song _Song);
		
	//	bool canSync {get;}
	//	void LoadSynchronized();
	//	bool OfflineService {get;}
		string Length { get; }

	}
	
}
