using System;
using System.Windows.Forms;

namespace NypProje.UI
{
    public partial class kayit_sayfa : Form
    {

        private void InitializeComponent()
        {
            // Form bileşenleri
            this.mainPanel = new System.Windows.Forms.Panel();
            this.loginPanel = new System.Windows.Forms.Panel();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.formPanel = new System.Windows.Forms.Panel();

            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();

            this.txtAd = new System.Windows.Forms.TextBox();
            this.txtSoyad = new System.Windows.Forms.TextBox();
            this.txtKullaniciAdi = new System.Windows.Forms.TextBox();
            this.lblCikis = new System.Windows.Forms.Label();
            this.txtSifre = new System.Windows.Forms.TextBox();
            this.txtTel = new System.Windows.Forms.TextBox();

            this.btnKayitOl = new System.Windows.Forms.Button();
            this.btnGeriDon = new System.Windows.Forms.Button();

            // Event Handlers
            this.btnGeriDon.Click += new System.EventHandler(this.btnGeriDon_Click);
            this.btnKayitOl.Click += new System.EventHandler(this.btnKayitOl_Click);

            this.lblCikis.Click += new System.EventHandler(this.lblCikis_Click);
            this.lblCikis.MouseEnter += new System.EventHandler(this.lblCikis_Enter);
            this.lblCikis.MouseLeave += new System.EventHandler(this.lblCikis_Leave);

            // Form Özellikleri
            this.ClientSize = new System.Drawing.Size(400, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;
            this.MaximizeBox = false;
            this.BackColor = System.Drawing.ColorTranslator.FromHtml("#F2F7FA");
            this.Font = new System.Drawing.Font("Segoe UI", 9F);

            // Panel ve Layout Ayarları
            this.mainPanel.Dock = DockStyle.Fill;
            this.mainPanel.Padding = new Padding(10);

            this.loginPanel.Size = new System.Drawing.Size(360, 460);
            this.loginPanel.BackColor = System.Drawing.Color.White;
            this.loginPanel.Location = new System.Drawing.Point(20, 20);

            this.headerPanel.Dock = DockStyle.Top;
            this.headerPanel.Height = 80;
            this.headerPanel.BackColor = System.Drawing.ColorTranslator.FromHtml("#65CCD1");
            this.headerPanel.Padding = new Padding(15);
            this.headerPanel.Controls.Add(this.lblCikis);

            this.lblHeader.Text = "Otel Yönetim Sistemi";
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Dock = DockStyle.Fill;
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.formPanel.Location = new System.Drawing.Point(30, 100);
            this.formPanel.Size = new System.Drawing.Size(300, 340);
            this.formPanel.BackColor = System.Drawing.Color.Transparent;

            // Bileşen Konfigürasyonları
            this.ConfigureTextBox(txtAd, "Yönetici Adı", -10);
            this.ConfigureTextBox(txtSoyad, "Yönetici Soyadı", 40);
            this.ConfigureTextBox(txtKullaniciAdi, "Kullanıcı Adı", 90);
            this.ConfigureTextBox(txtSifre, "Şifre", 140);
            this.ConfigureTextBox(txtTel, "Telefon Numarası", 190);

            this.ConfigureLabel(label1, "Yönetici Adı:", -5);
            this.ConfigureLabel(label2, "Yönetici Soyadı:", 45);
            this.ConfigureLabel(label3, "Kullanıcı Adı:", 95);
            this.ConfigureLabel(label4, "Şifre:", 145);
            this.ConfigureLabel(label5, "Telefon Numarası:", 195);

            this.ConfigureButton(btnKayitOl, "Kayıt Ol", "#65CCD1", 250);
            this.ConfigureButton(btnGeriDon, "Geri Dön", "#4A90E2", 300);
            ConfigureExitLabel();

            // Form Yapılandırması
            this.headerPanel.Controls.Add(this.lblHeader);
            this.formPanel.Controls.AddRange(new Control[] {
                txtKullaniciAdi, txtSifre, txtTel, txtAd, txtSoyad,
                label1, label2, label3, label4, label5,
                btnGeriDon, btnKayitOl
            });
            this.loginPanel.Controls.AddRange(new Control[] {
                headerPanel, formPanel
            });
            this.mainPanel.Controls.Add(this.loginPanel);
            this.Controls.Add(this.mainPanel);
        }

        private void ConfigureTextBox(TextBox txt, string placeholder, int yOffset)
        {
            txt.Size = new System.Drawing.Size(300, 35);
            txt.Location = new System.Drawing.Point(0, yOffset + 25);
            txt.Font = new System.Drawing.Font("Segoe UI", 11F);
            txt.BackColor = System.Drawing.ColorTranslator.FromHtml("#F8F9FA");
            txt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txt.Padding = new System.Windows.Forms.Padding(5);
        }

        private void ConfigureLabel(Label lbl, string text, int yOffset)
        {
            lbl.AutoSize = true;
            lbl.Location = new System.Drawing.Point(0, yOffset);
            lbl.Text = text;
            lbl.Font = new System.Drawing.Font("Segoe UI", 10F);
            lbl.ForeColor = System.Drawing.ColorTranslator.FromHtml("#6C757D");
        }

        private void ConfigureButton(Button btn, string text, string color, int yOffset)
        {
            btn.Size = new System.Drawing.Size(300, 45);
            btn.Location = new System.Drawing.Point(0, yOffset);
            btn.Text = text;
            btn.BackColor = System.Drawing.ColorTranslator.FromHtml(color);
            btn.ForeColor = System.Drawing.Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            btn.Cursor = Cursors.Hand;
        }

        private void ConfigureExitLabel()
        {
            this.lblCikis.AutoSize = true;
            this.lblCikis.Text = "X";
            this.lblCikis.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblCikis.ForeColor = System.Drawing.ColorTranslator.FromHtml("#9afaff");
            this.lblCikis.Location = new System.Drawing.Point(320, 10);
            this.lblCikis.Cursor = System.Windows.Forms.Cursors.Hand;
        }

        // Bileşen Tanımlamaları
        private Panel mainPanel;
        private Panel loginPanel;
        private Panel headerPanel;
        private Label lblHeader;
        private Panel formPanel;
        private System.Windows.Forms.Label lblCikis;
        private Label label1, label2, label3, label4, label5;
        private TextBox txtAd, txtSoyad, txtKullaniciAdi, txtSifre, txtTel;
        private Button btnKayitOl, btnGeriDon;
    }
}