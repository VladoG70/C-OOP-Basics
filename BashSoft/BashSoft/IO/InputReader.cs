using System;

namespace BashSoft
    {
    public class InputReader
        {
        private const string endCommand = "quit";
        private CommandInterpreter interpreter;

        public InputReader(CommandInterpreter interpreter)
            {
            this.interpreter = interpreter;
            }

        public void StartReadingCommands()
            {
            // Input Commands
            OutputWriter.WriteMessage($"{SessionData.currentPath}> ");
            string input = Console.ReadLine();
            input = input.Trim();

            while (input.ToLower() != endCommand)
                {
                this.interpreter.InterpredCommand(input);
                OutputWriter.WriteMessage($"{SessionData.currentPath}> ");
                input = Console.ReadLine();
                input = input.Trim();
                }
            }
        } // END of InputReader
    }