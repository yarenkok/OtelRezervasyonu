using System;
using System.Collections.Generic;
using NypProje.DAL;
using NypProje.ENTITY;

namespace NypProje.DOMAIN
{
    public class oda_service
    {
        private oda_dal _odaDal = new oda_dal();

        public void oda_ekle(oda_entity oda)
        {
            _odaDal.oda_ekle(oda);
        }

        public void oda_guncelle(oda_entity oda)
        {
            _odaDal.oda_guncelle(oda);
        }

        public void oda_sil(int oda_id)
        {
            _odaDal.oda_sil(oda_id);
        }

        public List<oda_entity> odalari_listele()
        {
            return _odaDal.odalari_listele();
        }
    }
}