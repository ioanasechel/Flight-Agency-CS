using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Flight_Agency.model;
using Flight_Agency.repository;

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
            
            Employee e = new Employee("pass1", "name1");
            e.ID="user3";
            repoEmployee.Save(e);
            
            Flight f = new Flight("dest1", DateTime.Now, "airport1", 300);
            f.ID = 100;
            repoFLights.Save(f);
            
            Ticket t = new Ticket(100, "name1", "tourists1", "address2", 4);
            t.ID = 100;
            repoTickets.Save(t);
            
            
            // Application.EnableVisualStyles();
            // Application.SetCompatibleTextRenderingDefault(false);
            // Application.Run(new Form1());
        }
    }
}