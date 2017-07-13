using System;
using _05_MordorsCrueltyPlan.Main_Models;

namespace _05_MordorsCrueltyPlan
    {
    class MordorsCrueltyPlanStartUp
        {
        static void Main(string[] args)
            {
            var gandalf = new Gandalf();
            var foodTokens = Console.ReadLine().Split(new[] { '\t', ' ', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var food in foodTokens)
                {
                gandalf.TakeFood(food.ToLower());
                }

            Console.WriteLine(gandalf);
            }
        }
    }
