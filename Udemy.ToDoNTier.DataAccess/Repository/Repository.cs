using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Udemy.ToDoNTier.DataAccess.Context;
using Udemy.ToDoNTier.DataAccess.Interfaces;
using Udemy.ToDoNTier.Entities.Domains;

namespace Udemy.ToDoNTier.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly TodoContext _context;

        public Repository(TodoContext context)
        {
            _context = context;
        }

        public async Task Create(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public async Task<List<T>> GetAll()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> Find(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> GetFilter(Expression<Func<T, bool>> filter, bool asNoTracking = false)
        {
            return asNoTracking ? await _context.Set<T>().SingleOrDefaultAsync(filter) : await _context.Set<T>()
                .AsNoTracking().SingleOrDefaultAsync(filter);
        }

        public IQueryable<T> GetQuery()
        {
            return _context.Set<T>().AsQueryable();
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void Update(T entity,T unChanged)
        {
            _context.Entry(unChanged).CurrentValues.SetValues(entity);
        }
    }
}
