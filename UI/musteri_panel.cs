using NypProje.DOMAIN;
using NypProje.ENTITY;
using System;
using System.Windows.Forms;

namespace NypProje.UI
{
    public partial class musteri_panel : UserControl
    {
        private readonly musteri_service _musteriService = new musteri_service();
        private int? seciliMusteriId = null;
        public musteri_panel()
        {
            InitializeComponent();
            LoadData();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtMusteriAd.Clear();
            txtMusteriSoyad.Clear();
            txtMusteriTc.Clear();
            txtMusteriTel.Clear();
            seciliMusteriId = null;
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (seciliMusteriId == null)
            {
                MessageBox.Show("Lütfen bir müşteri seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _musteriService.musteri_sil(seciliMusteriId.Value);
                MessageBox.Show("Müşteri başarıyla silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                btnTemizle_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Silme sırasında hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (seciliMusteriId == null)
            {
                MessageBox.Show("Lütfen bir müşteri seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!GirisKontrol())
            {
                return;
            }

            var musteri = new musteri_entity
            {
                musteri_id = seciliMusteriId.Value,
                musteri_ad = txtMusteriAd.Text.Trim(),
                musteri_soyad = txtMusteriSoyad.Text.Trim(),
                musteri_tc = txtMusteriTc.Text.Trim(),
                musteri_tel = txtMusteriTel.Text.Trim()
            };

            try
            {
                _musteriService.musteri_guncelle(musteri);
                MessageBox.Show("Müşteri bilgileri güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                btnTemizle_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Güncelleme sırasında hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (!GirisKontrol())
            {
                return;
            }

            var musteri = new musteri_entity
            {
                musteri_ad = txtMusteriAd.Text.Trim(),
                musteri_soyad = txtMusteriSoyad.Text.Trim(),
                musteri_tc = txtMusteriTc.Text.Trim(),
                musteri_tel = txtMusteriTel.Text.Trim()
            };

            try
            {
                _musteriService.musteri_ekle(musteri);
                MessageBox.Show("Müşteri başarıyla eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                btnTemizle_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ekleme sırasında hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgMusteriler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgMusteriler.Rows[e.RowIndex].Cells["musteri_id"].Value != null)
            {
                var selectedRow = dgMusteriler.Rows[e.RowIndex];

                seciliMusteriId = Convert.ToInt32(selectedRow.Cells["musteri_id"].Value);
                txtMusteriAd.Text = selectedRow.Cells["musteri_ad"].Value?.ToString() ?? "";
                txtMusteriSoyad.Text = selectedRow.Cells["musteri_soyad"].Value?.ToString() ?? "";
                txtMusteriTc.Text = selectedRow.Cells["musteri_tc"].Value?.ToString() ?? "";
                txtMusteriTel.Text = selectedRow.Cells["musteri_tel"].Value?.ToString() ?? "";
            }
        }

        private void LoadData()
        {
            try
            {
                var musteriler = _musteriService.musterileri_listele();
                dgMusteriler.DataSource = musteriler;
                if (dgMusteriler.Columns.Count > 0)
                {
                    dgMusteriler.Columns["musteri_id"].HeaderText = "Müşteri ID";
                    dgMusteriler.Columns["musteri_ad"].HeaderText = "Müşteri Adı";
                    dgMusteriler.Columns["musteri_soyad"].HeaderText = "Müşteri Soyadı";
                    dgMusteriler.Columns["musteri_tc"].HeaderText = "Müşteri TC";
                    dgMusteriler.Columns["musteri_tel"].HeaderText = "Müşteri Tel";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri yüklenirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool GirisKontrol()
        {
            if (string.IsNullOrEmpty(txtMusteriAd.Text.Trim()) || string.IsNullOrEmpty(txtMusteriSoyad.Text.Trim()))
            {
                MessageBox.Show("Lütfen ad ve soyad alanlarını doldurun!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(txtMusteriTc.Text.Trim()) || txtMusteriTc.Text.Length != 11 || !long.TryParse(txtMusteriTc.Text, out _))
            {
                MessageBox.Show("TC kimlik numarası 11 haneli ve sadece rakamlardan oluşmalıdır!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(txtMusteriTel.Text.Trim()) || txtMusteriTel.Text.Length != 10 || !long.TryParse(txtMusteriTel.Text, out _) || txtMusteriTel.Text.StartsWith("0"))
            {
                MessageBox.Show("Lütfen telefon numaranızı 0 koymadan ve 10 haneli olarak giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}
