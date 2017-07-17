using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BashSoft.Models;

namespace BashSoft
    {
    public class StudentsRepository
        {
        private bool isDataInitialized = false;
        private Dictionary<string, Dictionary<string, List<int>>> studentsByCourse;
        private RepositoryFilter filter;
        private RepositorySorter sorter;

        // NEW - File 01 - Problem 12
        private Dictionary<string, Course> courses;
        private Dictionary<string, Student> students;

        public StudentsRepository(RepositorySorter sorter, RepositoryFilter filter)
            {
            this.filter = filter;
            this.sorter = sorter;
            this.studentsByCourse = new Dictionary<string, Dictionary<string, List<int>>>();
            }

        public void LoadData(string fileName)
            {
            if (!this.isDataInitialized)
                {
                OutputWriter.WriteMessageOnNewLine("Reading data...");
                this.students = new Dictionary<string, Student>();
                this.courses = new Dictionary<string, Course>();
                ReadData(fileName);
                }
            else
                {
                OutputWriter.DisplayException(ExceptionMessages.DataAlreadyInitialisedException);
                }
            }

        public void UnloadData()
            {
            if (!this.isDataInitialized)
                {
                OutputWriter.DisplayException(ExceptionMessages.DataNotInitializedExceptionMessage);
                }
            //this.studentsByCourse = new Dictionary<string, Dictionary<string, List<int>>>();
            this.students = null;
            this.courses = null;
            this.isDataInitialized = false;
            }


        private void ReadData(string fileName)
            {
            var path = SessionData.currentPath + "\\" + fileName;

            if (File.Exists(path))
                {
                //var pattern = @"([A-Z][a-zA-Z#+]*_[A-Z][a-z]{2}_\d{4})\s+([A-Z][a-z]{0,3}\d{2}_\d{2,4})\s+(\d+)";
                var pattern = @"([A-Z][a-zA-Z#\++]*_[A-Z][a-z]{2}_\d{4})\s+([A-Za-z]+\d{2}_\d{2,4})\s([\s0-9]+)";
                var rgx = new Regex(pattern);
                var allInputLines = File.ReadAllLines(path);

                for (int line = 0; line < allInputLines.Length; line++)
                    {
                    if (!string.IsNullOrEmpty(allInputLines[line]) && rgx.IsMatch(allInputLines[line]))
                        {
                        var currentMatch = rgx.Match(allInputLines[line]);
                        var tokens = allInputLines[line].Split(' ');
                        var courseName = currentMatch.Groups[1].Value;
                        var studentName = currentMatch.Groups[2].Value;
                        var scoresStr = currentMatch.Groups[3].Value;

                        //var studentScoreOnTask = 0;
                        //bool hasParsedScore = int.TryParse(currentMatch.Groups[3].Value, out studentScoreOnTask);

                        //if (hasParsedScore && studentScoreOnTask >= 0 && studentScoreOnTask <= 100)
                        //    {
                        //    if (!studentsByCourse.ContainsKey(course))
                        //        {
                        //        studentsByCourse.Add(course, new Dictionary<string, List<int>>());
                        //        }

                        //    if (!studentsByCourse[course].ContainsKey(student))
                        //        {
                        //        studentsByCourse[course].Add(student, new List<int>());
                        //        }

                        //    studentsByCourse[course][student].Add(studentScoreOnTask);
                        //    }

                        // F01-P12 p.9
                        try
                            {
                            int[] scores = scoresStr.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray();

                            if (scores.Any(x => x > 100 || x < 0))
                                {
                                OutputWriter.DisplayException(ExceptionMessages.InvalidScore);
                                }

                            if (scores.Length > Course.NumberOfTasksOnExam)
                                {
                                OutputWriter.DisplayException(ExceptionMessages.InvalidNumberOfScores);
                                continue;
                                }

                            if (!this.students.ContainsKey(studentName))
                                {
                                this.students.Add(studentName, new Student(studentName));
                                }

                            if (!this.courses.ContainsKey(courseName))
                                {
                                this.courses.Add(courseName, new Course(courseName));
                                }

                            Course course = this.courses[courseName];
                            Student student = this.students[studentName];

                            student.EnrollInCourse(course);
                            student.SetMarksInCourse(courseName, scores);

                            course.EnrollStudent(student);
                            }
                        catch (FormatException fex)
                            {
                            OutputWriter.DisplayException(fex.Message + $"at line : {line}");
                            }

                        }
                    }

                isDataInitialized = true;
                OutputWriter.WriteMessageOnNewLine("Data read!");
                }
            else
                {
                OutputWriter.DisplayException(ExceptionMessages.InvalidPath);
                }
            }

        private bool IsQueryForCoursePossible(string courseName)
            {
            if (isDataInitialized)
                {
                //if (studentsByCourse.ContainsKey(courseName))
                if (this.courses.ContainsKey(courseName))
                    {
                    return true;
                    }
                else
                    {
                    OutputWriter.DisplayException(ExceptionMessages.InexistingCourseInDataBase);
                    }

                }
            else
                {
                OutputWriter.DisplayException(ExceptionMessages.DataNotInitializedExceptionMessage);
                }
            return false;
            }

        private bool IsQueryForStudentPossible(string courseName, string studentName)
            {
            //if (IsQueryForCoursePossible(courseName) && studentsByCourse[courseName].ContainsKey(studentName))
            if (IsQueryForCoursePossible(courseName) && this.courses[courseName].studentsByName.ContainsKey(studentName))
                {
                return true;
                }
            else
                {
                OutputWriter.DisplayException(ExceptionMessages.InexistingStudentInDataBase);
                }
            return false;
            }

        public void GetStudentScoreFromCourse(string courseName, string studentName)
            {
            if (IsQueryForStudentPossible(courseName, studentName))
                {
                // TODO .......
                /// CHECK for USERNAME or STUDENT NAME ??????
                OutputWriter.DisplayStudent(new KeyValuePair<string, double>(studentName, this.courses[courseName].studentsByName[studentName].marksByCourseName[courseName]));
                }
            }

        public void GetStudentFromCourse(string courseName, string userName)
            {
            if (IsQueryForStudentPossible(courseName, userName))
                {
                OutputWriter.DisplayStudent(new KeyValuePair<string, double>(userName, this.courses[courseName].studentsByName[userName].marksByCourseName[courseName]));
                }
            }

        public void GetAllStudentsFromCourse(string courseName)
            {
            if (IsQueryForCoursePossible(courseName))
                {
                OutputWriter.WriteMessageOnNewLine(courseName);

                foreach (var stdentMarksEntry in this.courses[courseName].studentsByName)
                    {
                    //OutputWriter.DisplayStudent(entry);
                    this.GetStudentScoreFromCourse(courseName, stdentMarksEntry.Key);
                    }
                }
            }


        public void OrderAndTake(string courseName, string comparison, int? studentsToTake = null)
            {
            if (IsQueryForCoursePossible(courseName))
                {
                if (studentsToTake == null)
                    {
                    //studentsToTake = studentsByCourse[courseName].Count;
                    studentsToTake = this.courses[courseName].studentsByName.Count;
                    }

                //this.sorter.OrderAndTake(studentsByCourse[courseName], comparison, studentsToTake.Value);
                Dictionary<string, double> marks = this.courses[courseName].studentsByName
                    .ToDictionary(x => x.Key, x => x.Value.marksByCourseName[courseName]);
                this.sorter.OrderAndTake(marks, comparison, studentsToTake.Value);
                }
            }


        public void FilterAndTake(string courseName, string givenFilter, int? studentsToTake = null)
            {
            if (this.IsQueryForCoursePossible(courseName))
                {
                if (studentsToTake == null)
                    {
                    studentsToTake = this.courses[courseName].studentsByName.Count;
                    }

                Dictionary<string, double> marks = this.courses[courseName].studentsByName
                    .ToDictionary(x => x.Key, x => x.Value.marksByCourseName[courseName]);

                this.filter.FilterAndTake(marks, givenFilter, studentsToTake.Value);
                }
            }


        }
    }
