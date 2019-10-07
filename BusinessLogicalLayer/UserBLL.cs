using System.Collections.Generic;
using DataTypeObject;
using System.Text.RegularExpressions;
using System;

namespace BusinessLogicalLayer
{
    public class UserBLL : IUSERCRUD
    {
        List<ErrorField> errors = new List<ErrorField>();
        private readonly IUSERDAL userDal;
        public UserBLL(IUSERDAL _userDal)
        {
            this.userDal = _userDal;
        }

        public User Find(int _Id)
        {
            return userDal.Find(_Id);
        }

        public void UpdatePoints ( User user) {
            user.TotalPoints += 1;
            userDal.UpdateUserPoints(user);
        }

        public void Remove(int Id)
        {
            var userFound = userDal.Find(Id);
            userDal.Remove(Id);
        }
        


        public User Authenticate(string username, string password)
        {
            validateEmail(username);
            validatePasswordString(password);
            return userDal.Authenticate(username, password);
        }

        private void validatePasswordString(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                errors.Add(new ErrorField());

            }
            else if (password.Length < 8)
            {
                errors.Add(new ErrorField());

            }
        }


        public User Add(User user)
        {
            validateEmail(user.Email);
            user.Email = user.Email.ToLower();
            return userDal.Add(user);
        }

        public IEnumerable<User> GetAll()
        {
            try{
                return userDal.GetAll();
            }
            catch(Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        public User Update(User user)
        {
            try{
                return userDal.Update(user);
            }
            catch(Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        public List<RankingData> GetRankingData()
        {
            try {
                return userDal.GetRankingData();
            }
            catch(Exception) {
                throw new Exception();
            }
        }

        private void validateEmail(string Email)
        {
            if (string.IsNullOrWhiteSpace(Email))
            {
                ErrorField error = new ErrorField()
                {
                    Error = "Email deve ser informado.",
                    PropertyName = "Email"
                };
                errors.Add(error);
            }
            else if (!Regex.IsMatch(Email, @"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$"))
            {
                ErrorField error = new ErrorField()
                {
                    Error = "Email inválido.",
                    PropertyName = "Email"
                };
                errors.Add(error);
            }
        }

        private void validateCellphone(string CelphoneNumber)
        {
            if (string.IsNullOrWhiteSpace(CelphoneNumber))
            {
                ErrorField error = new ErrorField()
                {
                    Error = "Telefone deve ser informado.",
                    PropertyName = "Telefone"
                };
                errors.Add(error);
            }
            else if (CelphoneNumber.Length < 7 && CelphoneNumber.Length > 15)
            {
                ErrorField error = new ErrorField()
                {
                    Error = "Telefone deve conter entre 7 e 15 caracteres.",
                    PropertyName = "Telefone"
                };
                errors.Add(error);
            }
        }
    }
}
