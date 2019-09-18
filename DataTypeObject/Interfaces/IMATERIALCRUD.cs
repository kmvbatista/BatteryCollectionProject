using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace DataTypeObject
{
    public interface IMATERIALCRUD
    {
        Task AddAsync(Material material);

        Task<IEnumerable<Material>> GetAll();

        Task<Material> Find(int Id);

        void Remove(int Id);

        void Update(Material material);
    }
}
