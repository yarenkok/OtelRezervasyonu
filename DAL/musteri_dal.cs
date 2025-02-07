using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using NypProje.ENTITY;

namespace NypProje.DAL
{
    public class musteri_dal
    {
        public void musteri_ekle(musteri_entity musteri)
        {
            using (MySqlConnection connection = dbBaglanti.Baglan())
            {
                try
                {
                    string query = "INSERT INTO musteri_tablo (musteri_ad, musteri_soyad, musteri_tc, musteri_tel) VALUES (@ad, @soyad, @tc, @tel)";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ad", musteri.musteri_ad);
                    command.Parameters.AddWithValue("@soyad", musteri.musteri_soyad);
                    command.Parameters.AddWithValue("@tc", musteri.musteri_tc);
                    command.Parameters.AddWithValue("@tel", musteri.musteri_tel);

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Müşteri ekleme sırasında hata oluştu: " + ex.Message);
                }
            }
        }

        public void musteri_guncelle(musteri_entity musteri)
        {
            using (MySqlConnection connection = dbBaglanti.Baglan())
            {
                try
                {
                    string query = "UPDATE musteri_tablo SET musteri_ad = @ad, musteri_soyad = @soyad, musteri_tc = @tc, musteri_tel = @tel WHERE musteri_id = @id";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ad", musteri.musteri_ad);
                    command.Parameters.AddWithValue("@soyad", musteri.musteri_soyad);
                    command.Parameters.AddWithValue("@tc", musteri.musteri_tc);
                    command.Parameters.AddWithValue("@tel", musteri.musteri_tel);
                    command.Parameters.AddWithValue("@id", musteri.musteri_id);

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Müşteri güncelleme sırasında hata oluştu: " + ex.Message);
                }
            }
        }

        public void musteri_sil(int musteri_id)
        {
            using (MySqlConnection connection = dbBaglanti.Baglan())
            {
                try
                {
                    string query = "DELETE FROM musteri_tablo WHERE musteri_id = @id";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id", musteri_id);

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Müşteri silme sırasında hata oluştu: " + ex.Message);
                }
            }
        }

        public List<musteri_entity> musterileri_listele()
        {
            List<musteri_entity> musteriler = new List<musteri_entity>();

            using (MySqlConnection connection = dbBaglanti.Baglan())
            {
                try
                {
                    string query = "SELECT * FROM musteri_tablo";
                    MySqlCommand command = new MySqlCommand(query, connection);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            musteriler.Add(new musteri_entity
                            {
                                musteri_id = Convert.ToInt32(reader["musteri_id"]),
                                musteri_ad = reader["musteri_ad"].ToString(),
                                musteri_soyad = reader["musteri_soyad"].ToString(),
                                musteri_tc = reader["musteri_tc"].ToString(),
                                musteri_tel = reader["musteri_tel"].ToString()
                            });
                        }
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