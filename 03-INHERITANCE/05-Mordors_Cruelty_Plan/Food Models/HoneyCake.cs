using _05_MordorsCrueltyPlan.Main_Models;

namespace _05_MordorsCrueltyPlan.Food_Models
    {
    class HoneyCake : Food
        {
        private const int DefaultPointsOfHappines = 5;

        public HoneyCake() :
            base(DefaultPointsOfHappines)
            { }
        }
    }
