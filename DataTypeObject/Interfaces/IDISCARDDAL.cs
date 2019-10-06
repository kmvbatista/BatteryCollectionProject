using System;
using System.Collections.Generic;
using System.Text;

namespace DataTypeObject
{
    public interface IDISCARDDAL
    {
        IEnumerable<Discard> GetMonthlyDiscards(User user);
        IEnumerable<Discard> GetYearDiscards(User user);
        double GetTotalUserDiscards(User user);
        ChartData GetChartsData(User user);
        GeneralData GetGeneralData(User user);
        Discard Find(int Id);
        void Add(Discard discard);
        List<StringValuePair> GetPieChartData(int Id);
        void validateDiscard(Discard discard);
    }
}
