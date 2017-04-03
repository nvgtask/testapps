using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1.Model.Entity
{
    public class TempTimeTaken : IEntity
    {
        public int Count { get; set; }
        public double Sum { get; set; }
    }
}
