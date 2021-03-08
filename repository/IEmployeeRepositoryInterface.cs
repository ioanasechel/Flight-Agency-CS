﻿using FlightAgency.model;

namespace FlightAgency.repository
{
    interface IEmployeeRepositoryInterface : IRepository<string, Employee>
    {
        
        Employee FindEmployeeByName(string name);
        
        
    }
}