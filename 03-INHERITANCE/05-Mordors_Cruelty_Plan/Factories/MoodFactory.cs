using _05_MordorsCrueltyPlan.Main_Models;
using _05_MordorsCrueltyPlan.Mood_Models;

namespace _05_MordorsCrueltyPlan.Factories
    {
    static class MoodFactory
        {
        public static Mood GetMood(int pointsOfHappines)
            {
            if (pointsOfHappines < -5)
                {
                return new Angry();
                }
            else if (pointsOfHappines >= -5 && pointsOfHappines <= 0)
                {
                return new Sad();
                }
            else if (pointsOfHappines >= 1 && pointsOfHappines <= 15)
                {
                return new Happy();
                }
            else
                {
                return new JavaScript();
                }
            }
        }
    }
