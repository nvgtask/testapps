using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.Model;

namespace ConsoleApplication1.FileHandle
{
    interface IFileReader
    {
        StreamReader ReadFile();
        int GetColNo(string str, string colName);
        string GetColStrVal(string str, int colNo);
    }
}
