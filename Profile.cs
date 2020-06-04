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
        public Profile(Database.User user)
        {
            InitializeComponent();
            fioLabel.Text = user.FullName;
            addressLabel.Text = user.Addres;
            telNumberLabel.Text = user.PhoneNumber;
            emailLabel.Text = user.Email;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
