using _05_MordorsCrueltyPlan.Main_Models;

namespace _05_MordorsCrueltyPlan.Food_Models
    {
    class Cram : Food
        {
        private const int DefaultPointsOfHappines = 2;

        public Cram() :
            base(DefaultPointsOfHappines)
            { }
        }
    }
