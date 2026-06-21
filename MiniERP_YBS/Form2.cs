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
    public partial class Form2 : Form
    {
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
                    MessageBox.Show("Ürün başarıyla stoka eklendi kanki! Kaslar bayram edecek.", "Sistem Bilgisi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
    }

