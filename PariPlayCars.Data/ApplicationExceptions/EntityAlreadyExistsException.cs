using System;

namespace PariPlayCars.Data.ApplicationExceptions
{
    public class EntityAlreadyExistsException : Exception
    {
        public EntityAlreadyExistsException(string message) 
            : base(message)
        {
        }
    }
}
