using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using NypProje.ENTITY;

namespace NypProje.DAL
{
    public class ekstra_dal
    {
        public void ekstra_ekle(ekstra_entity ekstra)
        {
            using (MySqlConnection connection = dbBaglanti.Baglan())
            {
                string query = "INSERT INTO ekstra_tablo (ekstra_urun, ekstra_fiyat) VALUES (@urun, @fiyat)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@urun", ekstra.ekstra_urun);
                command.Parameters.AddWithValue("@fiyat", ekstra.ekstra_fiyat);

                command.ExecuteNonQuery();
            }
        }

        public void ekstra_guncelle(ekstra_entity ekstra)
        {
            using (MySqlConnection connection = dbBaglanti.Baglan())
            {
                string query = "UPDATE ekstra_tablo SET ekstra_urun = @urun, ekstra_fiyat = @fiyat WHERE ekstra_id = @id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@urun", ekstra.ekstra_urun);
                command.Parameters.AddWithValue("@fiyat", ekstra.ekstra_fiyat);
                command.Parameters.AddWithValue("@id", ekstra.ekstra_id);

                command.ExecuteNonQuery();
            }
        }

        public void ekstra_sil(int ekstra_id)
        {
            using (MySqlConnection connection = dbBaglanti.Baglan())
            {
                string query = "DELETE FROM ekstra_tablo WHERE ekstra_id = @id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", ekstra_id);

                command.ExecuteNonQuery();
            }
        }

        public List<ekstra_entity> ekstra_listele()
        {
            List<ekstra_entity> ekstralar = new List<ekstra_entity>();
            using (MySqlConnection connection = dbBaglanti.Baglan())
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
            return ekstralar;
        }
    }
}