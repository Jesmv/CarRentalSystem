using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Domain.Entities
{
    public class ReservationRQ
    {
        public int Days { get; set; }
        public List<Car> Cars { get; set; }
    }
}
