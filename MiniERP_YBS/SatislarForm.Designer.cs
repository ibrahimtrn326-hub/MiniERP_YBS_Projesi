namespace MiniERP_YBS
{
    partial class SatislarForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBoxUrun = new System.Windows.Forms.ComboBox();
            this.comboBoxMusteri = new System.Windows.Forms.ComboBox();
            this.comboBoxPersonel = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSatisYap = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxAdet = new System.Windows.Forms.TextBox();
            this.textBoxFiyat = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxUrun
            // 
            this.comboBoxUrun.FormattingEnabled = true;
            this.comboBoxUrun.Location = new System.Drawing.Point(211, 54);
            this.comboBoxUrun.Name = "comboBoxUrun";
            this.comboBoxUrun.Size = new System.Drawing.Size(172, 24);
            this.comboBoxUrun.TabIndex = 0;
            // 
            // comboBoxMusteri
            // 
            this.comboBoxMusteri.FormattingEnabled = true;
            this.comboBoxMusteri.Location = new System.Drawing.Point(211, 137);
            this.comboBoxMusteri.Name = "comboBoxMusteri";
            this.comboBoxMusteri.Size = new System.Drawing.Size(172, 24);
            this.comboBoxMusteri.TabIndex = 1;
            // 
            // comboBoxPersonel
            // 
            this.comboBoxPersonel.FormattingEnabled = true;
            this.comboBoxPersonel.Location = new System.Drawing.Point(211, 215);
            this.comboBoxPersonel.Name = "comboBoxPersonel";
            this.comboBoxPersonel.Size = new System.Drawing.Size(172, 24);
            this.comboBoxPersonel.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(114, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "ürün ";
            // 
            // buttonSatisYap
            // 
            this.buttonSatisYap.Location = new System.Drawing.Point(496, 203);
            this.buttonSatisYap.Name = "buttonSatisYap";
            this.buttonSatisYap.Size = new System.Drawing.Size(149, 74);
            this.buttonSatisYap.TabIndex = 6;
            this.buttonSatisYap.Text = "SATIŞ YAP";
            this.buttonSatisYap.UseVisualStyleBackColor = true;
            this.buttonSatisYap.Click += new System.EventHandler(this.buttonSatisYap_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(114, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "müşteri";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(114, 223);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "personel";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(428, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "adet";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(428, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "fiyat";
            // 
            // textBoxAdet
            // 
            this.textBoxAdet.Location = new System.Drawing.Point(506, 60);
            this.textBoxAdet.Name = "textBoxAdet";
            this.textBoxAdet.Size = new System.Drawing.Size(154, 22);
            this.textBoxAdet.TabIndex = 11;
            // 
            // textBoxFiyat
            // 
            this.textBoxFiyat.Location = new System.Drawing.Point(506, 109);
            this.textBoxFiyat.Name = "textBoxFiyat";
            this.textBoxFiyat.Size = new System.Drawing.Size(154, 22);
            this.textBoxFiyat.TabIndex = 12;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(765, 33);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(814, 388);
            this.dataGridView1.TabIndex = 13;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(506, 295);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(139, 70);
            this.button1.TabIndex = 14;
            this.button1.Text = "EXCEL ÇIKTI ALMA";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SatislarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1617, 447);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBoxFiyat);
            this.Controls.Add(this.textBoxAdet);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonSatisYap);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxPersonel);
            this.Controls.Add(this.comboBoxMusteri);
            this.Controls.Add(this.comboBoxUrun);
            this.Name = "SatislarForm";
            this.Text = "SatislarForm";
            this.Load += new System.EventHandler(this.SatislarForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxUrun;
        private System.Windows.Forms.ComboBox comboBoxMusteri;
        private System.Windows.Forms.ComboBox comboBoxPersonel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSatisYap;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxAdet;
        private System.Windows.Forms.TextBox textBoxFiyat;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
    }
}