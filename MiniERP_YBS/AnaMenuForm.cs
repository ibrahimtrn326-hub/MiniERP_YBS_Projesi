using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniERP_YBS
{
    public partial class AnaMenuForm : Form
    {
        public AnaMenuForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 personelSayfasi = new Form1(); // Form1 dünkü personel sayfamızın adıydı
            personelSayfasi.Show(); // Sayfayı ekranda göster
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 urunSayfasi = new Form2(); // Bugün yaptığımız ürün sayfamız
            urunSayfasi.Show(); // Sayfayı ekranda göster
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MusterilerForm musteriSayfasi = new MusterilerForm();
            musteriSayfasi.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SatislarForm satisSayfasi = new SatislarForm();
            satisSayfasi.Show();
        }
    }
}
