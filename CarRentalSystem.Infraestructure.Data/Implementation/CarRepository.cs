using CarRentalSystem.Domain.Entities;
using CarRentalSystem.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Infraestructure.Data.Implementation
{
    public class CarRepository : BaseRepository<Car>, ICarRepository
    {
        public CarRepository(CarRentalDbContext dbContext) : base(dbContext)
        {
        }
    }
}
