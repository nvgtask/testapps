using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using ConsoleApplication1.FileHandle;
using ConsoleApplication1.Model.Entity;
using log4net;

namespace ConsoleApplication1.Command
{
    public class TimeTakenCommand : ICommand
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly string _filePath;
        private readonly string _timetakenColName = Constants.Common.TimeTakenColName;
        private int _timetakenColNo = -1;
        private List<Log> _logs = new List<Log>();

        //private double _tempResult;
        //private bool _firstTransTime = true;

        private List<TempTimeTaken> _tempData = new List<TempTimeTaken>();

        public TimeTakenCommand(string filePath)
        {
            _filePath = filePath;
        }

        public void DoJob()
        {
            StartCommand();
            EntityFileReader efr = new EntityFileReader(_filePath);
            ReadTimeTaken(efr);
            ShowResult();
        }

        private void StartCommand()
        {
            Console.WriteLine("TimeTakenCommand");
        }

        private void ReadTimeTaken(IFileReader efr)
        {
            using (StreamReader sr = efr.ReadFile())
            {
                string str;
                while ((str = sr.ReadLine()) != null)
                {
                    if (str.StartsWith("#Field"))
                    {
                        GetTimeTakenColNo(efr, str);
                        continue;
                    }

                    if (str.StartsWith("#"))
                    {
                        continue;
                    }

                    //Paging Reading
                    GetTimeTakenValueWithTemp(efr, str);
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
            //var timetaken = CaculateOnLogs();
            var timetaken = CaculateOnTemp();
            var result = "Time taken average is: " + timetaken;
            Console.WriteLine(result);
            Log.Info(result);
        }

        // Read data in one process
        #region Read data in one process
        private double CaculateOnLogs()
        {
            return _logs.Average(l => l.TimeTaken);
        }
        #endregion Read data in one process

        // Paging reading - Prevent out of memory
        #region Paging reading

        private void GetTimeTakenValueWithTemp(IFileReader efr, string s)
        {
            GetTimeTakenValue(efr, s);
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
            double sum = _logs.Sum(l => l.TimeTaken);
            _tempData.Add(new TempTimeTaken
            {
                Count = _logs.Count,
                Sum = sum
            });

            // Reset data list of text line
            _logs.Clear();
        }

        private double CaculateOnTemp()
        {
            int count = 0;
            double sum = 0;

            TransferDataListToTemp();
            foreach (var item in _tempData)
            {
                count += item.Count;
                sum += item.Sum;
            }
            return sum/count;
        }

        #endregion Paging reading
    }
}
