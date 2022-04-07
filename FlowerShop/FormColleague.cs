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
    public partial class FormColleague : Form
    {
        private Entry entry;
        public User user;
        public FormColleague()
        {
            InitializeComponent();
        }
        public FormColleague(Entry entry, User user, Colleague colleague)
        {
            InitializeComponent();
            this.entry = entry;
            this.user = user;
            label1.Text = "Добро пожаловать," + colleague.name + " " + colleague.surname;
            label2.Text = "Вы проживаете: " + colleague.address;
            label3.Text = "Ваша почта: " + user.Email;
            label5.Text = "Ваша должность: " + colleague.post;
            label4.Text = "Ваша зарплата: " + colleague.money;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            FormEdit edit = new FormEdit();
            edit.ShowDialog();
        }
       

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            Entry entry = new Entry();
            entry.ShowDialog();
        }
    }
}
