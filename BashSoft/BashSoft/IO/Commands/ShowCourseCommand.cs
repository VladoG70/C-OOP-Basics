﻿using BashSoft.Exceptions;

namespace BashSoft.IO.Commands
    {
    public class ShowCourseCommand : Command
        {
        public ShowCourseCommand(string input, string[] data, Tester judge, StudentsRepository repository, IOManager inputOutputManager) : base(input, data, judge, repository, inputOutputManager)
            { }

        public override void Execute()
            {
            if (this.Data.Length == 2)
                {
                var courseName = this.Data[1];
                this.Repository.GetAllStudentsFromCourse(courseName);
                }
            else if (this.Data.Length == 3)
                {
                var courseName = this.Data[1];
                var userName = this.Data[2];
                this.Repository.GetStudentFromCourse(courseName, userName);
                }
            else
                {
                throw new InvalidCommandException(this.Input);
                }
            }
        }
    }