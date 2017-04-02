﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.FileHandle;
using ConsoleApplication1.Model;
using ConsoleApplication1.Model.Result;
using log4net;

namespace ConsoleApplication1.Command
{
    public class SearchCommand : ICommand
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private string _filePath;
        private string _sipValue;
        private readonly string _sipString = Constants.Common.SipColName;
        private int _sipColNo = -1;
        private readonly List<Log> _logs = new List<Log>();

        public SearchCommand(string filePath)
        {
            _filePath = filePath;
        }

        public void DoJob()
        {
            Console.WriteLine("SearchCommand");
            Console.WriteLine("Input s-ip value:");
            _sipValue = Console.ReadLine();
            EntityFileReader efr = new EntityFileReader(_filePath);
            HandleData(efr);
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
