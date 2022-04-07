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
    public partial class Orderflower : Form
    {
        public Orderflower()
        {
            InitializeComponent();
            using (Model1Container db = new Model1Container())
            {
                foreach (Tovar flowers in db.TovarSet)
                {
                    if (flowers.type == "book")
                    {
                        listBox1.Items.Add(flowers.name_t);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (Model1Container db = new Model1Container())
            {
                foreach (Tovar flowers in db.TovarSet)
                {
                    for (int i = 0; i < listBox1.Items.Count; i++)
                    {
                        if (listBox1.SelectedItem.ToString() == flowers.name_t && flowers.type == "book")
                        {
                            pictureBox1.Image = (Image)(Image)((new ImageConverter()).ConvertFrom(flowers.photo));
                            label4.Text = "Количество товара: " + flowers.sum; ;
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
