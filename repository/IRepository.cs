using System.Collections.Generic;
using Flight_Agency.model;

namespace Flight_Agency.repository

{
    interface IRepository<ID, E> where E : Entity<ID>
    {
        IEnumerable<E> FindAll();
        
        E Save(E entity);
        
        E Update(E entity);
    }
}