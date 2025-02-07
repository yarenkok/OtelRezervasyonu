using System.Windows.Forms;

namespace NypProje.UI
{
    partial class rezervasyon_panel
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            // Form bileşenleri
            this.components = new System.ComponentModel.Container();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.formPanel = new System.Windows.Forms.Panel();
            this.buttonsPanel = new System.Windows.Forms.Panel();

            // Mevcut kontroller
            this.cmbMusteri = new System.Windows.Forms.ComboBox();
            this.cmbOda = new System.Windows.Forms.ComboBox();
            this.cmbEkstra = new System.Windows.Forms.ComboBox();
            this.dtpGiris = new System.Windows.Forms.DateTimePicker();
            this.dtpCikis = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblSonTutar = new System.Windows.Forms.Label();
            this.lblSonTutarValue = new System.Windows.Forms.Label();
            this.btnEkle = new System.Windows.Forms.Button();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnTemizle = new System.Windows.Forms.Button();
            this.dgRezervasyonlar = new System.Windows.Forms.DataGridView();
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            this.btnTemizle.Click += new System.EventHandler(this.btnTemizle_Click);

            // UserControl
            this.Size = new System.Drawing.Size(741, 560);
            this.BackColor = System.Drawing.ColorTranslator.FromHtml("#F2F7FA");
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Padding = new System.Windows.Forms.Padding(10);

            // Main Panel
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.AutoSize = true;
            this.mainPanel.BackColor = System.Drawing.Color.Transparent;
            this.mainPanel.Padding = new System.Windows.Forms.Padding(10);

            // Header Panel
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Height = 60;
            this.headerPanel.BackColor = System.Drawing.ColorTranslator.FromHtml("#65CCD1");
            this.headerPanel.Padding = new System.Windows.Forms.Padding(15);

            // Header Label
            this.lblHeader.Text = "Rezervasyon İşlemleri";
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Top;

            // Form Panel
            this.formPanel.Location = new System.Drawing.Point(10, 80);
            this.formPanel.Size = new System.Drawing.Size(780, 120);
            this.formPanel.BackColor = System.Drawing.Color.White;
            this.formPanel.Padding = new System.Windows.Forms.Padding(10);

            // ComboBoxes
            this.ConfigureComboBox(cmbMusteri, "Müşteri Seçiniz", 70, 10);
            this.ConfigureComboBox(cmbOda, "Oda Seçiniz", 70, 50);
            this.ConfigureComboBox(cmbEkstra, "Ekstra Seçiniz", 70, 90);

            // DateTimePickers
            this.ConfigureDateTimePicker(dtpGiris, 400, 10);
            this.ConfigureDateTimePicker(dtpCikis, 400, 50);

            // Labels
            this.ConfigureLabel(label1, "Müşteri:", 10, 13);
            this.ConfigureLabel(label2, "Oda:", 10, 53);
            this.ConfigureLabel(label3, "Ekstra:", 10, 93);
            this.ConfigureLabel(label4, "Giriş Tarihi:", 320, 13);
            this.ConfigureLabel(label5, "Çıkış Tarihi:", 320, 53);

            // Tutar Labels


            // Buttons Panel
            this.buttonsPanel.Location = new System.Drawing.Point(10, 210);
            this.buttonsPanel.Size = new System.Drawing.Size(780, 50);
            this.buttonsPanel.BackColor = System.Drawing.Color.Transparent;

            // Buttons
            this.ConfigureButton(btnEkle, "Ekle", "#65CCD1", 0);
            this.ConfigureButton(btnGuncelle, "Güncelle", "#4A90E2", 1);
            this.ConfigureButton(btnSil, "Sil", "#FF8674", 2);
            this.ConfigureButton(btnTemizle, "Temizle", "#9B9B9B", 3);

            // DataGridView
            this.dgRezervasyonlar.Location = new System.Drawing.Point(10, 270);
            this.dgRezervasyonlar.Size = new System.Drawing.Size(780, 320);
            this.dgRezervasyonlar.BackgroundColor = System.Drawing.Color.White;
            this.dgRezervasyonlar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgRezervasyonlar.AllowUserToAddRows = false;
            this.dgRezervasyonlar.AllowUserToDeleteRows = false;
            this.dgRezervasyonlar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgRezervasyonlar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ConfigureDataGridView();

