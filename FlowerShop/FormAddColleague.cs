using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;

namespace FlowerShop
{
    public partial class FormAddColleague : Form
    {
        public FormAddColleague()
        {
            InitializeComponent();
        }
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
        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            FormAdmin fa = new FormAdmin();
            fa.ShowDialog();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (!(textBox5.Text == "admin"))
            {
                using (Model1Container db = new Model1Container())
                {
                    if (db.ColleagueSet.ToList().Count == 0)
                    {
                        Colleague colleague = new Colleague()
                        {
                            name = textBox2.Text,
                            surname = textBox1.Text,
                            patronymic = textBox3.Text,
                            address = textBox4.Text,
                            post = textBox8.Text,
                            money = int.Parse(textBox9.Text),
                        };
                        db.ColleagueSet.Add(colleague);
                        db.SaveChanges();

                        User user = new User()
                        {
                            Login = textBox5.Text,
                            Password = GetHashString(textBox6.Text),
                            Email = textBox7.Text,
                            Role = "Colleague",
                            Colleague = colleague,
                        };
                        db.Users.Add(user);
                        db.SaveChanges();
                        //fa.listBox1.Items.Add(client.Id + " " + client.name);

                        Hide();
                        FormAdmin fa = new FormAdmin();
                        fa.ShowDialog();
                        Close();
                        return;
                    }
                    else
                    {
                        //foreach (User users in db.Users)
                        for (int i = 0; i < db.Users.ToList().Count; i++)
                        {
                            if (!(textBox5.Text == db.Users.ToList()[i].Login || textBox7.Text == db.Users.ToList()[i].Email))
                            {
                                Colleague client = new Colleague()
                                {
                                    name = textBox2.Text,
                                    surname = textBox1.Text,
                                    patronymic = textBox3.Text,
                                    address = textBox4.Text,
                                    post = textBox8.Text,
                                    money = int.Parse(textBox9.Text),
                                };
                                db.ColleagueSet.Add(client);
                                db.SaveChanges();

                                User user = new User()
                                {
                                    Login = textBox5.Text,
                                    Password = GetHashString(textBox6.Text),
                                    Email = textBox7.Text,
                                    Role = "Colleague",
                                    Colleague = client,
                                };
                                db.Users.Add(user);
                                db.SaveChanges();
                                //fa.listBox1.Items.Add(client.Id + " " + client.name);

                                Hide();
                                FormAdmin fa = new FormAdmin();
                                fa.ShowDialog();
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
            Hide();
            FormAdmin formAdmin = new FormAdmin();
            formAdmin.ShowDialog();
        }
    }
}
