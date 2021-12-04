using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjeOdevi
{
    class Altigen:Sekil
    {
        private int nokta = 0;
        Point[] altigen = new Point[6];
        private Point p1 { get; set; }
        private Point p2 { get; set; }
        private Point p3 { get; set; }
        private Point p4 { get; set; }
        private Point p5 { get; set; }
        private Point p6 { get; set; }
        public Altigen(Rectangle rectangle, Color sekilrenk)
        {
            this.Sekilrengi = sekilrenk;
            this.X =rectangle.X;
            this.Y = rectangle.Y;
        }
        public override void BitisKordinatlari(int bx, int by)
        {
            nokta = Math.Abs(bx - X) + Math.Abs(by - Y);
            p1 = new Point(X - (nokta / 4), Y - (nokta / 3));
            p2 = new Point((X - ((nokta / 2))), Y);
            p3 = new Point(X - (nokta / 4), Y + (nokta / 3));
            p4 = new Point(X + (nokta / 4), (Y + (nokta / 3)));
            p5 = new Point((X + ((nokta / 2))), Y);
            p6 = new Point(X + (nokta / 4), Y - (nokta / 3));

            altigen[0] = p1;
            altigen[1] = p2;
            altigen[2] = p3;
            altigen[3] = p4;
            altigen[4] = p5;
            altigen[5] = p6;
        }
        public override bool Mouse_Seklin_Icindemi(int bx, int by, int sekil_x, int sekil_y)
        {
            if ((bx>sekil_x-(nokta/4)&&by>(sekil_y-(nokta/3))&&bx<sekil_x&&by<sekil_y)
                ||(bx>sekil_x-(nokta/4)&&bx<sekil_x&&by>sekil_y-(nokta/3)&&by==sekil_y)||
                (bx>sekil_x-(nokta/4)&&bx<sekil_x&&by>sekil_y&&by<sekil_y+(nokta/3))||
                (bx>sekil_x-(nokta/4)&&bx<sekil_x&&by>sekil_y&&by<sekil_y+(nokta/4))||
                (bx>sekil_x&&bx<sekil_x+(nokta/2)&&by==sekil_y)||
                (bx>sekil_x&&bx<sekil_x+(nokta/4)&&by>sekil_y-(nokta/4)&&by<sekil_y)||
                (bx>sekil_x&&bx<sekil_x+nokta/2&&by>sekil_y&&by<sekil_y+nokta/2))
                return true;
            else
                return false;
        }
        public override void Ciz(Graphics cizimAraci)
        {
                Pen kalem = new Pen(Sekil_Cizgi_Rengi, 10);
                cizimAraci.DrawPolygon(kalem, altigen);
                cizimAraci.FillPolygon(new SolidBrush(base.Sekilrengi), altigen);
        }
    }
}
