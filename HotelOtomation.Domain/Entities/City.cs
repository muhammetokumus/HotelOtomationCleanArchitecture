using HotelOtomation.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelOtomation.Domain.Entities
{
    public class City : BaseEntity
    {
        public List<Hotel>? Hotels { get; set; }
        public string Name { get; set; }
    }
}
