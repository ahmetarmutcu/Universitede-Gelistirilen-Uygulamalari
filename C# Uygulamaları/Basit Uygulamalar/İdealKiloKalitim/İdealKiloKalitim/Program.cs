using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace İdealKiloKalitim
{
    class Program
    {
        static void Main(string[] args)
        {
            // Kare kare = new Kare();
            // kare.baslangiNo = new Nokta(1,3);
            // kare.kenarUzunluk = 5;
            // Console.WriteLine("Alanı: " + kare.Alan);
            //// Console.WriteLine("Çevresi: " + kare.Cevre);
            Daire daire = new Daire();
            daire.N = new Nokta(5, 4);
            daire.U = 4;
            Console.WriteLine("Dairenin alanı: " + daire.Alan);
            Console.WriteLine("Dairenin Cevresi: " + daire.Cevre);
            Console.ReadLine();
        }
    }
}
