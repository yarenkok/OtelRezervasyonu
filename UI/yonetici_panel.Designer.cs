using System;
using System.Drawing;
using System.Windows.Forms;

namespace NypProje.UI
{
    partial class yonetici_panel
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
            this.components = new System.ComponentModel.Container();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.formPanel = new System.Windows.Forms.Panel();
            this.buttonsPanel = new System.Windows.Forms.Panel();
            this.dgYoneticiler = new System.Windows.Forms.DataGridView();

            this.txtYoneticiAd = new System.Windows.Forms.TextBox();
            this.txtYoneticiSoyad = new System.Windows.Forms.TextBox();
            this.txtYoneticiTel = new System.Windows.Forms.TextBox();
            this.txtKullaniciAdi = new System.Windows.Forms.TextBox();
            this.txtSifre = new System.Windows.Forms.TextBox();

            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();

            this.btnEkle = new System.Windows.Forms.Button();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnTemizle = new System.Windows.Forms.Button();

            // Event handlers
            btnEkle.Click += new EventHandler(this.btnEkle_Click);
            btnGuncelle.Click += new EventHandler(this.btnGuncelle_Click);
            btnSil.Click += new EventHandler(this.btnSil_Click);
            btnTemizle.Click += new EventHandler(this.btnTemizle_Click);
            dgYoneticiler.CellClick += new DataGridViewCellEventHandler(this.dgYoneticiler_CellContentClick);

            // UserControl
            this.Size = new System.Drawing.Size(741, 560);
            this.BackColor = System.Drawing.ColorTranslator.FromHtml("#F2F7FA");
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Padding = new System.Windows.Forms.Padding(10);

            // Main Panel
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.AutoSize = true;
            this.mainPanel.Padding = new System.Windows.Forms.Padding(10);

            // Header Panel
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Height = 60;
            this.headerPanel.BackColor = System.Drawing.ColorTranslator.FromHtml("#65CCD1");
            this.headerPanel.Padding = new System.Windows.Forms.Padding(15);

            // Header Label
            this.lblHeader.Text = "Yönetici İşlemleri";
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Top;

            // Form Panel
            this.formPanel.Location = new System.Drawing.Point(10, 80);
            this.formPanel.Size = new System.Drawing.Size(780, 160);
            this.formPanel.BackColor = System.Drawing.Color.White;
            this.formPanel.Padding = new System.Windows.Forms.Padding(10);

            // Labels
            this.ConfigureLabel(label1, "Yönetici Adı:", 10, 13);
            this.ConfigureLabel(label2, "Yönetici Soyadı:", 10, 53);
            this.ConfigureLabel(label3, "Telefon:", 10, 93);
            this.ConfigureLabel(label4, "Kullanıcı Adı:", 400, 13);
            this.ConfigureLabel(label5, "Şifre:", 400, 53);

            // Textboxes
            this.ConfigureTextBox(txtYoneticiAd, 100, 10);
            this.ConfigureTextBox(txtYoneticiSoyad, 100, 50);
            this.ConfigureTextBox(txtYoneticiTel, 100, 90);
            this.ConfigureTextBox(txtKullaniciAdi, 490, 10);
            this.ConfigureTextBox(txtSifre, 490, 50);
            txtSifre.PasswordChar = '•';

            // Buttons Panel
            this.buttonsPanel.Location = new System.Drawing.Point(10, 250);
            this.buttonsPanel.Size = new System.Drawing.Size(780, 50);
            this.buttonsPanel.BackColor = System.Drawing.Color.Transparent;

            // Buttons
            this.ConfigureButton(btnEkle, "Ekle", "#65CCD1", 0);
            this.ConfigureButton(btnGuncelle, "Güncelle", "#4A90E2", 1);
            this.ConfigureButton(btnSil, "Sil", "#FF8674", 2);
            this.ConfigureButton(btnTemizle, "Temizle", "#9B9B9B", 3);

            // DataGridView
            this.dgYoneticiler.Location = new System.Drawing.Point(10, 310);
            this.dgYoneticiler.Size = new System.Drawing.Size(780, 240);
            this.dgYoneticiler.BackgroundColor = System.Drawing.Color.White;
            this.dgYoneticiler.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgYoneticiler.AllowUserToAddRows = false;
            this.dgYoneticiler.Dock = DockStyle.None;
            this.dgYoneticiler.AllowUserToDeleteRows = false;
            this.dgYoneticiler.ScrollBars = ScrollBars.Vertical;
            this.dgYoneticiler.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgYoneticiler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ConfigureDataGridView();

            // Add controls
            this.headerPanel.Controls.Add(this.lblHeader);
            this.formPanel.Controls.AddRange(new System.Windows.Forms.Control[] {
                txtYoneticiAd, txtYoneticiSoyad, txtYoneticiTel, txtKullaniciAdi, txtSifre,
                label1, label2, label3, label4, label5
            });
            this.buttonsPanel.Controls.AddRange(new System.Windows.Forms.Control[] {
                btnEkle, btnGuncelle, btnSil, btnTemizle
            });
            this.mainPanel.Controls.AddRange(new System.Windows.Forms.Control[] {
                headerPanel, formPanel, buttonsPanel, dgYoneticiler
            });
            this.Controls.Add(this.mainPanel);
        }

        private void ConfigureLabel(Label lbl, string text, int x, int y)
        {
            lbl.AutoSize = true;
            lbl.Location = new System.Drawing.Point(x, y);
            lbl.Text = text;
            lbl.Font = new System.Drawing.Font("Segoe UI", 9F);
            lbl.ForeColor = System.Drawing.ColorTranslator.FromHtml("#6C757D");
        }

        private void ConfigureTextBox(TextBox txt, int x, int y)
        {
            txt.Size = new System.Drawing.Size(250, 25);
            txt.Location = new System.Drawing.Point(x, y);
            txt.Font = new System.Drawing.Font("Segoe UI", 10F);
            txt.BackColor = System.Drawing.ColorTranslator.FromHtml("#F8F9FA");
            txt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txt.Padding = new System.Windows.Forms.Padding(5);
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

            dgYoneticiler.ColumnHeadersDefaultCellStyle = headerStyle;
            dgYoneticiler.ColumnHeadersHeight = 40;
            dgYoneticiler.EnableHeadersVisualStyles = false;
            dgYoneticiler.RowTemplate.Height = 35;
            dgYoneticiler.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#F8F9FA");
            dgYoneticiler.DefaultCellStyle.SelectionBackColor = System.Drawing.ColorTranslator.FromHtml("#65CCD1");
            dgYoneticiler.ReadOnly = true;
        }

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Panel formPanel;
        private System.Windows.Forms.Panel buttonsPanel;
        private System.Windows.Forms.DataGridView dgYoneticiler;
        private System.Windows.Forms.TextBox txtYoneticiAd;
        private System.Windows.Forms.TextBox txtYoneticiSoyad;
        private System.Windows.Forms.TextBox txtYoneticiTel;
        private System.Windows.Forms.TextBox txtKullaniciAdi;
        private System.Windows.Forms.TextBox txtSifre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnTemizle;
    }
}