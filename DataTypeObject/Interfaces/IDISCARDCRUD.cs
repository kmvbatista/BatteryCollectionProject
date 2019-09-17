using System;
using System.Collections.Generic;
using System.Text;

namespace DataTypeObject
{
    public interface IDISCARDCRUD
    {
         IEnumerable<Discard> GetMonthlyDiscards();
         IEnumerable<Discard> GetYearDiscards();
         double GetTotalDiscards();
         IEnumerable<Discard> GetAllDataDiscards(User user);
        
    }
}
