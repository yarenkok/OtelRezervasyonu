using System;
using System.Collections.Generic;
using NypProje.DAL;
using NypProje.ENTITY;

namespace NypProje.DOMAIN
{
    public class yonetici_service
    {
        private yonetici_dal _yoneticiDal = new yonetici_dal();
        private readonly rezervasyon_dal _rezervasyonDal = new rezervasyon_dal();

        public void yonetici_ekle(yonetici_entity yonetici)
        {
            _yoneticiDal.yonetici_ekle(yonetici);
        }

        public void yonetici_guncelle(yonetici_entity yonetici)
        {
            _yoneticiDal.yonetici_guncelle(yonetici);
        }

        public void yonetici_sil(int yonetici_id)
        {
            _yoneticiDal.yonetici_sil(yonetici_id);
        }

        public List<yonetici_entity> yoneticileri_listele()
        {
            return _yoneticiDal.yoneticileri_listele();
        }

        public void YeniYoneticiEkle(yonetici_entity yeniYonetici)
        {
            _yoneticiDal.yonetici_ekle(yeniYonetici);
        }

    }
}