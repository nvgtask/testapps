using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Command
{
    public class TimeTakenCommand : ICommand
    {
        public void DoJob()
        {
            Console.WriteLine("TimeTakenCommand");
        }
    }
}
