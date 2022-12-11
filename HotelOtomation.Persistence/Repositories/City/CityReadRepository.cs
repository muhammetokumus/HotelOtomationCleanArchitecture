using HotelOtomation.Application.Repositories;
using HotelOtomation.Domain.Entities;
using HotelOtomation.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelOtomation.Persistence.Repositories
{
    public class CityReadRepository : ReadRepository<City>, ICityReadRepository
    {
        public CityReadRepository(HotelOtomationDbContext context) : base(context)
        {
        }
    }
}
