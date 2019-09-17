using System;
using System.Collections.Generic;
using System.Text;

namespace DataTypeObject
{
    public interface IUSERPOINTSCRUD
    {
       void Add(UserPoints userPoints);

        void Update(UserPoints userPoints);

        IEnumerable<UserPoints> GetMonthlyPoints();

        UserPoints Find(int Id);
        IEnumerable<UserPoints> GetYearPoints();
        double GetTotalPoints();
        IEnumerable<UserPoints> GetAllDataPoints(User user);
    }
}