            // Add controls
            this.headerPanel.Controls.Add(this.lblHeader);
            this.formPanel.Controls.AddRange(new System.Windows.Forms.Control[] {
        cmbMusteri, cmbOda, cmbEkstra,
        dtpGiris, dtpCikis,
        label1, label2, label3, label4, label5,
        lblSonTutar, lblSonTutarValue
    });
            this.buttonsPanel.Controls.AddRange(new System.Windows.Forms.Control[] {
        btnEkle, btnGuncelle, btnSil, btnTemizle
    });
            this.mainPanel.Controls.AddRange(new System.Windows.Forms.Control[] {
        headerPanel, formPanel, buttonsPanel, dgRezervasyonlar
    });
            this.Controls.Add(this.mainPanel);
        }



        private void ConfigureComboBox(ComboBox cmb, string placeholder, int x, int y)
        {
            cmb.Size = new System.Drawing.Size(180, 30);
            cmb.Location = new System.Drawing.Point(x, y);
            cmb.Font = new System.Drawing.Font("Segoe UI", 10F);
            cmb.BackColor = System.Drawing.ColorTranslator.FromHtml("#F8F9FA");
            cmb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        }

        private void ConfigureDateTimePicker(DateTimePicker dtp, int x, int y)
        {
            dtp.Size = new System.Drawing.Size(180, 30);
            dtp.Location = new System.Drawing.Point(x, y);
            dtp.Font = new System.Drawing.Font("Segoe UI", 10F);
            dtp.Format = System.Windows.Forms.DateTimePickerFormat.Short;
        }

        private void ConfigureLabel(Label lbl, string text, int x, int y)
        {
            lbl.AutoSize = true;
            lbl.Location = new System.Drawing.Point(x, y);
            lbl.Text = text;
            lbl.Font = new System.Drawing.Font("Segoe UI", 9F);
            lbl.ForeColor = System.Drawing.ColorTranslator.FromHtml("#6C757D");
        }

        private void ConfigureButton(Button btn, string text, string color, int index)
        {
            btn.Size = new System.Drawing.Size(100, 40);
            btn.Location = new System.Drawing.Point(10 + (index * 120), 5);
            btn.Text = text;
            btn.BackColor = System.Drawing.ColorTranslator.FromHtml(color);
            btn.ForeColor = System.Drawing.Color.White;
            btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btn.Cursor = System.Windows.Forms.Cursors.Hand;
        }

        private void ConfigureDataGridView()
        {
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            headerStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#65CCD1");
            headerStyle.ForeColor = System.Drawing.Color.White;
            headerStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            headerStyle.WrapMode = DataGridViewTriState.True;

            dgRezervasyonlar.ColumnHeadersDefaultCellStyle = headerStyle;
            dgRezervasyonlar.ColumnHeadersHeight = 40;
            dgRezervasyonlar.EnableHeadersVisualStyles = false;
            dgRezervasyonlar.RowTemplate.Height = 35;
            dgRezervasyonlar.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#F8F9FA");
            dgRezervasyonlar.DefaultCellStyle.SelectionBackColor = System.Drawing.ColorTranslator.FromHtml("#65CCD1");
            dgRezervasyonlar.ReadOnly = true;
        }

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Panel formPanel;
        private System.Windows.Forms.Panel buttonsPanel;
        private System.Windows.Forms.ComboBox cmbMusteri;
        private System.Windows.Forms.ComboBox cmbOda;
        private System.Windows.Forms.ComboBox cmbEkstra;
        private System.Windows.Forms.DateTimePicker dtpGiris;
        private System.Windows.Forms.DateTimePicker dtpCikis;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblSonTutar;
        private System.Windows.Forms.Label lblSonTutarValue;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnTemizle;
        private System.Windows.Forms.DataGridView dgRezervasyonlar;
    }
}