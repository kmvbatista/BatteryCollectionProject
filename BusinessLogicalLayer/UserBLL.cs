using System;
using System.Collections.Generic;
using System.Text;
using DataTypeObject;

namespace BusinessLogicalLayer
{
    public class UserBLL : ICRUD
    {
        public void Add(User user)
        {
            validateEmail(user.Email);
            validateCpf(user.CPF);
            //adicionar outros métodos de validação e implementá-los
        }

        private void validateCpf(string cPF)
        {
            throw new NotImplementedException();
        }

        private void validateEmail(string email)
        {

        }

        public User Find(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(User user, User userFound)
        {
            throw new NotImplementedException();
        }
    }
}
