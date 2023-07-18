using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Domain.Entities
{
    public class ReservationRS
    {
        public string Currency => "Euros";
        public Dictionary<string, double> Cars { get; set; }
        public double Total { get; set; }
        public int LoyaltyPoints { get; set; }
    }
}
