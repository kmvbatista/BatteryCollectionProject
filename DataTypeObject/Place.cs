﻿namespace DataTypeObject
{
    public class Place
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public Discard Discard { get; set; }
    }
}