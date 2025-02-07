using System;
using System.Windows.Forms;

namespace NypProje.UI
{
    partial class anamenu_sayfa
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblWelcome;

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
            // Form components
            this.components = new System.ComponentModel.Container();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.sidePanel = new System.Windows.Forms.Panel();
            this.panelUserControl = new System.Windows.Forms.Panel();
            this.headerPanel = new System.Windows.Forms.Panel();

            // Controls
            this.btnMusteri = new System.Windows.Forms.Button();
            this.btnOda = new System.Windows.Forms.Button();
            this.btnEkstra = new System.Windows.Forms.Button();
            this.btnRezervasyon = new System.Windows.Forms.Button();
            this.btnFatura = new System.Windows.Forms.Button();
            this.btnYonetici = new System.Windows.Forms.Button();
            this.lblCikis = new System.Windows.Forms.Label();
            this.lblTarihSaat = new System.Windows.Forms.Label();

            // Timer for updating date/time
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer1.Interval = 1000; // Update every second
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);

            // Event handlers
            this.btnMusteri.Click += new System.EventHandler(this.btnMusteri_Click);
            this.btnMusteri.Click += new System.EventHandler(this.HideWelcomeText);

            this.btnOda.Click += new System.EventHandler(this.btnOda_Click);
            this.btnOda.Click += new System.EventHandler(this.HideWelcomeText);

            this.btnEkstra.Click += new System.EventHandler(this.btnEkstra_Click);
            this.btnEkstra.Click += new System.EventHandler(this.HideWelcomeText);

            this.btnRezervasyon.Click += new System.EventHandler(this.btnRezervasyon_Click);
            this.btnRezervasyon.Click += new System.EventHandler(this.HideWelcomeText);

            this.btnFatura.Click += new System.EventHandler(this.btnFatura_Click);
            this.btnFatura.Click += new System.EventHandler(this.HideWelcomeText);

            this.btnYonetici.Click += new System.EventHandler(this.btnYonetici_Click);
            this.btnYonetici.Click += new System.EventHandler(this.HideWelcomeText);

            // Keep other original event handlers
            this.lblCikis.Click += new System.EventHandler(this.lblCikis_Click);
            this.lblCikis.MouseEnter += new System.EventHandler(this.lblCikis_Enter);
            this.lblCikis.MouseLeave += new System.EventHandler(this.lblCikis_Leave);



            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblWelcome.Text = "OTEL REZERVASYON SİSTEMİ";
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.ForeColor = System.Drawing.ColorTranslator.FromHtml("#65CCD1");
            this.lblWelcome.AutoSize = false;
            this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblWelcome.Dock = DockStyle.Fill;

            // Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.BackColor = System.Drawing.ColorTranslator.FromHtml("#F2F7FA");
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            // Main Panel
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.BackColor = System.Drawing.Color.Transparent;
            this.mainPanel.Padding = new System.Windows.Forms.Padding(10);

            // Side Panel
            this.sidePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidePanel.Width = 200;
            this.sidePanel.BackColor = System.Drawing.ColorTranslator.FromHtml("#65CCD1");
            this.sidePanel.Padding = new System.Windows.Forms.Padding(10);

            // Header Panel
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Height = 40;
            this.headerPanel.BackColor = System.Drawing.ColorTranslator.FromHtml("#65CCD1");
            this.headerPanel.Controls.Add(this.lblCikis);

            // User Control Panel
            this.panelUserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelUserControl.BackColor = System.Drawing.Color.White;
            this.panelUserControl.Controls.Add(this.lblWelcome);

            // Configure Navigation Buttons
            this.ConfigureNavigationButton(btnMusteri, "Müşteri İşlemleri", 0);
            this.ConfigureNavigationButton(btnOda, "Oda İşlemleri", 1);
            this.ConfigureNavigationButton(btnEkstra, "Kampanya İşlemleri", 2);
            this.ConfigureNavigationButton(btnRezervasyon, "Rezervasyon İşlemleri", 3);
            this.ConfigureNavigationButton(btnFatura, "Fatura İşlemleri", 4);
            this.ConfigureNavigationButton(btnYonetici, "Yönetici İşlemleri", 5);

            // Configure Exit Label and DateTime Label
            this.ConfigureExitLabel();
            this.ConfigureDateTimeLabel();

            // Start the timer
            this.timer1.Start();

            // Add controls to panels
            this.sidePanel.Controls.AddRange(new System.Windows.Forms.Control[] {
                btnMusteri, btnOda, btnEkstra,
                btnRezervasyon, btnFatura, btnYonetici
            });

            this.headerPanel.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblCikis,
                this.lblTarihSaat
            });

            this.mainPanel.Controls.AddRange(new System.Windows.Forms.Control[] {
                panelUserControl, sidePanel, headerPanel
            });

            this.Controls.Add(this.mainPanel);
        }

        private void ConfigureNavigationButton(Button btn, string text, int index)
        {
            btn.Size = new System.Drawing.Size(180, 45);
            btn.Location = new System.Drawing.Point(10, 50 + (index * 55));
            btn.Text = text;
            btn.BackColor = System.Drawing.Color.Transparent;
            btn.ForeColor = System.Drawing.Color.White;
            btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btn.Cursor = System.Windows.Forms.Cursors.Hand;
            btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btn.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
        }

        private void ConfigureExitLabel()
        {
            this.lblCikis.AutoSize = true;
            this.lblCikis.Text = "X";
            this.lblCikis.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblCikis.ForeColor = System.Drawing.ColorTranslator.FromHtml("#9afaff");
            this.lblCikis.Location = new System.Drawing.Point(1350, 10);
            this.lblCikis.Cursor = System.Windows.Forms.Cursors.Hand;
        }

        private void HideWelcomeText(object sender, EventArgs e)
        {
            if (lblWelcome != null && !lblWelcome.IsDisposed)
            {
                lblWelcome.Visible = false;
            }
        }


        private void ConfigureDateTimeLabel()
        {
            this.lblTarihSaat.AutoSize = true;
            this.lblTarihSaat.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTarihSaat.ForeColor = System.Drawing.Color.White;
            this.lblTarihSaat.Location = new System.Drawing.Point(970, 11);
            this.lblTarihSaat.Text = DateTime.Now.ToString("dd.MM.yy HH:mm:ss");
        }

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel sidePanel;
        private System.Windows.Forms.Panel panelUserControl;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Button btnMusteri;
        private System.Windows.Forms.Button btnOda;
        private System.Windows.Forms.Button btnEkstra;
        private System.Windows.Forms.Button btnRezervasyon;
        private System.Windows.Forms.Button btnFatura;
        private System.Windows.Forms.Button btnYonetici;
        private System.Windows.Forms.Label lblCikis;
        private System.Windows.Forms.Label lblTarihSaat;
        private System.Windows.Forms.Timer timer1;
    }
}