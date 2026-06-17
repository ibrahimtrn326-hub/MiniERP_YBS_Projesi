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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // Tabloyu yenilemek için ortak bir fonksiyon yazdık
        void Listele()
        {
            dataGridView1.DataSource = PersonelBLL.PersonelleriGetirBLL();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Nesnemizi oluşturup içini Textbox'lardan gelen verilerle dolduruyoruz
                Personel yeniPersonel = new Personel();
                yeniPersonel.AdSoyad = textBox1.Text;
                yeniPersonel.Maas = Convert.ToDecimal(textBox2.Text);
                yeniPersonel.DepartmanID = Convert.ToInt32(textBox4.Text);
                yeniPersonel.GirisTarihi = DateTime.Now; // Giriş tarihini otomatik bugün yapıyoruz

                // 2. Veriyi kontrol etmesi için Business Katmanına (BLL) gönderiyoruz
                int sonuc = PersonelBLL.PersonelEkleBLL(yeniPersonel);

                // 3. BLL'den gelen cevaba göre aksiyon alıyoruz
                if (sonuc > 0)
                {
                    MessageBox.Show("Personel başarıyla eklendi kanki!", "Sistem Bilgisi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Listele(); // Ekleme sonrası tabloyu otomatik yenile

                    // Textbox'ların içini temizle
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox4.Clear();
                }
                else
                {
                    MessageBox.Show("Ekleme başarısız! İş kurallarına uymayan veri girdiniz.\n(İsim en az 3 harf olmalı ve Maaş asgari ücretten az olamaz!)", "İş Kuralı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                // Sayısal alanlara harf girilmesi gibi durumlarda uygulamanın çökmesini önlüyoruz
                MessageBox.Show("Lütfen veri girişlerini doğru formatta yapınız! Hata: " + ex.Message, "Sistem Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
    

