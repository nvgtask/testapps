using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace ConsoleApplication1.Command
{
    interface ICommand
    {
        void DoJob();
    }
}
