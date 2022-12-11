using HotelOtomation.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HotelOtomation.Application.Repositories
{
    public interface IReadRepository<T> : IRepository<T> where T : BaseEntity 
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetWhere(Expression<Func<T,bool>> filter);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> filter);
        Task<T> GetByIdAsync(int id);

    }
}
