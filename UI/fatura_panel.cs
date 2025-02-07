using System;
using System.Linq;
using System.Windows.Forms;
using NypProje.DOMAIN;
using NypProje.ENTITY;
using NypProje.UI;

namespace NypProje.UI
{
    public partial class fatura_panel : UserControl
    {
        private readonly fatura_service _faturaService = new fatura_service();
        private int? seciliFaturaId = null;
        public fatura_panel()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var faturalar = _faturaService.faturalari_listele();
                dgFaturalar.DataSource = faturalar;

                // Sütun başlıklarını özelleştir
                dgFaturalar.Columns["fatura_id"].HeaderText = "Fatura No";
                dgFaturalar.Columns["musteri_ad"].HeaderText = "Müşteri Adı";
                dgFaturalar.Columns["musteri_soyad"].HeaderText = "Müşteri Soyadı";
                dgFaturalar.Columns["oda_numara"].HeaderText = "Oda Numarası";
                dgFaturalar.Columns["giris"].HeaderText = "Giriş Tarihi";
                dgFaturalar.Columns["cikis"].HeaderText = "Çıkış Tarihi";
                dgFaturalar.Columns["son_tutar"].HeaderText = "Toplam Tutar";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veri yüklenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgFaturalar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedFatura = (fatura_entity)dgFaturalar.Rows[e.RowIndex].DataBoundItem;
                if (selectedFatura != null)
                {
                    seciliFaturaId = selectedFatura.fatura_id;
                }
            }
        }

        private void btnGoruntule_Click(object sender, EventArgs e)
        {
            if (seciliFaturaId == null)
            {
                MessageBox.Show("Lütfen bir fatura seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var selectedFatura = _faturaService.faturalari_listele().FirstOrDefault(f => f.fatura_id == seciliFaturaId);
                if (selectedFatura != null)
                {
                    var faturaGoruntulemeForm = new fatura_goruntuleme_sayfa(selectedFatura);
                    faturaGoruntulemeForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fatura görüntülenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (seciliFaturaId == null)
            {
                MessageBox.Show("Lütfen bir fatura seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _faturaService.fatura_sil(seciliFaturaId.Value);
                MessageBox.Show("Fatura başarıyla silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData(); // Verileri yeniden yükle
                seciliFaturaId = null; // Seçili fatura ID'sini sıfırla
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Silme sırasında hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
