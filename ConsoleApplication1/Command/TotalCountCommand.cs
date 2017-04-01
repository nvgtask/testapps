using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.Constants;
using ConsoleApplication1.FileHandle;

namespace ConsoleApplication1.Command
{
    public class TotalCountCommand : ICommand
    {
        public void DoJob()
        {
            Console.WriteLine("TotalCountCommand");
            EntityFileReader efr = new EntityFileReader(Common.SipString);
            efr.Read();
        }
    }
}
