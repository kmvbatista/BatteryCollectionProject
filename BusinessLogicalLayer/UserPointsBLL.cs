using System.Collections.Generic;
using DataAccessLayer;
using DataTypeObject;
using System.Linq;
using System;

namespace BusinessLogicalLayer
{
    public class UserPointBLL : IUSERPOINTSCRUD
    {
        List<ErrorField> errors = new List<ErrorField>();
        private readonly BatteryCollectorDbContext userPointsDbContext;
        public UserPointBLL(BatteryCollectorDbContext _userPointsDbContext)
        {
            userPointsDbContext = _userPointsDbContext;
        }

        public void Add(UserPoints userPoints)
        {
            //adicionar outros métodos de validação e implementá-los
            userPoints.Date = DateTime.Now.AddMonths(1);
            userPointsDbContext.Add(userPoints);
            userPointsDbContext.SaveChanges();
        }

        public UserPoints Find(int Id)
        {
            return userPointsDbContext.UserPoints.Find(Id);
        }

        public IEnumerable<UserPoints> GetMonthlyPoints()
        {
            return userPointsDbContext.UserPoints.Where(x => x.Date.Month == DateTime.Now.Month);
        }

        public IEnumerable<UserPoints> GetYearPoints()
        {
            return userPointsDbContext.UserPoints.Where(x => x.Date.Year == DateTime.Now.Year);
        }

        public double GetTotalPoints()
        {
            return userPointsDbContext.UserPoints.ToList().Count;
        }

        public void Update(UserPoints userPoints)
        {
            userPointsDbContext.Update(userPoints);
            userPointsDbContext.SaveChanges();
        }


        IEnumerable<UserPoints> IUSERPOINTSCRUD.GetAllDataPoints(User user)
        {
            try
            {
                return userPointsDbContext.UserPoints.ToList();
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}
