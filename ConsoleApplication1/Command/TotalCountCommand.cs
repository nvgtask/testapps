using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.Constants;
using ConsoleApplication1.FileHandle;
using ConsoleApplication1.Model;
using ConsoleApplication1.Model.Result;

namespace ConsoleApplication1.Command
{
    public class TotalCountCommand : ICommand
    {
        private readonly string _sipString = Constants.Common.SipColName;
        private int _sipColNo = -1;
        private readonly List<Log> _logs = new List<Log>();

        public void DoJob(string filePath)
        {
            Console.WriteLine("TotalCountCommand");
            EntityFileReader efr = new EntityFileReader(filePath);
            ReadSip(efr);
            ShowResult();
        }

        private void ReadSip(IFileReader efr)
        {
            using (StreamReader sr = efr.ReadFile())
            {
                string s = String.Empty;
                while ((s = sr.ReadLine()) != null)
                {
                    if (s.StartsWith("#Field"))
                    {
                        GetSipColNo(efr,s);
                        continue;
                    }

                    if (s.StartsWith("#"))
                    {
                        continue;
                    }

                    GetSipValue(efr,s);
                }
            }
        }

        private void GetSipColNo(IFileReader efr, string s)
        {
            _sipColNo = efr.GetColNo(s, _sipString);
        }

        private void GetSipValue(IFileReader efr, string s)
        {
            Log log = new Log
            {
                Sip = efr.GetColStrVal(s, _sipColNo)
            };

            _logs.Add(log);
        }

        private void ShowResult()
        {
            var results = _logs.GroupBy(l => l.Sip)
                      .Select(g => new TotalCountResult { Sip = g.Key, Count = g.Count() });

            foreach (var result in results)
            {
                Console.WriteLine(result.Sip + " : " + result.Count);
            }
        }
    }
}
