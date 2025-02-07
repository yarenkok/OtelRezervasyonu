using System;
using System.Drawing;
using System.Windows.Forms;

namespace NypProje.UI
{
    partial class fatura_goruntuleme_sayfa
    {
        private System.ComponentModel.IContainer components = null;

        // Declare all the controls at class level
        private Panel mainPanel;
        private Panel headerPanel;
        private Label lblHeader;
        private Panel faturaNoPanel;
        private Panel musteriBilgileriPanel;
        private Panel konaklamaBilgileriPanel;
        private Panel tutarPanel;
        private Label lblMusteriBilgileri;
        private Label lblKonaklamaBilgileri;
        private Label lblToplamTutar;
        public Label lblMusteriAdValue;  // Changed to public for access
        public Label lblMusteriSoyadValue;  // Changed to public for access
        public Label lblOdaNumaraValue;  // Changed to public for access
        public Label lblGirisTarihiValue;  // Changed to public for access
        public Label lblCikisTarihiValue;  // Changed to public for access
        public Label lblToplamTutarValue;  // Changed to public for access
        private Button btnKapat;
        private Label lblMusteriAd;
        private Label lblMusteriSoyad;
        private Label lblOdaNumara;
        private Label lblGirisTarihi;
        private Label lblCikisTarihi;

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

            // Initialize all controls
            mainPanel = new Panel();
            headerPanel = new Panel();
            lblHeader = new Label();
            faturaNoPanel = new Panel();
            musteriBilgileriPanel = new Panel();
            konaklamaBilgileriPanel = new Panel();
            tutarPanel = new Panel();
            lblMusteriBilgileri = new Label();
            lblKonaklamaBilgileri = new Label();
            lblToplamTutar = new Label();

            // Initialize the value labels that will be used in FaturaBilgileriniYukle
            lblMusteriAdValue = new Label();
            lblMusteriSoyadValue = new Label();
            lblOdaNumaraValue = new Label();
            lblGirisTarihiValue = new Label();
            lblCikisTarihiValue = new Label();
            lblToplamTutarValue = new Label();

            // Initialize label descriptions
            lblMusteriAd = new Label();
            lblMusteriSoyad = new Label();
            lblOdaNumara = new Label();
            lblGirisTarihi = new Label();
            lblCikisTarihi = new Label();

            btnKapat = new Button();

            // Form settings
            this.Size = new System.Drawing.Size(600, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = System.Drawing.ColorTranslator.FromHtml("#F2F7FA");

            // Main Panel
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Padding = new Padding(20);
            mainPanel.BackColor = Color.White;

            // Header Panel
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Height = 60;
            headerPanel.BackColor = System.Drawing.ColorTranslator.FromHtml("#65CCD1");

            // Header Label
            lblHeader.Text = "Fatura Detayları";
            lblHeader.ForeColor = Color.White;
            lblHeader.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            lblHeader.AutoSize = true;
            lblHeader.Location = new Point(20, 15);

            // Configure Panels
            musteriBilgileriPanel.Location = new Point(20, 130);
            musteriBilgileriPanel.Size = new Size(560, 150);
            musteriBilgileriPanel.BackColor = Color.White;

            konaklamaBilgileriPanel.Location = new Point(20, 330);
            konaklamaBilgileriPanel.Size = new Size(560, 150);
            konaklamaBilgileriPanel.BackColor = Color.White;

            tutarPanel.Location = new Point(20, 500);
            tutarPanel.Size = new Size(560, 100);
            tutarPanel.BackColor = System.Drawing.ColorTranslator.FromHtml("#E9ECEF");

            // Configure Labels
            SetupLabel(lblMusteriAd, "Müşteri Adı:", new Point(20, 20), musteriBilgileriPanel);
            SetupLabel(lblMusteriSoyad, "Müşteri Soyadı:", new Point(20, 60), musteriBilgileriPanel);
            SetupLabel(lblOdaNumara, "Oda Numarası:", new Point(300, 20), musteriBilgileriPanel);

            // Configure Value Labels
            SetupValueLabel(lblMusteriAdValue, new Point(120, 20), musteriBilgileriPanel);
            SetupValueLabel(lblMusteriSoyadValue, new Point(120, 60), musteriBilgileriPanel);
            SetupValueLabel(lblOdaNumaraValue, new Point(400, 20), musteriBilgileriPanel);

            // Konaklama Labels
            SetupLabel(lblGirisTarihi, "Giriş Tarihi:", new Point(20, 20), konaklamaBilgileriPanel);
            SetupLabel(lblCikisTarihi, "Çıkış Tarihi:", new Point(20, 60), konaklamaBilgileriPanel);

            SetupValueLabel(lblGirisTarihiValue, new Point(120, 20), konaklamaBilgileriPanel);
            SetupValueLabel(lblCikisTarihiValue, new Point(120, 60), konaklamaBilgileriPanel);

            // Total Amount
            lblToplamTutar.Text = "Toplam Tutar:";
            lblToplamTutar.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblToplamTutar.Location = new Point(20, 30);
            tutarPanel.Controls.Add(lblToplamTutar);

            lblToplamTutarValue.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblToplamTutarValue.ForeColor = System.Drawing.ColorTranslator.FromHtml("#65CCD1");
            lblToplamTutarValue.Location = new Point(400, 30);
            tutarPanel.Controls.Add(lblToplamTutarValue);

            // Close Button
            btnKapat.Size = new Size(100, 40);
            btnKapat.Location = new Point(480, 620);
            btnKapat.Text = "Kapat";
            btnKapat.BackColor = System.Drawing.ColorTranslator.FromHtml("#6C757D");
            btnKapat.ForeColor = Color.White;
            btnKapat.FlatStyle = FlatStyle.Flat;
            btnKapat.FlatAppearance.BorderSize = 0;
            btnKapat.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnKapat.Cursor = Cursors.Hand;
            btnKapat.Click += new EventHandler(this.btnKapat_Click);

            // Add controls to form
            headerPanel.Controls.Add(lblHeader);
            mainPanel.Controls.AddRange(new Control[] {
                headerPanel,
                musteriBilgileriPanel,
                konaklamaBilgileriPanel,
                tutarPanel,
                btnKapat
            });
            this.Controls.Add(mainPanel);
        }

        private void SetupLabel(Label label, string text, Point location, Control parent)
        {
            label.Text = text;
            label.AutoSize = true;
            label.Location = location;
            label.Font = new Font("Segoe UI", 9F);
            label.ForeColor = System.Drawing.ColorTranslator.FromHtml("#6C757D");
            parent.Controls.Add(label);
        }

        private void SetupValueLabel(Label label, Point location, Control parent)
        {
            label.AutoSize = true;
            label.Location = location;
            label.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label.ForeColor = System.Drawing.ColorTranslator.FromHtml("#212529");
            parent.Controls.Add(label);
        }
    }
}