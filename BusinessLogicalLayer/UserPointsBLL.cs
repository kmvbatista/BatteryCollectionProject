using System.Collections.Generic;
using DataAccessLayer;
using DataTypeObject;
using System.Linq;

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

            userPointsDbContext.Add(userPoints);
            userPointsDbContext.SaveChanges();
        }

        public UserPoints Find(int Id)
        {
            return userPointsDbContext.UserPoints.Find(Id);
        }

        public IEnumerable<UserPoints> GetAll()
        {
            return userPointsDbContext.UserPoints.ToList();
        }

        public void Remove(int Id)
        {
            var userPointsFound = userPointsDbContext.Users.Find(Id);
            userPointsDbContext.Users.Remove(userPointsFound);
            userPointsDbContext.SaveChanges();
        }

        public void Update(UserPoints userPoints)
        {
            userPointsDbContext.Update(userPoints);
            userPointsDbContext.SaveChanges();
        }

        public User FindUser(int UserId)
        {
            return userPointsDbContext.Users.FirstOrDefault(user => user.Id.Equals(UserId));
        }
    }
}
