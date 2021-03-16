using System;

namespace Flight_Agency.model
{
    public class Ticket : Entity<int>
    {
        public Ticket(int flightId, string clientName, string tourists, string clientAddress, int seats)
        {
            FlightId = flightId;
            ClientName = clientName;
            Tourists = tourists;
            ClientAddress = clientAddress;
            Seats = seats;
        }

        public int FlightId { get; set; }
        
        public String ClientName{ get; set; }
        
        public String Tourists{ get; set; }
        
        public String ClientAddress { get; set; }
        
        public int Seats { get; set; }
    }
}