using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataTypeObject
{
    public interface IPLACECRUD
    {
        void Add(Place place);

        IEnumerable<Place> GetAll();

        Place Find(int Id);

        void Remove(int Id);

        void Update(Place place);
    }
}
