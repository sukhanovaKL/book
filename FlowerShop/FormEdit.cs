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
    public partial class FormEdit : Form
    {
        public FormEdit()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (Model1Container db = new Model1Container())
            {
                for (int i = 0; i < db.TovarSet.ToList().Count; i++)
                {
                    if (db.TovarSet.ToList()[i].name_t == listBox2.SelectedItem.ToString())
                    {
                        db.TovarSet.Remove(db.TovarSet.ToList()[i]);
                        listBox2.Items.Remove(listBox2.SelectedItem.ToString());
                        db.SaveChanges();
                    }
                }
                listBox2.Items.Clear();
                foreach (Tovar flowers in db.TovarSet)
                {
                    if (flowers.name_t == "Flower")
                    {
                        listBox2.Items.Add(flowers.name_t);
                    }
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            using (Model1Container db = new Model1Container())
            {
                for (int i = 0; i < db.TovarSet.ToList().Count; i++)
                {
                    if (db.TovarSet.ToList()[i].name_t == listBox1.SelectedItem.ToString())
                    {
                        db.TovarSet.Remove(db.TovarSet.ToList()[i]);
                        listBox1.Items.Remove(listBox1.SelectedItem.ToString());
                        db.SaveChanges();
                    }
                }
                listBox1.Items.Clear();
                foreach (Tovar byket in db.TovarSet)
                {
                    if (byket.name_t == "Byket")
                    {
                        listBox1.Items.Add(byket.name_t);
                    }
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            using (Model1Container db = new Model1Container())
            {
                for (int i = 0; i < db.TovarSet.ToList().Count; i++)
                {
                    if (db.TovarSet.ToList()[i].name_t == listBox3.SelectedItem.ToString())
                    {
                        db.TovarSet.Remove(db.TovarSet.ToList()[i]);
                        listBox3.Items.Remove(listBox3.SelectedItem.ToString());
                        db.SaveChanges();
                    }
                }
                listBox3.Items.Clear();
                foreach (Tovar access in db.TovarSet)
                {
                    if (access.name_t == "Byket")
                    {
                        listBox3.Items.Add(access.name_t);
                    }
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            using (Model1Container db = new Model1Container())
            {
                foreach (Tovar tovar in db.TovarSet)
                {
                    if (tovar.type == "book")
                    {
                        listBox2.Items.Add(tovar.name_t);
                    }
                }
                foreach (Tovar tovar in db.TovarSet)
                {
                    if (tovar.type == "magazin")
                    {
                        listBox1.Items.Add(tovar.name_t);
                    }
                }
                foreach (Tovar tovar in db.TovarSet)
                {
                    if (tovar.type == "stationary")
                    {
                        listBox3.Items.Add(tovar.name_t);
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Hide();
            FormPlus plus = new FormPlus();
            plus.ShowDialog();
        }
    }
}
