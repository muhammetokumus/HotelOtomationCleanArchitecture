using HotelOtomation.Application.Repositories;
using HotelOtomation.Domain.Entities.Common;
using HotelOtomation.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HotelOtomation.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly HotelOtomationDbContext _context;

        public ReadRepository(HotelOtomationDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll() => Table;

        public async Task<T> GetByIdAsync(int id) => await Table.FindAsync(id);

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> filter) => await Table.FirstOrDefaultAsync(filter);

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> filter) => Table.Where(filter);
    }
}
