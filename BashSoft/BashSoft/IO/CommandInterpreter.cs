using BashSoft.Exceptions;
using BashSoft.IO.Commands;
using System;

namespace BashSoft
    {
    public class CommandInterpreter
        {
        private Tester judge;
        private StudentsRepository repository;
        private IOManager inputOutputManager;

        public CommandInterpreter(Tester judge, StudentsRepository repository, IOManager inputOutputManager)
            {
            this.judge = judge;
            this.repository = repository;
            this.inputOutputManager = inputOutputManager;
            }

        public void InterpredCommand(string input)
            {
            string[] data = input.Split(' ');

            string commandName = data[0];
            commandName = commandName.ToLower();

            try
                {
                Command command = this.ParseCommand(input, commandName, data);
                command.Execute();
                }
            catch (Exception e)
                {
                OutputWriter.DisplayException(e.Message);
                }
            }

        private Command ParseCommand(string input, string command, string[] data)
            {
            // All Commands-name must to be lowercase
            switch (command)
                {
                case "open":
                    return new OpenFileCommand(input, data, this.judge, this.repository, this.inputOutputManager);
                    break;

                case "mkdir":
                    return new MakeDirectoryCommand(input, data, this.judge, this.repository, this.inputOutputManager);
                    break;

                case "ls":
                    return new TraverseFoldersCommand(input, data, this.judge, this.repository, this.inputOutputManager);
                    break;

                case "cmp":
                    return new CompareFilesCommand(input, data, this.judge, this.repository, this.inputOutputManager);
                    break;

                case "cdrel":
                    return new ChangeRelativePathCommand(input, data, this.judge, this.repository, this.inputOutputManager);
                    break;

                case "cdabs":
                    return new ChangeAbsolutePathCommand(input, data, this.judge, this.repository, this.inputOutputManager);
                    break;

                case "readdb":
                    return new ReadDatabaseCommand(input, data, this.judge, this.repository, this.inputOutputManager);
                    break;

                case "dropdb":
                    return new DropDatabaseCommand(input, data, this.judge, this.repository, this.inputOutputManager);
                    break;

                case "help":
                    return new GetHelpCommand(input, data, this.judge, this.repository, this.inputOutputManager);
                    break;

                case "filter":
                    return new PrintFilteredStudentsCommand(input, data, this.judge, this.repository, this.inputOutputManager);
                    break;

                case "order":
                    return new PrintOrderedStudentsCommand(input, data, this.judge, this.repository, this.inputOutputManager);
                    break;

                case "download":
                    //TODO: DOWNLOAD cmd
                    throw new InvalidCommandException(input);
                    break;

                case "downloadasynch":
                    //TODO: downloadASYNCH cmd
                    throw new InvalidCommandException(input);
                    break;

                case "show":
                    return new ShowCourseCommand(input, data, this.judge, this.repository, this.inputOutputManager);
                    break;

                default:
                    throw new InvalidCommandException(input);
                    break;
                }
            }

        }
    }