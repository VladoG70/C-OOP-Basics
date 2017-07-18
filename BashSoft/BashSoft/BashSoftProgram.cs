namespace BashSoft
    {
    internal class BashSoftProgram
        {

        private static void Main(string[] args)
            {
            Tester tester = new Tester();
            IOManager ioManager = new IOManager();
            StudentsRepository repo = new StudentsRepository(new RepositorySorter(), new RepositoryFilter());

            CommandInterpreter currentInterpreter = new CommandInterpreter(tester, repo, ioManager);
            InputReader reader = new InputReader(currentInterpreter);

            // COMMAND Interpreter - READY
            reader.StartReadingCommands();
            }
        }
    }