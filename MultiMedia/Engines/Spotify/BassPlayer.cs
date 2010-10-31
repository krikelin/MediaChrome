﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

using CDON;
using SpofityRuntime;
using Spotify;
using Un4seen.Bass;
using Un4seen.Bass;

namespace SpofityRuntime
{
	public class SpotifyPlayer : CDON.IPlayEngine
    {
		public String Title
		{
			get
			{
				return "Spotify";
			}
		}
		public String Namespace
		{
			get
			{
				return "sp";
			}
		}
		public bool RawFind(Song _Song)
		{
			// TODO: Add handler later
			return false;
		}
		private MultiMedia.Spotify.SpotifyView view;
		public Control MediaControl
		{
			get
			{
				return view;
			}
			
		}
				
		public MainForm Host {get;set;}
		public bool Ready {get;set;}
		public int FilesCompleted {get;set;}
		public int TotalFiles {get;set;}
		public List<Song> Find(String Query)
		{
			List<Song> Songs = new List<Song>();
			Search D = SpotifySession.SearchSync(Query,0,100,0,100,0,100,new TimeSpan(1200000));

			try{
				foreach(Track Df in D.Tracks)
				{
					Song A = new CDON.Song();
					A.Title = Df.Name;
					A.Artist = Df.Artists[0].Name;
					A.Album = Df.Album.Name;
					A.Path = "sp:"+Df.LinkString;
					A.Store="Spotify";
					A.Engine="sp";
					Songs.Add(A);
					
				}
			}catch{
				
			}
			return Songs;
		}
		public void Import(SQLiteConnection Conn,String Query)
		{
			Conn.Open();
			foreach(Playlist D in SpotifySession.PlaylistContainer.CurrentLists)
			{
				foreach(Track Ds in D.CurrentTracks)
				{
					SQLiteCommand C = new SQLiteCommand("SELECT count(*) FROM song WHERE path='sp:"+Ds.LinkString+"'",Conn);
					SQLiteDataReader SQDR = C.ExecuteReader();
					
					if(SQDR.HasRows)
					{
						SQDR.Read();
						if(SQDR.GetInt32(0)==0)
						{
							try
							{
							SQLiteCommand Df = new SQLiteCommand("INSERT INTO song (name,artist,album,engine,path,genre,store) VALUES(\""+Ds.Name+"\",\""+Ds.Artists[0].Name+"\",\""+Ds.Album.Name+"\",\"sp\",\"sp:"+Ds.LinkString+"\",\"pop\",\"Spotify\")",Conn);
							Df.ExecuteNonQuery();
							}
							catch
							{
								
							}
						}
					}
				}
			}
			Conn.Close();
		}
		public void ImportEx(SQLiteConnection Conn,String Query)
		{
			
		}
		
		public String Length {get;set;}
		public void Seek(int a){}
		public void Unload(){}

		public void Pause()
		{
			SpotifySession.PlayerPlay(false);
		}
       /// <summary>
        /// The main entry point for the application.
        /// </summary>
		public  Session SpotifySession ;  
		public  BassPlayer player;
		public  AutoResetEvent playbackDone = new AutoResetEvent(false);
		private  AutoResetEvent loggedOut = new AutoResetEvent(false);
		public  Track currentTrack = null;
		public  bool Sucess=false;
		
		public List<CDON.Song> Search()
		{
			return new List<CDON.Song>();
		}
		public SpotifyPlayer()
		{
			
			view = new MultiMedia.Spotify.SpotifyView();
        	  Spocky.MyClass D = new Spocky.MyClass();
             SpotifySession = Spotify.Session.CreateInstance(D.AppKey(), "SpofityCaches", "SpofityCaches", "LinSpot");
        	 Application.EnableVisualStyles();
            
            SpofityRuntime.Login sD = new SpofityRuntime.Login(this);
            if(sD.ShowDialog() == DialogResult.OK)
            {
        	    SpotifySession.LogInSync(sD.User,sD.Pass,new TimeSpan(4000));
            }
        	SpotifySession.OnConnectionError+= new SessionEventHandler(SpotifySession_OnConnectionError);
        	SpotifySession.OnMusicDelivery+= new MusicDeliveryEventHandler(SpotifySession_OnMusicDelivery);
            
        	SpotifySession.OnEndOfTrack+= new SessionEventHandler(SpotifySession_OnEndOfTrack);
        	SpotifySession.OnPlaylistContainerLoaded+= new SessionEventHandler(SpotifySession_OnPlaylistContainerLoaded);
        	SpotifySession.OnAlbumBrowseComplete+= new AlbumBrowseEventHandler(SpotifySession_OnAlbumBrowseComplete);
        	SpotifySession.OnImageLoaded+= new ImageEventHandler(SpotifySession_OnImageLoaded);
            
       
        } 
		 
         void SpotifySession_OnAlbumBrowseComplete(Session sender, AlbumBrowseEventArgs e)
        {
        	
        	/*
        	string d = (string)e.State;
        	string x = "";
        	int i=1;
        	foreach(Track _Track in e.Result.Tracks)
        	{
        		x+="<treeitem>\n";
        		x+="<treerow uri=\""+_Track.LinkString+"\" id=\"track-"+i.ToString()+"\"> \n";
        		x+="<treecell value=\""+_Track.Name+"\"/>\n";
        		x+="<treecell value=\""+_Track.Artists[0].Name+"\"/>\n";
        		x+="<treecell type=\"progressbar\" value=\"0."+_Track.Popularity.ToString()+"\"/>\n";
        		x+="</treerow>\n";
        		x+="</treeitem>\n";
        			i++;
        	}
        	d = d.Replace("<Spotify:Album.Tracks/>",x);
        	d = d.Replace("spotify:track","http://go.go/sp_play-spotify:track");
            d = d.Replace("http://open.spotify.com/track/","http://go.go/sp_play-spotify:track:");
            using(StreamWriter SW = new StreamWriter(Program.GetAppString()+"\\views\\"+X.app+"\\main.view.php"))
            {
              	SW.Write(d);
              	SW.Close();
            }
            X.Times();*/
	                      	 
        }

