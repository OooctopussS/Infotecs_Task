using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infotecs.Domain
{
    public class Result
    {
        public Guid Id { get; set; }
        public string FileName { get; set; } = null!;
        public TimeSpan AllTime{ get; set; }
        public DateTime MinDateAndTime { get; set; }
        public int AvgSeсonds { get; set; }
        public float AvgIndicator { get; set; }
        public float MedianIndicator { get; set; }
        public float MinIndicator { get; set; }
        public float MaxIndicator { get; set; }
        public int CountStrings { get; set; }
    }
}
