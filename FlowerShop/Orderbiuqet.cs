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
    public partial class Orderbiuqet : Form
    {
        public Orderbiuqet()
        {
            InitializeComponent();
            using (Model1Container db = new Model1Container())
            {
                foreach (Tovar byket in db.TovarSet)
                {
                    if (byket.type == "magazin")
                    {
                        listBox1.Items.Add(byket.name_t);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (Model1Container db = new Model1Container())
            {
                foreach (Tovar byket in db.TovarSet)
                {
                    for (int i = 0; i < listBox1.Items.Count; i++)
                    {
                        if (listBox1.SelectedItem.ToString() == byket.name_t && byket.type == "magazin")
                        {
                            pictureBox1.Image = (Image)(Image)((new ImageConverter()).ConvertFrom(byket.photo));
                            label4.Text = "Количество товара: " + byket.sum;
                            label2.Text = "Цена: " + byket.price;
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
    }
}
