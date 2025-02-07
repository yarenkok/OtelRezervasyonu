using System;

namespace NypProje.ENTITY
{
    public class rezervasyon_entity
    {
        public int rezervasyon_id { get; set; }
        public int musteri_id { get; set; }
        public int oda_id { get; set; }
        public DateTime giris { get; set; }
        public DateTime cikis { get; set; }
        public int ekstra_id { get; set; }
        public decimal son_tutar { get; set; }
    }
}