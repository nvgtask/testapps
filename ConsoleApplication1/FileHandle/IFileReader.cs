using System.IO;

namespace ConsoleApplication1.FileHandle
{
    interface IFileReader
    {
        StreamReader ReadFile();
        int GetColNo(string str, string colName);
        string GetColStrVal(string str, int colNo);
    }
}
