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
    public partial class Orderacces : Form
    {
        public Orderacces()
        {
            InitializeComponent();
            using (Model1Container db = new Model1Container())
            {
                foreach (Tovar accessories in db.TovarSet)
                {
                    if (accessories.type == "stationary")
                    {
                        listBox1.Items.Add(accessories.name_t);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (Model1Container db = new Model1Container())
            {
                foreach (Tovar access in db.TovarSet)
                {
                    for (int i = 0; i < listBox1.Items.Count; i++)
                    {
                        if (listBox1.SelectedItem.ToString() == access.name_t && access.type == "stationary")
                        {
                            pictureBox1.Image = (Image)(Image)((new ImageConverter()).ConvertFrom(access.photo));
                            label4.Text = "Количество товара: " + access.sum;
                            label2.Text = "Цена: " + access.price;
                        }
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            Entry entry = new Entry();
            entry.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
