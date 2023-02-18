using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailService.Application.Exceptions
{
    public class NoBodyException : Exception
    {
        public NoBodyException() : base ("Mail requires a body")
        {
        }

        
    }
}
