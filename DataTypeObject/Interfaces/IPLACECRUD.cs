using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataTypeObject
{
    public interface IPLACECRUD
    {
        IEnumerable<Place> GetAll();
        Place Find(int Id);
    }
}
