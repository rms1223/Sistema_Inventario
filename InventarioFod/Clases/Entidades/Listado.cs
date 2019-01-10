using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioFod.Clases.Entidades
{
    class Listado : Institucion
    {
        public int lista { get; set; }
        public int total_maquinas { get; set; }
        public int total_paquetes { get; set; }
        public string modalidad { get; set; }
        public string tipo { get; set; }
        public string equipo { get; set; }
        public string cartel { get; set; }

        public Listado(string lista, string codigo,string institucion, string total_maquinas, string total_paquetes, string modalidad, string tipo, string equipo, string cartel)
            :base(codigo,institucion)
        {
            this.codigo = codigo;
            this.modalidad = modalidad;
            this.tipo = tipo;
            this.equipo = equipo;
            this.cartel = cartel;
            convert_val_to_int(lista,total_maquinas,total_paquetes);
        }
        public Listado()
            : base()
        { }

        private void convert_val_to_int(string lista,string total_maquinas,string total_paquetes)
        {
            this.lista = Convert.ToInt32(lista);
            this.total_maquinas = Convert.ToInt32(total_maquinas);
            this.total_paquetes = Convert.ToInt32(total_paquetes);
        }
    }
}
