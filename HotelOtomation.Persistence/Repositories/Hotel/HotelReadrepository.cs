using HotelOtomation.Application.Repositories;
using HotelOtomation.Domain.Entities;
using HotelOtomation.Domain.Entities.Common;
using HotelOtomation.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelOtomation.Persistence.Repositories
{
    public class HotelReadrepository : ReadRepository<Hotel>, IHotelReadRepository
    {
        public HotelReadrepository(HotelOtomationDbContext context) : base(context)
        {
        }
    }
}
