using System;

namespace PariPlayCars.Data.ApplicationExceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string message) : base(message)
        {
        }
    }
}
