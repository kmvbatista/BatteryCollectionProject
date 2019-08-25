using System;
using System.Collections.Generic;
using System.Text;

namespace DataTypeObject
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
        public string CelphoneNumber { get; set; }
        public string Password { get; set; }
        public int TotalPoints { get; set; }

        public User()
        {

        }
    }
}
