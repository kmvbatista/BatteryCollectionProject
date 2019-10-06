using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer;
using DataTypeObject;
using System.Linq;

namespace BusinessLogicalLayer
{
    public class PlaceBLL : IPLACECRUD
    {
        private readonly BatteryCollectorDbContext placeDbContext;
        public PlaceBLL(BatteryCollectorDbContext _placeDbContext)
        {
            placeDbContext = _placeDbContext;
        }
        public PlaceBLL()
        {

        }
        public void Add(Place place)
        {
            try
            {
                placeDbContext.Place.Add(place);
                placeDbContext.SaveChanges();
            }
            catch(Exception)
            {
                throw new Exception();
            }
        }

        public  Place Find(int Id)
        {
            try
            {
                return  placeDbContext.Place.Find(Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Place> GetAll()
        {
            try
            {
                return placeDbContext.Place.ToList();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public void Remove(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(Place place)
        {
            throw new NotImplementedException();
        }
    }
}
