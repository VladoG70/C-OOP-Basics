using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Mankind
    {
    public class Student : Human
        {
        private string facultyNumber;

        public Student(string firstName, string lastName, string facultyNumber)
            : base(firstName, lastName)
            {
            this.FacultyNumber = facultyNumber;
            }

        public string FacultyNumber
            {
            get { return this.facultyNumber; }
            private set
                {
                if (value.Length < 5 || value.Length > 10 || !value.All(character => char.IsLetterOrDigit(character)))
                    {
                    throw new ArgumentException("Invalid faculty number!");
                    }

                this.facultyNumber = value;
                }
            }
        }
    }
