using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Flight_Agency.model;
using Flight_Agency.service;

namespace Flight_Agency
{
    public partial class LogInPage : Form
    {
        private Service service;
        
        public LogInPage(Service service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void buttonLogIn_Click(object sender, EventArgs e)
        {
            String user = txtUsername.Text;
            String pass = txtPassword.Text;
            Employee employee = service.getOneEmployee(user);
            if (user!=string.Empty && 
                pass != string.Empty &&
                employee!=null &&
                employee.Password==pass)
            {
                MainPage mainpage = new MainPage(service);
                //this.Hide();
                mainpage.Show();
            }
            else
            {
                MessageBox.Show("Login error!");
            }
        }


    }
}