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
                                                         // SQL'den 'SatisIslemleri' tablosundaki tüm verileri çekip ekrandaki tabloya (DataGridView) basıyoruz.
            Listele();
        }
        public void Listele()
        {
            // Eğer BLL (İş Katmanı) tarafında önceden yazdığın bir satış listeleme komutun varsa 
            // direkt onu da eşitleyebilirsin. Yoksa az önceki kodun aynısını buraya koyuyoruz:
            System.Data.SqlClient.SqlConnection baglanti = MiniERP_YBS.DataAccessLayer.Baglanti.BaglantiAl();
            System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter("SELECT * FROM SatisIslemleri", baglanti);
            System.Data.DataTable dt = new System.Data.DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
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
                    Listele(); // Satış sonrası tabloyu güncelle
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0 && dataGridView1.Columns.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Excel Dosyası (*.xls)|*.xls";
                sfd.FileName = "Satis_Raporu_" + DateTime.Now.ToString("dd_MM_yyyy") + ".xls";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Excel dosyasını arka planda oluşturuyoruz
                        using (System.IO.StreamWriter sw = new System.IO.StreamWriter(sfd.FileName, false, System.Text.Encoding.Unicode))
                        {
                            // 1. Kolon Başlıklarını Yazdırıyoruz
                            for (int i = 0; i < dataGridView1.Columns.Count; i++)
                            {
                                sw.Write(dataGridView1.Columns[i].HeaderText + "\t");
                            }
                            sw.WriteLine();

                            // 2. Satırlardaki Verileri Tek Tek Aktarıyoruz
                            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                            {
                                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                                {
                                    if (dataGridView1.Rows[i].Cells[j].Value != null)
                                    {
                                        sw.Write(dataGridView1.Rows[i].Cells[j].Value.ToString() + "\t");
                                    }
                                    else
                                    {
                                        sw.Write("\t");
                                    }
                                }
                                sw.WriteLine();
                            }
                        }

                        MessageBox.Show("Veriler başarıyla Excel'e aktarıldı !", "Sistem Bilgisi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Excel'e aktarılırken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Excel'e aktarılacak hiç veri yok.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
    }

