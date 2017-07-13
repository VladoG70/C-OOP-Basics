using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_Animals
    {
    public class Tomcat : Cat
        {
        private const string tGender = "Male";

        public Tomcat(string name, int age, string gender)
                : base(name, age, tGender)
            { }

        public override void ProduceSound()
            {
            Console.WriteLine("Give me one million b***h");
            }
        }
    }
