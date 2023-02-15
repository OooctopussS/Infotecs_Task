using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infotecs.Domain
{
    public class Value
    {
        public Guid Id { get; set; }
        public string? FileName { get; set; }
        public DateTime DateAndTime { get; set; }
        public int Seсonds { get; set; }
        public float Indicator { get; set; }
    }
}
