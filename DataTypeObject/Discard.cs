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
        public Place Place { get; set; }
        public int PlaceId { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }
        public string MaterialName { get; set; }
        public string PlaceName { get; set; }
        public int DayOfWeek { get; set; }

        public Discard()
        {
            

        }
        public Discard(Material material, int materialId, User user,
            int userId, Place place, int placeId, int quantity, DateTime date,
            string materialName, string placeName, int weekOfMonth)
        {
            this.Material = material;
            this.MaterialId = materialId;
            this.Place = place;
            this.PlaceId = PlaceId;
            this.Quantity = quantity;
            this.User = user;
            this.UserId = userId;
            this.Date = date;
            this.MaterialName = materialName;
            this.PlaceName = placeName;
            this.DayOfWeek = weekOfMonth;
        }
    }
}
