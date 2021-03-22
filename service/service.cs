using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Flight_Agency.model;
using Flight_Agency.repository;
using Flight_Agency.utils.observer;

namespace Flight_Agency.service
{
    public class Service : IObservable
    {
        private IEmployeeRepositoryInterface repoEmployee;
        private IFlightRepositoryInterface repoFlights;
        private ITicketRepositoryInterface repoTickets;
        
        private List<IObserver>  observers = new List<IObserver>();

        public Service(IEmployeeRepositoryInterface repoEmployee, IFlightRepositoryInterface repoFlights, ITicketRepositoryInterface repoTickets)
        {
            this.repoEmployee = repoEmployee;
            this.repoFlights = repoFlights;
            this.repoTickets = repoTickets;
        }


        public override void addObserver(IObserver o)
        {
            observers.Add(o);
        }

        public override void removeObserver(IObserver o)
        {
            observers.Remove(o);
        }

        public override void notifyObservers()
        {
            foreach (var observer in observers)
            {
                observer.update();
            }
        }

        public IEnumerable<Flight> getAllFlights()
        {
            return repoFlights.FindAll();
        }

        public Employee getOneEmployee(String username)
        {
           return repoEmployee.findOne(username);
        }

        public void addTicket(Ticket ticket)
        {
            repoTickets.Save(ticket);
            Flight flight = repoFlights.findOne(ticket.FlightId);
            flight.AvailableSeats = flight.AvailableSeats - ticket.Seats;
            repoFlights.Update(flight);
        }
    }
}