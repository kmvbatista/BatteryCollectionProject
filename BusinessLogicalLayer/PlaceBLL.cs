using System;
using System.Collections.Generic;
using DataTypeObject;

namespace BusinessLogicalLayer
{
    public class PlaceBLL : IPLACECRUD
    {
        private readonly IPLACEDAL placeDal;
        public PlaceBLL(IPLACEDAL _placeDal)
        {
            this.placeDal = _placeDal;
        }

        public Place Find(int Id)
        {
            return placeDal.Find(Id);
        }

        public IEnumerable<Place> GetAll()
        {
            try
            {
                return placeDal.GetAll();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
