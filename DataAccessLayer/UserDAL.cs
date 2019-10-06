using System;
using System.Collections.Generic;
using System.Linq;
using DataTypeObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DataAccessLayer
{
    public class UserDAL : IUSERDAL
    {
        private readonly BatteryCollectorDbContext userDbContext;

        public UserDAL(BatteryCollectorDbContext _userDbContext)
        {
            userDbContext = _userDbContext;
            userDbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public List<RankingData> GetRankingData()
        {
            string[] array = new string[5];
            var ranking = userDbContext.Users.
            OrderByDescending(x => x.TotalPoints).Select(x => new RankingData(x.Name, x.TotalPoints)).ToList();
            return ranking;
        }

        public User Find(int _Id)
        {
            return userDbContext.Users.Find(_Id);
        }

        public IEnumerable<User> GetAll()
        {
            return userDbContext.Users.ToList();
        }

        public User Add(User user)
        {
            userDbContext.Add(user);
            userDbContext.SaveChanges();
            user.Password = "";
            return user;
        }

        public User Update(User user)
        {
            int totalPoints = userDbContext.Users.Where(x => x.Id == user.Id).Select(x => x.TotalPoints).ToList()[0];
            user.TotalPoints = totalPoints;
            EntityEntry<User> response = userDbContext.Update(user);
            userDbContext.SaveChanges();
            return user;
            throw new Exception();
        }

        public User Authenticate(string username, string password)
        {
            return userDbContext.Users.FirstOrDefault(u => u.Email == username && u.Password == password);
        }

        public void Remove(int Id)
        {
            
        }
    }
}
