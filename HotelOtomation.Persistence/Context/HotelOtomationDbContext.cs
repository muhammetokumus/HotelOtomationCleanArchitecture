using HotelOtomation.Domain.Entities;
using HotelOtomation.Domain.Entities.Common;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelOtomation.Persistence.Context
{
    public class HotelOtomationDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=HotelOtomationDb;Trusted_Connection=True;");
        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<City> Cities { get; set; }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var now = DateTime.UtcNow;

            foreach (var changedEntity in ChangeTracker.Entries())
            {
                if (changedEntity.Entity is BaseEntity entity)
                {
                    switch (changedEntity.State)
                    {
                        case EntityState.Added:
                            entity.CreatedDate = now;
                            entity.UpdatedDate = now;
                            break;

                        case EntityState.Modified:
                            Entry(entity).Property(x => x.CreatedDate).IsModified = false;
                            entity.UpdatedDate = now;
                            break;
                    }
                }
            }
            return await base.SaveChangesAsync();
        }
    }
}
