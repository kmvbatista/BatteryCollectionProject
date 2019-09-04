using System;
using System.Collections.Generic;
using System.Text;

namespace DataTypeObject
{
    public interface IUSERPOINTSCRUD
    {
       void Add(UserPoints userPoints);

        void Remove(int Id);

        void Update(UserPoints userPoints);

        User FindUser(int UserId);

        UserPoints Find(int Id);

    }
}
