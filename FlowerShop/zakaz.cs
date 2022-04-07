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
    public partial class zakaz : Form
    {
        public Client client;
        public Order order;
        public int id_tovara = 0;
        private int sum = 0;
        public zakaz(Client client)
        {
            InitializeComponent();
            listBox1.Items.Add("товары");
            this.client = client;

            using (Model1Container db = new Model1Container())
            {
                order = new Order() { address = " ", data = " ", isObrabotan = false };
                db.OrderSet.Add(order);
                db.SaveChanges();
            }
            using (Model1Container db = new Model1Container())
            {
                foreach (Client item in db.Clients)
                {
                    if (item.name == this.client.name)
                    {
                        db.OrderSet.Find(order.Id).Client = item;
                    }
                }
                db.SaveChanges();
            }
            label7.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (Model1Container db = new Model1Container())
            {
                if (radioButton1.Checked == true)
                {
                    foreach (Tovar flowers in db.TovarSet)
                    {
                        for (int i = 0; i < listBox1.Items.Count; i++)
                        {
                            if (listBox1.SelectedItem.ToString() == flowers.name_t && flowers.type == "book")
                            {
                                pictureBox1.Image = (Image)(Image)((new ImageConverter()).ConvertFrom(flowers.photo));
                                label1.Text = "Количество товара: " + flowers.sum;
                                label2.Text = "Цена: " + flowers.price;
                                id_tovara = flowers.Id;
                            }
                        }
                    }
                }
                else if (radioButton2.Checked == true)
                {
                    foreach (Tovar byket in db.TovarSet)
                    {
                        for (int i = 0; i < listBox1.Items.Count; i++)
                        {
                            if (listBox1.SelectedItem.ToString() == byket.name_t && byket.type == "magazin")
                            {
                                pictureBox1.Image = (Image)(Image)((new ImageConverter()).ConvertFrom(byket.photo));
                                label1.Text = "Количество товара: " + byket.sum;
                                label2.Text = "Цена: " + byket.price;
                                id_tovara = byket.Id;
                            }
                        }
                    }
                }
                else if (radioButton3.Checked == true)
                {
                    foreach (Tovar access in db.TovarSet)
                    {
                        for (int i = 0; i < listBox1.Items.Count; i++)
                        {
                            if (listBox1.SelectedItem.ToString() == access.name_t && access.type == "stationary")
                            {
                                pictureBox1.Image = (Image)(Image)((new ImageConverter()).ConvertFrom(access.photo));
                                label1.Text = "Количество товара: " + access.sum;
                                label2.Text = "Цена: " + access.price;
                                id_tovara = access.Id;
                            }
                        }
                    }

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (Model1Container db = new Model1Container())
            {
                //OrderTovar orderTovar = new OrderTovar();
                //Order order = (from o in db.OrderSet
                //               where o.Id == this.order.Id
                //               select o).FirstOrDefault();
                //orderTovar.Order = order;
                //db.OrderTovarSet.Add(orderTovar);
                //db.SaveChanges();

                foreach (Tovar item in db.TovarSet)
                {
                    if (Convert.ToString(listBox1.SelectedItem) == item.name_t && item.sum > int.Parse(textBox1.Text))
                    {
                        OrderTovar orderTovar = new OrderTovar();
                        Order order = (from o in db.OrderSet
                                       where o.Id == this.order.Id
                                       select o).FirstOrDefault();
                        orderTovar.Order = order;
                        orderTovar.Tovar = item;
                        orderTovar.sum = int.Parse(textBox1.Text);
                        db.OrderTovarSet.Add(orderTovar);
                        //db.SaveChanges();
                        listBox2.Items.Add("кол-во: " + textBox1.Text + " товар: " + item.name_t + "   сумма: " + item.price * int.Parse(textBox1.Text));
                        sum += item.price * int.Parse(textBox1.Text);
                        label7.Text = sum.ToString();
                        item.sum -= int.Parse(textBox1.Text);
                    }
                }
                db.SaveChanges();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (Model1Container db = new Model1Container())
            {
                if (client.money >= sum)
                {
                    client.money -= sum;
                    db.OrderSet.Find(order.Id).address = textBox2.Text;
                    db.OrderSet.Find(order.Id).data = Convert.ToString(dateTimePicker1.Text);
                    db.OrderSet.Find(order.Id).isObrabotan = true;
                    db.OrderSet.Find(order.Id).price = sum;
                    db.SaveChanges();
                }
                else { MessageBox.Show("Недостаточно средств...");}
            }
            Hide();
            FormPacage fp = new FormPacage(this.client, this.order);
            fp.ShowDialog();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            using (Model1Container db = new Model1Container())
            {
                foreach (Tovar flowers in db.TovarSet)
                {
                    if (flowers.type == "book")
                    {
                        if (flowers.sum == 0)
                        {
                            db.TovarSet.Remove(flowers);
                            db.SaveChanges();
                        }
                        listBox1.Items.Add(flowers.name_t);
                    }
                }
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            using (Model1Container db = new Model1Container())
            {
                foreach (Tovar byket in db.TovarSet)
                {
                    if (byket.type == "magazin")
                    {
                        if (byket.sum == 0)
                        {
                            db.TovarSet.Remove(byket);
                            db.SaveChanges();
                        }
                        listBox1.Items.Add(byket.name_t);
                    }
                }
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            using (Model1Container db = new Model1Container())
            {
                foreach (Tovar access in db.TovarSet)
                {
                    if (access.type == "stationary")
                    {
                        if (access.sum == 0)
                        {
                            db.TovarSet.Remove(access);
                            db.SaveChanges();
                        }
                        listBox1.Items.Add(access.name_t);
                    }
                }
            }
        }
    }
  
}
