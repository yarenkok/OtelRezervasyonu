using System;
using System.Drawing;
using System.Windows.Forms;

namespace NypProje.UI
{
    partial class musteri_panel
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
            this.dgMusteriler = new System.Windows.Forms.DataGridView();

            this.txtMusteriAd = new System.Windows.Forms.TextBox();
            this.txtMusteriSoyad = new System.Windows.Forms.TextBox();
            this.txtMusteriTc = new System.Windows.Forms.TextBox();
            this.txtMusteriTel = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnEkle = new System.Windows.Forms.Button();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnTemizle = new System.Windows.Forms.Button();

            btnEkle.Click += new EventHandler(this.btnEkle_Click);
            btnGuncelle.Click += new EventHandler(this.btnGuncelle_Click);
            btnSil.Click += new EventHandler(this.btnSil_Click);
            btnTemizle.Click += new EventHandler(this.btnTemizle_Click);
            dgMusteriler.CellClick += new DataGridViewCellEventHandler(this.dgMusteriler_CellClick);

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
            this.lblHeader.Text = "Müşteri İşlemleri";
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Top;

            // Form Panel
            this.formPanel.Location = new System.Drawing.Point(10, 80);
            this.formPanel.Size = new System.Drawing.Size(780, 120);
            this.formPanel.BackColor = System.Drawing.Color.White;
            this.formPanel.Padding = new System.Windows.Forms.Padding(10);

            // Labels and Textboxes
            this.ConfigureLabel(label1, "Ad:", 10, 13);
            this.ConfigureLabel(label2, "Soyad:", 10, 53);
            this.ConfigureLabel(label3, "TC Kimlik:", 220, 13);
            this.ConfigureLabel(label4, "Telefon:", 220, 53);

            this.ConfigureTextBox(txtMusteriAd, 70, 10);
            this.ConfigureTextBox(txtMusteriSoyad, 70, 50);
            this.ConfigureTextBox(txtMusteriTc, 300, 10);
            this.ConfigureTextBox(txtMusteriTel, 300, 50);

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
            this.dgMusteriler.Location = new System.Drawing.Point(10, 270);
            this.dgMusteriler.Size = new System.Drawing.Size(780, 320);
            this.dgMusteriler.BackgroundColor = System.Drawing.Color.White;
            this.dgMusteriler.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgMusteriler.AllowUserToAddRows = false;
            this.dgMusteriler.Dock = DockStyle.None;
            this.dgMusteriler.Size = new System.Drawing.Size(800, 600);
            this.dgMusteriler.AllowUserToDeleteRows = false;
            this.dgMusteriler.ScrollBars = ScrollBars.Vertical;
            this.dgMusteriler.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgMusteriler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ConfigureDataGridView();

            // Add controls
            this.headerPanel.Controls.Add(this.lblHeader);
            this.formPanel.Controls.AddRange(new System.Windows.Forms.Control[] {
                txtMusteriAd, txtMusteriSoyad, txtMusteriTc, txtMusteriTel,
                label1, label2, label3, label4
            });
            this.buttonsPanel.Controls.AddRange(new System.Windows.Forms.Control[] {
                btnEkle, btnGuncelle, btnSil, btnTemizle
            });
            this.mainPanel.Controls.AddRange(new System.Windows.Forms.Control[] {
                headerPanel, formPanel, buttonsPanel, dgMusteriler
            });
            this.Controls.Add(this.mainPanel);
        }

        private void ConfigureLabel(System.Windows.Forms.Label lbl, string text, int x, int y)
        {
            lbl.AutoSize = true;
            lbl.Location = new System.Drawing.Point(x, y);
            lbl.Text = text;
            lbl.Font = new System.Drawing.Font("Segoe UI", 9F);
            lbl.ForeColor = System.Drawing.ColorTranslator.FromHtml("#6C757D");
        }

        private void ConfigureTextBox(System.Windows.Forms.TextBox txt, int x, int y)
        {
            txt.Size = new System.Drawing.Size(130, 25);
            txt.Location = new System.Drawing.Point(x, y);
            txt.Font = new System.Drawing.Font("Segoe UI", 10F);
            txt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txt.BackColor = System.Drawing.ColorTranslator.FromHtml("#F8F9FA");
            txt.Padding = new System.Windows.Forms.Padding(5);

        }

        private void ConfigureButton(System.Windows.Forms.Button btn, string text, string color, int index)
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

            dgMusteriler.ColumnHeadersDefaultCellStyle = headerStyle;
            dgMusteriler.ColumnHeadersHeight = 40;
            dgMusteriler.EnableHeadersVisualStyles = false;
            dgMusteriler.RowTemplate.Height = 35;
            dgMusteriler.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#F8F9FA");
            dgMusteriler.DefaultCellStyle.SelectionBackColor = System.Drawing.ColorTranslator.FromHtml("#65CCD1");
            dgMusteriler.ReadOnly = true;
        }

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Panel formPanel;
        private System.Windows.Forms.Panel buttonsPanel;
        private System.Windows.Forms.DataGridView dgMusteriler;
        private System.Windows.Forms.TextBox txtMusteriAd, txtMusteriSoyad, txtMusteriTc, txtMusteriTel;
        private System.Windows.Forms.Label label1, label2, label3, label4;
        private System.Windows.Forms.Button btnEkle, btnGuncelle, btnSil, btnTemizle;
    }
}