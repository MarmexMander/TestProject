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
    public partial class SignupForm : Form
    {
        public SignupForm(Database.User user)
        {
            InitializeComponent();
            //Database.User.register("mykola", "adres", "e-mail", "1", "2", "phone", 100, "test");
        }
    }
}
