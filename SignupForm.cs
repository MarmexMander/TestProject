using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestProject
{
    public partial class SignupForm : Form
    {
        string pattern = @"[+][3][8]-[0]\d{2}-\d{3}-\d{2}-\d{2}";
        Form1 f;
        public SignupForm(Form1 f)
        {
            InitializeComponent();
            this.f = f; 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (fioBox.Text != "" && addressBox.Text != "" && telNumberBox.Text != "" && emailBox.Text != "" && departmentBox.Text != "" && positionBox.Text != "" && salaryBox.Text != "" && passwordBox.Text != "")
            {
                try
                {


                    MatchCollection matches = Regex.Matches(telNumberBox.Text.ToString(), pattern);
                    if (matches[0].Value != null)
                    {


                        if (Database.Users.register(fioBox.Text, false, addressBox.Text, emailBox.Text, positionBox.Text, departmentBox.Text, telNumberBox.Text, Convert.ToSingle(salaryBox.Text), 0, 0, passwordBox.Text))
                        {
                            MessageBox.Show("User registered");
                            f.update();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Some error in database");
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Number not verified");
                }
            }
            else
            {
                MessageBox.Show("Все поля обязательны.");
               
            }
        }
    }
}
