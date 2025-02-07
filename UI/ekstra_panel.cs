using NypProje.DOMAIN;
using System;
using System.Windows.Forms;
using NypProje.ENTITY;

namespace NypProje.UI
{
    public partial class ekstra_panel : UserControl
    {
        private readonly ekstra_service _ekstraService = new ekstra_service();
        private int? seciliEkstraId = null;
        public ekstra_panel()
        {
            InitializeComponent();
            LoadData();
            dgEkstralar.CellClick += dgEkstralar_CellContentClick;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (!GirisKontrol())
            {
                return;
            }

            var ekstra = new ekstra_entity
            {
                ekstra_urun = txtEkstraUrun.Text.Trim(),
                ekstra_fiyat = Convert.ToDecimal(txtEkstraFiyat.Text.Trim())
            };

            try
            {
                _ekstraService.ekstra_ekle(ekstra);
                MessageBox.Show("Ekstra başarıyla eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                btnTemizle_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ekleme sırasında hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (seciliEkstraId == null)
            {
                MessageBox.Show("Lütfen bir ekstra seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!GirisKontrol())
            {
                return;
            }

            var ekstra = new ekstra_entity
            {
                ekstra_id = seciliEkstraId.Value,
                ekstra_urun = txtEkstraUrun.Text.Trim(),
                ekstra_fiyat = Convert.ToDecimal(txtEkstraFiyat.Text.Trim())
            };

            try
            {
                _ekstraService.ekstra_guncelle(ekstra);
                MessageBox.Show("Ekstra bilgileri güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                btnTemizle_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Güncelleme sırasında hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (seciliEkstraId == null)
            {
                MessageBox.Show("Lütfen bir ekstra seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _ekstraService.ekstra_sil(seciliEkstraId.Value);
                MessageBox.Show("Ekstra başarıyla silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                btnTemizle_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Silme sırasında hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtEkstraUrun.Clear();
            txtEkstraFiyat.Clear();

            seciliEkstraId = null;
        }

        private void dgEkstralar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgEkstralar.Rows[e.RowIndex].Cells["ekstra_id"].Value != null)
            {
                var selectedRow = dgEkstralar.Rows[e.RowIndex];

                seciliEkstraId = Convert.ToInt32(selectedRow.Cells["ekstra_id"].Value);

                txtEkstraUrun.Text = selectedRow.Cells["ekstra_urun"].Value?.ToString() ?? string.Empty;
                txtEkstraFiyat.Text = selectedRow.Cells["ekstra_fiyat"].Value?.ToString() ?? string.Empty;
            }
        }

        private void LoadData()
        {
            try
            {
                var ekstralar = _ekstraService.ekstra_listele();
                dgEkstralar.DataSource = ekstralar;
                if (dgEkstralar.Columns.Count > 0)
                {
                    dgEkstralar.Columns["ekstra_id"].HeaderText = "Kampanya ID";
                    dgEkstralar.Columns["ekstra_urun"].HeaderText = "Kampanya Adı";
                    dgEkstralar.Columns["ekstra_fiyat"].HeaderText = "Fiyat";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri yüklenirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool GirisKontrol()
        {
            if (string.IsNullOrEmpty(txtEkstraUrun.Text.Trim()))
            {
                MessageBox.Show("Lütfen ekstra ürün adını giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(txtEkstraFiyat.Text.Trim()) || !decimal.TryParse(txtEkstraFiyat.Text.Trim(), out _))
            {
                MessageBox.Show("Lütfen geçerli bir fiyat giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}
