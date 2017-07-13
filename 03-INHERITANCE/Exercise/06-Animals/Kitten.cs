using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_Animals
    {
    public class Kitten : Cat
        {
        private const string kGender = "Female";

        public Kitten(string name, int age, string gender)
                : base(name, age, kGender)
            { }

        public override void ProduceSound()
            {
            Console.WriteLine("Miau");
            }
        }
    }
