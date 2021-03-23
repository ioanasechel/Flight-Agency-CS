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
            log.Info("Entering findAll...");
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
            log.Info("Exiting findAll...");
            return flights;
        }

        public Flight Save(Flight entity)
        {
            log.Info("Entering save function...");
            var con = DBUtils.getConnection();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText =
                    "insert into Flights(flightID, destination, departure_date, airport, available_seats) values (@flightID, @destination, @departure_date, @airport, @available_seats)";
                
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
                    log.Info("No flights added!");
            }
            log.Info("Exiting save function...");
            return entity;
        }

        public Flight Update(Flight entity)
        {
            log.Info("Entering update function...");
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
                    log.Info("No flights updated!");
            }
            log.Info("Exiting update function...");
            return entity;
        }

        public Flight findOne(int ticketFlightId)
        {
            log.Info("Entering find one function...");
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
                        log.Info("Exiting findOne function with 1 entities...");
                        return flight;
                    }
                }
            }
            log.Info("Exiting findOne function with 0 entities...");
            return null;
        }
    }
}