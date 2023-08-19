using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraShop.Application.Exceptions
{
    public class EmailNotSendException : Exception
    {
        public EmailNotSendException(string message)
            : base(message)
        {
        }
    }
}
