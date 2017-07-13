using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Mankind
    {
    class MankindStartUp
        {
        static void Main(string[] args)
            {
            var inputStudentInfo = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var inputWorkerInfo = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var studentFirstName = inputStudentInfo[0];
            var studentLastName = inputStudentInfo[1];
            var studentFacultyNumber = inputStudentInfo[2];

            var workerFirstName = inputWorkerInfo[0];
            var workerLastName = inputWorkerInfo[1];
            var workerWeekSalary = decimal.Parse(inputWorkerInfo[2]);
            var workerHoursPerDay = double.Parse(inputWorkerInfo[3]);


            try
                {
                Student student = new Student(studentFirstName, studentLastName, studentFacultyNumber);
                Worker worker = new Worker(workerFirstName, workerLastName, workerWeekSalary, workerHoursPerDay);

                Console.WriteLine($"First Name: {student.FirstName}");
                Console.WriteLine($"Last Name: {student.LastName}");
                Console.WriteLine($"Faculty number: {student.FacultyNumber}");

                Console.WriteLine();

                Console.WriteLine($"First Name: {worker.FirstName}");
                Console.WriteLine($"Last Name: {worker.LastName}");
                Console.WriteLine($"Week Salary: {worker.WeekSalary:F2}");
                Console.WriteLine($"Hours per day: {worker.WorkHoursPerDay:F2}");
                Console.WriteLine($"Salary per hour: {worker.SalaryPerHour():F2}");

                }
            catch (ArgumentException ex)
                {
                Console.WriteLine(ex.Message);
                }
            }
        }
    }
