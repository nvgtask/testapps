using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.FileHandle;
using ConsoleApplication1.Model;
using ConsoleApplication1.Model.Result;

namespace ConsoleApplication1.Command
{
    public class TimeTakenCommand : ICommand
    {
        private readonly string _timetakenColName = Constants.Common.TimeTakenColName;
        private int _timetakenColNo = -1;
        private readonly List<Log> _logs = new List<Log>();

        public void DoJob(string filePath)
        {
            Console.WriteLine("TimeTakenCommand");
            EntityFileReader efr = new EntityFileReader(filePath);
            ReadTimeTaken(efr);
            ShowResult();
        }

        private void ReadTimeTaken(IFileReader efr)
        {
            using (StreamReader sr = efr.ReadFile())
            {
                string s = String.Empty;
                while ((s = sr.ReadLine()) != null)
                {
                    if (s.StartsWith("#Field"))
                    {
                        GetTimeTakenColNo(efr, s);
                        continue;
                    }

                    if (s.StartsWith("#"))
                    {
                        continue;
                    }

                    GetTimeTakenValue(efr, s);
                }
            }
        }

        private void GetTimeTakenColNo(IFileReader efr, string s)
        {
            _timetakenColNo = efr.GetColNo(s, _timetakenColName);
        }

        private void GetTimeTakenValue(IFileReader efr, string s)
        {
            string valueStr = efr.GetColStrVal(s, _timetakenColNo);
            double value;

            if (double.TryParse(valueStr, out value))
            {
                Log log = new Log
                {
                    TimeTaken = value
                };
                _logs.Add(log);
            }
        }

        private void ShowResult()
        {
            var result = _logs.Average(l => l.TimeTaken);
            Console.WriteLine("Time taken average is: " + result);
        }
    }
}
