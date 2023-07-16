﻿namespace CarRentalSystem.Domain.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Category { get; set; }
        public bool IsRent { get; set; }
    }
}