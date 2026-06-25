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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MiniERP_YBS
{
    public partial class Form2 : Form
    {
        int secilenUrunID = 0; // Seçilen ürünün ID'sini tutacak değişken, başlangıçta -1 (hiçbir ürün seçilmedi) olarak ayarlan
        public Form2()
        {
            InitializeComponent();
        }
        void Listele()
        {
            dataGridView1.DataSource = UrunBLL.UrunleriGetirBLL();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Kutulardaki verileri alıp yeni bir ürün nesnesi oluşturuyoruz
                Urun yeniUrun = new Urun();
                yeniUrun.UrunAdi = textBoxUrunAdi.Text;
                yeniUrun.StokMiktari = Convert.ToInt32(textBoxStok.Text);
                yeniUrun.BirimFiyat = Convert.ToDecimal(textBoxFiyat.Text);

                // 2. Kontrol etmesi için İş Katmanına (BLL) yolluyoruz
                int sonuc = UrunBLL.UrunEkleBLL(yeniUrun);

                // 3. Sonuca göre mesaj veriyoruz
                if (sonuc > 0)
                {
                    MessageBox.Show("Ürün başarıyla stoka eklendi!.", "Sistem Bilgisi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Listele(); // Tabloyu anında yenile

                    // Kutuları temizle
                    textBoxUrunAdi.Clear();
                    textBoxStok.Clear();
                    textBoxFiyat.Clear();
                }
                else
                {
                    MessageBox.Show("Ekleme başarısız! Ürün adı boş olamaz, stok veya fiyat 0'dan küçük girilemez.", "İş Kuralı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lütfen sayısal alanlara harf girmeyiniz! Hata: " + ex.Message, "Sistem Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Tablodan tıklanan satırın verilerini alıp yandaki TextBox'lara dolduruyoruz
            if (e.RowIndex >= 0)
            {
                secilenUrunID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value); // Gizli ID
                textBoxUrunAdi.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString(); // Ürün Adı
                textBoxStok.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString(); // Stok
                textBoxFiyat.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString(); // Fiyat
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (secilenUrunID != 0)
            {
                // TextBox'lardaki yeni verileri alıp güncelliyoruz
                Urun guncelUrun = new Urun();
                guncelUrun.UrunID = secilenUrunID;
                guncelUrun.UrunAdi = textBoxUrunAdi.Text;
                guncelUrun.StokMiktari = Convert.ToInt32(textBoxStok.Text);
                guncelUrun.BirimFiyat = Convert.ToDecimal(textBoxFiyat.Text);

                UrunBLL.UrunGuncelleBLL(guncelUrun); // BLL katmanına gönder

                MessageBox.Show("Ürün başarıyla güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Listele(); // Tabloyu anında yenile
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (secilenUrunID != 0)
            {
                DialogResult cevap = MessageBox.Show("Bu ürünü silmek istediğine emin misin ?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (cevap == DialogResult.Yes)
                {
                    UrunBLL.UrunSilBLL(secilenUrunID); // BLL katmanına sadece ID'yi gönderiyoruz
                    MessageBox.Show("Ürün depodan silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Listele(); // Tabloyu anında yenile
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBoxUrunAdi.Clear();
            textBoxFiyat.Clear();
            textBoxStok.Clear();
        }
    }
    }

