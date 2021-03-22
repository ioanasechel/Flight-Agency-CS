using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Flight_Agency.model;
using Flight_Agency.repository;
using Flight_Agency.service;

namespace Flight_Agency
{
    internal class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
       // [STAThread]
        public static void Main (string[] args)
        {
            EmployeeDBRepository repoEmployee = new EmployeeDBRepository();
            FlightDBRepository repoFLights = new FlightDBRepository();
            TicketDBRepository repoTickets = new TicketDBRepository();
            
            Service service = new Service(repoEmployee, repoFLights, repoTickets);
            
            //Employee e = new Employee("pass1", "name1");
            //e.ID="user3";
            //repoEmployee.Save(e);

            // for (int i = 0; i < 10; i++)
            // {
            //     Flight f = new Flight("dest1", DateTime.Now, "airport1", 300);
            //     f.ID = 100+i;
            //     repoFLights.Save(f);
            // }

            Ticket t = new Ticket(100, "name1", "tourists1", "address2", 4);
            t.ID = 1000;
            //repoTickets.Save(t);
            //service.addTicket(t);
            
            
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new LogInPage(service));
            Application.Run(new MainPage(service));
        }
    }
}