using System;
using System.Collections.Generic;
using DataAccessLayer;
using DataTypeObject;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogicalLayer
{
    public class MaterialBLL : IMATERIALCRUD
    {
        List<ErrorField> errors = new List<ErrorField>();
        private readonly BatteryCollectorDbContext materialsDbContext;
        public MaterialBLL(BatteryCollectorDbContext _materialsDbContext)
        {
            materialsDbContext = _materialsDbContext;
        }
        public MaterialBLL()
        {

        }
        public async Task AddAsync(Material material)
        {
            try
            {
                await materialsDbContext.Materials.AddAsync(material);
                await materialsDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public  Material Find(int Id)
        {
            try
            {
                return  materialsDbContext.Materials.Find(Id);
            }
            catch
            {
                throw new Exception();
            }
        }

        public async Task<IEnumerable<Material>> GetAll()
        {
            try
            {
                return await materialsDbContext.Materials.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(""+ex);
            }
        }
       

        public void Remove(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(Material material)
        {
            throw new NotImplementedException();
        }
    }
}
