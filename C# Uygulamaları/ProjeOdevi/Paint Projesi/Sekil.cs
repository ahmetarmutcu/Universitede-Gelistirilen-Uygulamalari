using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ProjeOdevi
{
    class Sekil
    {
        private int x;
        public int X
        {
            get { return x; }
            set
            {
                if (value > 0 && value < 603)
                    this.x = value;
            }
        }
        private int y;
        public int Y
        {
            get { return y; }
            set
            {
                if (value > 0 && value < 565)
                    this.y = value;
            }
        }
        public String sekiladi;
        public Color Sekilrengi { get; set; }
        public Color Sekil_Cizgi_Rengi { get; set; }
        public virtual bool Mouse_Seklin_Icindemi(int bx, int by, int seklin_x, int seklin_y) { return false; }
        public virtual void Ciz(Graphics cizimAraci) { }
        public virtual void BitisKordinatlari(int bx, int by) { }
        
    }
}
   
