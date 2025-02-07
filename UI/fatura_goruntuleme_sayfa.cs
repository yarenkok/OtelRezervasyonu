using NypProje.ENTITY;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NypProje.UI
{
    public partial class fatura_goruntuleme_sayfa : Form
    {
        public fatura_goruntuleme_sayfa(fatura_entity fatura)
        {
            InitializeComponent();
            FaturaBilgileriniYukle(fatura);
        }

        private void FaturaBilgileriniYukle(fatura_entity fatura)
        {
            lblMusteriAdValue.Text = fatura.musteri_ad;
            lblMusteriSoyadValue.Text = fatura.musteri_soyad;
            lblOdaNumaraValue.Text = fatura.oda_numara;
            lblGirisTarihiValue.Text = fatura.giris.ToShortDateString();
            lblCikisTarihiValue.Text = fatura.cikis.ToShortDateString();
            lblToplamTutarValue.Text = fatura.son_tutar.ToString("C");
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
