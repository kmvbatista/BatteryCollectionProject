using System.Collections.Generic;

namespace DataTypeObject
{
    public interface IDISCARDCRUD
    {
        IEnumerable<Discard> GetMonthlyDiscards(User user);
        IEnumerable<Discard> GetYearDiscards(User user);
        double GetTotalUserDiscards(User user);
        ChartData GetChartsData(User user);
        GeneralData GetGeneralData(User user);
        Discard Find(int Id);
        void Add(Discard discard);
        List<StringValuePair> GetPieChartData(int Id);
    }
}
