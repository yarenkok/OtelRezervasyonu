using System;
using System.Drawing;
using System.Windows.Forms;

namespace NypProje.UI
{
    partial class fatura_panel
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
            this.buttonsPanel = new System.Windows.Forms.Panel();
            this.dgFaturalar = new System.Windows.Forms.DataGridView();
            this.btnGoruntule = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();

            btnGoruntule.Click += new EventHandler(this.btnGoruntule_Click);
            btnSil.Click += new EventHandler(this.btnSil_Click);
            dgFaturalar.CellContentClick += new DataGridViewCellEventHandler(this.dgFaturalar_CellContentClick);

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
            this.lblHeader.Text = "Fatura İşlemleri";
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Top;

            // Buttons Panel
            this.buttonsPanel.Location = new System.Drawing.Point(10, 80);
            this.buttonsPanel.Size = new System.Drawing.Size(780, 50);
            this.buttonsPanel.BackColor = System.Drawing.Color.Transparent;

            // Buttons
            this.ConfigureButton(btnGoruntule, "Görüntüle", "#65CCD1", 0);
            this.ConfigureButton(btnSil, "Sil", "#FF8674", 1);

            // DataGridView
            this.dgFaturalar.Location = new System.Drawing.Point(10, 140);
            this.dgFaturalar.Size = new System.Drawing.Size(780, 400);
            this.dgFaturalar.BackgroundColor = System.Drawing.Color.White;
            this.dgFaturalar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgFaturalar.AllowUserToAddRows = false;
            this.dgFaturalar.Dock = DockStyle.None;
            this.dgFaturalar.AllowUserToDeleteRows = false;
            this.dgFaturalar.ScrollBars = ScrollBars.Vertical;
            this.dgFaturalar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgFaturalar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ConfigureDataGridView();

            // Add controls
            this.headerPanel.Controls.Add(this.lblHeader);
            this.buttonsPanel.Controls.AddRange(new System.Windows.Forms.Control[] {
                btnGoruntule, btnSil
            });
            this.mainPanel.Controls.AddRange(new System.Windows.Forms.Control[] {
                headerPanel, buttonsPanel, dgFaturalar
            });
            this.Controls.Add(this.mainPanel);
        }

        private void ConfigureButton(System.Windows.Forms.Button btn, string text, string color, int index)
        {
            btn.Size = new System.Drawing.Size(120, 40);
            btn.Location = new System.Drawing.Point(10 + (index * 140), 5);
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

            dgFaturalar.ColumnHeadersDefaultCellStyle = headerStyle;
            dgFaturalar.ColumnHeadersHeight = 40;
            dgFaturalar.EnableHeadersVisualStyles = false;
            dgFaturalar.RowTemplate.Height = 35;
            dgFaturalar.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#F8F9FA");
            dgFaturalar.DefaultCellStyle.SelectionBackColor = System.Drawing.ColorTranslator.FromHtml("#65CCD1");
            dgFaturalar.ReadOnly = true;
        }

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Panel buttonsPanel;
        private System.Windows.Forms.DataGridView dgFaturalar;
        private System.Windows.Forms.Button btnGoruntule;
        private System.Windows.Forms.Button btnSil;
    }
}