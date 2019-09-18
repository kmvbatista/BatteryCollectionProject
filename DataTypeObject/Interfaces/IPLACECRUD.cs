using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataTypeObject
{
    public interface IPLACECRUD
    {
        Task Add(Place place);

        Task<IEnumerable<Place>> GetAll();

        Task<Place> Find(int Id);

        void Remove(int Id);

        void Update(Place place);
    }
}
