using System;

namespace NypProje.ENTITY
{
    public class fatura_entity
    {
        public int fatura_id { get; set; }
        public string musteri_ad { get; set; }
        public string musteri_soyad { get; set; }
        public string oda_numara { get; set; }
        public DateTime giris { get; set; }
        public DateTime cikis { get; set; }
        public decimal son_tutar { get; set; }
    }
}