using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BashSoft
    {
    public class RepositorySorter
        {
        public void OrderAndTake(Dictionary<string, double> studentsWithMarks, string comparison, int studentsToTake)
            {
            comparison = comparison.ToLower();

            if (comparison == "ascending")
                {
                this.PrintStudents(studentsWithMarks
                    .OrderBy(x => x.Value)
                    .Take(studentsToTake)
                    .ToDictionary(pair => pair.Key, pair => pair.Value));
                }
            else if (comparison == "descending")
                {
                this.PrintStudents(studentsWithMarks
                    .OrderByDescending(x => x.Value)
                    .Take(studentsToTake)
                    .ToDictionary(pair => pair.Key, pair => pair.Value));
                }
            else
                {
                OutputWriter.DisplayException(ExceptionMessages.InvalidComparisonQuery);
                }
            }

        private void PrintStudents(Dictionary<string, double> studentsSorted)
            {
            foreach (var keyValuePair in studentsSorted)
                {
                OutputWriter.DisplayStudent(keyValuePair);
                }
            }
        }
    }
