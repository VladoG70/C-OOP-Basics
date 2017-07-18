using BashSoft.Exceptions;

namespace BashSoft.IO.Commands
    {
    public class MakeDirectoryCommand : Command
        {
        public MakeDirectoryCommand(string input, string[] data, Tester judge, StudentsRepository repository, IOManager inputOutputManager) : base(input, data, judge, repository, inputOutputManager)
            { }

        public override void Execute()
            {
            if (this.Data.Length != 1)
                {
                throw new InvalidCommandException(Input);
                }

            string folderName = this.Data[1];
            this.InputOutputManager.CreateDirectoryInCurrentFolder(folderName);
            }
        }
    }