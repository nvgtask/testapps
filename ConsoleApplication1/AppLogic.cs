using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.AppData;
using ConsoleApplication1.Constants;
using ConsoleApplication1.FileHandle;
using ConsoleApplication1.Task;

namespace ConsoleApplication1
{
    public class AppLogic
    {
        public void ExecuteTask(string[] args)
        {
             var filePath = @"C:\nvgtask\testapps\ConsoleApplication1\Testdata\is24_iis.log";
            //TODO: Add applogic here
            AboutApp.Introduce();
            ITaskHandler handler = new ExamHandler(filePath);
            handler.Listener();
        }
    }
}
