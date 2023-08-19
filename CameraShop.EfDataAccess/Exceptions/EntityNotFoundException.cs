using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraShop.EfDataAccess.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(int id, Type type)
            : base($"Entity of type {type.Name} with id {id} was not found.")
        {
        }

        public EntityNotFoundException(string message) : base(message)
        {
        }
    }
    public class ValidationException : Exception
    {
        public ValidationException(IEnumerable<string> messages)
            : base(string.Join(", ", messages))
        {
        }
    }
}
