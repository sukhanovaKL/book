using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;


namespace FlowerShop
{
    public partial class FormMail : Form
    {
        public static string mail;
        private int host = 0;
        public FormMail()
        {
            InitializeComponent();
        }
        private void RandGen()
        {
            Random random = new Random();
            host = random.Next(10000, 99999);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            MailAddress from = new MailAddress("cvetidai@mail.ru", "Ksusha");
            MailAddress to = new MailAddress(textBox1.Text);
            MailMessage m = new MailMessage(from, to);
            m.Subject = "Восстановить";
            using (Model1Container db = new Model1Container())
            {
                foreach (User user in db.Users)
                {
                    if (textBox1.Text == user.Email)
                    {
                        RandGen();
                        m.Body = "<h1>Код: " + host + "</h1>"; ;
                    }
                }
            }
            m.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.mail.ru", 25);
            smtp.Credentials = new NetworkCredential("cvetidai", "oaipnashevse");
            smtp.EnableSsl = true;
            smtp.Send(m);
            mail = textBox1.Text;
            MessageBox.Show("Код был отправлен на указанную почту");
            label1.Text = "Введите код";
            textBox1.Text = "";
            button1.Visible = true;
            button2.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (host == Convert.ToInt32(textBox1.Text))
            {
                this.Hide();
                FormNewPass fnp = new FormNewPass();
                fnp.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверный код, проверь все еще раз");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            Entry f2 = new Entry();
            f2.ShowDialog();
        }
    }
}
