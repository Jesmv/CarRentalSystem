using CarRentalSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Domain.Interfaces.Services
{
    public interface IInventoryService
    {
        List<Car> AvailableCars();
        List<Car> GetAll();
    }
}
