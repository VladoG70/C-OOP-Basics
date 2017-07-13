using System;
using _04_OnlineRadioDatabase.Exceptions;

namespace _04_OnlineRadioDatabase
    {
    public class Song
        {
        private string artistName;
        private string songName;
        private int min;
        private int sec;

        public Song(string artistName, string songName, int min, int sec)
            {
            this.ArtistName = artistName;
            this.SongName = songName;
            this.Min = min;
            this.Sec = sec;
            }

        public string ArtistName
            {
            get { return this.artistName; }
            private set
                {
                if (value.Length < 3 || value.Length > 20)
                    {
                    throw new InvalidArtistNameException();
                    }
                this.artistName = value;
                }
            }

        public string SongName
            {
            get { return this.songName; }
            private set
                {
                if (value.Length < 3 || value.Length > 20)
                    {
                    throw new InvalidSongNameException();
                    }
                this.songName = value;
                }
            }

        public int Min
            {
            get { return this.min; }
            private set
                {
                if (value < 0 || value > 14)
                    {
                    //throw new ArgumentException("Invalid song length." + Environment.NewLine + "Song minutes should be between 0 and 14.");
                    throw new InvalidSongMinutesException();
                    }
                this.min = value;
                }
            }

        public int Sec
            {
            get { return this.sec; }
            private set
                {
                if (value < 0 || value > 59)
                    {
                    throw new InvalidSongSecondsException();
                    }
                this.sec = value;
                }
            }

        }
    }
