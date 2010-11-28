﻿/*
 * Created by SharpDevelop.
 * User: Alex
 * Date: 2010-10-27
 * Time: 19:03
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MediaChrome;
namespace MediaChrome
{
	/// <summary>
	/// Class with program entry point.
	/// </summary>
	internal sealed class Program
	{
		
		public static Dictionary<String, IPlayEngine> MediaEngines = new Dictionary<string, IPlayEngine>();
		public static MainForm Host;
		public static String KeyQuery<T>(Dictionary<String,T> Dict,char delimiter)
		{
			string d = "(";
			foreach(String Key in Dict.Keys)
			{
				d+="'"+Key+"'"+delimiter;
			}
			d+=")";
			d=d.Replace(",)",")");
			return d;
		}
		/// <summary>
		/// Program entry point.
		/// </summary>
		[STAThread]
		private static void Main(string[] args)
		{
			
			 Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

            MediaEngines.Add("mp3", new MP3Player());
            MediaEngines.Add("youtube", new MediaChrome.Youtube() { Host = Program.Host });
		//	MediaEngines.Add("sp",new SpofityRuntime.SpotifyPlayer());
			
			
			Host = new MainForm();
         //     Application.Run(new MultiMedia.Artist());
			
			Application.Run(Host);
		}
		
	}
}
