using MiniERP_YBS.BusinessLayer;
using MiniERP_YBS.EntityLayer;
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
    public partial class MusterilerForm : Form
    {
        public MusterilerForm()
        {
            InitializeComponent();
        }
        void Listele()
        {
            dataGridView1.DataSource = MusteriBLL.MusterileriGetirBLL();
        }
        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                // 1. Kutulardaki verilerle yeni müşteri nesnesi oluştur
                Musteri yeniMusteri = new Musteri();
                yeniMusteri.SirketAdi_AdSoyad = textBoxAdSoyad.Text;
                yeniMusteri.Telefon = textBoxTelefon.Text;
                yeniMusteri.Email = textBoxMail.Text;

                // 2. İş Katmanına (BLL) gönder
                int sonuc = MusteriBLL.MusteriEkleBLL(yeniMusteri);

                // 3. Sonuca göre aksiyon al
                if (sonuc > 0)
                {
                    MessageBox.Show("Müşteri başarıyla CRM sistemine eklendi kanki!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Listele(); // Tabloyu yenile

                    // Kutuları temizle
                    textBoxAdSoyad.Clear();
                    textBoxTelefon.Clear();
                    textBoxMail.Clear();
                }
                else
                {
                    MessageBox.Show("Ekleme başarısız! İsim boş olamaz ve Telefon en az 10 haneli olmalıdır.", "İş Kuralı İhlali", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu! Hata detayı: " + ex.Message, "Sistem Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void MusterilerForm_Load(object sender, EventArgs e)
        {
            Listele();
        }
    }
}
