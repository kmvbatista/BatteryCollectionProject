using System;
using System.Collections.Generic;
using System.Text;

namespace DataTypeObject
{
    public class Discard
    {
        public int Id { get; set; }
        public Material Material { get; set; }
        public int MaterialId { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public int Points { get; set; }

        public Discard()
        {

        }
    }
}
