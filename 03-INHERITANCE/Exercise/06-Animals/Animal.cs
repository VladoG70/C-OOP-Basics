using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_Animals
    {
    public abstract class Animal
        {
        private string name;
        private int age;
        private string gender;

        public Animal(string name, int age, string gender)
            {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
            }

        public string Name
            {
            get { return this.name; }
            private set
                {
                if (value == null)
                    {
                    throw new ArgumentException("Invalid input!");
                    }
                this.name = value;
                }
            }

        public int Age
            {
            get { return this.age; }
            private set
                {
                if (value < 0 )
                    {
                    throw new ArgumentException("Invalid input!");
                    }
                this.age = value;
                }
            }

        public string Gender
            {
            get { return this.gender; }
            protected set
                {
                if (value == null || !(value.ToLower() == "male" || value.ToLower() == "female"))
                    {
                    throw new ArgumentException("Invalid input!");
                    }
                this.gender = value;
                }
            }

        public abstract void ProduceSound();

        }
    }
