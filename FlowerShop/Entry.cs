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
using System.Net.Mail;

namespace FlowerShop
{
    public partial class Entry : Form
    {
        public Entry()
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
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "admin" && textBox2.Text == "parol")
            {
                Hide();
                FormAdmin fradmin = new FormAdmin();
                fradmin.ShowDialog();
            }
            using (Model1Container db = new Model1Container())
            {
                //try
                //{
                foreach (User user in db.Users)
                {
                    if (user.Role == "User")
                    {
                        foreach (Client client in db.Clients)
                        {
                            if (user.Login == textBox1.Text && user.Password == GetHashString(textBox2.Text))
                            {
                                Hide();
                                FormProf fp = new FormProf(user, user.Client);
                                fp.ShowDialog();
                                Close();
                                return;
                            }
                        }
                    }
                    else if (user.Role == "Colleague")
                    {
                        foreach (Colleague colleague in db.ColleagueSet)
                        {
                            if (user.Login == textBox1.Text && user.Password == GetHashString(textBox2.Text))
                            {
                                Hide();
                                FormColleague fp = new FormColleague(this, user, user.Colleague);
                                fp.ShowDialog();
                                Close();
                                return;
                            }
                        }
                    }
                }
                //}
                //catch
                //{
                //    MessageBox.Show("Пользователь не найден...");
                //}
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Hide();
            Form1 f1 = new Form1();
            f1.ShowDialog();
            Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Hide();
            FormMail fs = new FormMail();
            fs.ShowDialog();
            Close();
        }

        private void Entry_Load(object sender, EventArgs e)
        {

        }
    }
}
