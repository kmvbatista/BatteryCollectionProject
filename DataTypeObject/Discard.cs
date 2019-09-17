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
        public Place Place { get; set; }
        public int IdPlace { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set }

        public Discard()
        {

        }
    }
}
