﻿using System;

namespace FlightAgency.model
{
    class Ticket : Entity<int>
    {
        public int FlightId { get; set; }
        
        public String ClientName{ get; set; }
        
        public String Tourists{ get; set; }
        
        public String ClientAddress { get; set; }
        
        public int Seats { get; set; }
    }
}