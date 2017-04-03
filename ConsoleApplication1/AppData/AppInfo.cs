using System;
using ConsoleApplication1.Constants;

namespace ConsoleApplication1.AppData
{
    public static class AppInfo
    {
        public static void Introduce()
        {
            string seperator = ", ";
            string commands = Common.Command.Help + seperator
                              + Common.Command.TotalCount + seperator
                              + Common.Command.Search + seperator
                              + Common.Command.TimeTaken + seperator
                              + Common.Command.Exit;

            Console.WriteLine("We have five commands: " + commands);
        }
    }
}
