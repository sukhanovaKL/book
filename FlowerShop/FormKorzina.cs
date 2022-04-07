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
    public partial class FormKorzina : Form
    {
        public Client client;
        public Order order;
        public FormKorzina(Client client)
        {
            InitializeComponent();
            this.client = client;
            using (Model1Container db = new Model1Container())
            {
               foreach (Order order in db.OrderSet)
                {
                    if(order.Client.Id == this.client.Id && order.isObrabotan == true)
                    {
                        listBox1.Items.Add("Номер заказа: " + order.Id + "    Дата заказа: " + order.data);
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            FormProf fp = new FormProf(client.User, client);
            fp.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            Main m = new Main();
            m.ShowDialog();
        }
    }
}
