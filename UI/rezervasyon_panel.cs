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
    public partial class rezervasyon_panel : UserControl
    {
        private readonly rezervasyon_service _rezervasyonService = new rezervasyon_service();
        private int? seciliRezervasyonId = null;
        public rezervasyon_panel()
        {
            InitializeComponent();
            LoadData(); // Verileri yükle
            dgRezervasyonlar.CellContentClick += dgRezervasyonlar_CellContentClick; // CellClick event'ini bağla

            // ComboBox'ları doldur
            OdalariDoldur();
            MusterileriDoldur();
            EkstralariDoldur();

            // Bind the Resize event
            this.Resize += rezervasyon_panel_Resize;
        }

        public void rezervasyon_panel_Resize(object sender, EventArgs e)
        {
            cmbMusteri.Width = this.Width / 5;
            cmbOda.Width = this.Width / 5;
            cmbEkstra.Width = this.Width / 5;

            dtpGiris.Width = this.Width / 5;
            dtpCikis.Width = this.Width / 5;

            dgRezervasyonlar.Width = this.Width - 40;
            dgRezervasyonlar.Height = this.Height / 2;
        }

        private void OdalariDoldur()
        {
            try
            {
                var odalar = _rezervasyonService.OdalariListele();
                cmbOda.Items.Clear();

                foreach (var oda in odalar)
                {
                    cmbOda.Items.Add(new { oda.oda_id, OdaBilgi = $"Oda {oda.oda_numara} ({oda.oda_tip})" });
                }

                cmbOda.DisplayMember = "OdaBilgi";
                cmbOda.ValueMember = "oda_id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Oda bilgileri yüklenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Müşteri ComboBox'ını veritabanından doldur
        private void MusterileriDoldur()
        {
            try
            {
                var musteriler = _rezervasyonService.MusterileriListele();
                cmbMusteri.Items.Clear();

                foreach (var musteri in musteriler)
                {
                    cmbMusteri.Items.Add(new { musteri.musteri_id, AdSoyad = $"{musteri.musteri_ad} {musteri.musteri_soyad}" });
                }

                cmbMusteri.DisplayMember = "AdSoyad";
                cmbMusteri.ValueMember = "musteri_id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Müşteri bilgileri yüklenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Ekstra ComboBox'ını veritabanından doldur
        private void EkstralariDoldur()
        {
            try
            {
                var ekstralar = _rezervasyonService.EkstralariListele();
                cmbEkstra.Items.Clear();

                foreach (var ekstra in ekstralar)
                {
                    cmbEkstra.Items.Add(new { ekstra.ekstra_id, EkstraBilgi = $"{ekstra.ekstra_urun} ({ekstra.ekstra_fiyat:C})" });
                }

                cmbEkstra.DisplayMember = "EkstraBilgi";
                cmbEkstra.ValueMember = "ekstra_id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ekstra bilgileri yüklenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgRezervasyonlar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgRezervasyonlar.Rows[e.RowIndex].DataBoundItem == null)
                return;

            // Seçilen rezervasyonu al
            var selectedRezervasyon = (rezervasyon_entity)dgRezervasyonlar.Rows[e.RowIndex].DataBoundItem;
            if (selectedRezervasyon == null)
                return;

            // Seçili rezervasyon ID'sini ayarla
            seciliRezervasyonId = selectedRezervasyon.rezervasyon_id;

            // Müşteri ComboBox'ını ayarla
            cmbMusteri.SelectedItem = cmbMusteri.Items.Cast<dynamic>()
                .FirstOrDefault(x => x.musteri_id == selectedRezervasyon.musteri_id);

            // Oda ComboBox'ını ayarla
            cmbOda.SelectedItem = cmbOda.Items.Cast<dynamic>()
                .FirstOrDefault(x => x.oda_id == selectedRezervasyon.oda_id);

            // Ekstra ComboBox'ını ayarla
            cmbEkstra.SelectedItem = cmbEkstra.Items.Cast<dynamic>()
                .FirstOrDefault(x => x.ekstra_id == selectedRezervasyon.ekstra_id);

            // Giriş ve çıkış tarihlerini ayarla
            dtpGiris.Value = selectedRezervasyon.giris;
            dtpCikis.Value = selectedRezervasyon.cikis;


            // Debug: Ekstra bilgisi kontrolü
            if (cmbEkstra.SelectedItem == null)
            {
                MessageBox.Show($"Ekstra bilgisi bulunamadı! (ekstra_id: {selectedRezervasyon.ekstra_id})", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (!GirisKontrol()) return;

            int oda_id = Convert.ToInt32((cmbOda.SelectedItem as dynamic)?.oda_id);
            int musteri_id = Convert.ToInt32((cmbMusteri.SelectedItem as dynamic)?.musteri_id);
            int ekstra_id = Convert.ToInt32((cmbEkstra.SelectedItem as dynamic)?.ekstra_id);

            DateTime giris = dtpGiris.Value;
            DateTime cikis = dtpCikis.Value;

            // Oda müsaitliğini kontrol et
            if (!_rezervasyonService.OdaMusaitMi(oda_id, giris, cikis, seciliRezervasyonId))
            {
                MessageBox.Show("Seçilen tarihler arasında oda dolu!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var rezervasyon = new rezervasyon_entity
            {
                musteri_id = musteri_id,
                oda_id = oda_id,
                giris = giris,
                cikis = cikis,
                ekstra_id = ekstra_id,
                son_tutar = 0 // Hesaplama serviste yapılacak
            };

            try
            {
                _rezervasyonService.rezervasyon_fatura_olustur(rezervasyon);
                MessageBox.Show("Rezervasyon başarıyla eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                btnTemizle_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ekleme sırasında hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (seciliRezervasyonId == null)
            {
                MessageBox.Show("Lütfen bir rezervasyon seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!GirisKontrol()) return;

            int oda_id = Convert.ToInt32((cmbOda.SelectedItem as dynamic)?.oda_id);
            int musteri_id = Convert.ToInt32((cmbMusteri.SelectedItem as dynamic)?.musteri_id);
            int ekstra_id = Convert.ToInt32((cmbEkstra.SelectedItem as dynamic)?.ekstra_id); // Ekstra ID'sini al
            DateTime giris = dtpGiris.Value;
            DateTime cikis = dtpCikis.Value;

            // Oda müsaitliğini kontrol et
            if (!_rezervasyonService.OdaMusaitMi(oda_id, giris, cikis, seciliRezervasyonId))
            {
                MessageBox.Show("Seçilen tarihler arasında oda dolu!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var rezervasyon = new rezervasyon_entity
            {
                rezervasyon_id = seciliRezervasyonId.Value,
                musteri_id = musteri_id,
                oda_id = oda_id,
                giris = giris,
                cikis = cikis,
                ekstra_id = ekstra_id, // Ekstra ID'sini ata
                son_tutar = 0 // Hesaplama serviste yapılacak
            };

            try
            {
                _rezervasyonService.rezervasyon_guncelle(rezervasyon);
                MessageBox.Show("Rezervasyon başarıyla güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                btnTemizle_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Güncelleme sırasında hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadData()
        {
            try
            {
                var rezervasyonlar = _rezervasyonService.rezervasyonlari_listele();
                dgRezervasyonlar.DataSource = rezervasyonlar;

                // Sütun başlıklarını özelleştir
                dgRezervasyonlar.Columns["rezervasyon_id"].HeaderText = "Rezervasyon No";
                dgRezervasyonlar.Columns["musteri_id"].HeaderText = "Müşteri ID";
                dgRezervasyonlar.Columns["oda_id"].HeaderText = "Oda ID";
                dgRezervasyonlar.Columns["ekstra_id"].HeaderText = "Ekstra ID";
                dgRezervasyonlar.Columns["giris"].HeaderText = "Giriş Tarihi";
                dgRezervasyonlar.Columns["cikis"].HeaderText = "Çıkış Tarihi";
                dgRezervasyonlar.Columns["son_tutar"].HeaderText = "Toplam Tutar";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veri yüklenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool GirisKontrol()
        {
            if (cmbMusteri.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen bir müşteri seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbOda.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen bir oda seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbEkstra.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen bir ekstra seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (dtpGiris.Value >= dtpCikis.Value)
            {
                MessageBox.Show("Çıkış tarihi giriş tarihinden sonra olmalıdır!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (seciliRezervasyonId == null)
            {
                MessageBox.Show("Lütfen bir rezervasyon seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _rezervasyonService.rezervasyon_sil(seciliRezervasyonId.Value);
                MessageBox.Show("Rezervasyon başarıyla silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                btnTemizle_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Silme sırasında hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            cmbMusteri.SelectedIndex = -1;
            cmbOda.SelectedIndex = -1;
            cmbEkstra.SelectedIndex = -1;
            // Tarih seçicileri bugünün tarihine ayarla
            dtpGiris.Value = DateTime.Today;
            dtpCikis.Value = DateTime.Today.AddDays(1);
            // Seçili rezervasyon ID'sini sıfırla
            seciliRezervasyonId = null;
        }

    }
}
