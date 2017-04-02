using System.IO;
using System.Linq;

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

        public string GetColStrVal(string str, int colNo)
        {
            var lineData = str.Split(' ').ToList();
            return lineData[colNo];
        }
    }
}
