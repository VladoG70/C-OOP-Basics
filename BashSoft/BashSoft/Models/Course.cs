﻿using BashSoft.Exceptions;
using System.Collections.Generic;

namespace BashSoft.Models
    {
    public class Course
        {
        private string name;
        private Dictionary<string, Student> studentsByName;

        public const int NumberOfTasksOnExam = 5;
        public const int MaxScoreOnExamTask = 100;

        public Course(string name)
            {
            this.Name = name;
            this.studentsByName = new Dictionary<string, Student>();
            }

        public string Name
            {
            get { return this.name; }
            private set
                {
                if (string.IsNullOrEmpty(value))
                    {
                    throw new InvalidStringException($"{nameof(this.name)} {ExceptionMessages.NullOrEmptyValue}");
                    }
                this.name = value;
                }
            }

        public IReadOnlyDictionary<string, Student> StudentsByName
            {
            get { return this.studentsByName; }
            }

        public void EnrollStudent(Student student)
            {
            if (this.studentsByName.ContainsKey(student.UserName))
                {
                throw new DuplicateEntryInStructureException(student.UserName, this.Name);
                }

            this.studentsByName.Add(student.UserName, student);
            }
        }
    }