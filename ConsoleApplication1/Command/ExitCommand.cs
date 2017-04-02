using System;

namespace ConsoleApplication1.Command
{
    public class ExitCommand : ICommand
    {
        public void DoJob()
        {
            Environment.Exit(0);
        }
    }
}
