using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using NypProje.ENTITY;

namespace NypProje.DAL
{
    public class yonetici_dal
    {
        // Yönetici Ekleme
        public void yonetici_ekle(yonetici_entity yonetici)
        {
            using (MySqlConnection connection = dbBaglanti.Baglan())
            {
                string query = "INSERT INTO yonetici_tablo (yonetici_ad, yonetici_soyad, yonetici_tel, kullanici_adi, yonetici_sifre) VALUES (@ad, @soyad, @tel, @kullanici, @sifre)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@ad", yonetici.yonetici_ad);
                command.Parameters.AddWithValue("@soyad", yonetici.yonetici_soyad);
                command.Parameters.AddWithValue("@tel", yonetici.yonetici_tel);
                command.Parameters.AddWithValue("@kullanici", yonetici.kullanici_adi);
                command.Parameters.AddWithValue("@sifre", yonetici.yonetici_sifre);

                // ExecuteNonQuery ile sorguyu çalıştır
                command.ExecuteNonQuery();
            }
        }

        // Yönetici Güncelleme
        public void yonetici_guncelle(yonetici_entity yonetici)
        {
            using (MySqlConnection connection = dbBaglanti.Baglan())
            {
                string query = "UPDATE yonetici_tablo SET yonetici_ad = @ad, yonetici_soyad = @soyad, yonetici_tel = @tel, kullanici_adi = @kullanici, yonetici_sifre = @sifre WHERE yonetici_id = @id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@ad", yonetici.yonetici_ad);
                command.Parameters.AddWithValue("@soyad", yonetici.yonetici_soyad);
                command.Parameters.AddWithValue("@tel", yonetici.yonetici_tel);
                command.Parameters.AddWithValue("@kullanici", yonetici.kullanici_adi);
                command.Parameters.AddWithValue("@sifre", yonetici.yonetici_sifre);
                command.Parameters.AddWithValue("@id", yonetici.yonetici_id);

                // ExecuteNonQuery ile sorguyu çalıştır
                command.ExecuteNonQuery();
            }
        }

        // Yönetici Silme
        public void yonetici_sil(int yonetici_id)
        {
            using (MySqlConnection connection = dbBaglanti.Baglan())
            {
                string query = "DELETE FROM yonetici_tablo WHERE yonetici_id = @id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", yonetici_id);

                // ExecuteNonQuery ile sorguyu çalıştır
                command.ExecuteNonQuery();
            }
        }

        // Yönetici Listeleme
        public List<yonetici_entity> yoneticileri_listele()
        {
            List<yonetici_entity> yoneticiler = new List<yonetici_entity>();

            using (MySqlConnection connection = dbBaglanti.Baglan())
            {
                string query = "SELECT * FROM yonetici_tablo";
                MySqlCommand command = new MySqlCommand(query, connection);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yoneticiler.Add(new yonetici_entity
                        {
                            yonetici_id = Convert.ToInt32(reader["yonetici_id"]),
                            yonetici_ad = reader["yonetici_ad"].ToString(),
                            yonetici_soyad = reader["yonetici_soyad"].ToString(),
                            yonetici_tel = reader["yonetici_tel"].ToString(),
                            kullanici_adi = reader["kullanici_adi"].ToString(),
                            yonetici_sifre = reader["yonetici_sifre"].ToString()
                        });
                    }
                }
            }

            return yoneticiler;
        }

    }
}