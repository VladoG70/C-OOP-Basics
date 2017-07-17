using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BashSoft
    {
    class BashSoftProgram
        {
        public const string filePathBashSoftPRJ = @"..\..\tests\";

        static void Main(string[] args)
            {
            Tester tester = new Tester();
            IOManager ioManager = new IOManager();
            StudentsRepository repo = new StudentsRepository(new RepositorySorter(), new RepositoryFilter());

            CommandInterpreter currentInterpreter = new CommandInterpreter(tester, repo, ioManager);
            InputReader reader = new InputReader(currentInterpreter);

            //testFunctionality();

            // COMMAND Interpreter - READY
            reader.StartReadingCommands();

            }

        // ONLY for TESTING
        private static void testFunctionality()
            {
            //IOManager.TraverseDirectory(@"D:\Install");
            //StudentsRepository.InitializeData();

            //Console.WriteLine(new string('-', 50));
            //Console.WriteLine("GetAllStudentsFromCourse ".PadRight(50, '-'));
            //Console.WriteLine(new string('-', 50));
            //StudentsRepository.GetAllStudentsFromCourse("Unity");

            //Console.WriteLine(new string('-', 50));
            //Console.WriteLine("GetStudentScoreFromCourse ".PadRight(50, '-'));
            //Console.WriteLine(new string('-', 50));
            //StudentsRepository.GetStudentScoreFromCourse("Unity", "Ivan");

            //IOManager.CreateDirectoryInCurrentFolder("pesho");

            //IOManager.ChangeCurrentDirectoryAbsolute(@"C:\Windows");
            //IOManager.TraverseDirectory(20);

            // Making a Directory with Illegal Symbols
            //IOManager.CreateDirectoryInCurrentFolder("*2");

            // TEST Simple JUDGE
            //Tester.CompareContent(filePathBashSoftPRJ + @"test1.txt", filePathBashSoftPRJ + @"test2.txt");

            //Tester.CompareContentfilePathBashSoftPRJ + @"test2.txt", filePathBashSoftPRJ + @"test3.txt");

            //IOManager.CreateDirectoryInCurrentFolder("pesho");

            //Tester.CompareContent(filePathBashSoftPRJ + @"actual.txt", filePathBashSoftPRJ + @"expected.txt");

            // Test for Invalid Path/File messages
            //Tester.CompareContent(filePathBashSoftPRJ + @"actdual.txt", filePathBashSoftPRJ + @"expected.txt");

            // Problem 6.Going One Folder up the Hierarchy
            //IOManager.ChangeCurrentDirectoryRelative("..");
            //IOManager.ChangeCurrentDirectoryRelative("..");
            //IOManager.ChangeCurrentDirectoryRelative("..");
            //IOManager.ChangeCurrentDirectoryRelative("..");
            //IOManager.ChangeCurrentDirectoryRelative("..");
            //IOManager.ChangeCurrentDirectoryRelative("..");
            //IOManager.ChangeCurrentDirectoryRelative("..");
            //IOManager.ChangeCurrentDirectoryRelative("..");
            //IOManager.ChangeCurrentDirectoryRelative("..");
            //IOManager.ChangeCurrentDirectoryRelative("..");
            //IOManager.ChangeCurrentDirectoryRelative("..");
            //IOManager.ChangeCurrentDirectoryRelative("..");
            //IOManager.ChangeCurrentDirectoryRelative("..");
            }
        }
    }
