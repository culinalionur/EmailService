using EmailService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailService.Application.Repositories.Mail
{
    public interface IMailRepository<T> : IRepository<Email> 
    {

    }
   
    
}
