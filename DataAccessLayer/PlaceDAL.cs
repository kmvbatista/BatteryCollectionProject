using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataTypeObject;

namespace DataAccessLayer
{
    public class PlaceDAL : IPLACEDAL
    {
        private readonly BatteryCollectorDbContext placeDbContext;
        public PlaceDAL(BatteryCollectorDbContext _placeDbContext)
        {
            placeDbContext = _placeDbContext;
        }

        public Place Find(int Id)
        {
            return placeDbContext.Place.Find(Id);
        }

        public IEnumerable<Place> GetAll()
        {
            return placeDbContext.Place.ToList();
        }
    }
}
