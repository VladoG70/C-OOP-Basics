using System;

namespace _04_OnlineRadioDatabase.Exceptions
    {
    //public class InvalidSongException : Exception ??? Inheritance Exception OR ArgumentException ???
    public class InvalidSongException : ArgumentException
        {
        public override string Message
            {
            get { return "Invalid song."; }
            }
        }
    }
