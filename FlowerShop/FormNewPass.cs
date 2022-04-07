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

namespace FlowerShop
{
    public partial class FormNewPass : Form
    {
        public FormNewPass()
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
            if (textBox1.Text == textBox2.Text)
            {
                using (Model1Container db = new Model1Container())
                {
                    foreach (User user in db.Users)
                    {
                        if (user.Email == FormMail.mail)
                        {
                            user.Password = GetHashString(textBox2.Text);
                        }
                    }
                    db.SaveChanges();
                    Hide();
                    Entry entry = new Entry();
                    entry.ShowDialog();
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Пароли не совпадают:");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            Entry f2 = new Entry();
            f2.ShowDialog();
        }
    }
}
