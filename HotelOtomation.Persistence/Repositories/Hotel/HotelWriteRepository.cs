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
    public class HotelWriteRepository : WriteRepository<Hotel>, IHotelWriteRepository
    {
        public HotelWriteRepository(HotelOtomationDbContext context) : base(context)
        {
        }
    }
}
