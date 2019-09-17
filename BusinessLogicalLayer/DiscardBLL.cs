using System.Collections.Generic;
using DataAccessLayer;
using DataTypeObject;
using System.Linq;
using System;

namespace BusinessLogicalLayer
{
    public class DiscardBLL : IDISCARDCRUD
    {
        List<ErrorField> errors = new List<ErrorField>();
        private readonly BatteryCollectorDbContext userPointsDbContext;
        public DiscardBLL(BatteryCollectorDbContext _userPointsDbContext)
        {
            userPointsDbContext = _userPointsDbContext;
        }

        public void Add(Discard userPoints)
        {
            //adicionar outros métodos de validação e implementá-los
            userPoints.Date = DateTime.Now.AddMonths(1);
            userPointsDbContext.Add(userPoints);
            userPointsDbContext.SaveChanges();
        }
        public Discard Find(int Id)
        {
            return userPointsDbContext.Discards.Find(Id);
        }
        public void Update(Discard userPoints)
        {
            userPointsDbContext.Update(userPoints);
            userPointsDbContext.SaveChanges();
        }
        public IEnumerable<Discard> GetMonthlyDiscards()
        {
            return userPointsDbContext.Discards.Where(x => x.Date.Month == DateTime.Now.Month);
        }

        public IEnumerable<Discard> GetYearDiscards()
        {
            return userPointsDbContext.Discards.Where(x => x.Date.Year == DateTime.Now.Year);
        }
        public double GetTotalDiscards()
        {
            return userPointsDbContext.Discards.ToList().Count;
        }

        IEnumerable<Discard> IDISCARDCRUD.GetAllDataDiscards(User user)
        {
            try
            {
                return userPointsDbContext.Discards.ToList();
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}
