using MySql.Data.MySqlClient;
using NypProje.DAL;
using NypProje.DOMAIN;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace NypProje.UI
{
    public partial class giris_sayfa : Form
    {
        private readonly yonetici_service _yoneticiService = new yonetici_service();
        public giris_sayfa()
        {
            InitializeComponent();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = txtKullaniciAdi.Text.Trim();
            string sifre = txtSifre.Text.Trim();

            // Boş alan kontrolü
            if (string.IsNullOrEmpty(kullaniciAdi) || string.IsNullOrEmpty(sifre))
            {
                MessageBox.Show("Lütfen kullanıcı adı ve şifreyi giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Veritabanı bağlantısı oluştur
                using (MySqlConnection connection = dbBaglanti.Baglan())
                {
                    // SQL sorgusu: Kullanıcı adı ve şifre kontrolü
                    string query = "SELECT COUNT(*) FROM yonetici_tablo WHERE kullanici_adi = @kullaniciAdi AND yonetici_sifre = @sifre";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@kullaniciAdi", kullaniciAdi);
                    command.Parameters.AddWithValue("@sifre", sifre);

                    // Sorguyu çalıştır ve sonucu al
                    int result = Convert.ToInt32(command.ExecuteScalar());

                    // Giriş kontrolü
                    if (result > 0)
                    {
                        MessageBox.Show("Giriş Başarılı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Ana menüye yönlendir
                        anamenu_sayfa anaMenu = new anamenu_sayfa();
                        anaMenu.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı adı veya şifre hatalı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Giriş sırasında bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnKayitOl_Click(object sender, EventArgs e)
        {
            kayit_sayfa kayitSayfasi = new kayit_sayfa();
            kayitSayfasi.Show();
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
