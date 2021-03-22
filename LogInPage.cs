using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            if (txtUsername.Text!=string.Empty && 
                txtPassword.Text != string.Empty &&
                service.getOneEmployee(txtUsername.Text)!=null)
            {
                MainPage mainpage = new MainPage(service);
                mainpage.Show();
            }
            else
            {
                MessageBox.Show("Login error!");
            }
        }


    }
}