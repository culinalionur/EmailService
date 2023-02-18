using EmailService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailService.Application.Repositories
{
    public interface IRepository<T> where T : class
    {
        DbSet<T> Table { get; }
        IEnumerable<IGrouping<string,Email>> GetAll();
        Task<bool> AddAsync(T model);
        bool Remove(T model);
        Task<int> SaveAsync();
    }
}
