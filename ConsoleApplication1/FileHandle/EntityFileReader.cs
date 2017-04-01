using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.Model;
using ConsoleApplication1.Model.Result;

namespace ConsoleApplication1.FileHandle
{
    public class EntityFileReader : IFileReader
    {
        private readonly string _sipString;
        private readonly string fileName = @"C:\nvgtask\testapps\ConsoleApplication1\Testdata\is24_iis.log";
        private int _sipColNo;

        public EntityFileReader(string sipString)
        {
            this._sipString = sipString;
        }

        public void Read()
        {
            GetSipColNo();
            GetSip();
        }

        private void GetSipColNo()
        {
            _sipColNo = -1;
            using (StreamReader sr = File.OpenText(fileName))
            {
                string s = String.Empty;
                while ((s = sr.ReadLine()) != null)
                {
                    if (s.StartsWith("#Field"))
                    {
                        var lineData = s.Split(' ').ToList();
                        lineData.RemoveAt(0);

                        for (int i = 0; i < lineData.Count; i++)
                        {
                            if (lineData[i] == _sipString)
                            {
                                _sipColNo = i;
                            }
                        }
                    }
                }
            }
        }

        private void GetSip()
        {
            List<Log> logs = new List<Log>();
            using (StreamReader sr = File.OpenText(fileName))
            {
                string s = String.Empty;
                while ((s = sr.ReadLine()) != null)
                {
                    if(s.StartsWith("#"))
                    {
                        continue;   
                    }

                    var lineData = s.Split(' ').ToList();
                    Log log = new Log()
                    {
                        Sip = lineData[_sipColNo]
                    };

                    logs.Add(log);
                }
            }

            var results = logs.GroupBy(l => l.Sip)
                      .Select(g => new TotalCountResult { Sip = g.Key, Count = g.Count()});

            foreach (var result in results)
            {
                Console.WriteLine(result.Sip + " : " + result.Count);
            }
        }
    }
}
