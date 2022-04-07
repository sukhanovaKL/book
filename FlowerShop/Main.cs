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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Entry entry = new Entry();
            entry.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Orderflower flower = new Orderflower();
            flower.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Orderacces access = new Orderacces();
            access.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Orderbiuqet buket = new Orderbiuqet();
            buket.ShowDialog();
        }
    }
}
