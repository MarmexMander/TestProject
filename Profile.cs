using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestProject
{
    public partial class Profile : Form
    {
        Form parent;
        Database.User User;
        public Profile(Database.User user, Form form)
        {
            InitializeComponent();
            fioLabel.Text = user.FullName;
            addressLabel.Text = user.Addres;
            telNumberLabel.Text = user.PhoneNumber;
            emailLabel.Text = user.Email;
            departmentLabel.Text = user.Departament;
            positionLabel.Text = user.Position;
            hoursLabel.Text = user.Hours.ToString();
            reprimantQuantituLabel.Text = user.ReprimentQuantity.ToString();
            salaryLabel.Text = user.Wage.ToString();
            TotalWage.Text = user.calcWage().ToString();
            User = user;
            parent = form;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            User.logout();
            parent.Visible = true;
            this.Close();
        }

        private void Profile_FormClosing(object sender, FormClosingEventArgs e)
        {
            User.logout();
            parent.Visible = true;
        }
    }
}
