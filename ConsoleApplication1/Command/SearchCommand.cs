using System;
using System.IO;
using ConsoleApplication1.FileHandle;
using log4net;

namespace ConsoleApplication1.Command
{
    public class SearchCommand : ICommand
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly string _filePath;
        private string _sipValue;
        private readonly string _sipString = Constants.Common.SipColName;
        private int _sipColNo = -1;

        public SearchCommand(string filePath)
        {
            _filePath = filePath;
        }

        public void DoJob()
        {
            StartCommand();
            _sipValue = Console.ReadLine();
            EntityFileReader efr = new EntityFileReader(_filePath);
            HandleData(efr);
        }

        private void StartCommand()
        {
            Console.WriteLine("SearchCommand");
            Console.WriteLine("");
            Console.WriteLine("Input s-ip value:");
        }

        private void HandleData(IFileReader efr)
        {
            using (StreamReader sr = efr.ReadFile())
            {
                string s = String.Empty;
                while ((s = sr.ReadLine()) != null)
                {
                    if (s.StartsWith("#Field"))
                    {
                        GetSipColNo(efr, s);
                        continue;
                    }

                    if (s.StartsWith("#"))
                    {
                        continue;
                    }

                    GetLineBySip(efr, s);
                }
            }
        }

        private void GetSipColNo(IFileReader efr, string s)
        {
            _sipColNo = efr.GetColNo(s, _sipString);
        }

        private void GetLineBySip(IFileReader efr, string lineData)
        {
            string sipValue = efr.GetColStrVal(lineData, _sipColNo);
            if (sipValue == _sipValue)
            {
                Console.WriteLine(lineData);
                Log.Info(lineData);
            }
        }
    }
}
