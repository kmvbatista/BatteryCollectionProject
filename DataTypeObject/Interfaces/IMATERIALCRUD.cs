using System;
using System.Collections.Generic;
using System.Text;

namespace DataTypeObject
{
    public interface IMATERIALCRUD
    {
        void Add(Material material);

        IEnumerable<Material> GetAll();

        Material Find(int Id);

        void Remove(int Id);

        void Update(Material material);
    }
}
