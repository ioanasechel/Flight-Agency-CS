using System;

namespace Flight_Agency.model

{
    public class Flight : Entity<int>
    {
        public Flight(string destination, DateTime departureDate, string airport, int availableSeats)
        {
            Destination = destination;
            DepartureDate = departureDate;
            Airport = airport;
            AvailableSeats = availableSeats;
        }

        public String Destination { get; set; }
        
        public DateTime DepartureDate { get; set; }
        
        public String Airport { get; set; }
        
        public int AvailableSeats { get; set; }

        public override string ToString()
        {
            return "ID="+ID+" Destination="+Destination+" Departure_date="+DepartureDate+" Airport="+Airport+" AvailableSeats="+AvailableSeats;
        }
    }
}