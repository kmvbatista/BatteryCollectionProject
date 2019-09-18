using System;
using System.Collections.Generic;
using System.Text;
using DataTypeObject;

namespace BusinessLogicalLayer
{
    public class PlaceBLL : IPLACECRUD
    {
        private readonly BatteryCollectorDbContext materialsDbContext;
        public PlaceBLL(BatteryCollectorDbContext _materialsDbContext)
        {
            materialsDbContext = _materialsDbContext;
        }
        public void Add(Place place)
        {
            materialsDbContext.Places.Add(place);
        }

        public Place Find(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Place> GetAll()
        {
            throw new NotImplementedException();
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
