using System.Collections.Generic;
using System.Data;
using Flight_Agency.model;
using log4net;

namespace Flight_Agency.repository
{
    public class TicketDBRepository:ITicketRepositoryInterface
    {
        private static readonly ILog log = LogManager.GetLogger("TicketDBRepository");

        public TicketDBRepository()
        {
            log.Info("Creating TicketDBRepository");
        }
        
        public IEnumerable<Ticket> FindAll()
        {
            IDbConnection con = DBUtils.getConnection();
            IList<Ticket> tickets = new List<Ticket>();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select * from Tickets";
                using (var dataR=comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        int ticketID = dataR.GetInt32(0);
                        int flightID = dataR.GetInt32(1);
                        string client_name = dataR.GetString(2);
                        string tourists = dataR.GetString(3);
                        string client_address = dataR.GetString(4);
                        int seats = dataR.GetInt32(5);
                        Ticket ticket = new Ticket(flightID, client_name, tourists, client_address, seats);
                        ticket.ID = ticketID;
                        tickets.Add(ticket);
                    }
                }
            }
            return tickets;
        }

        public Ticket Save(Ticket entity)
        {
            var con = DBUtils.getConnection();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "insert into Tickets(flightID, client_name, tourists, client_address, seats) values (@flightID, @client_name, @tourists, @client_address, @seats)";

                var paramFID = comm.CreateParameter();
                paramFID.ParameterName = "@flightID";
                paramFID.Value = entity.FlightId;
                comm.Parameters.Add(paramFID);
                
                var paramClient = comm.CreateParameter();
                paramClient.ParameterName = "@client_name";
                paramClient.Value = entity.ClientName;
                comm.Parameters.Add(paramClient);
                
                var paramTourists = comm.CreateParameter();
                paramTourists.ParameterName = "@tourists";
                paramTourists.Value = entity.Tourists;
                comm.Parameters.Add(paramTourists);
                
                var paramAddress = comm.CreateParameter();
                paramAddress.ParameterName = "@client_address";
                paramAddress.Value = entity.ClientAddress;
                comm.Parameters.Add(paramAddress);
                
                var paramSeats = comm.CreateParameter();
                paramSeats.ParameterName = "@seats";
                paramSeats.Value = entity.Seats;
                comm.Parameters.Add(paramSeats);
                
                var result = comm.ExecuteNonQuery();
                if (result == 0)
                    System.Console.Write("No tickets added!");
            }
            return entity;
        }

        public Ticket Update(Ticket entity)
        {
            //TODO implement method
            throw new System.NotImplementedException();
        }
    }
}