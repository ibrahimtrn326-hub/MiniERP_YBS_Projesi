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
    public partial class DepartmanForm : Form
    {
        int secilenDepartmanID = 0;
        public DepartmanForm()
        {
            InitializeComponent();
        }
        public void Listele()
        {
            System.Data.SqlClient.SqlConnection baglanti = MiniERP_YBS.DataAccessLayer.Baglanti.BaglantiAl();
            System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter("SELECT * FROM Departmanlar", baglanti);
            System.Data.DataTable dt = new System.Data.DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void DepartmanForm_Load(object sender, EventArgs e)
        {
            Listele();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                secilenDepartmanID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Departman yeniDepartman = new Departman();
            // Entity'deki isme göre DepartmanAdi yaptık (Dal'da düzelttiğimiz gibi)
            yeniDepartman.DepartmanAdi = textBox1.Text;

            // BLL'den true dönerse eklenmiştir
            if (DepartmanBLL.DepartmanEkleBLL(yeniDepartman))
            {
                MessageBox.Show("Yeni departman başarıyla eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Listele();
                textBox1.Clear();
            }
            else
            {
                MessageBox.Show("Ekleme başarısız! İsim boş olamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (secilenDepartmanID != 0)
            {
                Departman guncel = new Departman();
                guncel.DepartmanID = secilenDepartmanID;
                guncel.DepartmanAdi = textBox1.Text;

                if (DepartmanBLL.DepartmanGuncelleBLL(guncel))
                {
                    MessageBox.Show("Departman güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Listele();
                }
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (secilenDepartmanID != 0)
            {
                DialogResult cevap = MessageBox.Show("Departmanı silmek istediğine emin misin?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (cevap == DialogResult.Yes)
                {
                    try
                    {
                        // Hata çıkmazsa normal silme işlemini yap
                        if (DepartmanBLL.DepartmanSilBLL(secilenDepartmanID))
                        {
                            MessageBox.Show("Departman sistemden silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Listele();
                            textBox1.Clear();
                        }
                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        // SQL Hata Kodu 547: Foreign Key (İlişkisel Veri) ihlalidir
                        if (ex.Number == 547)
                        {
                            MessageBox.Show("Bu departmanı silemezsiniz! Sisteme kayıtlı bazı personeller bu departmanda çalışıyor görünüyor. Önce o personelleri silin veya departmanlarını değiştirin.", "İlişkisel Veri Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            // Farklı bir SQL hatası varsa onu göster
                            MessageBox.Show("Veritabanı hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
    }
}
