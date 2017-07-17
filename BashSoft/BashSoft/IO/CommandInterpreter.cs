using System.Diagnostics;

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

            string command = data[0];

            switch (command)
                {
                case "open":
                    TryOpenFile(input, data);
                    break;
                case "mkdir":
                    TryCreateDirectory(input, data);
                    break;
                case "ls":
                    TryTraverseFolders(input, data);
                    break;
                case "cmp":
                    TryCompareFiles(input, data);
                    break;
                case "cdRel":
                    TryChangePathRelatively(input, data);
                    break;
                case "cdAbs":
                    TryChangePathAbsolute(input, data);
                    break;
                case "readDb":
                    TryReadDatabaseFromFile(input, data);
                    break;
                case "help":
                    TryGetHelp();
                    break;
                case "filter":
                    TryFilterAndTake(input, data);
                    break;
                case "order":
                    TryOrderAndTake(input, data);
                    break;
                case "download":
                    //TODO: DOWNLOAD cmd
                    break;
                case "downloadAsynch":
                    //TODO: downloadASYNCH cmd
                    break;
                case "show":
                    TryShowWantedData(input, data);
                    break;
                default:
                    this.DisplayInvalidCommandMessage(input);
                    break;
                }

            }

        private void DisplayInvalidCommandMessage(string input)
            {
            OutputWriter.DisplayException($"The command '{input}' is invalid");
            }

        private void TryOpenFile(string input, string[] data)
            {
            if (data.Length == 2)
                {
                string fileName = data[1];
                Process.Start(SessionData.currentPath + "\\" + fileName);
                }
            else
                {
                this.DisplayInvalidCommandMessage(input);
                }
            }

        private void TryCreateDirectory(string input, string[] data)
            {
            if (data.Length == 2)
                {
                string folderName = data[1];
                this.inputOutputManager.CreateDirectoryInCurrentFolder(folderName);
                }
            else
                {
                this.DisplayInvalidCommandMessage(input);
                }
            }


        private void TryTraverseFolders(string input, string[] data)
            {
            if (data.Length == 1)
                {
                this.inputOutputManager.TraverseDirectory(0);
                }
            else if (data.Length == 2)
                {
                var depth = 0;

                if (int.TryParse(data[1], out depth))
                    {
                    this.inputOutputManager.TraverseDirectory(depth);
                    }
                else
                    {
                    OutputWriter.DisplayException(ExceptionMessages.UnableToParseNumber);
                    }
                }
            else
                {
                this.DisplayInvalidCommandMessage(input);
                }
            }

        private void TryCompareFiles(string input, string[] data)
            {
            if (data.Length == 3)
                {
                string firstPath = data[1];
                string secondPath = data[2];

                this.judge.CompareContent(firstPath, secondPath);
                }
            else
                {
                this.DisplayInvalidCommandMessage(input);
                }
            }

        private void TryChangePathRelatively(string input, string[] data)
            {
            if (data.Length == 2)
                {
                string relPath = data[1];
                this.inputOutputManager.ChangeCurrentDirectoryRelative(relPath);
                }
            else
                {
                this.DisplayInvalidCommandMessage(input);
                }
            }


        private void TryChangePathAbsolute(string input, string[] data)
            {
            if (data.Length == 2)
                {
                string absolutePath = data[1];
                this.inputOutputManager.ChangeCurrentDirectoryAbsolute(absolutePath);
                }
            else
                {
                this.DisplayInvalidCommandMessage(input);
                }
            }

        private void TryReadDatabaseFromFile(string input, string[] data)
            {
            if (data.Length == 2)
                {
                string fileName = data[1];
                this.repository.LoadData(fileName);
                }
            else
                {
                this.DisplayInvalidCommandMessage(input);
                }
            }


        private void TryGetHelp()
            {
            OutputWriter.WriteMessageOnNewLine($"{new string('_', 100)}");
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "open file - open: [path]file "));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "make directory - mkdir: path "));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "traverse directory - ls: depth "));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "comparing files - cmp: path1 path2"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "change directory - cdRel: relative path"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "change directory - cdAbs: absolute path"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "read students data base - readDb: [path]file"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "filter {courseName} excelent/average/poor  take 2/5/all students - filterExcelent (the output is written on the console)"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "order increasing students - order {courseName} ascending/descending take 20/10/all (the output is written on the console)"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "show wanted data (course/student) from Database (readDb first!) - show: [path]course[, username]"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "download file - download: path of file (saved in current directory)"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "download file asinchronously - downloadAsynch: path of file (save in the current directory)"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "get help – help"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "QUIT from BashSoft – quit"));

            OutputWriter.WriteMessageOnNewLine($"{new string('_', 100)}");
            OutputWriter.WriteEmptyLine();
            }


        private void TryFilterAndTake(string input, string[] data)
            {
            if (data.Length == 5)
                {
                var courseName = data[1];
                var filter = data[2].ToLower();
                var takeCommand = data[3].ToLower();
                var takeQuantity = data[4].ToLower();

                TryParseParametersForFilterAndTake(takeCommand, takeQuantity, courseName, filter);
                }
            else
                {
                this.DisplayInvalidCommandMessage(input);
                }
            }


        private void TryParseParametersForFilterAndTake(string takeCommand, string takeQuantity, string courseName, string filter)
            {
            if (takeCommand == "take")
                {
                if (takeQuantity == "all")
                    {
                    this.repository.FilterAndTake(courseName, filter);
                    }
                else
                    {
                    var studentsToTake = 0;

                    if (int.TryParse(takeQuantity, out studentsToTake))
                        {
                        this.repository.FilterAndTake(courseName, filter, studentsToTake);
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


        private void TryOrderAndTake(string input, string[] data)
            {
            if (data.Length == 5)
                {
                var courseName = data[1];
                var filter = data[2].ToLower();
                var takeCommand = data[3].ToLower();
                var takeQuantity = data[4].ToLower();

                TryParseParametersForOrderAndTake(takeCommand, takeQuantity, courseName, filter);
                }
            else
                {
                this.DisplayInvalidCommandMessage(input);
                }
            }


        private void TryParseParametersForOrderAndTake(string takeCommand, string takeQuantity, string courseName, string filter)
            {
            if (takeCommand == "take")
                {
                if (takeQuantity == "all")
                    {
                    this.repository.OrderAndTake(courseName, filter);
                    }
                else
                    {
                    var studentsToTake = 0;

                    if (int.TryParse(takeQuantity, out studentsToTake))
                        {
                        this.repository.OrderAndTake(courseName, filter, studentsToTake);
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


        private void TryShowWantedData(string input, string[] data)
            {
            if (data.Length == 2)
                {
                var courseName = data[1];
                this.repository.GetAllStudentsFromCourse(courseName);
                }
            else if (data.Length == 3)
                {
                var courseName = data[1];
                var userName = data[2];
                this.repository.GetStudentFromCourse(courseName, userName);
                }
            else
                {
                this.DisplayInvalidCommandMessage(input);
                }
            }

        private void TryDropDb(string input, string[] data)
            {
            if (data.Length != 1)
                {
                this.DisplayInvalidCommandMessage(input);
                return;
                }

            this.repository.UnloadData();
            OutputWriter.WriteMessageOnNewLine("Database dropped!");
            }

        }
    }
