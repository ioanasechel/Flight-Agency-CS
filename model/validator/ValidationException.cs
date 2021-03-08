﻿using System;

namespace FlightAgency.model.validator

{
    class ValidationException : ApplicationException
    {
        public ValidationException(String message): base(message) { }
    }
}
