using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace İdealKiloKalitim
{
    class Daire
    {
        public Nokta N { get; set; }
        public int U { get; set; }
        private double pi = 3.14;
        public Double Alan
        {
            get { return pi * U * U; }
        }
       public Double Cevre
        {
            get
            {
                return  2 * U;
            }
        }
      }
}
