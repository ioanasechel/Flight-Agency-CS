﻿namespace FlightAgency.model.validator
{
    interface IValidator<E>
    {
        void Validate(E e);
    }
}
