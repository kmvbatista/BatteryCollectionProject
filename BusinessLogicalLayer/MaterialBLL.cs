using System;
using System.Collections.Generic;
using DataAccessLayer;
using DataTypeObject;

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
        public void Add(Material material)
        {
            materialsDbContext.Materials.Add(material);
            SaveChanges();
        }

        public Material Find(int Id)
        {
            try
            {
                return materialsDbContext.Materials.Find(Id);
            }
            catch
            {
                throw new Exception();
            }
        }

        public IEnumerable<Material> GetAll()
        {
            throw new NotImplementedException();
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
