using System;
using System.Collections.Generic;
using NypProje.DAL;
using NypProje.ENTITY;

namespace NypProje.DOMAIN
{
    public class musteri_service
    {
        private musteri_dal _musteriDal = new musteri_dal();

        public void musteri_ekle(musteri_entity musteri)
        {
            _musteriDal.musteri_ekle(musteri);
        }

        public void musteri_guncelle(musteri_entity musteri)
        {
            _musteriDal.musteri_guncelle(musteri);
        }

        public void musteri_sil(int musteri_id)
        {
            _musteriDal.musteri_sil(musteri_id);
        }

        public List<musteri_entity> musterileri_listele()
        {
            return _musteriDal.musterileri_listele();
        }
    }
}