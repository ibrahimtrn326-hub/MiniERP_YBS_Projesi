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

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void AnaMenuForm_Load(object sender, EventArgs e)
        {
            lblUrunSayisi1.Text = BusinessLayer.IstatistikBLL.UrunSayisiBLL().ToString();
            lblMusteriSayisi.Text = BusinessLayer.IstatistikBLL.MusteriSayisiBLL().ToString();
            lblSatisAdedi.Text = BusinessLayer.IstatistikBLL.ToplamSatisAdediBLL().ToString();
            lblCiro.Text = BusinessLayer.IstatistikBLL.ToplamCiroBLL();

            // DAL katmanındaki metotları çağırıp, gelen sayıları string'e (metne) çevirerek etiketlere yazdırıyoruz.

        }

        private void btnExcelAktar_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Az önce sıfırdan yaptığımız o küçük formun adını yazıyoruz
            DepartmanForm frmDepartman = new DepartmanForm();
            frmDepartman.Show();
        }
    }
}
