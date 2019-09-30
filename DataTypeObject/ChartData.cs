using System;
using System.Collections.Generic;
using System.Text;

namespace DataTypeObject
{
    public class ChartData
    {
        public int[] YearPoints { get; set; }
        public int[] WeekPoints { get; set; }

        public ChartData(int[] yearPoints, int[] weekPoints)
        {
            YearPoints = yearPoints;
            WeekPoints = weekPoints;
        }
    }
}
