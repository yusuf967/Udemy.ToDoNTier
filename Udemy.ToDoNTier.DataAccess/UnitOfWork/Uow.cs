using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.ToDoNTier.DataAccess.Context;
using Udemy.ToDoNTier.DataAccess.Interfaces;
using Udemy.ToDoNTier.DataAccess.Repository;
using Udemy.ToDoNTier.Entities.Domains;

namespace Udemy.ToDoNTier.DataAccess.UnitOfWork
{
    public class Uow : IUow
    {
        private readonly TodoContext _context;

        public Uow(TodoContext context)
        {
            _context = context;
        }

        public IRepository<T> GetRepository<T>() where T : BaseEntity
        {
            return new Repository<T>(_context);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
