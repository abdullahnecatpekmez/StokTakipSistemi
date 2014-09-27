namespace WP_ÖDEV
{
    partial class Personel
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
            System.Windows.Forms.Label müşteriTCLabel;
            System.Windows.Forms.Label müşteriAdıLabel;
            System.Windows.Forms.Label telefonLabel;
            System.Windows.Forms.Label adresLabel;
            System.Windows.Forms.Label adetLabel;
            System.Windows.Forms.Label tarihLabel;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.müşterigöster = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.müşgüncelle = new System.Windows.Forms.Button();
            this.müşekle = new System.Windows.Forms.Button();
            this.adresTextBox = new System.Windows.Forms.TextBox();
            this.telefonTextBox = new System.Windows.Forms.TextBox();
            this.müşteriAdıTextBox = new System.Windows.Forms.TextBox();
            this.müşteriTCTextBox = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.satışgöster = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.satışiptal = new System.Windows.Forms.Button();
            this.satışgüncelle = new System.Windows.Forms.Button();
            this.satışekle = new System.Windows.Forms.Button();
            this.ürüncomboBox = new System.Windows.Forms.ComboBox();
            this.markacomboBox = new System.Windows.Forms.ComboBox();
            this.müştericomboBox = new System.Windows.Forms.ComboBox();
            this.tarih = new System.Windows.Forms.DateTimePicker();
            this.adetTextBox = new System.Windows.Forms.TextBox();
            müşteriTCLabel = new System.Windows.Forms.Label();
            müşteriAdıLabel = new System.Windows.Forms.Label();
            telefonLabel = new System.Windows.Forms.Label();
            adresLabel = new System.Windows.Forms.Label();
            adetLabel = new System.Windows.Forms.Label();
            tarihLabel = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.müşterigöster)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.satışgöster)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // müşteriTCLabel
            // 
            müşteriTCLabel.AutoSize = true;
            müşteriTCLabel.Location = new System.Drawing.Point(6, 32);
            müşteriTCLabel.Name = "müşteriTCLabel";
            müşteriTCLabel.Size = new System.Drawing.Size(106, 28);
            müşteriTCLabel.TabIndex = 0;
            müşteriTCLabel.Text = "Müşteri TC:";
            // 
            // müşteriAdıLabel
            // 
            müşteriAdıLabel.AutoSize = true;
            müşteriAdıLabel.Location = new System.Drawing.Point(397, 32);
            müşteriAdıLabel.Name = "müşteriAdıLabel";
            müşteriAdıLabel.Size = new System.Drawing.Size(112, 28);
            müşteriAdıLabel.TabIndex = 2;
            müşteriAdıLabel.Text = "Müşteri Adı:";
            // 
            // telefonLabel
            // 
            telefonLabel.AutoSize = true;
            telefonLabel.Location = new System.Drawing.Point(6, 83);
            telefonLabel.Name = "telefonLabel";
            telefonLabel.Size = new System.Drawing.Size(75, 28);
            telefonLabel.TabIndex = 4;
            telefonLabel.Text = "Telefon:";
            // 
            // adresLabel
            // 
            adresLabel.AutoSize = true;
            adresLabel.Location = new System.Drawing.Point(6, 136);
            adresLabel.Name = "adresLabel";
            adresLabel.Size = new System.Drawing.Size(63, 28);
            adresLabel.TabIndex = 6;
            adresLabel.Text = "Adres:";
            // 
            // adetLabel
            // 
            adetLabel.AutoSize = true;
            adetLabel.Location = new System.Drawing.Point(8, 179);
            adetLabel.Name = "adetLabel";
            adetLabel.Size = new System.Drawing.Size(56, 28);
            adetLabel.TabIndex = 0;
            adetLabel.Text = "Adet:";
            // 
            // tarihLabel
            // 
            tarihLabel.AutoSize = true;
            tarihLabel.Location = new System.Drawing.Point(436, 32);
            tarihLabel.Name = "tarihLabel";
            tarihLabel.Size = new System.Drawing.Size(60, 28);
            tarihLabel.TabIndex = 2;
            tarihLabel.Text = "Tarih:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(6, 32);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(78, 28);
            label2.TabIndex = 0;
            label2.Text = "Müşteri:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(6, 81);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(67, 28);
            label3.TabIndex = 0;
            label3.Text = "Marka:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(6, 130);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(58, 28);
            label4.TabIndex = 0;
            label4.Text = "Ürün:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(13, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(863, 598);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tabPage1.Controls.Add(this.müşterigöster);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 37);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(855, 557);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Müşteri Ekleme";
            // 
            // müşterigöster
            // 
            this.müşterigöster.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.müşterigöster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.müşterigöster.Location = new System.Drawing.Point(4, 286);
            this.müşterigöster.Name = "müşterigöster";
            this.müşterigöster.ReadOnly = true;
            this.müşterigöster.Size = new System.Drawing.Size(845, 265);
            this.müşterigöster.TabIndex = 3;
            this.müşterigöster.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.müşterigöster_CellContentClick);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(6, 216);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(843, 66);
            this.label1.TabIndex = 2;
            this.label1.Text = "Güncellemek İstediğiniz MÜŞTERİ\'yi Aşağıdaki Listeden Seçiniz Ve Güncellemek İste" +
    "diğiniz Veriyi Değiştirerek Güncelle Tuşuna Basınız";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.müşgüncelle);
            this.groupBox1.Controls.Add(this.müşekle);
            this.groupBox1.Controls.Add(adresLabel);
            this.groupBox1.Controls.Add(this.adresTextBox);
            this.groupBox1.Controls.Add(telefonLabel);
            this.groupBox1.Controls.Add(this.telefonTextBox);
            this.groupBox1.Controls.Add(müşteriAdıLabel);
            this.groupBox1.Controls.Add(this.müşteriAdıTextBox);
            this.groupBox1.Controls.Add(müşteriTCLabel);
            this.groupBox1.Controls.Add(this.müşteriTCTextBox);
            this.groupBox1.Location = new System.Drawing.Point(7, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(842, 194);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Müşteri Ekleme Ve Güncelleme";
            // 
            // müşgüncelle
            // 
            this.müşgüncelle.Location = new System.Drawing.Point(623, 80);
            this.müşgüncelle.Name = "müşgüncelle";
            this.müşgüncelle.Size = new System.Drawing.Size(213, 89);
            this.müşgüncelle.TabIndex = 8;
            this.müşgüncelle.Text = "Güncelle";
            this.müşgüncelle.UseVisualStyleBackColor = true;
            this.müşgüncelle.Click += new System.EventHandler(this.müşgüncelle_Click);
            // 
            // müşekle
            // 
            this.müşekle.Location = new System.Drawing.Point(402, 80);
            this.müşekle.Name = "müşekle";
            this.müşekle.Size = new System.Drawing.Size(215, 89);
            this.müşekle.TabIndex = 8;
            this.müşekle.Text = "Müşteri Ekle";
            this.müşekle.UseVisualStyleBackColor = true;
            this.müşekle.Click += new System.EventHandler(this.müşekle_Click);
            // 
            // adresTextBox
            // 
            this.adresTextBox.Location = new System.Drawing.Point(118, 133);
            this.adresTextBox.Multiline = true;
            this.adresTextBox.Name = "adresTextBox";
            this.adresTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.adresTextBox.Size = new System.Drawing.Size(259, 36);
            this.adresTextBox.TabIndex = 7;
            // 
            // telefonTextBox
            // 
            this.telefonTextBox.Location = new System.Drawing.Point(118, 80);
            this.telefonTextBox.Name = "telefonTextBox";
            this.telefonTextBox.Size = new System.Drawing.Size(259, 36);
            this.telefonTextBox.TabIndex = 5;
            // 
            // müşteriAdıTextBox
            // 
            this.müşteriAdıTextBox.Location = new System.Drawing.Point(515, 29);
            this.müşteriAdıTextBox.Name = "müşteriAdıTextBox";
            this.müşteriAdıTextBox.Size = new System.Drawing.Size(321, 36);
            this.müşteriAdıTextBox.TabIndex = 3;
            // 
            // müşteriTCTextBox
            // 
            this.müşteriTCTextBox.Location = new System.Drawing.Point(118, 29);
            this.müşteriTCTextBox.Name = "müşteriTCTextBox";
            this.müşteriTCTextBox.Size = new System.Drawing.Size(259, 36);
            this.müşteriTCTextBox.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tabPage2.Controls.Add(this.satışgöster);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 37);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(855, 557);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Satış Ekleme";
            // 
            // satışgöster
            // 
            this.satışgöster.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.satışgöster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.satışgöster.Location = new System.Drawing.Point(7, 283);
            this.satışgöster.Name = "satışgöster";
            this.satışgöster.Size = new System.Drawing.Size(842, 268);
            this.satışgöster.TabIndex = 1;
            this.satışgöster.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.satışgöster_CellContentClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.satışiptal);
            this.groupBox2.Controls.Add(this.satışgüncelle);
            this.groupBox2.Controls.Add(this.satışekle);
            this.groupBox2.Controls.Add(this.ürüncomboBox);
            this.groupBox2.Controls.Add(this.markacomboBox);
            this.groupBox2.Controls.Add(this.müştericomboBox);
            this.groupBox2.Controls.Add(tarihLabel);
            this.groupBox2.Controls.Add(this.tarih);
            this.groupBox2.Controls.Add(label4);
            this.groupBox2.Controls.Add(label3);
            this.groupBox2.Controls.Add(label2);
            this.groupBox2.Controls.Add(adetLabel);
            this.groupBox2.Controls.Add(this.adetTextBox);
            this.groupBox2.Location = new System.Drawing.Point(7, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(856, 223);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Satış Ekleme Ve Güncelleme";
            // 
            // satışiptal
            // 
            this.satışiptal.Enabled = false;
            this.satışiptal.Location = new System.Drawing.Point(643, 147);
            this.satışiptal.Name = "satışiptal";
            this.satışiptal.Size = new System.Drawing.Size(199, 65);
            this.satışiptal.TabIndex = 5;
            this.satışiptal.Text = "Satış İptal";
            this.satışiptal.UseVisualStyleBackColor = true;
            this.satışiptal.Click += new System.EventHandler(this.satışiptal_Click);
            // 
            // satışgüncelle
            // 
            this.satışgüncelle.Location = new System.Drawing.Point(441, 147);
            this.satışgüncelle.Name = "satışgüncelle";
            this.satışgüncelle.Size = new System.Drawing.Size(199, 65);
            this.satışgüncelle.TabIndex = 5;
            this.satışgüncelle.Text = "Satış Güncelleme";
            this.satışgüncelle.UseVisualStyleBackColor = true;
            this.satışgüncelle.Click += new System.EventHandler(this.satışgüncelle_Click);
            // 
            // satışekle
            // 
            this.satışekle.Location = new System.Drawing.Point(441, 78);
            this.satışekle.Name = "satışekle";
            this.satışekle.Size = new System.Drawing.Size(401, 65);
            this.satışekle.TabIndex = 5;
            this.satışekle.Text = "Satış Ekle";
            this.satışekle.UseVisualStyleBackColor = true;
            this.satışekle.Click += new System.EventHandler(this.satışekle_Click);
            // 
            // ürüncomboBox
            // 
            this.ürüncomboBox.FormattingEnabled = true;
            this.ürüncomboBox.Location = new System.Drawing.Point(108, 127);
            this.ürüncomboBox.Name = "ürüncomboBox";
            this.ürüncomboBox.Size = new System.Drawing.Size(294, 36);
            this.ürüncomboBox.TabIndex = 4;
            // 
            // markacomboBox
            // 
            this.markacomboBox.FormattingEnabled = true;
            this.markacomboBox.Location = new System.Drawing.Point(108, 78);
            this.markacomboBox.Name = "markacomboBox";
            this.markacomboBox.Size = new System.Drawing.Size(294, 36);
            this.markacomboBox.TabIndex = 4;
            this.markacomboBox.SelectedIndexChanged += new System.EventHandler(this.markacomboBox_SelectedIndexChanged);
            // 
            // müştericomboBox
            // 
            this.müştericomboBox.FormattingEnabled = true;
            this.müştericomboBox.Location = new System.Drawing.Point(108, 29);
            this.müştericomboBox.Name = "müştericomboBox";
            this.müştericomboBox.Size = new System.Drawing.Size(294, 36);
            this.müştericomboBox.TabIndex = 4;
            // 
            // tarih
            // 
            this.tarih.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.tarih.Location = new System.Drawing.Point(544, 29);
            this.tarih.Name = "tarih";
            this.tarih.Size = new System.Drawing.Size(179, 36);
            this.tarih.TabIndex = 3;
            // 
            // adetTextBox
            // 
            this.adetTextBox.Location = new System.Drawing.Point(108, 176);
            this.adetTextBox.Name = "adetTextBox";
            this.adetTextBox.Size = new System.Drawing.Size(83, 36);
            this.adetTextBox.TabIndex = 1;
            // 
            // Personel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(888, 623);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.MaximizeBox = false;
            this.Name = "Personel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Personel";
            this.Load += new System.EventHandler(this.Personel_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.müşterigöster)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.satışgöster)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button müşgüncelle;
        private System.Windows.Forms.Button müşekle;
        private System.Windows.Forms.TextBox adresTextBox;
        private System.Windows.Forms.TextBox telefonTextBox;
        private System.Windows.Forms.TextBox müşteriAdıTextBox;
        private System.Windows.Forms.TextBox müşteriTCTextBox;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker tarih;
        private System.Windows.Forms.TextBox adetTextBox;
        private System.Windows.Forms.DataGridView satışgöster;
        private System.Windows.Forms.ComboBox ürüncomboBox;
        private System.Windows.Forms.ComboBox markacomboBox;
        private System.Windows.Forms.ComboBox müştericomboBox;
        private System.Windows.Forms.Button satışgüncelle;
        private System.Windows.Forms.Button satışekle;
        private System.Windows.Forms.Button satışiptal;
        private System.Windows.Forms.DataGridView müşterigöster;
    }
}