using System;
using System.Collections.Generic;
using NypProje.DAL;
using NypProje.ENTITY;

namespace NypProje.DOMAIN
{
    public class fatura_service
    {
        private fatura_dal _faturaDal = new fatura_dal();

        public List<fatura_entity> faturalari_listele()
        {
            return _faturaDal.faturalari_listele();
        }

        public void fatura_sil(int fatura_id)
        {
            _faturaDal.fatura_sil(fatura_id);
        }
    }
}