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
    public partial class MusterilerForm : Form
    {
        int secilenMusteriID = 0;
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                secilenMusteriID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                textBoxAdSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBoxTelefon.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                textBoxMail.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (secilenMusteriID != 0)
            {
                Musteri guncelMusteri = new Musteri();
                guncelMusteri.MusteriID = secilenMusteriID;
                guncelMusteri.SirketAdi_AdSoyad = textBoxAdSoyad.Text;
                guncelMusteri.Telefon = textBoxTelefon.Text;
                guncelMusteri.Email = textBoxMail.Text;

                MusteriBLL.MusteriGuncelleBLL(guncelMusteri);

                MessageBox.Show("Müşteri başarıyla güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Listele();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (secilenMusteriID != 0)
            {
                DialogResult cevap = MessageBox.Show("Müşteriyi silmek istediğine emin misin?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (cevap == DialogResult.Yes)
                {
                    MusteriBLL.MusteriSilBLL(secilenMusteriID);
                    MessageBox.Show("Müşteri sistemden silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Listele();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
           textBoxAdSoyad.Clear();
            textBoxTelefon.Clear();
            textBoxMail.Clear();
        }
    }
}
