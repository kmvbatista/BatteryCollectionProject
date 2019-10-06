using System.Collections.Generic;

namespace DataTypeObject
{
    public interface IPLACEDAL
    {
        IEnumerable<Place> GetAll();
        Place Find(int Id);
    }
}
