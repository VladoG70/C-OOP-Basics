using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Mankind
    {
    public class Worker : Human
        {
        private decimal weekSalary;
        private double workHoursPerDay;

        public Worker(string firstName, string lastName, decimal weekSalary, double workHoursPerDay)
                : base(firstName, lastName)
            {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
            }

        public decimal WeekSalary
            {
            get { return this.weekSalary; }
            private set
                {
                if (value <= 10)
                    {
                    throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
                    }
                this.weekSalary = value;
                }
            }

        public double WorkHoursPerDay
            {
            get { return this.workHoursPerDay; }
            private set
                {
                if (value < 1 || value > 12)
                    {
                    throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
                    }
                this.workHoursPerDay = value;
                }
            }

        public decimal SalaryPerHour()
            {
            decimal earnsByHour = 0m;

            earnsByHour = this.weekSalary / (5 * (decimal)this.workHoursPerDay);

            return earnsByHour;
            }
        }
    }
