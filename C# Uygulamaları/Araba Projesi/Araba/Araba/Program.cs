using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Ahmet Armutcu
//G171210351
//1C
namespace Araba
{
    class ElektronikBeyin : IPedal, IDireksiyon, IFarKumandaKolu, ISinyalKumandaKolu
    {
        private bool kontakAnahtari = false;//Kontak anantarı başlangıcta false yani Kapalı ise
        public int HızGostergesi(int hızdurumu)//Pedal Interface içinde Hız Gostergesi metodu tanımladım değer olarak int döndürecek
        {
            return hızdurumu;//sadece hızı döndürecek
        }
        public int FreneBasildi(int hız)//Pedal Interface içinde Frene bas metodu tanımladım değer olarak int döndürecek
        {
            if (kontakAnahtari == true)//Arac calisiyorsa yani kontakanahtari açık ise
                hız = hız - 10;// hızı 10 azaltcak
            else
                hız = 0;// çalışmıyorsa hız sıfırdır
            return hız;

        }
        public int FreneBasilmadi(int hız)//Frene Basilmadı
        {
            if (kontakAnahtari == true)//Araba çalışırken Frene basılmadı ise hız sabit olucak
                hız += 0;
            else
                hız = 0;//Araç çalışmıyorsa hız 0 olucaktır.
            return hız;// geriye hız döndürecektir.
        }
        public int GazaBasildi(int hız, string motortipi)//Pedal Interface içinde Gaza bas metodu tanımladım değer olarak int döndürecek
        {
            if (kontakAnahtari == true)//Arac calisiyorsa yani kontak anahtari açık ise
            {
                if (motortipi == "Benzinli") //Motor tipi benzinli ise
                    hız = hız + 10;// hız 10 artır
                else if (motortipi == "Dizel")// Motor tipi Dizel ise
                    hız = hız + 8; // hızı 8 artır
            }
            else
                hız = 0;//Arac çalışmıyorsa hızı 0 olucaktır.
            return hız;
        }
        public int GazaBasilmadi(int hız)//Gaza Basılmadı
        {
            if (kontakAnahtari == true)//Kontak açık iken gaza basılmadı ise hız sabit olucaktır.
                hız += 0;
            else
                hız = 0;//Kontak kapalı iken hız 0 olur
            return hız;
        }
        public int SagaDonuk(int tekerlek)//IDreksiyon interface içinde Saga Donuk metodu
        {
            if (kontakAnahtari == true)
                tekerlek += 5;
            else
                tekerlek = 0;
            return tekerlek;
        }
        public int SolaDonuk(int tekerlek)//IDreksiyon interface içinde Sola Donuk metodu
        {
            if (kontakAnahtari == true)
                tekerlek += 5;
            else
                tekerlek = 0;
            return tekerlek;
        }
        public int Duz(int tekerlek)//IDreksiyon interface içinde Duz metodu
        {
            if (kontakAnahtari)
                return tekerlek;
            else
                tekerlek = 0;
            return tekerlek;
        }
        public String UzunFarAcik(bool uzunfar, bool kısafar)//IFarKumandaKolu interface de KumandaKolu UzunFarAcik metodu
        {
            uzunfar = true; 
            kısafar = false;
            return "uzunfar" + uzunfar;

        }
        public String KısaFarAcik(bool uzunfar, bool kısafar)//IFarKumandaKolu interface de KumandaKolu KısafarAcik metodu
        {
            kısafar = true; 
            uzunfar = false;
            return "kısafar" + kısafar;
        }
        public string FarKapali(bool uzunfar, bool kısafar)//IFarKumandaKolu interface de KumandaKolu FarKapali metodu
        {
            kısafar = false;
            uzunfar = false;    //Her iki lambada kapalidir.
            return "Farlar" + uzunfar;//
        }
        public void SolaSinyal_Acik(bool solsinyal,bool sagsinyal)//ISinyalKumandaKolunda interface içinde SolaSinyalAcik metodu
        {

            solsinyal = true;
            sagsinyal = false;
        }

