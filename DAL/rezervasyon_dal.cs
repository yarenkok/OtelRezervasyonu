using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using NypProje.ENTITY;

namespace NypProje.DAL
{
    public class rezervasyon_dal
    {
        // Gün Sayısı Hesaplama Methodu
        private int gun_sayisi_hesapla(DateTime giris, DateTime cikis)
        {
            TimeSpan fark = cikis - giris;
            return fark.Days;
        }

        // Rezervasyon Ekleme
        public void rezervasyon_fatura_olustur(rezervasyon_entity rezervasyon)
        {
            using (MySqlConnection connection = dbBaglanti.Baglan())
            {
                try
                {
                    decimal oda_fiyat = 0;
                    decimal ekstra_fiyat = 0;

                    // Oda fiyatını al
                    string oda_query = "SELECT oda_fiyat FROM oda_tablo WHERE oda_id = @oda_id";
                    MySqlCommand oda_command = new MySqlCommand(oda_query, connection);
                    oda_command.Parameters.AddWithValue("@oda_id", rezervasyon.oda_id);
                    object oda_result = oda_command.ExecuteScalar();
                    if (oda_result != null)
                    {
                        oda_fiyat = Convert.ToDecimal(oda_result);
                    }

                    // Ekstra fiyatını al
                    string ekstra_query = "SELECT ekstra_fiyat FROM ekstra_tablo WHERE ekstra_id = @ekstra_id";
                    MySqlCommand ekstra_command = new MySqlCommand(ekstra_query, connection);
                    ekstra_command.Parameters.AddWithValue("@ekstra_id", rezervasyon.ekstra_id);
                    object ekstra_result = ekstra_command.ExecuteScalar();
                    if (ekstra_result != null)
                    {
                        ekstra_fiyat = Convert.ToDecimal(ekstra_result);
                    }

                    // Gün sayısını hesapla ve son tutarı bul
                    int gun_sayisi = gun_sayisi_hesapla(rezervasyon.giris, rezervasyon.cikis);
                    decimal son_tutar = (oda_fiyat + ekstra_fiyat) * gun_sayisi;

                    // Rezervasyon ekle
                    string rezervasyon_query = @"
                        INSERT INTO rezervasyon_tablo 
                        (musteri_id, oda_id, giris, cikis, son_tutar, ekstra_id) 
                        VALUES (@musteri_id, @oda_id, @giris, @cikis, @son_tutar, @ekstra_id)";
                    MySqlCommand rezervasyon_command = new MySqlCommand(rezervasyon_query, connection);
                    rezervasyon_command.Parameters.AddWithValue("@musteri_id", rezervasyon.musteri_id);
                    rezervasyon_command.Parameters.AddWithValue("@oda_id", rezervasyon.oda_id);
                    rezervasyon_command.Parameters.AddWithValue("@giris", rezervasyon.giris);
                    rezervasyon_command.Parameters.AddWithValue("@cikis", rezervasyon.cikis);
                    rezervasyon_command.Parameters.AddWithValue("@son_tutar", son_tutar);
                    rezervasyon_command.Parameters.AddWithValue("@ekstra_id", rezervasyon.ekstra_id);
                    rezervasyon_command.ExecuteNonQuery();

                    // Son eklenen rezervasyon ID'sini al
                    int rezervasyon_id = Convert.ToInt32(rezervasyon_command.LastInsertedId);

                    // Müşteri bilgilerini al
                    string musteri_query = "SELECT musteri_ad, musteri_soyad FROM musteri_tablo WHERE musteri_id = @musteri_id";
                    MySqlCommand musteri_command = new MySqlCommand(musteri_query, connection);
                    musteri_command.Parameters.AddWithValue("@musteri_id", rezervasyon.musteri_id);
                    MySqlDataReader musteri_reader = musteri_command.ExecuteReader();
                    string musteri_ad = "";
                    string musteri_soyad = "";
                    if (musteri_reader.Read())
                    {
                        musteri_ad = musteri_reader["musteri_ad"].ToString();
                        musteri_soyad = musteri_reader["musteri_soyad"].ToString();
                    }
                    musteri_reader.Close();

                    // Oda numarasını al
                    string oda_numara_query = "SELECT oda_numara FROM oda_tablo WHERE oda_id = @oda_id";
                    MySqlCommand oda_numara_command = new MySqlCommand(oda_numara_query, connection);
                    oda_numara_command.Parameters.AddWithValue("@oda_id", rezervasyon.oda_id);
                    string oda_numara = oda_numara_command.ExecuteScalar()?.ToString();

                    // Fatura oluştur
                    string fatura_query = @"
                        INSERT INTO fatura_tablo 
                        (musteri_ad, musteri_soyad, oda_numara, giris, cikis, son_tutar) 
                        VALUES (@ad, @soyad, @numara, @giris, @cikis, @tutar)";
                    MySqlCommand fatura_command = new MySqlCommand(fatura_query, connection);
                    fatura_command.Parameters.AddWithValue("@ad", musteri_ad);
                    fatura_command.Parameters.AddWithValue("@soyad", musteri_soyad);
                    fatura_command.Parameters.AddWithValue("@numara", oda_numara);
                    fatura_command.Parameters.AddWithValue("@giris", rezervasyon.giris);
                    fatura_command.Parameters.AddWithValue("@cikis", rezervasyon.cikis);
                    fatura_command.Parameters.AddWithValue("@tutar", son_tutar);
                    fatura_command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Rezervasyon ekleme sırasında hata oluştu: " + ex.Message);
                }
            }
        }

