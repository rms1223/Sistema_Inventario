using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioFod.Entidades
{
    class Acciones
    {
        public int Codigo { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }

        public Acciones(int codigo, string descripcion, DateTime fecha)
        {
            Codigo = codigo;
            Descripcion = descripcion;
            Fecha = fecha;
        }
    }
}
