using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjeOdevi
{
    class Ucgen:Sekil
    {
        Point[] ucgen = new Point[3];
        private int delta_x = 0;
        private int delta_y = 0;
        public Point p1 { get; set; }
        public Point p2 { get; set; }
        public Point p3 { get; set; }
        public override void BitisKordinatlari(int bx, int by)
        {
            delta_x = Math.Abs(bx - X);
            delta_y = Math.Abs(by - Y);
            p1 = new Point(X, Y);
            p2 = new Point(bx, by);
            p3 = new Point(X - delta_x, Y + delta_y);
            ucgen[0] = p1;
            ucgen[1] = p2;
            ucgen[2] = p3;
           
        }
        public Ucgen(Rectangle rectangle, Color sekilrengi)
        {
            base.X = rectangle.X;
            base.Y = rectangle.Y;
            base.Sekilrengi = sekilrengi;
        }
        public override bool Mouse_Seklin_Icindemi(int bx, int by, int sekil_x, int sekil_y)
        {
            if ((bx < sekil_x && bx > sekil_x - delta_x && by > sekil_y && by < sekil_y +delta_y)||(bx>sekil_x&&bx<sekil_x+delta_x&&by>sekil_y&&by<sekil_y+delta_y))
                return true;
            else
                return false;
        }
        public override void Ciz(Graphics cizimaraci)
        {
            Pen kalem = new Pen(Sekil_Cizgi_Rengi, 10);
            cizimaraci.DrawPolygon(kalem,ucgen);
            cizimaraci.FillPolygon(new SolidBrush(base.Sekilrengi), ucgen);
        }
    }
}
