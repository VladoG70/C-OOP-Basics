namespace _05_MordorsCrueltyPlan.Main_Models
    {
    abstract class Mood
        {
        private string happinesDescription;

        public Mood(string happinesDescription)
            {
            this.HappinesDescription = happinesDescription;
            }

        public string HappinesDescription
            {
            get
                {
                return this.happinesDescription;
                }
            private set
                {
                this.happinesDescription = value;
                }
            }
        }
    }
