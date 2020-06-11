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
    public partial class ShowReprimentsForm : Form
    {
        public ShowReprimentsForm(int userId = -1)
        {
            InitializeComponent();
            init(userId);
        }

        void init(int userId = -1)
        {
            listView1.Items.Clear();
            List<Database.Repriment> repriments;
            if (userId == -1)
                repriments = Database.Repriment.GetRepriments();
            else
                repriments = new Database.User(userId).GetUserRepriments();
            foreach (Database.Repriment repriment in repriments)
            {
                string truncText = repriment.Text;
                if (truncText.Length > 50)
                {
                    truncText.Remove(50, truncText.Length - 50);
                    truncText += "...";
                }
                ListViewItem item = new ListViewItem(repriment.Id.ToString());
                item.SubItems.Add(new Database.User(repriment.UserId).FullName);
                item.SubItems.Add(truncText);
                item.Tag = repriment;
                listView1.Items.Add(item);
            }
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Database.Repriment repriment;
            if (listView1.SelectedItems.Count > 0)
            {
                repriment = (Database.Repriment)listView1.SelectedItems[0].Tag;
                SelectedName.Text = new Database.User(repriment.UserId).FullName;
                SelectedText.Text = repriment.Text;
            }
            else
                return;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length <= 0)
            {
                init();
            }
            else
            {
                Database.User user = new Database.User(Database.User.getIdByFullName(textBox1.Text));
                if (user != null)
                {
                    init(user.Id);
                }
                else
                {
                    MessageBox.Show("Немає доган на це ім'я");
                }
            }
        }
    }
}
