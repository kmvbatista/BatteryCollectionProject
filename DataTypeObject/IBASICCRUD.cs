using System;
using System.Collections.Generic;
using System.Text;

namespace DataTypeObject
{
    public interface IBASICCRUD
    {
        void Add(User user);

        IEnumerable<User> GetAll();

        User Find(int Id);

        void Remove(int Id);

        void Update(User user);
    }
}
