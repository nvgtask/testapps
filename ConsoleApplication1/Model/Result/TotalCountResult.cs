using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Model.Result
{
    public class TotalCountResult : IResult
    {
        public string Sip { get; set; }
        public int Count { get; set; }
    }
}
