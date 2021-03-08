﻿using System;

namespace FlightAgency.model

{
    class Flight : Entity<int>
    {
        public String Destination { get; set; }
        
        public DateTime DepartureTime { get; set; }
        
        public String Airport { get; set; }
        
        public int AvailableSeats { get; set; }

    }
}