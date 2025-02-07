using NypProje.DOMAIN;
using NypProje.ENTITY;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace NypProje.UI
{
    public partial class kayit_sayfa : Form
    {
        private readonly yonetici_service _yoneticiService = new yonetici_service();
        public kayit_sayfa()
        {
            InitializeComponent();
        }

        private void btnKayitOl_Click(object sender, EventArgs e)
        {
            string ad = txtAd.Text.Trim();
            string soyad = txtSoyad.Text.Trim();
            string tel = txtTel.Text.Trim();
            string kullaniciAdi = txtKullaniciAdi.Text.Trim();
            string sifre = txtSifre.Text.Trim();

            if (string.IsNullOrEmpty(ad) || string.IsNullOrEmpty(soyad) ||
                string.IsNullOrEmpty(tel) || string.IsNullOrEmpty(kullaniciAdi))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Yeni yönetici nesnesi oluştur
                yonetici_entity yeniYonetici = new yonetici_entity
                {
                    yonetici_ad = ad,
                    yonetici_soyad = soyad,
                    yonetici_tel = tel,
                    kullanici_adi = kullaniciAdi,
                    yonetici_sifre = sifre
                };

                // Yeni yöneticiyi kaydet
                _yoneticiService.YeniYoneticiEkle(yeniYonetici);

                MessageBox.Show("Kayıt Başarılı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Giriş sayfasına geri dön
                giris_sayfa girisSayfasi = new giris_sayfa();
                girisSayfasi.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kayıt sırasında bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGeriDon_Click(object sender, EventArgs e)
        {
            giris_sayfa girisSayfasi = new giris_sayfa();
            girisSayfasi.Show();
            this.Hide();
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
    }
}
