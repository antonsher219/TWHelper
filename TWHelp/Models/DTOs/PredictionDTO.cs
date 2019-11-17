using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TWHelp.Models.DTOs
{
    public class PredictionDTO
    {
        public string ActivityChartPath { get; set; }
        public string PieChartPath { get; set; }
        public DateTime LastModified { get; set; }
        public double GoodEmotionRate { get; set; }
        public double BadEmotionRate { get; set; }
    }
}
