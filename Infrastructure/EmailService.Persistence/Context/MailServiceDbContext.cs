using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailService.Persistence.Context
{
    public class MailServiceDbContext : DbContext
    {
        public MailServiceDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
