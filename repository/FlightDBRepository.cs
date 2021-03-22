using System;
using System.Collections.Generic;
using System.Data;
using Flight_Agency.model;
using log4net;

namespace Flight_Agency.repository
{
    public class FlightDBRepository: IFlightRepositoryInterface
    {
        private static readonly ILog log = LogManager.GetLogger("FlightDBRepository");

        public FlightDBRepository()
        {
            log.Info("Creating FlightDBRepository");
        }
        
        public IEnumerable<Flight> FindAll()
        {
            IDbConnection con = DBUtils.getConnection();
            IList<Flight> flights = new List<Flight>();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select * from Flights";
                using (var dataR=comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        int flightID = dataR.GetInt32(0);
                        string destination = dataR.GetString(1);
                        DateTime departure_date = dataR.GetDateTime(2);
                        string airport = dataR.GetString(3);
                        int available_seats = dataR.GetInt32(4);
                        Flight flight = new Flight(destination, departure_date, airport, available_seats);
                        flight.ID = flightID;
                        flights.Add(flight);
                    }
                }
            }
            return flights;
        }

        public Flight Save(Flight entity)
        {
            var con = DBUtils.getConnection();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText =
                    "insert into Flights values (@flightID, @destination, @departure_date, @airport, @available_seats)";
                
                var paramId = comm.CreateParameter();
                paramId.ParameterName = "@flightID";
                paramId.Value = entity.ID;
                comm.Parameters.Add(paramId);
                
                var paramDest = comm.CreateParameter();
                paramDest.ParameterName = "@destination";
                paramDest.Value = entity.Destination;
                comm.Parameters.Add(paramDest);
                
                var paramDate = comm.CreateParameter();
                paramDate.ParameterName = "@departure_date";
                paramDate.Value = entity.DepartureDate;
                comm.Parameters.Add(paramDate);
                
                var paramAirport = comm.CreateParameter();
                paramAirport.ParameterName = "@airport";
                paramAirport.Value = entity.Airport;
                comm.Parameters.Add(paramAirport);
                
                var paramSeats = comm.CreateParameter();
                paramSeats.ParameterName = "@available_seats";
                paramSeats.Value = entity.AvailableSeats;
                comm.Parameters.Add(paramSeats);
                
                var result = comm.ExecuteNonQuery();
                if (result == 0)
                    System.Console.Write("No flights added!");
            }

            return entity;
        }

        public Flight Update(Flight entity)
        {
            var con = DBUtils.getConnection();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText =
                    "update Flights set available_seats=@seats where flightID=@flightID";
                
                var paramSeats = comm.CreateParameter();
                paramSeats.ParameterName = "@seats";
                paramSeats.Value = entity.AvailableSeats;
                comm.Parameters.Add(paramSeats);
                
                var paramId = comm.CreateParameter();
                paramId.ParameterName = "@flightID";
                paramId.Value = entity.ID;
                comm.Parameters.Add(paramId);
                
                var result = comm.ExecuteNonQuery();
                if (result == 0)
                    System.Console.Write("No flights updated!");
            }

            return entity;
        }

        public Flight findOne(int ticketFlightId)
        {
            IDbConnection con = DBUtils.getConnection();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select * from Flights where flightID=@flightID";
                var dataParameter = comm.CreateParameter();
                dataParameter.ParameterName = "@flightID";
                dataParameter.Value = ticketFlightId;
                comm.Parameters.Add(dataParameter);
                
                using (var dataR=comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        int flightID = dataR.GetInt32(0);
                        string destination = dataR.GetString(1);
                        DateTime departure_date = dataR.GetDateTime(2);
                        string airport = dataR.GetString(3);
                        int available_seats = dataR.GetInt32(4);
                        Flight flight = new Flight(destination, departure_date, airport, available_seats);
                        flight.ID = flightID;
                        return flight;
                    }
                }
            }
            return null;
        }
    }
}