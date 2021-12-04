using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjeOdevi
{
    class Kare : Sekil
    {
        private int width;
        public Kare(Rectangle rectangle, Color sekilrengi,String sekiladi)
        {
            base.X = rectangle.X;
            base.Y = rectangle.Y;
            base.Sekilrengi = sekilrengi;
        }
        public override void BitisKordinatlari(int baslingic_x, int baslangic_y)
        {
            width = baslingic_x - X;
           
        }
        public override bool Mouse_Seklin_Icindemi(int baslingic_x, int baslangic_y, int sekil_x, int sekil_y)
        {
            if (baslingic_x > sekil_x && baslingic_x < sekil_x + width && baslangic_y > sekil_y && baslangic_y < sekil_y + width)
                return true;
            else
                return false;
        }
        public override void Ciz(Graphics cizimAraci)
        {
            if (width > 150)
                width = 150;
            if (base.X > 0 && base.X < 603 && base.Y > 0 && base.Y < 565)
            {
                if ((width + X > 602) || width + Y > 565)
                {
                    width = width / 2;
                }
                Pen kalem = new Pen(Sekil_Cizgi_Rengi, 8);
                cizimAraci.DrawRectangle(kalem, base.X, base.Y, width, width);
                cizimAraci.FillRectangle(new SolidBrush(base.Sekilrengi), base.X, base.Y, width, width);
            }

        }
       
    }
}
