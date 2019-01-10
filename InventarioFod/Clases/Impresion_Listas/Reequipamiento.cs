using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioFod.Clases
{
    class  Reequipamiento
    {
        public static int get_paquetes(int cant_estu)
        {
            double total;//=contador/ 3.0;
            if ((cant_estu % 3) == 0)
            {
                total = cant_estu / 3;
            }
            else
            {
                double subtotal = cant_estu / 3.0;

                decimal total2 = Math.Ceiling(Convert.ToDecimal(subtotal));
                total = Convert.ToDouble(total2);
            }
            return Convert.ToInt32(total);
        }
    }
}
