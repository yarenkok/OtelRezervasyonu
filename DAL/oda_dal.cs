using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using NypProje.ENTITY;

namespace NypProje.DAL
{
    public class oda_dal
    {
        public void oda_ekle(oda_entity oda)
        {
            using (MySqlConnection connection = dbBaglanti.Baglan())
            {
                string query = "INSERT INTO oda_tablo (oda_tip, oda_numara, oda_durum, oda_fiyat) VALUES (@tip, @numara, @durum, @fiyat)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@tip", oda.oda_tip);
                command.Parameters.AddWithValue("@numara", oda.oda_numara);
                command.Parameters.AddWithValue("@durum", oda.oda_durum);
                command.Parameters.AddWithValue("@fiyat", oda.oda_fiyat);

                command.ExecuteNonQuery();
            }
        }
        public void oda_guncelle(oda_entity oda)
        {
            using (MySqlConnection connection = dbBaglanti.Baglan())
            {
                string query = "UPDATE oda_tablo SET oda_tip = @tip, oda_numara = @numara, oda_durum = @durum, oda_fiyat = @fiyat WHERE oda_id = @id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@tip", oda.oda_tip);
                command.Parameters.AddWithValue("@numara", oda.oda_numara);
                command.Parameters.AddWithValue("@durum", oda.oda_durum);
                command.Parameters.AddWithValue("@fiyat", oda.oda_fiyat);
                command.Parameters.AddWithValue("@id", oda.oda_id);

                command.ExecuteNonQuery();
            }
        }
        public void oda_sil(int oda_id)
        {
            using (MySqlConnection connection = dbBaglanti.Baglan())
            {
                string query = "DELETE FROM oda_tablo WHERE oda_id = @id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", oda_id);

                command.ExecuteNonQuery();
            }
        }
        public List<oda_entity> odalari_listele()
        {
            List<oda_entity> odalar = new List<oda_entity>();
            using (MySqlConnection connection = dbBaglanti.Baglan())
            {
                string query = "SELECT * FROM oda_tablo";
                MySqlCommand command = new MySqlCommand(query, connection);

                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    odalar.Add(new oda_entity
                    {
                        oda_id = Convert.ToInt32(reader["oda_id"]),
                        oda_tip = reader["oda_tip"].ToString(),
                        oda_numara = reader["oda_numara"].ToString(),
                        oda_durum = reader["oda_durum"].ToString(),
                        oda_fiyat = Convert.ToDecimal(reader["oda_fiyat"])
                    });
                }
            }
            return odalar;
        }
    }
}