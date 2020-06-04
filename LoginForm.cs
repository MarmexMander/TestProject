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
    public partial class Login_Form : Form
    {
        public Login_Form()
        {
            InitializeComponent();
        }

        private void LogButton_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                MessageBox.Show("Введите корректный e-mail");
            else if (textBox2.Text == "")
                MessageBox.Show("Введите корректный пароль");
            else
            {
                //SignupForm signup = new SignupForm(user);
            }
        }
    }
}
