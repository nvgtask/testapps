using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.AppData;

namespace ConsoleApplication1.Command
{
    public class HelpCommand : ICommand
    {
        public void DoJob()
        {
            AboutApp.Introduce();
        }
    }
}
