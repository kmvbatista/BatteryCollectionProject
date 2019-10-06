using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataTypeObject
{
    public interface IMATERIALDAL
    {
        IEnumerable<Material> GetAll();

        Material Find(int Id);
    }
}