        public void SagaSinyal_Acik(bool solsinyal, bool sagsinyal)
        {
            solsinyal = false;
            sagsinyal = true;
        }
        public void DortluSinyal_Acik(bool solsinyal, bool sagsinyal)
        {
            solsinyal = true;
            sagsinyal = true;
        }
        public void SİnyalKumandaKoluKapali(bool solsinyal, bool sagsinyal)
        {
            solsinyal = false;
            sagsinyal = false;
        }

       
    }
    interface IPedal
    {
        int GazaBasildi(int hız, String motortipi);
        int GazaBasilmadi(int hız);
        int FreneBasildi(int hız);
        int FreneBasilmadi(int hız);
        int HızGostergesi(int hızdurumu);
    }
    class Motor : ElektronikBeyin
    {
        private int hız;
        private String motortipi;
        public String MotorTipi//Property tanımladım. 
        {
            get { return motortipi; }
            set
            {
                if (value == "Benzinli")
                    motortipi = "Benzinli";
                if (value == "Dizel")
                    motortipi = "Dizel";
                motortipi = "Seçilmedi";
            }
        }
        public int Hız//Hız en fazla 220 olabilir 
        {
            get { return hız; }
            set
            {
                if (value > 220)
                    hız = 220;
                else if (value < 0)
                    hız = 0;// Hız 0 dan küçük olamaz
            }
        }
        public void Gaz_PedalinaBasılma_KontrolEdildi()//Beyinde Gaz Pedalı Kontrol edildiyse 
        {
            GazaBasildi(Hız, MotorTipi);//Hız ve Motortipi property giriyoruz
            Console.WriteLine(HızGostergesi(GazaBasildi(Hız, MotorTipi)));//Hız göstergesinde hızı gösteriyoruz
        }
        public void Gaz_PedalinaBasılmadi_KontrolEdildi()
        {
            GazaBasilmadi(GazaBasildi(Hız, MotorTipi));//Araç çalışıyor ve Araba hareket halindeyken Gaza Basılmazsa araç hızı sabit olucaktır.
            Console.WriteLine(HızGostergesi(GazaBasilmadi(Hız)));
        }
        public void Fren_PedaliBasildi_KontrolEdildi()//Beyinde Fren pedalı kontrol edildiyse 
        {
            FreneBasildi(Hız);//Frene bas metodu çağırılıyor ve hız propertiyi giriyoruz
            Console.WriteLine(HızGostergesi(FreneBasildi(hız)));//Hızı gösteriyoruz;
        }
        public void Fren_PedaliBasilmadi_KontrolEdildi()
        {
            FreneBasilmadi(FreneBasildi(Hız));
            Console.WriteLine(HızGostergesi(FreneBasilmadi(hız)));
        }

    }
    interface IDireksiyon
    {
        int SagaDonuk(int tekerlek);
        int SolaDonuk(int tekerlek);
        int Duz(int tekerlek);

    }
    class Tekerlek : ElektronikBeyin
    {
        private String direksiyonYonu;
        private int tekerlekacisi;
        public String DireksiyonYonu
        {
            get { return direksiyonYonu; }
            set
            {
                switch (value)
                {
                    case "SagaDondur": direksiyonYonu = "SagaDondur"; break;
                    case "SolaDondur": direksiyonYonu = "SolaDondur"; break;
                    case "Duz": direksiyonYonu = "Duz"; break;
                }
            }
        }
        public int TekerlekAci
        {
            get { return tekerlekacisi; }
            set
            {
                if (value > 45)
                    tekerlekacisi = 45;
                else if (value > 0 && value < 45)
                    tekerlekacisi = value;
            }
        }
        public void Direksiyon()
        {
            if (DireksiyonYonu == "SagaDondur")
                SagaDonuk(tekerlekacisi);
            else if (DireksiyonYonu == "SolaDondur")
                SolaDonuk(tekerlekacisi);
            else if (DireksiyonYonu == "Duz")
                Duz(tekerlekacisi);
        }

    }
    interface IFarKumandaKolu
    {
        String UzunFarAcik(bool uzunfar, bool kısafar);
        String KısaFarAcik(bool uzunfar, bool kısafar);
        String FarKapali(bool uzunfar, bool kısafar);

    }
    class Far : ElektronikBeyin
    {
        private bool kısafar;
        private bool uzunfar;

        public void KısaFarlarAcik()//Far Kumanda kolu açık ise 
        {
           KısaFarAcik(uzunfar, kısafar);//Elektronik beyinde Kumanda Kolu KısaFarlarAcik ise KısaFarlarAcik metodunu çağırıyor
        }
        public void UzunFarlarAcik()
        {
            UzunFarAcik(uzunfar, kısafar);//Elektronik beyinde Kumanda Kolu UzunFarlar Acik ise KısaFarlarAcik metodunu çağırıyor
        }
        public void FarKapali()
        {
            FarKapali(uzunfar, kısafar);
        }
    }
    interface ISinyalKumandaKolu
    {
        void SolaSinyal_Acik(bool solsinyal,bool sagsinyal);
        void SagaSinyal_Acik(bool solsinyal, bool sagsinyal);
        void DortluSinyal_Acik(bool solsinyal, bool sagsinyal);
        void SİnyalKumandaKoluKapali(bool solsinyal, bool sagsinyal);

    }
    class SinyalLambalari : ElektronikBeyin
    {
        private bool solsinyallamba;
        private bool sagsinyallamba;
        private bool dortlusinyallamba;
        private String kumanda_kolu;
        public void SinyaKumandaKolu()
        {
            switch (kumanda_kolu)
            {
                case "SolaSinyalVer": SolaSinyal_Acik(solsinyallamba, sagsinyallamba); break;//SolaSinyal verildiğse kumanda kolundan sol lamba yanacak
                case "SagaSinyalVer": SagaSinyal_Acik(solsinyallamba, sagsinyallamba); break;//SağaSinyal verildiğse kumanda kolundan sağ lamba yanacak.
                case "DortluleriAc": DortluSinyal_Acik(solsinyallamba, sagsinyallamba); break;//Dortlu Sinyal açık ise kumanda kolundan dortlu lamba yanacak
                default:
                    SİnyalKumandaKoluKapali(solsinyallamba, sagsinyallamba);
                    break;
            }
        }
         
    }
   class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
