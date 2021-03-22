using System;
using System.Windows.Forms;
using Flight_Agency.model;
using Flight_Agency.service;

namespace Flight_Agency
{
    public partial class MainPage : Form
    {
        private Service service;
        public MainPage(Service service)
        {
            InitializeComponent();
            this.service = service;
            flightsGridView.DataSource = service.getAllFlights();
        }

        public void clearFields()
        {
            txtAddress.Text = "";
            txtName.Text = "";
            txtSeats.Text = "";
            txtTourists.Text = "";
        }
        
        private void buttonPurchase_Click(object sender, EventArgs e)
        {
            Flight flight = flightsGridView.CurrentRow?.DataBoundItem as Flight;
            int fID = flight.ID;
            // foreach (DataGridViewRow dgvRow in flightsGridView.SelectedRows)
            // {
            //     fID = int.Parse(dgvRow.Cells[4].Value.ToString());
            // }
            String clientName = txtName.Text;
            String clientAddress = txtAddress.Text;
            String tourists = txtTourists.Text;
            int seats = int.Parse(txtSeats.Text);
            Ticket ticket = new Ticket(fID, clientName, tourists, clientAddress, seats);
            //testLabel.Text = flight.ToString();
            service.addTicket(ticket);
            clearFields();
        }
    }
}