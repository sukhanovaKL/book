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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public FormAdmin fa;
        public byte[] imageBytes;

        private string GetHashString(string s)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(s);
            MD5CryptoServiceProvider CSP = new MD5CryptoServiceProvider();
            byte[] byteHash = CSP.ComputeHash(bytes);
            string hash = "";
            foreach (byte b in byteHash)
            {
                hash += string.Format("{0:x2}", b);
            }
            return hash;
        }
 

        private void button1_Click(object sender, EventArgs e) //регистрация
        {
            if (!(textBox5.Text == "admin"))
            {
                using (Model1Container db = new Model1Container())
                {
                    if (db.Clients.ToList().Count == 0)
                    {
                        Client client = new Client()
                        {
                            name = textBox2.Text,
                            surname = textBox1.Text,
                            patronymic = textBox3.Text,
                            address = textBox4.Text,
                            photo = imageBytes,
                            money = 2000,
                        };
                        db.Clients.Add(client);
                        db.SaveChanges();

                        User user = new User()
                        {
                            Login = textBox5.Text,
                            Password = GetHashString(textBox6.Text),
                            Email = textBox7.Text,
                            Role = "User",
                            Client = client,
                        };
                        db.Users.Add(user);
                        db.SaveChanges();

                        Hide();
                        Entry entry = new Entry();
                        entry.ShowDialog();
                        Close();
                        return;
                    }
                    else
                    {
                        for (int i = 0; i < db.Users.ToList().Count; i++)
                        {
                            if (!(textBox5.Text == db.Users.ToList()[i].Login || textBox7.Text == db.Users.ToList()[i].Email))
                            {
                                Client client = new Client()
                                {
                                    name = textBox2.Text,
                                    surname = textBox1.Text,
                                    patronymic = textBox3.Text,
                                    address = textBox4.Text,
                                    photo = imageBytes,
                                    money = 2000,
                                };

                                db.Clients.Add(client);
                                db.SaveChanges();

                                User user = new User()
                                {
                                    Login = textBox5.Text,
                                    Password = GetHashString(textBox6.Text),
                                    Email = textBox7.Text,
                                    Role = "User",
                                    Client = client,
                                };
                                db.Users.Add(user);
                                db.SaveChanges();

                                Hide();
                                Entry entry = new Entry();
                                entry.ShowDialog();
                                Close();
                                return;
                            }
                            else
                            {
                                MessageBox.Show("Логин или почта уже используются");
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Логин уже используется");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog open_dialog = new OpenFileDialog();
            open_dialog.Filter = "Image Files(*.BMP; *.JPG; *.GIF; *.PNG)| *.BMP; *.JPG; *.GIF; *.PNG | All files(*.*) | *.* ";
            if (open_dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    imageBytes = File.ReadAllBytes(open_dialog.FileName);
                    label2.Text = "Успешно";
                }
                catch
                {
                    label2.Text = "Ошибка";
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Entry f2 = new Entry();
            f2.ShowDialog();
        }
    }
}