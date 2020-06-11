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
            string m = textBox1.Text;
            int l = textBox1.Text.Length;
            if (textBox1.Text == "" || textBox1.Text.Length <= 10 || m[l-1] != 'm' || m[l - 2] != 'o' || m[l - 3] != 'c' || m[l - 4] != '.' || m[l - 5] != 'l' || m[l - 6] != 'i' || m[l - 7] != 'a' || m[l - 8] != 'm' || m[l - 9] != 'g' || m[l - 10] != '@')
                MessageBox.Show("Введите корректный e-mail");
            else if (textBox2.Text == "")
                MessageBox.Show("Введите корректный пароль");
            else
            {
                Database.User user = Database.User.login(textBox1.Text, textBox2.Text);
                if (user == null)
                    MessageBox.Show("Неправильное имя пользователя или пароль");
                else
                {
                    if (user.Role)
                    {
                        Form1 adminPanel = new Form1(user, this);
                        adminPanel.Show();
                    }
                    else
                    {
                        Profile profile = new Profile(user, this);
                        profile.Show();
                    }
                    this.Visible = false;
                }
            }
        }
    }
}
