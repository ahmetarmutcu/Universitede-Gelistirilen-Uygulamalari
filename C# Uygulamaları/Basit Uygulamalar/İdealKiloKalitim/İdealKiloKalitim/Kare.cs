using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace İdealKiloKalitim
{
    class Kare
    {
        public Nokta N { get; set; }
        public Nokta U { get; set; }
        public double Alan
        {
            get
            {
                return U * U;
            }
        }
    }
}
