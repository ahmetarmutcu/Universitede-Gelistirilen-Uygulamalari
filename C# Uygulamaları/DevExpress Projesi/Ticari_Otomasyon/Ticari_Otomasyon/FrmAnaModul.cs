using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ticari_Otomasyon
{
    public partial class FrmAnaModul : Form
    {
        public FrmAnaModul()
        {
            InitializeComponent();
        }
        FrmUrunler fr;
        private void BTNUrunler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(fr==null)
            {
                fr = new FrmUrunler();
                fr.MdiParent = this;
                fr.Show();
            }
           
        }
        FrmMusteriler fr2;

        private void BTNMusteriler_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr2 == null)
            {
                fr2 = new FrmMusteriler();
                fr2.MdiParent = this;
                fr2.Show();
            }
        }
        FrmFirmalar fr3;
        private void BTNFirmalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(fr3==null)
            {
                fr3 = new FrmFirmalar();
                fr3.MdiParent = this;
                fr3.Show();
            }

        }
        FrmPersonel frm4;
        private void BTNPersoneller_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(frm4==null)
            {
                frm4 = new FrmPersonel();
                frm4.MdiParent = this;
                frm4.Show();
            }
        }
        FrmRehber frm5;
        private void BTNRehber_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm5 = new FrmRehber();
            frm5.MdiParent = this;
            frm5.Show();
        }

        FrmGiderler frm6;
        private void BTNGiderler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if(frm6==null)
            {
                frm6 = new FrmGiderler();
                frm6.MdiParent = this;
                frm6.Show();
            }
        }
        FrmBankalar frm7;
        private void BTNBankalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(frm7==null)
            {
                frm7 = new FrmBankalar();
                frm7.MdiParent = this;
                frm7.Show();
            }
        }
        FrmFaturalar frm8;
        private void BTNFaturalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(frm8==null)
            {
                frm8 = new FrmFaturalar();
                frm8.MdiParent = this;
                frm8.Show();
            }
        }
        FrmNotlar frm9;
        private void BTNNotlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(frm9==null)
            {
                frm9 = new FrmNotlar();
                frm9.MdiParent = this;
                frm9.Show();
            }

        }
        FrmHareketler frm10;
        private void btnHareketler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm10 == null)
            {
                frm10 = new FrmHareketler();
                frm10.MdiParent = this;
                frm10.Show();
            }
        }
        FrmRaporlar frm11;
        private void btnRaporlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(frm11==null)
            {
                frm11 = new FrmRaporlar();
                frm11.MdiParent = this;
                frm11.Show();
            }
        }
        FrmStoklar frm12;
        private void BTNStoklar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(frm12==null)
            {
                frm12 = new FrmStoklar();
                frm12.MdiParent = this;
                frm12.Show();
            }
        }
        FrmAyarlar frm13;
        private void BTNAyarlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm13 == null)
            {
                frm13 = new FrmAyarlar();
                frm13.Show();
            }
        }
        FrmKasa frm14;
        private void BTNKasa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm14 == null)
            {
                frm14 = new FrmKasa();
                frm14.ad = kullanici;
                frm14.MdiParent = this;
                frm14.Show();
            }
        }
        public string kullanici;
        private void FrmAnaModul_Load(object sender, EventArgs e)
        {
            if (frm15 == null)
            {
                frm15 = new FrmAnasayfa();
                frm15.MdiParent = this;
                frm15.Show();
            }
        }
        FrmAnasayfa frm15;
        private void BTNAnasayfa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm15 == null)
            {
                frm15 = new FrmAnasayfa();
                frm15.MdiParent = this;
                frm15.Show();
            }
        }
    }
}
