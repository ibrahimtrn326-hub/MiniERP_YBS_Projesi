using MiniERP_YBS.BusinessLayer;
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
    public partial class IstatistikForm : Form
    {
        public IstatistikForm()
        {
            InitializeComponent();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void IstatistikForm_Load(object sender, EventArgs e)
        {
            int toplamPersonel = IstatistikBLL.ToplamPersonelBLL();
            decimal toplamMaas = IstatistikBLL.ToplamMaasBLL();
            decimal enYuksekMaas = IstatistikBLL.EnYuksekMaasBLL();

            // 2. Grafiğin varsayılan ayarlarını temizleyip kendi serimizi oluşturuyoruz
            chart1.Series.Clear();
            chart1.Series.Add("SirketVerileri");

            // Grafiğin türünü Sütun (Column) grafiği yapıyoruz
            chart1.Series["SirketVerileri"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;

            // Sütunların üzerine rakamları yazdıralım ki janti dursun
            chart1.Series["SirketVerileri"].IsValueShownAsLabel = true;

            // 3. Verileri X ve Y eksenine ekliyoruz
            chart1.Series["SirketVerileri"].Points.AddXY("Toplam Personel", toplamPersonel);
            chart1.Series["SirketVerileri"].Points.AddXY("Toplam Maaş Gideri", toplamMaas);
            chart1.Series["SirketVerileri"].Points.AddXY("En Yüksek Maaş", enYuksekMaas);
        }
    }
}
