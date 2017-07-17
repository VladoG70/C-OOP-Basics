using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BashSoft
    {
    public class IOManager
        {
        public void TraverseDirectory(int depth) // change straing path -> int depth (f03-p04)
            {
            OutputWriter.WriteMessageOnNewLine(SessionData.currentPath);
            // change file03-Problem 4 (f03-p04)
            int initialIdentation = SessionData.currentPath.Split('\\').Length;
            Queue<string> subFolders = new Queue<string>();
            // change file03-Problem 4
            subFolders.Enqueue(SessionData.currentPath);

            while (subFolders.Count != 0)
                {
                string currentPath = subFolders.Dequeue();
                int identation = currentPath.Split('\\').Length - initialIdentation;
                OutputWriter.WriteMessageOnNewLine($"{new string('-', identation)}{currentPath}");

                try
                    {
                    // f03-p04
                    foreach (string file in Directory.GetFiles(currentPath))
                        {
                        int indexOfLastSlash = file.LastIndexOf("\\");
                        string fileName = file.Substring(indexOfLastSlash);
                        OutputWriter.WriteMessageOnNewLine(new string('-', indexOfLastSlash) + fileName);

                        if (depth - identation < 0)
                            {
                            break;
                            }
                        }

                    foreach (var directoryPath in Directory.GetDirectories(currentPath))
                        {
                        subFolders.Enqueue(directoryPath);
                        }
                    }
                catch (UnauthorizedAccessException)
                    {
                    OutputWriter.DisplayException(ExceptionMessages.UnauthorizedAccessExceptionMessage);
                    }


                }

            }

        public void CreateDirectoryInCurrentFolder(string name)
            {
            string path = GetCurrentDirectoryPath() + "\\" + name;
            try
                {
                Directory.CreateDirectory(path);
                }
            catch (ArgumentException)
                {
                OutputWriter.DisplayException(ExceptionMessages.ForbiddenSymbolsContainedInName);
                }

            }

        private string GetCurrentDirectoryPath()
            {
            return Directory.GetCurrentDirectory();
            }

        public void ChangeCurrentDirectoryRelative(string relativePath)
            {
            if (relativePath == "..")
                {
                try
                    {
                    string currentPath = SessionData.currentPath;
                    int indexOfLastSlash = currentPath.LastIndexOf("\\");
                    string newPath = currentPath.Substring(0, indexOfLastSlash);
                    SessionData.currentPath = newPath;
                    }
                catch (ArgumentOutOfRangeException)
                    {
                    OutputWriter.DisplayException(ExceptionMessages.UnableToGoHigherInPartitionHierarchy);
                    }
                }
            else
                {
                string currentPath = SessionData.currentPath;
                currentPath += "\\" + relativePath;
                ChangeCurrentDirectoryAbsolute(currentPath);
                }
            }

        public void ChangeCurrentDirectoryAbsolute(string absolutePath)
            {
            if (!Directory.Exists(absolutePath))
                {
                OutputWriter.DisplayException(ExceptionMessages.InvalidPath);
                return;
                }

            SessionData.currentPath = absolutePath;
            }

        } // End of class IOManager
    }
