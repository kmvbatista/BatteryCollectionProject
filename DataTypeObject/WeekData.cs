using System;
using System.Collections.Generic;
using System.Text;

namespace DataTypeObject
{
    public class WeekData
    {
        public int Week { get; set; }
        public int Discards { get; set; }

        public WeekData(int week, int discards)
        {
            Week = week;
            Discards = discards;
        }
    }
}
