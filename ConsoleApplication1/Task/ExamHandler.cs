using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.Command;
using ConsoleApplication1.Constants;

namespace ConsoleApplication1.Task
{
    public class ExamHandler : ITaskHandler
    {
        private ICommand _command;
        public void Listener()
        {
            string command;
            do
            {
                do
                {
                    Console.WriteLine("Input command:");
                    command = Console.ReadLine();

                    switch (command)
                    {
                        case Common.Command.TotalCount:
                            _command = new TotalCountCommand();
                            break;
                        case Common.Command.Search:
                            _command = new SearchCommand();
                            break;
                        case Common.Command.TimeTaken:
                            _command = new TimeTakenCommand();
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
