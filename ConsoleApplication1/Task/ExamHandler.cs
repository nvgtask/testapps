using System;
using ConsoleApplication1.Command;
using ConsoleApplication1.Constants;

namespace ConsoleApplication1.Task
{
    public class ExamHandler : ITaskHandler
    {
        private ICommand _command;
        private string _filePath;

        public ExamHandler(string filePath)
        {
            _filePath = filePath;
        }

        public void Listener()
        {
            string command;
            do
            {
                do
                {
                    Console.WriteLine("=================");
                    Console.WriteLine("                 ");
                    Console.WriteLine("=================");
                    Console.WriteLine("Input command:");
                    command = Console.ReadLine();

                    switch (command)
                    {
                        case Common.Command.TotalCount:
                            _command = new TotalCountCommand(_filePath);
                            break;
                        case Common.Command.Search:
                            _command = new SearchCommand(_filePath);
                            break;
                        case Common.Command.TimeTaken:
                            _command = new TimeTakenCommand(_filePath);
                            break;
                        case Common.Command.Exit:
                            _command = new ExitCommand();
                            break;
                        case Common.Command.Help:
                            _command = new HelpCommand();
                            break;
                        default:
                            _command = new IncorrectCommand();
                            break;
                    }
                } while (_command == null);

                _command.DoJob();
            } while (command != Common.Command.Exit);

            Console.Read();
        }
    }
}
