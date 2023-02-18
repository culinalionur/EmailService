using EmailService.Application.Repositories;
using EmailService.Domain.Entities;
using EmailService.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailService.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly MailServiceDbContext _context;

        public Repository(MailServiceDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AddAsync(T model)
        {
            EntityEntry<T> entityEntry = await Table.AddAsync(model);
            SaveAsync();
            return true;
        }

        public IEnumerable<IGrouping<string, Email>> GetAll()
        {
            return _context.Set<Email>().GroupBy(i=>i.From).ToList();
        }

        public bool Remove(T model)
        {
            EntityEntry<T> entityEntry = Table.Remove(model);
            SaveAsync();
            return entityEntry.State == EntityState.Deleted;
        }

        public async Task<int> SaveAsync()
            => await _context.SaveChangesAsync();
        
    }
}
