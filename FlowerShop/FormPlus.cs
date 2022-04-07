using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using System.Security.Cryptography;
using System.IO;

namespace FlowerShop
{
    public partial class FormPlus : Form
    {
        public FormPlus()
        {
            InitializeComponent();
        }
        public byte[] imageBytes;
        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog open_dialog = new OpenFileDialog();
            open_dialog.Filter = "Image Files(*.BMP; *.JPG; *.GIF; *.PNG)| *.BMP; *.JPG; *.GIF; *.PNG | All files(*.*) | *.* ";
            if (open_dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    imageBytes = File.ReadAllBytes(open_dialog.FileName);
                    label4.Text = "Успешно";
                }
                catch
                {
                    label4.Text = "Ошибка";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (Model1Container db = new Model1Container())
            {
                if (radioButton1.Checked == true)  //книги
                {
                    Tovar flowers = new Tovar()
                    {
                        name_t = textBox1.Text,
                        sum = int.Parse(textBox2.Text),
                        price = int.Parse(textBox3.Text),
                        type = "book",
                        photo = imageBytes,
                    };
                    db.TovarSet.Add(flowers);
                    db.SaveChanges();
                }
                else if (radioButton2.Checked == true)  //журналы
                {
                    Tovar byket = new Tovar()
                    {
                        name_t = textBox1.Text,
                        sum = int.Parse(textBox2.Text),
                        price = int.Parse(textBox3.Text),
                        type = "magazin",
                        photo = imageBytes,
                    };
                    db.TovarSet.Add(byket);
                    db.SaveChanges();
                }
                else if (radioButton3.Checked == true)  //канцтовары
                {
                    Tovar accessories = new Tovar()
                    {
                        name_t = textBox1.Text,
                        sum = int.Parse(textBox2.Text),
                        price = int.Parse(textBox3.Text),
                        type = "stationary",
                        photo = imageBytes,
                    };
                    db.TovarSet.Add(accessories);
                    db.SaveChanges();
                }
            }
            Hide();
            FormEdit fe = new FormEdit();
            fe.ShowDialog();
        }
    }
}
