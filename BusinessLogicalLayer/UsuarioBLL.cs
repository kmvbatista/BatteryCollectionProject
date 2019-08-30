using BusinessLogicalLayer.Extensions;
using DataTypeObject;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace BusinessLogicalLayer
{
    public class UsuarioBLL : ICRUD
    {
        List<ErrorField> errors = new List<ErrorField>();

        public void Add(User user)
        {
            if (string.IsNullOrWhiteSpace(user.Name))
            {
                ErrorField error = new ErrorField()
                {
                    Error = "Nome deve ser informado.",
                    PropertyName = "Nome"
                };
                errors.Add(error);
            }
            else if (user.Name.Length < 3 || user.Name.Length > 70)
            {
                ErrorField error = new ErrorField()
                {
                    Error = "Nome deve conter entre 3 e 70 caracteres.",
                    PropertyName = "Nome"
                };
                errors.Add(error);
            }
            if (string.IsNullOrWhiteSpace(user.CPF))
            {
                ErrorField error = new ErrorField()
                {
                    Error = "Nome deve ser informado.",
                    PropertyName = "Nome"
                };
                errors.Add(error);
            }
            else if (!user.CPF.IsValidCPF())
            {
                ErrorField error = new ErrorField()
                {
                    Error = "CPF inválido.",
                    PropertyName = "CPF"
                };
                errors.Add(error);
            }
            if (string.IsNullOrWhiteSpace(user.Email))
            {
                ErrorField error = new ErrorField()
                {
                    Error = "Email deve ser informado.",
                    PropertyName = "Email"
                };
                errors.Add(error);
            }
            else if (!Regex.IsMatch(user.Email, @"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$"))
            {
                ErrorField error = new ErrorField()
                {
                    Error = "Email inválido.",
                    PropertyName = "Email"
                };
                errors.Add(error);
            }
            if (string.IsNullOrWhiteSpace(user.CelphoneNumber))
            {
                ErrorField error = new ErrorField()
                {
                    Error = "Telefone deve ser informado.",
                    PropertyName = "Telefone"
                };
                errors.Add(error);
            }
            else if (user.CelphoneNumber.Length < 7 || user.CelphoneNumber.Length > 15)
            {
                ErrorField error = new ErrorField()
                {
                    Error = "Telefone deve conter entre 7 e 15 caracteres.",
                    PropertyName = "Telefone"
                };
                errors.Add(error);
            }
        }

        public User Authenticate(string username, string password)
        {
            
            User user = new User();
            return user;
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

        public void Update(User user)
        {
            throw new NotImplementedException();
        }


    }
}
