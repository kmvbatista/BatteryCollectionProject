using System;
using System.Collections.Generic;
using System.Text;

namespace DataTypeObject
{
    public class Discard
    {
        public int Id { get; set; }
        public int MaterialId { get; set; }
        public int UserId { get; set; }
        public int PlaceId { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }
        public string MaterialName { get; set; }
        public string PlaceName { get; set; }
        public int DayOfWeek { get; set; }
    public Discard()
        {
            

        }
        public Discard(int materialId,
            int userId, int placeId, int quantity, DateTime date,
            string materialName, string placeName, int weekOfMonth)
        {
            this.MaterialId = materialId;
            this.PlaceId = placeId;
            this.Quantity = quantity;
            this.UserId = userId;
            this.Date = date;
            this.MaterialName = materialName;
            this.PlaceName = placeName;
            this.DayOfWeek = weekOfMonth;
        }
    }
}
