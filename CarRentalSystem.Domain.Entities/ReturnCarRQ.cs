using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Domain.Entities
{
    public class ReturnCarRQ
    {
        public List<Car> Cars { get; set; }
        public int ExtraDays { get; set; }
    }
}
