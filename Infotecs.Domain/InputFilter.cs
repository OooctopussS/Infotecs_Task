using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infotecs.Domain
{
    public class InputFilter
    {
        public string? FileName { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int? SecondsLowerBoundle { get; set; }
        public int? SecondsUpperBoundle { get; set; }
        public float? IndicatorLowerBoundle { get; set; }
        public float? IndicatorUpperBoundle { get; set; }
    }
}
