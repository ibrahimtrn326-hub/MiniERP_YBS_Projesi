using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiniERP_YBS.DataAccessLayer;
namespace MiniERP_YBS
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Kutulara yazılanları DAL katmanına yollayıp kontrol ediyoruz
            bool kontrol = AdminDAL.LoginKontrol(textBox1.Text, textBox2.Text);

            if (kontrol)
            {
                AnaMenuForm anaMenu = new AnaMenuForm();
                anaMenu.Show(); // Ana menüyü aç
                this.Hide();    // Bu login ekranını gizle
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre hatalı knk!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
           label1.BackColor=Color.Transparent;
            label2.BackColor=Color.Transparent;
        }
    }
    }

