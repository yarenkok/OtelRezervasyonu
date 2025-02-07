using System;
using System.Drawing;
using System.Windows.Forms;

namespace NypProje.UI
{
    public partial class anamenu_sayfa : Form
    {
        public anamenu_sayfa()
        {
            InitializeComponent();
            this.Resize += anamenu_sayfa_Resize;
        }

        private void anamenu_sayfa_Resize(object sender, EventArgs e)
        {
            if (panelUserControl.Controls.Count > 0 && panelUserControl.Controls[0] is rezervasyon_panel rezPanel)
            {
                rezPanel.rezervasyon_panel_Resize(sender, e);
            }

        }

        private void ClearPanel()
        {
            panelUserControl.Controls.Clear();
        }
        private void btnMusteri_Click(object sender, EventArgs e)
        {
            ClearPanel();
            musteri_panel musteriPanel = new musteri_panel();
            musteriPanel.Dock = DockStyle.Fill;
            musteriPanel.AutoSize = true;
            musteriPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panelUserControl.Controls.Add(musteriPanel);
        }

        private void btnOda_Click(object sender, EventArgs e)
        {
            ClearPanel();
            oda_panel odaPanel = new oda_panel();
            odaPanel.Dock = DockStyle.Fill;
            odaPanel.AutoSize = true;
            odaPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panelUserControl.Controls.Add(odaPanel);
        }

        private void btnEkstra_Click(object sender, EventArgs e)
        {
            ClearPanel();
            ekstra_panel ekstraPanel = new ekstra_panel();
            ekstraPanel.Dock = DockStyle.Fill;
            ekstraPanel.AutoSize = true;
            ekstraPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panelUserControl.Controls.Add(ekstraPanel);
        }

        private void btnRezervasyon_Click(object sender, EventArgs e)
        {
            ClearPanel();
            rezervasyon_panel rezervasyonPanel = new rezervasyon_panel();
            rezervasyonPanel.Dock = DockStyle.Fill;
            rezervasyonPanel.AutoSize = true;
            rezervasyonPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panelUserControl.Controls.Add(rezervasyonPanel);
        }

        private void btnFatura_Click(object sender, EventArgs e)
        {
            ClearPanel();
            fatura_panel faturaPanel = new fatura_panel();
            faturaPanel.Dock = DockStyle.Fill;
            faturaPanel.AutoSize = true;
            faturaPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panelUserControl.Controls.Add(faturaPanel);
        }

        private void btnYonetici_Click(object sender, EventArgs e)
        {
            ClearPanel();
            yonetici_panel yoneticiPanel = new yonetici_panel();
            yoneticiPanel.Dock = DockStyle.Fill;
            yoneticiPanel.AutoSize = true;
            yoneticiPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panelUserControl.Controls.Add(yoneticiPanel);
        }

        private void lblCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblCikis_Enter(object sender, EventArgs e)
        {
            lblCikis.ForeColor = ColorTranslator.FromHtml("#FB8677");
        }

        private void lblCikis_Leave(object sender, EventArgs e)
        {
            lblCikis.ForeColor = ColorTranslator.FromHtml("#9afaff");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTarihSaat.Text = DateTime.Now.ToString("dd.MM.yy HH:mm:ss");
        }
    }
}