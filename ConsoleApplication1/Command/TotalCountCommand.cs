using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ConsoleApplication1.FileHandle;
using ConsoleApplication1.Model;
using ConsoleApplication1.Model.Result;
using log4net;

namespace ConsoleApplication1.Command
{
    public class TotalCountCommand : ICommand
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly string _filePath;
        private readonly string _sipString = Constants.Common.SipColName;
        private int _sipColNo = -1;
        private List<Log> _logs = new List<Log>();

        private readonly List<TotalCountResult> _tempResult = new List<TotalCountResult>();

        public TotalCountCommand(string filePath)
        {
            _filePath = filePath;
        }

        public void DoJob()
        {
            StartCommand();
            EntityFileReader efr = new EntityFileReader(_filePath);
            ReadSip(efr);
            ShowResult();
        }

        private void StartCommand()
        {
            Console.WriteLine("TotalCountCommand");
        }

        private void ReadSip(IFileReader efr)
        {
            using (StreamReader sr = efr.ReadFile())
            {
                string str;
                while ((str = sr.ReadLine()) != null)
                {
                    if (str.StartsWith("#Field"))
                    {
                        GetSipColNo(efr,str);
                        continue;
                    }

                    if (str.StartsWith("#"))
                    {
                        continue;
                    }

                    GetSipValueWithTemp(efr,str);
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
            var results = CaculateOnTemp();
            //var results = CaculateOnLogs();

            foreach (var result in results)
            {
                string formatedResult = result.Sip + " : " + result.Count;
                Console.WriteLine(formatedResult);
                Log.Info(formatedResult);
            }
        }

        // Read data in one process
        #region Read data in one process
        private IEnumerable<TotalCountResult> CaculateOnLogs()
        {
            var results = _logs.GroupBy(l => l.Sip)
          .Select(g => new TotalCountResult { Sip = g.Key, Count = g.Count() });

            return results;
        }
        #endregion Read data in one process

        // Paging reading - Prevent out of memory
        #region Paging reading

        private void GetSipValueWithTemp(IFileReader efr, string s)
        {
            GetSipValue(efr, s);
            // paging reading
            AddToTempResult();
        }

        private void AddToTempResult()
        {
            if (_logs.Count > 1000)
            {
                TransferDataListToTemp();
            }
        }

        private void TransferDataListToTemp()
        {
            var results = _logs.GroupBy(l => l.Sip)
                      .Select(g => new TotalCountResult { Sip = g.Key, Count = g.Count() }).ToList();

            // Transfer results to temp
            foreach (var result in results)
            {
                _tempResult.Add(result);
            }

            // Reset _log
            _logs = new List<Log>();
        }

        private IEnumerable<TotalCountResult> CaculateOnTemp()
        {
            TransferDataListToTemp();
            var results = _tempResult.GroupBy(temp => temp.Sip)
                      .Select(g => new TotalCountResult { Sip = g.Key, Count = g.Sum(temp => temp.Count) });

            return results;
        }
        #endregion Paging reading
    }
}
