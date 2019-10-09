using System;
using System.Collections.Generic;
using System.Text;

namespace DataTypeObject
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int TotalPoints { get; set; }

        public User(int id, string name, string email, string password, int totalPoints )
        {
            this.Email= email;
            this.Id = id;
            this.TotalPoints = totalPoints;
            this.Password = password;
            this.Name = name;
        }

    public User(int id, string name, string email)
    {
      Id = id;
      Name = name;
      Email = email;
    }
    public User()
    {
        
    }
  }
}
