using System;
using System.Collections.Generic;
using DataTypeObject;
using System.Threading.Tasks;

namespace BusinessLogicalLayer
{
    public class MaterialBLL : IMATERIALCRUD
    {
        List<ErrorField> errors = new List<ErrorField>();
        private readonly IMATERIALDAL materialDal;
        public MaterialBLL(IMATERIALDAL _materialDal)
        {
            this.materialDal = _materialDal;
        }

        public  Material Find(int Id)
        {
            try
            {
                return materialDal.Find(Id);
            }
            catch
            {
                throw new Exception();
            }
        }

        public IEnumerable<Material> GetAll()
        {
            try
            {
                return materialDal.GetAll();
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
