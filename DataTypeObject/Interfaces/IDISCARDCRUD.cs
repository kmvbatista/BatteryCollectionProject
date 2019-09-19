using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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
