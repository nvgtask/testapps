using System;

namespace ConsoleApplication1.Command
{
    public class IncorrectCommand : ICommand
    {
        public void DoJob()
        {
            Console.WriteLine("IncorrectCommand - Please input again.");
        }
    }
}
