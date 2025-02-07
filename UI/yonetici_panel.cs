using System;
using System.Linq;
using System.Windows.Forms;
using NypProje.DOMAIN;
using NypProje.ENTITY;

namespace NypProje.UI
{
    public partial class yonetici_panel : UserControl
    {
        private readonly yonetici_service _yoneticiService = new yonetici_service();
        private int? seciliYoneticiId = null;
        public yonetici_panel()
        {
            InitializeComponent();
            LoadData();
            dgYoneticiler.CellClick += dgYoneticiler_CellContentClick;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (!GirisKontrol())
            {
                return; // Eğer giriş geçersizse işlemi durdur
            }

            var yonetici = new yonetici_entity
            {
                yonetici_ad = txtYoneticiAd.Text.Trim(),
                yonetici_soyad = txtYoneticiSoyad.Text.Trim(),
                yonetici_tel = txtYoneticiTel.Text.Trim(),
                kullanici_adi = txtKullaniciAdi.Text.Trim(),
                yonetici_sifre = txtSifre.Text.Trim()
            };

            try
            {
                _yoneticiService.yonetici_ekle(yonetici);
                MessageBox.Show("Yönetici başarıyla eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData(); // Verileri yeniden yükle
                btnTemizle_Click(sender, e); // Alanları temizle
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ekleme sırasında hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (seciliYoneticiId == null)
            {
                MessageBox.Show("Lütfen bir yönetici seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!GirisKontrol())
            {
                return; // Eğer giriş geçersizse işlemi durdur
            }

            var yonetici = new yonetici_entity
            {
                yonetici_id = seciliYoneticiId.Value,
                yonetici_ad = txtYoneticiAd.Text.Trim(),
                yonetici_soyad = txtYoneticiSoyad.Text.Trim(),
                yonetici_tel = txtYoneticiTel.Text.Trim(),
                kullanici_adi = txtKullaniciAdi.Text.Trim(),
                yonetici_sifre = txtSifre.Text.Trim()
            };

            try
            {
                _yoneticiService.yonetici_guncelle(yonetici);
                MessageBox.Show("Yönetici bilgileri güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData(); // Verileri yeniden yükle
                btnTemizle_Click(sender, e); // Alanları temizle
            }
            catch (Exception ex)
            {
                MessageBox.Show("Güncelleme sırasında hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (seciliYoneticiId == null)
            {
                MessageBox.Show("Lütfen bir yönetici seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _yoneticiService.yonetici_sil(seciliYoneticiId.Value); // Saklanan yönetici ID'sini kullan
                MessageBox.Show("Yönetici başarıyla silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData(); // Verileri yeniden yükle
                btnTemizle_Click(sender, e); // Alanları temizle
            }
            catch (Exception ex)
            {
                MessageBox.Show("Silme sırasında hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtYoneticiAd.Clear();
            txtYoneticiSoyad.Clear();
            txtYoneticiTel.Clear();
            txtKullaniciAdi.Clear();
            txtSifre.Clear();

            seciliYoneticiId = null;
        }
        private void dgYoneticiler_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgYoneticiler.Rows[e.RowIndex].Cells["yonetici_id"].Value != null)
            {
                var selectedRow = dgYoneticiler.Rows[e.RowIndex];

                seciliYoneticiId = Convert.ToInt32(selectedRow.Cells["yonetici_id"].Value);

                txtYoneticiAd.Text = selectedRow.Cells["yonetici_ad"].Value?.ToString() ?? string.Empty;
                txtYoneticiSoyad.Text = selectedRow.Cells["yonetici_soyad"].Value?.ToString() ?? string.Empty;
                txtYoneticiTel.Text = selectedRow.Cells["yonetici_tel"].Value?.ToString() ?? string.Empty;
                txtKullaniciAdi.Text = selectedRow.Cells["kullanici_adi"].Value?.ToString() ?? string.Empty;
                txtSifre.Text = selectedRow.Cells["yonetici_sifre"].Value?.ToString() ?? string.Empty;
            }
        }
        private void LoadData()
        {
            try
            {
                var yoneticiler = _yoneticiService.yoneticileri_listele();
                dgYoneticiler.DataSource = yoneticiler;
                if (dgYoneticiler.Columns.Count > 0)
                {
                    dgYoneticiler.Columns["yonetici_id"].HeaderText = "Yönetici ID";
                    dgYoneticiler.Columns["yonetici_ad"].HeaderText = "Yönetici Adı";
                    dgYoneticiler.Columns["yonetici_soyad"].HeaderText = "Yönetici Soyadı";
                    dgYoneticiler.Columns["yonetici_tel"].HeaderText = "Yönetici Tel";
                    dgYoneticiler.Columns["kullanici_adi"].HeaderText = "Kullanıcı Adı";
                    dgYoneticiler.Columns["yonetici_sifre"].HeaderText = "Şifre";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri yüklenirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool GirisKontrol()
        {
            if (string.IsNullOrEmpty(txtYoneticiAd.Text.Trim()))
            {
                MessageBox.Show("Lütfen yönetici adını giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(txtYoneticiSoyad.Text.Trim()))
            {
                MessageBox.Show("Lütfen yönetici soyadını giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(txtYoneticiTel.Text.Trim()) || txtYoneticiTel.Text.Length != 10 || !long.TryParse(txtYoneticiTel.Text, out _) || txtYoneticiTel.Text.StartsWith("0"))
            {
                MessageBox.Show("Lütfen telefon numaranızı 0 koymadan ve 10 haneli olarak giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(txtKullaniciAdi.Text.Trim()))
            {
                MessageBox.Show("Lütfen kullanıcı adını giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(txtSifre.Text.Trim()))
            {
                MessageBox.Show("Lütfen şifreyi giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}
