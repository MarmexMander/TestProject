using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace TestProject
{
    public partial class SignupForm : Form
    {
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
            else
            {
                MessageBox.Show("Все поля обязательны.");
               
            }
        }

        private void fioBox_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            string text = tb.Text;
            if (text != "")
            foreach(char c in text)
            {
                if(!char.IsLetter(c) || !char.IsWhiteSpace(c))
                {
                        text.Replace(c.ToString(), "");
                    }
            }

        }

        private void salaryBox_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            string text = tb.Text;
            if (text != "")
                foreach (char c in text)
                {
                    if (!char.IsNumber(c))
                    {
                        text.Replace(c.ToString(), "");
                    }
                }
        }

        private void emailBox_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            string text = tb.Text;
            if (text != "")
                foreach (char c in text)
                {
                    if (!char.IsNumber(c) || !char.IsLetter(c))
                    {
                        text.Replace(c.ToString(), "");
                    }
                }
        }
    }
}
