namespace NypProje.UI
{
    partial class giris_sayfa
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
            this.mainPanel = new System.Windows.Forms.Panel();
            this.loginPanel = new System.Windows.Forms.Panel();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.formPanel = new System.Windows.Forms.Panel();

            // Kontroller
            this.txtKullaniciAdi = new System.Windows.Forms.TextBox();
            this.txtSifre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCikis = new System.Windows.Forms.Label();
            this.btnGiris = new System.Windows.Forms.Button();
            this.btnKayitOl = new System.Windows.Forms.Button();

            // Event handlers
            this.btnGiris.Click += new System.EventHandler(this.btnGiris_Click);
            this.btnKayitOl.Click += new System.EventHandler(this.btnKayitOl_Click);

            this.lblCikis.Click += new System.EventHandler(this.lblCikis_Click);
            this.lblCikis.MouseEnter += new System.EventHandler(this.lblCikis_Enter);
            this.lblCikis.MouseLeave += new System.EventHandler(this.lblCikis_Leave);

            // Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 432);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.BackColor = System.Drawing.ColorTranslator.FromHtml("#F2F7FA");
            this.Font = new System.Drawing.Font("Segoe UI", 9F);

            // Main Panel
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.BackColor = System.Drawing.Color.Transparent;
            this.mainPanel.Padding = new System.Windows.Forms.Padding(20);

            // Login Panel
            this.loginPanel.Size = new System.Drawing.Size(360, 460);
            this.loginPanel.BackColor = System.Drawing.Color.White;
            this.loginPanel.Location = new System.Drawing.Point(20, 20);

            // Header Panel
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Height = 80;
            this.headerPanel.BackColor = System.Drawing.ColorTranslator.FromHtml("#65CCD1");
            this.headerPanel.Padding = new System.Windows.Forms.Padding(15);
            this.headerPanel.Controls.Add(this.lblCikis);


            // Header Label
            this.lblHeader.Text = "Otel Yönetim Sistemi";
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // Form Panel
            this.formPanel.Location = new System.Drawing.Point(30, 100);
            this.formPanel.Size = new System.Drawing.Size(300, 340);
            this.formPanel.BackColor = System.Drawing.Color.Transparent;

            // TextBoxes
            this.ConfigureTextBox(txtKullaniciAdi, "Kullanıcı Adı", 0);
            this.ConfigureTextBox(txtSifre, "Şifre", 80);
            txtSifre.PasswordChar = '•';

            // Labels
            this.ConfigureLabel(label1, "Kullanıcı Adı:", 0);
            this.ConfigureLabel(label2, "Şifre:", 80);

            // Buttons
            this.ConfigureButton(btnGiris, "Giriş Yap", "#65CCD1", 160);
            this.ConfigureButton(btnKayitOl, "Kayıt Ol", "#4A90E2", 220);
            this.ConfigureExitLabel();

            // Add controls
            this.headerPanel.Controls.Add(this.lblHeader);
            this.formPanel.Controls.AddRange(new System.Windows.Forms.Control[] {
                txtKullaniciAdi, txtSifre,
                label1, label2,
                btnGiris, btnKayitOl
            });
            this.loginPanel.Controls.AddRange(new System.Windows.Forms.Control[] {
                headerPanel, formPanel
            });
            this.mainPanel.Controls.Add(this.loginPanel);
            this.Controls.Add(this.mainPanel);
        }

        private void ConfigureTextBox(System.Windows.Forms.TextBox txt, string placeholder, int yOffset)
        {
            txt.Size = new System.Drawing.Size(300, 35);
            txt.Location = new System.Drawing.Point(0, yOffset + 25);
            txt.Font = new System.Drawing.Font("Segoe UI", 11F);
            txt.BackColor = System.Drawing.ColorTranslator.FromHtml("#F8F9FA");
            txt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txt.Padding = new System.Windows.Forms.Padding(5);
        }

        private void ConfigureLabel(System.Windows.Forms.Label lbl, string text, int yOffset)
        {
            lbl.AutoSize = true;
            lbl.Location = new System.Drawing.Point(0, yOffset);
            lbl.Text = text;
            lbl.Font = new System.Drawing.Font("Segoe UI", 10F);
            lbl.ForeColor = System.Drawing.ColorTranslator.FromHtml("#6C757D");
        }

        private void ConfigureButton(System.Windows.Forms.Button btn, string text, string color, int yOffset)
        {
            btn.Size = new System.Drawing.Size(300, 45);
            btn.Location = new System.Drawing.Point(0, yOffset);
            btn.Text = text;
            btn.BackColor = System.Drawing.ColorTranslator.FromHtml(color);
            btn.ForeColor = System.Drawing.Color.White;
            btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            btn.Cursor = System.Windows.Forms.Cursors.Hand;
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

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel loginPanel;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Panel formPanel;
        private System.Windows.Forms.TextBox txtKullaniciAdi;
        private System.Windows.Forms.TextBox txtSifre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCikis;
        private System.Windows.Forms.Button btnGiris;
        private System.Windows.Forms.Button btnKayitOl;
    }
}