         void SpotifySession_OnImageLoaded(Session sender, ImageEventArgs e)
        {
        	/*
			if (e.Image != null)
			{
				try
				{
					string d = GetAppString()+"\\covers\\"+e.State+".jpg";
					e.Image.Save(d, System.Drawing.Imaging.ImageFormat.Jpeg);
					
				}
				catch
				{
				}
			}*/
        }
      
        public  Queue<Playlist> toBeAdded = new Queue<Playlist>();
         void SpotifySession_OnPlaylistContainerLoaded(Session sender, SessionEventArgs e)
        {	
        	foreach(Playlist PlsList in SpotifySession.PlaylistContainer.CurrentLists)
            {
        		toBeAdded.Enqueue(PlsList);
           		
           		
            }
        	
        }
        private  float pos;
        public  bool Paused
        {
            get;set;
        }
         void SpotifySession_OnMusicDelivery(Session sender, MusicDeliveryEventArgs e)
        {
        	if (e.Samples.Length > 0)
			{
                       
				if (player == null)
				{
					//player = new AlsaPlayer(e.Rate / 2); // Buffer 500ms of audio
					player = new BassPlayer();
           
					Console.WriteLine("Player created");
				}
                

				// Don't forget to set how many frames we consumed
				e.ConsumedFrames = player.EnqueueSamples(new AudioData(e.Channels, e.Rate-12, e.Samples, e.Frames));

                /*X.Maximum = (float)currentTrack.Duration;
                X.Value  +=10;*/

			}
			else
			{
				e.ConsumedFrames = 0;
			}
        }
        public  void NextTrack()
        {
        	
        	MainForm.NextSong();
        	
            /*if (playQueue.Count > 0)
            {
                Track D = playQueue.Dequeue();
                if (currentTrack!=null)
                {
                    playHistory.Push(currentTrack);
                }
                currentTrack = D;
               
                SpotifySession.PlayerLoad(D);
                if (File.Exists("covers\\" + D.Album.LinkString.Replace(":", "_") + ".jpg"))
                {
                    try
                    {
                        X.CoverImage = System.Drawing.Bitmap.FromFile("covers\\" + D.Album.LinkString.Replace(":", "_") + ".jpg");
                    }
                    catch { }
                }
                SpotifySession.PlayerPlay(true);
                X.PlayIndex++;
                X.Value = 1;
            }*/
        }
        public  bool paused = false;
        public  void PreviousTrack()
        {
          /*  if (playHistory.Count > 0)
            {

                Track D = playHistory.Pop();
                SpotifySession.PlayerLoad(D);
                X.CoverImage = System.Drawing.Bitmap.FromFile("covers\\" + D.Album.LinkString.Replace(":", "_") + ".jpg");

                SpotifySession.PlayerPlay(true);
                playHistory.Push(currentTrack);
                currentTrack = D;
            }*/
        }
         void SpotifySession_OnEndOfTrack(Session sender, SessionEventArgs e)
        {
        	//Console.WriteLine("End of music delivery. Flushing player buffer...");
			Thread.Sleep(1500); // Samples left in player buffer. Player lags 500 ms
		
            playbackDone.Set();
         
			try
			{
              
                NextTrack();
            }
			catch
			{
			
			}
		//	Console.WriteLine("Playback complete");
		
        }
        public  Stack<Track> playHistory = new Stack<Track>();
        public  Queue<Track> playQueue = new Queue<Track>();
        public  string currentView = "";
         void SpotifySession_OnConnectionError(Session sender, SessionEventArgs e)
        {
        	
        }
         public void Load(string URI)
         {
         	SpotifySession.PlayerLoad(Track.CreateFromLink(Link.Create(URI)));
         }
         public void Play()
         {
         	SpotifySession.PlayerPlay(true);
         	
         }
         public void Stop()
         {
         	SpotifySession.PlayerPlay(false);
         	SpotifySession.PlayerUnload();
         }
    }
}

	public class BassPlayer
	{
		private BASSBuffer basbuffer = null;
		private STREAMPROC streamproc = null;

		public int EnqueueSamples(AudioData audioData)
		{
			return EnqueueSamples(audioData.Channels, audioData.Rate, audioData.Samples, audioData.Frames);
		}

		public int EnqueueSamples(int channels, int rate, byte[] samples, int frames)
		{
			int consumed = 0;
			if (basbuffer == null)
			{
				Bass.BASS_Init(-1, rate, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero);
				basbuffer = new BASSBuffer(2, rate, channels, 2);
				streamproc = new STREAMPROC(Reader);
				int bassId = Bass.BASS_StreamCreate(rate, channels, BASSFlag.BASS_DEFAULT, streamproc, IntPtr.Zero);
				Bass.BASS_ChannelPlay(bassId, false);
			}

			if (basbuffer.Space(0) > samples.Length)
			{
				basbuffer.Write(samples, samples.Length);
				consumed = frames;
			}

			return consumed;
		}

		private int Reader(int handle, IntPtr buffer, int length, IntPtr user)
		{
			return basbuffer.Read(buffer, length, user.ToInt32());
		}

		public void Stop()
		{ 
			//Bass.BASS_SampleStop
			Bass.BASS_Stop();
			
		}
	}

