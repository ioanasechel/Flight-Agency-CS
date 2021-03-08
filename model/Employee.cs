﻿using System;

namespace FlightAgency.model
{
    class Employee : Entity<string>
    {
        public String Password { get; set; }
        
        public String Name { get; set; }
        
    }
}