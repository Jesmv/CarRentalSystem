using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Domain.Entities
{
    public class LoyaltyProgram
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public int Points { get; set; }
    }
}
