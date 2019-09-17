using System;
using System.Collections.Generic;
using System.Text;

namespace DataTypeObject
{
    public class UserPoints
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime Date { get; set; }
    }
}
