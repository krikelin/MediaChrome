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
            public String Title { get; set; }
            public IPlayEngine Engine { get; set; }
            public String ID { get; set; }
            public MainForm MainForm;
            public List<Song> Songs { get; set; }
            public Playlist(IPlayEngine Engine, string Name, MediaChrome.MainForm d)
            {
                Songs = new List<Song>();
                this.Engine = Engine;
                this.Title = Name;
                this.MainForm = d;
                Thread ds = new Thread(RetrieveData);
                ds.Start();
            }
            public bool Loaded { get; set; }
            public void RetrieveData()
            {
                Songs = Engine.ViewPlaylist(this.ID);
                Loaded = true;
            }
        }
    }
}
