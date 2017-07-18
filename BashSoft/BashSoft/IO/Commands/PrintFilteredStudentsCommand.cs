using BashSoft.Exceptions;

namespace BashSoft.IO.Commands
    {
    public class PrintFilteredStudentsCommand : Command
        {
        public PrintFilteredStudentsCommand(string input, string[] data, Tester judge, StudentsRepository repository, IOManager inputOutputManager) : base(input, data, judge, repository, inputOutputManager)
            { }

        public override void Execute()
            {
            if (this.Data.Length != 5)
                {
                throw new InvalidCommandException(this.Input);
                }

            var courseName = this.Data[1];
            var filter = this.Data[2].ToLower();
            var takeCommand = this.Data[3].ToLower();
            var takeQuantity = this.Data[4].ToLower();

            TryParseParametersForFilterAndTake(takeCommand, takeQuantity, courseName, filter);
            }

        private void TryParseParametersForFilterAndTake(string takeCommand, string takeQuantity, string courseName, string filter)
            {
            if (takeCommand == "take")
                {
                if (takeQuantity == "all")
                    {
                    this.Repository.FilterAndTake(courseName, filter);
                    }
                else
                    {
                    var studentsToTake = 0;

                    if (int.TryParse(takeQuantity, out studentsToTake))
                        {
                        this.Repository.FilterAndTake(courseName, filter, studentsToTake);
                        }
                    else
                        {
                        OutputWriter.DisplayException(ExceptionMessages.InvalidTakeQuantityParameter);
                        }
                    }
                }
            else
                {
                OutputWriter.DisplayException(ExceptionMessages.InvalidTakeQuantityParameter);
                }
            }
        }
    }