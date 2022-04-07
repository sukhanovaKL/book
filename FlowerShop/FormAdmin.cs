using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlowerShop
{
    public partial class FormAdmin : Form
    {
        public FormAdmin()
        {
            InitializeComponent();
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            Hide();
            Entry f2 = new Entry();
            f2.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)  //удаление пользователя
        {
            using (Model1Container db = new Model1Container())
            {
                foreach(User user in db.Users)
                {
                    if(listBox1.SelectedItem.ToString() == user.Login)
                    {
                        db.Clients.Remove(user.Client);
                        db.Users.Remove(user);
                    }
                }
                db.SaveChanges();
                listBox1.Items.Clear();
                foreach (User user in db.Users)
                {
                    if (user.Role == "User")
                    {
                        listBox1.Items.Add(user.Login);
                    }
                }
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            using (Model1Container db = new Model1Container())
            {
                foreach (User user in db.Users)
                {
                    if (user.Role == "User")
                    {
                        listBox1.Items.Add(user.Login);
                    }
                }
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Hide();
            FormAddColleague ac = new FormAddColleague();
            ac.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            using (Model1Container db = new Model1Container())
            {
                foreach (User user in db.Users)
                {
                    if (user.Role == "Colleague")
                    {
                        listBox2.Items.Add(user.Login);
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e) //удаление сотрудника
        {
            using (Model1Container db = new Model1Container())
            {
                foreach (User user in db.Users)
                {
                    if (listBox1.SelectedItem.ToString() == user.Login)
                    {
                        db.ColleagueSet.Remove(user.Colleague);
                        db.Users.Remove(user);
                    }
                }
                db.SaveChanges();
                listBox2.Items.Clear();
                foreach (User user in db.Users)
                {
                    if (user.Role == "Colleague")
                    {
                        listBox2.Items.Add(user.Login);
                    }
                }
            }
        }
    }
}
