using MySql.Data.MySqlClient;
using System;

namespace NypProje.DAL
{
    public class dbBaglanti
    {
        public static MySqlConnection Baglan()
        {
            MySqlConnection baglanti = new MySqlConnection("Server=172.21.54.253;Database=25_132330040;User=25_132330040;Password=!nif.ogr40KO;");

            if (baglanti.State != System.Data.ConnectionState.Open)
            {
                try
                {
                    baglanti.Open();
                }
                catch (Exception ex)
                {
                    throw new Exception("Veritabanı bağlantısı açılırken hata oluştu: " + ex.Message);
                }
            }

            return baglanti;
        }
    }
}