        // Rezervasyon Güncelleme
        public void rezervasyon_guncelle(rezervasyon_entity rezervasyon)
        {
            using (MySqlConnection connection = dbBaglanti.Baglan())
            {
                try
                {
                    string query = @"
                UPDATE rezervasyon_tablo 
                SET musteri_id = @musteri_id, 
                    oda_id = @oda_id, 
                    giris = @giris, 
                    cikis = @cikis, 
                    son_tutar = @son_tutar, 
                    ekstra_id = @ekstra_id 
                WHERE rezervasyon_id = @id";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@musteri_id", rezervasyon.musteri_id);
                    command.Parameters.AddWithValue("@oda_id", rezervasyon.oda_id);
                    command.Parameters.AddWithValue("@giris", rezervasyon.giris);
                    command.Parameters.AddWithValue("@cikis", rezervasyon.cikis);
                    command.Parameters.AddWithValue("@son_tutar", rezervasyon.son_tutar);
                    command.Parameters.AddWithValue("@ekstra_id", rezervasyon.ekstra_id); // Ekstra ID'sini ekle
                    command.Parameters.AddWithValue("@id", rezervasyon.rezervasyon_id);
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Rezervasyon güncelleme sırasında hata oluştu: " + ex.Message);
                }
            }
        }

        // Rezervasyon Silme
        public void rezervasyon_sil(int rezervasyon_id)
        {
            using (MySqlConnection connection = dbBaglanti.Baglan())
            {
                try
                {
                    string query = "DELETE FROM rezervasyon_tablo WHERE rezervasyon_id = @id";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id", rezervasyon_id);
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Rezervasyon silme sırasında hata oluştu: " + ex.Message);
                }
            }
        }

        // Rezervasyon Listeleme
        public List<rezervasyon_entity> rezervasyonlari_listele()
        {
            List<rezervasyon_entity> rezervasyonlar = new List<rezervasyon_entity>();
            using (MySqlConnection connection = dbBaglanti.Baglan())
            {
                try
                {
                    string query = "SELECT * FROM rezervasyon_tablo";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        rezervasyonlar.Add(new rezervasyon_entity
                        {
                            rezervasyon_id = Convert.ToInt32(reader["rezervasyon_id"]),
                            musteri_id = Convert.ToInt32(reader["musteri_id"]),
                            oda_id = Convert.ToInt32(reader["oda_id"]),
                            giris = Convert.ToDateTime(reader["giris"]),
                            cikis = Convert.ToDateTime(reader["cikis"]),
                            ekstra_id = Convert.ToInt32(reader["ekstra_id"]),
                            son_tutar = Convert.ToDecimal(reader["son_tutar"])
                        });
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Rezervasyon listeleme sırasında hata oluştu: " + ex.Message);
                }
            }
            return rezervasyonlar;
        }

