using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Domain.Interfaces.Services
{
    public interface IPriceStrategy
    {
        double calculatePrice(int days);

        double calculateExtraDays(int extraDays);
    }
}
