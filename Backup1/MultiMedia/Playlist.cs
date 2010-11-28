using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MediaChrome;
using System.Threading;
namespace MediaChrome
{
    namespace Views
    {
        public class Playlist
        {
            public Playlist()
            {
            }
            public Playlist(IPlayEngine Engine,String ID,String Name)
            {
                this.ID = ID;
                this.Title = Name;
                this.Engine = Engine;
                
            }
            public bool CanModify { get; set; }
            public String Title { get; set; }
            public IPlayEngine Engine { get; set; }
            public String ID { get; set; }
            public MainForm MainForm;
            public List<Song> Songs { get; set; }
            public void Remove(int id)
            {
                Engine.RemoveFromPlaylist(ID, id);
            }
            public void Add(Song _Song, int pos)
            {
                Engine.AddToPlaylist(ID, _Song, pos);
                RetrieveData();
            }
            public void Rorder(Song _Song, int spos, int epos)
            {
                Engine.MoveSongPlaylist(ID, spos, epos);
            }
            public Playlist(IPlayEngine Engine, string Name,String ID, MediaChrome.MainForm d)
            {
                Songs = new List<Song>();
                this.Engine = Engine;
                this.Title = Name;
                this.ID = ID;
                this.MainForm = d;
                Thread ds = new Thread(RetrieveData);
                ds.Start();
            }
            public bool Loaded { get; set; }
            public void RetrieveData()
            {
                try
                {
                    Playlist X =  this;
                  Songs= Engine.LoadPlaylist(this.ID,ref X);
                }
                catch
                {
                }
                Loaded = true;
            }
        }
    }
}
