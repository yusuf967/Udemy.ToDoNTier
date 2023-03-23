using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Udemy.ToDoNTier.Entities.Domains;

namespace Udemy.ToDoNTier.DataAccess.Interfaces
{
    public interface IRepository<T>  where T: BaseEntity
    {
        Task<List<T>> GetAll();

        Task<T> GetById(int id);
        Task<T> GetFilter(Expression<Func<T,bool>> filter,bool asNoTracking=false);

        Task Create(T entity);
        void Update(T entity);

        void Remove(int id);
        IQueryable<T> GetQuery();

    }
}