        // Oda Müsaitlik Kontrolü
        public bool oda_musait_mi(int oda_id, DateTime giris, DateTime cikis, int? rezervasyon_id = null)
        {
            using (MySqlConnection connection = dbBaglanti.Baglan())
            {
                try
                {
                    string query = @"
                        SELECT COUNT(*) 
                        FROM rezervasyon_tablo 
                        WHERE oda_id = @oda_id 
                          AND (@rezervasyon_id IS NULL OR rezervasyon_id != @rezervasyon_id)
                          AND (
                            (@giris BETWEEN giris AND cikis) OR 
                            (@cikis BETWEEN giris AND cikis) OR 
                            (giris >= @giris AND cikis <= @cikis)
                          )";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@oda_id", oda_id);
                    command.Parameters.AddWithValue("@giris", giris);
                    command.Parameters.AddWithValue("@cikis", cikis);
                    command.Parameters.AddWithValue("@rezervasyon_id", rezervasyon_id ?? (object)DBNull.Value);
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count == 0; // Eğer count 0 ise oda müsait, değilse dolu
                }
                catch (Exception ex)
                {
                    throw new Exception("Oda müsaitlik kontrolü sırasında hata oluştu: " + ex.Message);
                }
            }
        }

        // Ekstraları Listele
        public List<ekstra_entity> EkstralariListele()
        {
            List<ekstra_entity> ekstralar = new List<ekstra_entity>();
            using (MySqlConnection connection = dbBaglanti.Baglan())
            {
                try
                {
                    string query = "SELECT * FROM ekstra_tablo";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        ekstralar.Add(new ekstra_entity
                        {
                            ekstra_id = Convert.ToInt32(reader["ekstra_id"]),
                            ekstra_urun = reader["ekstra_urun"].ToString(),
                            ekstra_fiyat = Convert.ToDecimal(reader["ekstra_fiyat"])
                        });
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Ekstra listeleme sırasında hata oluştu: " + ex.Message);
                }
            }
            return ekstralar;
        }

        // Odaları Listele
        public List<oda_entity> OdalariListele()
        {
            List<oda_entity> odalar = new List<oda_entity>();
            using (MySqlConnection connection = dbBaglanti.Baglan())
            {
                try
                {
                    string query = "SELECT * FROM oda_tablo";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        odalar.Add(new oda_entity
                        {
                            oda_id = Convert.ToInt32(reader["oda_id"]),
                            oda_numara = reader["oda_numara"].ToString(),
                            oda_tip = reader["oda_tip"].ToString(),
                            oda_durum = reader["oda_durum"].ToString(),
                            oda_fiyat = Convert.ToDecimal(reader["oda_fiyat"])
                        });
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Oda listeleme sırasında hata oluştu: " + ex.Message);
                }
            }
            return odalar;
        }

        // Müşterileri Listele
        public List<musteri_entity> MusterileriListele()
        {
            List<musteri_entity> musteriler = new List<musteri_entity>();
            using (MySqlConnection connection = dbBaglanti.Baglan())
            {
                try
                {
                    string query = "SELECT * FROM musteri_tablo";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        musteriler.Add(new musteri_entity
                        {
                            musteri_id = Convert.ToInt32(reader["musteri_id"]),
                            musteri_ad = reader["musteri_ad"].ToString(),
                            musteri_soyad = reader["musteri_soyad"].ToString(),
                            musteri_tel = reader["musteri_tel"].ToString()
                        });
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Müşteri listeleme sırasında hata oluştu: " + ex.Message);
                }
            }
            return musteriler;
        }
    }
}