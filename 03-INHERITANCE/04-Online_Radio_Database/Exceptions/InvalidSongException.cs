using System;

namespace _04_OnlineRadioDatabase.Exceptions
    {
    public class InvalidSongException : Exception
        {
        public override string Message
            {
            get { return "Invalid song."; }
            }
        }
    }
