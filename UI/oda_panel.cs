using NypProje.DOMAIN;
using NypProje.ENTITY;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NypProje.UI
{
    public partial class oda_panel : UserControl
    {
        private readonly oda_service _odaService = new oda_service();
        private int? seciliOdaId = null;
        public oda_panel()
        {
            InitializeComponent();
            LoadData();
            dgOdalar.CellClick += dgOdalar_CellContentClick;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (!GirisKontrol())
            {
                return;
            }

            var oda = new oda_entity
            {
                oda_tip = txtOdaTip.Text.Trim(),
                oda_numara = txtOdaNumara.Text.Trim(),
                oda_durum = "Boş",
                oda_fiyat = Convert.ToDecimal(txtOdaFiyat.Text.Trim())
            };

            try
            {
                _odaService.oda_ekle(oda);
                MessageBox.Show("Oda başarıyla eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (seciliOdaId == null)
            {
                MessageBox.Show("Lütfen bir oda seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!GirisKontrol())
            {
                return;
            }

            var oda = new oda_entity
            {
                oda_id = seciliOdaId.Value,
                oda_tip = txtOdaTip.Text.Trim(),
                oda_numara = txtOdaNumara.Text.Trim(),
                oda_durum = "Boş",
                oda_fiyat = Convert.ToDecimal(txtOdaFiyat.Text.Trim())
            };

            try
            {
                _odaService.oda_guncelle(oda);
                MessageBox.Show("Oda bilgileri güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (seciliOdaId == null)
            {
                MessageBox.Show("Lütfen bir oda seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _odaService.oda_sil(seciliOdaId.Value);
                MessageBox.Show("Oda başarıyla silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            txtOdaTip.Clear();
            txtOdaNumara.Clear();
            txtOdaFiyat.Clear();

            seciliOdaId = null;
        }

        private void dgOdalar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgOdalar.Rows[e.RowIndex].Cells["oda_id"].Value != null)
            {
                var selectedRow = dgOdalar.Rows[e.RowIndex];

                seciliOdaId = Convert.ToInt32(selectedRow.Cells["oda_id"].Value);

                txtOdaTip.Text = selectedRow.Cells["oda_tip"].Value?.ToString() ?? string.Empty;
                txtOdaNumara.Text = selectedRow.Cells["oda_numara"].Value?.ToString() ?? string.Empty;
                txtOdaFiyat.Text = selectedRow.Cells["oda_fiyat"].Value?.ToString() ?? string.Empty;
            }
        }

        private void LoadData()
        {
            try
            {
                var odalar = _odaService.odalari_listele();
                dgOdalar.DataSource = odalar;
                if (dgOdalar.Columns.Count > 0)
                {
                    dgOdalar.Columns["oda_id"].HeaderText = "Oda ID";
                    dgOdalar.Columns["oda_tip"].HeaderText = "Oda Tipi";
                    dgOdalar.Columns["oda_numara"].HeaderText = "Oda Numarası";
                    dgOdalar.Columns["oda_durum"].HeaderText = "Oda Durumu";
                    dgOdalar.Columns["oda_fiyat"].HeaderText = "Oda Fiyatı";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri yüklenirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool GirisKontrol()
        {
            if (string.IsNullOrEmpty(txtOdaTip.Text.Trim()))
            {
                MessageBox.Show("Lütfen oda tipini giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(txtOdaNumara.Text.Trim()))
            {
                MessageBox.Show("Lütfen oda numarasını giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(txtOdaFiyat.Text.Trim()) || !decimal.TryParse(txtOdaFiyat.Text.Trim(), out _))
            {
                MessageBox.Show("Lütfen geçerli bir oda fiyatı giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}
