using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace colorx
{
    public class Collection
    {
        public Collection()
        {
            Artists = new List<Artist>();
        }
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        private List<Artist> artists;
        public List<Artist> Artists
        {
            get
            {
                return artists;
            }
            set
            {
                artists = value;
            }
        }
    }
    public class Song
    {
        private string type;
        public string Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }
        private int number;
        public int Number
        {
            get
            {
                return number;
            }
            set
            {
                number = value;
            }
        }
        private string file;
        public string File
        {
            get
            {
                return file;
            }
            set
            {
                file = value;
            }
        }
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        private string artist;
        public string Artist
        {
            get
            {
                return artist;
            }
            set
            {
                artist = value;
            }
        }
        private string album
        {
            get
            {
                return album;
            }
            set
            {
                album = value;
            }
        }
    }
    public class Artist
    {
        public Artist()
        {
            Albums = new List<Album>();
        }
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        private List<Album> albums;
        public List<Album> Albums
        {
            get
            {
                return albums;
            }
            set
            {
                albums = value;
            }
        }
    }
    public class Album
    {
        public Album()
        {
            Songs = new List<Song>();
        }
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        private List<Song> songs;
        public List<Song> Songs
        {
            get
            {
                return songs;
            }
            set
            {
                songs = value;
            }
        }

    }
    public class Podcast
    {
        private string title;
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
               title = value;
            }
        }
        private string url;
        public string URL
        {
            get
            {
                return url;
            }
            set
            {
                url = value;
            }
        }
    }
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
