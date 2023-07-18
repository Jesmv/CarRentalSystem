using CarRentalSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Domain.Interfaces.Services
{
    public interface IPriceService
    {
        double calculateRentalPrice(Car car, int days);
        double calculateExtraDayPrice(Car car, int extraDays);

    }
}
