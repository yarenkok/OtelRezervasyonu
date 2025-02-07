using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using NypProje.ENTITY;

namespace NypProje.DAL
{
    public class fatura_dal
    {
        public List<fatura_entity> faturalari_listele()
        {
            List<fatura_entity> faturalar = new List<fatura_entity>();
            using (MySqlConnection connection = dbBaglanti.Baglan())
            {
                string query = "SELECT * FROM fatura_tablo";
                MySqlCommand command = new MySqlCommand(query, connection);

                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    faturalar.Add(new fatura_entity
                    {
                        fatura_id = Convert.ToInt32(reader["fatura_id"]),
                        musteri_ad = reader["musteri_ad"].ToString(),
                        musteri_soyad = reader["musteri_soyad"].ToString(),
                        oda_numara = reader["oda_numara"].ToString(),
                        giris = Convert.ToDateTime(reader["giris"]),
                        cikis = Convert.ToDateTime(reader["cikis"]),
                        son_tutar = Convert.ToDecimal(reader["son_tutar"])
                    });
                }
            }
            return faturalar;
        }

        public void fatura_sil(int fatura_id)
        {
            using (MySqlConnection connection = dbBaglanti.Baglan())
            {
                string query = "DELETE FROM fatura_tablo WHERE fatura_id = @id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", fatura_id);

                command.ExecuteNonQuery();
            }
        }
    }
}