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
using System.Text.RegularExpressions;

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
                        string m = emailBox.Text;
                        int l = emailBox.Text.Length;
                        if (l <= 10 || m[l - 1] != 'm' || m[l - 2] != 'o' || m[l - 3] != 'c' || m[l - 4] != '.' || m[l - 5] != 'l' || m[l - 6] != 'i' || m[l - 7] != 'a' || m[l - 8] != 'm' || m[l - 9] != 'g' || m[l - 10] != '@')
                        {
                            MessageBox.Show("Some error in database");
                        }
                        else if (Database.Users.register(fioBox.Text, false, addressBox.Text, emailBox.Text, positionBox.Text, departmentBox.Text, telNumberBox.Text, Convert.ToSingle(salaryBox.Text), 0, 0, passwordBox.Text))
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

        private void fioBox_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            string text = tb.Text;
            if (text != "")
            for(int i = 0; i < text.Length; i ++)
            {
                if(!char.IsLetter(text[i]) && !char.IsWhiteSpace(text[i]))
                {
                       tb.Text = text.Remove(i, 1);
                        
                }
            }

        }

        private void salaryBox_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            string text = tb.Text;
            if (text != "")
                for (int i = 0; i < text.Length; i++)
                {
                    if (!char.IsNumber(text[i]))
                    {
                        tb.Text = text.Remove(i, 1);
                    }
                }
        }

        private void emailBox_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            string text = tb.Text;
            if (text != "")
                for (int i = 0; i < text.Length; i++)
                {
                    if (!char.IsNumber(text[i]) && !char.IsLetter(text[i]) && text[i] != '@' && text[i] != '.')
                    {
                        tb.Text = text.Remove(i, 1);
                    }
                }
        }
    }
}
