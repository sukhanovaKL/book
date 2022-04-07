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
    public partial class FormProf : Form
    {
        public User user;
        public Client client;
        public static string name;

        public FormProf(User user, Client client)
        {
            InitializeComponent();
            //this.entry = entry;
            this.user = user;
            this.client = client;
            label1.Text = "Добро пожаловать," + client.name + " " + client.surname;
            label2.Text = "Вы проживаете: " + client.address;
            label3.Text = "Ваша почта: " + user.Email;
            label4.Text = "Счет: " + client.money;
            pictureBox1.Image = (Image)(Image)((new ImageConverter()).ConvertFrom(client.photo));
            textBox1.Visible = false;
            button4.Visible = false;
            name = client.name;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int money = int.Parse(textBox1.Text);
            using (Model1Container db = new Model1Container())
            {
                foreach (Client client in db.Clients)
                {
                    if (client.name == FormProf.name)
                    {
                        client.money += money;
                        label4.Text = "Счет: " + client.money;
                    }
                }
                db.SaveChanges();
            }
            textBox1.Visible = false;
            button4.Visible = false;
            button3.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            zakaz zakaz = new zakaz(this.client);
            zakaz.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Visible = true;
            button4.Visible = true;
            button3.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            Entry entry = new Entry();
            entry.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            FormKorzina fk = new FormKorzina(client);
            fk.ShowDialog();
        }
    }
}
