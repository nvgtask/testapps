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
        
        private readonly string _filePath;

        public EntityFileReader(string filePath)
        {
            _filePath = filePath;
        }

        public StreamReader ReadFile()
        {
            return File.OpenText(_filePath);
        }

        public int GetColNo(string str, string colName)
        {
            var colNo = -1;
            var lineData = str.Split(' ').ToList();
            lineData.RemoveAt(0);

            for (var i = 0; i < lineData.Count; i++)
            {
                if (lineData[i] == colName)
                {
                    colNo = i;
                }
            }

            return colNo;
        }

        public Log GetColVal(string str, int colNo)
        {
            var lineData = str.Split(' ').ToList();
            Log log = new Log()
            {
                Sip = lineData[colNo]
            };

            return log;
        }

        public string GetColStrVal(string str, int colNo)
        {
            var lineData = str.Split(' ').ToList();
            return lineData[colNo];
        }
    }
}
