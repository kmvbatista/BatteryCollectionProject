using System;
using System.Collections.Generic;
using System.Text;

namespace DataTypeObject
{
    public interface IUSERDAL
    {
        User Add(User user);

        IEnumerable<User> GetAll();

        User Find(int Id);

        void Remove(int Id);

        User Update(User user);

        User Authenticate(string username, string password);

        List<RankingData> GetRankingData();

        void UpdateUserPoints(User user);
    }
}
