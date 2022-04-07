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
    public partial class FormPacage : Form
    {
        public Client client;
        public Order order;
        int count = 1;
        public FormPacage(Client client, Order order)
        {
            InitializeComponent();
            this.client = client;
            this.order = order;
            using (Model1Container db = new Model1Container())
            { 
                foreach (OrderTovar orderTovar in db.OrderTovarSet)
                {
                    if (orderTovar.Order.Id == order.Id)
                    { 
                        foreach (Tovar tovar in db.TovarSet)
                        {
                            if (tovar.Id == orderTovar.Tovar.Id)
                            {
                                if (orderTovar.Order.isObrabotan == false)
                                {
                                    label1.Text = "Не удалось выполнить заказ...";
                                }
                                label6.Text = orderTovar.Order.address;
                                label7.Text = orderTovar.Order.data;
                                label8.Text = Convert.ToString(orderTovar.Order.price);
                                listBox1.Items.Add(count + ": " + tovar.name_t + "   " + orderTovar.sum + "  сумма: " + tovar.price * orderTovar.sum);
                                count++;
                            }
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            Main main = new Main();
            main.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            FormProf prof = new FormProf(client.User, client);
            prof.ShowDialog();
        }
    }
}
