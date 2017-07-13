namespace _04_OnlineRadioDatabase.Exceptions
    {
    public class InvalidSongMinutesException : InvalidSongLengthException
        {
        public override string Message
            {
            get { return "Song minutes should be between 0 and 14."; }
            }
        }
    }
