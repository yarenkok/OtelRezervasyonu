using System;
using System.Collections.Generic;
using NypProje.DAL;
using NypProje.ENTITY;

namespace NypProje.DOMAIN
{
    public class rezervasyon_service
    {
        private readonly rezervasyon_dal _rezervasyonDal = new rezervasyon_dal();

        public void rezervasyon_fatura_olustur(rezervasyon_entity rezervasyon)
        {
            try
            {
                _rezervasyonDal.rezervasyon_fatura_olustur(rezervasyon);
            }
            catch (Exception ex)
            {
                throw new Exception("Rezervasyon ekleme sırasında hata oluştu: " + ex.Message);
            }
        }

        public void rezervasyon_guncelle(rezervasyon_entity rezervasyon)
        {
            try
            {
                _rezervasyonDal.rezervasyon_guncelle(rezervasyon);
            }
            catch (Exception ex)
            {
                throw new Exception("Rezervasyon güncelleme sırasında hata oluştu: " + ex.Message);
            }
        }

        public void rezervasyon_sil(int rezervasyon_id)
        {
            try
            {
                _rezervasyonDal.rezervasyon_sil(rezervasyon_id);
            }
            catch (Exception ex)
            {
                throw new Exception("Rezervasyon silme sırasında hata oluştu: " + ex.Message);
            }
        }

        public List<rezervasyon_entity> rezervasyonlari_listele()
        {
            try
            {
                return _rezervasyonDal.rezervasyonlari_listele();
            }
            catch (Exception ex)
            {
                throw new Exception("Rezervasyon listeleme sırasında hata oluştu: " + ex.Message);
            }
        }

        public bool OdaMusaitMi(int oda_id, DateTime giris, DateTime cikis, int? rezervasyon_id = null)
        {
            try
            {
                return _rezervasyonDal.oda_musait_mi(oda_id, giris, cikis, rezervasyon_id);
            }
            catch (Exception ex)
            {
                throw new Exception("Oda müsaitlik kontrolü sırasında hata oluştu: " + ex.Message);
            }
        }

        public List<ekstra_entity> EkstralariListele()
        {
            try
            {
                return _rezervasyonDal.EkstralariListele();
            }
            catch (Exception ex)
            {
                throw new Exception("Ekstra listeleme sırasında hata oluştu: " + ex.Message);
            }
        }

        public List<oda_entity> OdalariListele()
        {
            try
            {
                return _rezervasyonDal.OdalariListele();
            }
            catch (Exception ex)
            {
                throw new Exception("Oda listeleme sırasında hata oluştu: " + ex.Message);
            }
        }

        public List<musteri_entity> MusterileriListele()
        {
            try
            {
                return _rezervasyonDal.MusterileriListele();
            }
            catch (Exception ex)
            {
                throw new Exception("Müşteri listeleme sırasında hata oluştu: " + ex.Message);
            }
        }
    }
}