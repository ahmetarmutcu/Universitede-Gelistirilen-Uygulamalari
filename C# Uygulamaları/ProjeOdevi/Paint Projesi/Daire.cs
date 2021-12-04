using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjeOdevi
{
    class Daire:Sekil
    {
        private int cap;
        public Daire(Rectangle rectangle, Color sekilrengi,String sekiladi)
        {
                base.X = rectangle.X;
                base.Y = rectangle.Y;
                base.Sekilrengi = sekilrengi;
        }
        public override bool Mouse_Seklin_Icindemi(int baslangic_x, int baslangic_y, int sekil_x, int sekil_y)
        {
            if (baslangic_x > sekil_x && baslangic_x < sekil_x + cap && baslangic_y > sekil_y && baslangic_y < sekil_y + cap)
                return true;
            else
                return false;
        }
        public override void BitisKordinatlari(int bx, int by)
        {
           cap = bx - X;
        }
        public override void Ciz(Graphics cizimaraci)
        {
            if (cap > 150)
                cap = 150;
            if(base.X>0 && base.X<603 &&base.Y>0 &&base.Y<565)
            {
                if((cap+base.X>602)||cap+base.Y>565)
                {
                    cap = cap / 2;
                }
                Pen kalem = new Pen(Sekil_Cizgi_Rengi, 4);
                cizimaraci.DrawRectangle(kalem, base.X - 5, base.Y - 5, cap + 10, cap + 10);
                cizimaraci.FillEllipse(new SolidBrush(base.Sekilrengi), base.X, base.Y, cap, cap);
            }
        }

    }
}
