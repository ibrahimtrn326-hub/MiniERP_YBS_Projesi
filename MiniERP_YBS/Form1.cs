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
        int secilenPersonelID = 0;
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (secilenPersonelID != 0)
            {
                DialogResult cevap = MessageBox.Show("Bu personeli sistemden silmek istediğine emin misin?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (cevap == DialogResult.Yes)
                {
                    if (PersonelBLL.PersonelSilBLL(secilenPersonelID))
                    {
                        MessageBox.Show("Personel sistemden silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Listele(); metodun varsa onu çağırıp tabloyu yenile
                        Listele();
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox4.Clear();
                    }
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                secilenPersonelID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);

                // TextBox isimlerini kendi formundaki isimlere göre uyarlamayı unutma knk
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

                // Departman 2. indekste, Maaş 3. indekste! İşte çözüldü.
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
               textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (secilenPersonelID != 0)
            {
                Personel guncelPersonel = new Personel();
                guncelPersonel.PersonelID = secilenPersonelID;
                guncelPersonel.AdSoyad = textBox1.Text;
                guncelPersonel.Maas = Convert.ToDecimal(textBox2.Text);
                guncelPersonel.DepartmanID = Convert.ToInt32(textBox4.Text);

                try
                {
                    if (PersonelBLL.PersonelGuncelleBLL(guncelPersonel))
                    {
                        MessageBox.Show("Personel bilgileri başarıyla güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Listele();
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox4.Clear();
                    }
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    // SQL Hata Kodu 547: Foreign Key (İlişkisel Veri) ihlalidir
                    if (ex.Number == 547)
                    {
                        MessageBox.Show("Hata: Girdiğiniz Departman Numarası sistemde bulunamadı! Lütfen Departmanlar listesinde var olan geçerli bir ID girin.", "Geçersiz Departman", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Veritabanı hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
    }
}
}


