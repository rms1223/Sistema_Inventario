using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioFod.Clases.Entidades
{
    class Institucion
    {
        public string codigo { get; set; }
        public string nombre { get; set; }

        public Institucion() { }
        public Institucion(string codigo, string nombre)
        {
            this.codigo = codigo;
            this.nombre = nombre;
        }
    }
}
