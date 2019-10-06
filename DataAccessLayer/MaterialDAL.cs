using System.Collections.Generic;
using System.Linq;
using DataTypeObject;

namespace DataAccessLayer
{
    public class MaterialDAL : IMATERIALDAL
    {
        private readonly BatteryCollectorDbContext materialsDbContext;
        public MaterialDAL(BatteryCollectorDbContext batteryCollectorDbContext)
        {
            this.materialsDbContext = batteryCollectorDbContext;
        }
        public Material Find(int Id)
        {
            return materialsDbContext.Materials.Find(Id);
        }

        public IEnumerable<Material> GetAll()
        {
            return materialsDbContext.Materials.ToList();
        }
    }
}
