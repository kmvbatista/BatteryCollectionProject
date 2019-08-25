using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer;
using DataTypeObject;
using System.Linq;

namespace BusinessLogicalLayer
{
    public class UserBLL : ICRUD
    {
        private readonly BatteryCollectorDbContext userDbContext;
        public UserBLL(BatteryCollectorDbContext userDbContext)
        {
            this.userDbContext = userDbContext;
        }

        public void Add(User user)
        {
            validateEmail(user.Email);
            validateCpf(user.CPF);
            //adicionar outros métodos de validação e implementá-los

            userDbContext.Add(user);
        }



        public User Find(int _Id)
        {

            return userDbContext.Users.Find(_Id);
        }

        public IEnumerable<User> GetAll()
        {
            //return userDbContext.Users.;
            return userDbContext.Users.ToList();
        }

        public void Remove(int Id)
        {
            var userFound = userDbContext.Users.Find(Id);
            userDbContext.Users.Remove(userFound);
            userDbContext.SaveChanges();
        }

        public void Update(User user)
        {
            userDbContext.Update(user);
            userDbContext.SaveChanges();
        }

        private void validateCpf(string cPF)
        {
            throw new NotImplementedException();
        }

        private void validateEmail(string email)
        {

        }

        public User Authenticate(string username, string password)
        {
            return userDbContext.Users.FirstOrDefault(u => u.Email == username && u.Password == password);
        }
    }
}
