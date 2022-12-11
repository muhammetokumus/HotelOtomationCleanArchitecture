using HotelOtomation.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelOtomation.Domain.Entities
{
    public class Hotel : BaseEntity
    {
        public int CityId { get; set; }
        public string Name { get; set; }
        public City? City { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string WebSiteUrl { get; set; }
        public decimal DailyPrice { get; set; }
    }
}
