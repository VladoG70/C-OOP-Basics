using _05_MordorsCrueltyPlan.Main_Models;

namespace _05_MordorsCrueltyPlan.Food_Models
    {
    class Mushroom : Food
        {
        private const int DefaultPointsOfHappines = -10;

        public Mushroom() :
            base(DefaultPointsOfHappines)
            { }
        }
    }
