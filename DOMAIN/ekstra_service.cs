using System;
using System.Collections.Generic;
using NypProje.DAL;
using NypProje.ENTITY;

namespace NypProje.DOMAIN
{
    public class ekstra_service
    {
        private ekstra_dal _ekstraDal = new ekstra_dal();

        public void ekstra_ekle(ekstra_entity ekstra)
        {
            _ekstraDal.ekstra_ekle(ekstra);
        }

        public void ekstra_guncelle(ekstra_entity ekstra)
        {
            _ekstraDal.ekstra_guncelle(ekstra);
        }

        public void ekstra_sil(int ekstra_id)
        {
            _ekstraDal.ekstra_sil(ekstra_id);
        }

        public List<ekstra_entity> ekstra_listele()
        {
            return _ekstraDal.ekstra_listele();
        }
    }
}