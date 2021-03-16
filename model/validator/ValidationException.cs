using System;

namespace Flight_Agency.model.validator

{
    class ValidationException : ApplicationException
    {
        public ValidationException(String message): base(message) { }
    }
}
