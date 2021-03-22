namespace Flight_Agency.model.validator
{
    interface IValidator<E>
    {
        void Validate(E e);
    }
}
