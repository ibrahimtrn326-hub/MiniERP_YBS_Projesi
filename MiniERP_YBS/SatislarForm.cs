using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiniERP_YBS.EntityLayer;
using MiniERP_YBS.BusinessLayer;
namespace MiniERP_YBS
{
    public partial class SatislarForm : Form
    {
        public SatislarForm()
        {
            InitializeComponent();
        }

        private void SatislarForm_Load(object sender, EventArgs e)
        {
            // 1. ÜRÜNLERİ COMBOBOX'A DOLDUR
            comboBoxUrun.DataSource = UrunBLL.UrunleriGetirBLL();
            comboBoxUrun.DisplayMember = "UrunAdi"; // Ekranda ürünün adı yazsın
            comboBoxUrun.ValueMember = "UrunID";    // Arka planda ID'sini tutsun

            // 2. MÜŞTERİLERİ COMBOBOX'A DOLDUR
            comboBoxMusteri.DataSource = MusteriBLL.MusterileriGetirBLL();
            comboBoxMusteri.DisplayMember = "AdSoyad"; // Ekranda müşterinin adı yazsın
            comboBoxMusteri.ValueMember = "MusteriID"; // Arka planda ID'sini tutsun

            /* NOT: Eğer Personel listeleme metodun varsa onu da buraya aynı mantıkla ekleyebilirsin. 
               Eğer yoksa şimdilik sadece bu ikisi kalsın, PersonelID'yi sabit bir sayı veya TextBox yapabiliriz. */
            comboBoxPersonel.DataSource = PersonelBLL.PersonelleriGetirBLL(); // Senin Personel listeleme metodunun adı
            comboBoxPersonel.DisplayMember = "AdSoyad"; // Personel Entity sınıfındaki isim değişkeninin adı (Sende "Ad" veya "PersonelAd" olabilir, ona göre düzelt)
            comboBoxPersonel.ValueMember = "PersonelID"; // Personel Entity sınıfındaki ID değişkeninin adı
        }

        private void buttonSatisYap_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Yeni Satış Nesnesi Oluştur
                Satis yeniSatis = new Satis();

                // ComboBox'lardan seçilen nesnelerin gizli ID değerlerini alıyoruz
                yeniSatis.UrunID = Convert.ToInt32(comboBoxUrun.SelectedValue);
                yeniSatis.MusteriID = Convert.ToInt32(comboBoxMusteri.SelectedValue);

                // Şimdilik işlemi yapan personel ID'sini 1 (Admin) olarak sabit veriyorum
                // (İleride giriş yapan kullanıcının ID'sini buraya çekeriz)
                yeniSatis.PersonelID = Convert.ToInt32(comboBoxPersonel.SelectedValue);

                yeniSatis.Adet = Convert.ToInt32(textBoxAdet.Text);
                yeniSatis.Fiyat = Convert.ToDecimal(textBoxFiyat.Text);

                // 2. İş Katmanına (BLL) gönder
                int sonuc = SatisBLL.SatisYapBLL(yeniSatis);

                // 3. Sonuca göre aksiyon al
                if (sonuc > 0)
                {
                    MessageBox.Show("Satış başarıyla gerçekleşti ve stoktan düşüldü kanki!", "Sistem Bilgisi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBoxAdet.Clear();
                    textBoxFiyat.Clear();
                }
                else
                {
                    MessageBox.Show("Satış başarısız! Adet veya fiyat bilgilerini kontrol et.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu! Lütfen kutuları boş bırakmayın. Hata detayı: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    }

