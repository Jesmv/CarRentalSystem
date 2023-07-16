﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Infraestructure.Data.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Category { get; set; }
        public bool IsRent { get; set; }
    }
}