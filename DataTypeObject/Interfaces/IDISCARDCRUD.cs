using System.Collections.Generic;

namespace DataTypeObject
{
    public interface IDISCARDCRUD
    {
         IEnumerable<Discard> GetMonthlyDiscards(User user);
         IEnumerable<Discard> GetYearDiscards(User user);
         double GetTotalUserDiscards(User user);
         IEnumerable<Discard> GetAllDataDiscards(User user);
        Discard Find(int Id);
        void Add(Discard discard);
    }
}
