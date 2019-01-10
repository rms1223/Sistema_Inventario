using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioFod.Clases.Entidades
{
    class Equipos_Listados
    {
        public string lista_actual { get; set; }
        public string codigo_equipo { get; set; }
        public string inst_actual { get; set; }
        public string tipo_actual { get; set; }
        public string cartel_actual { get; set; }
        public string modelo_actual { get; set; }
        public string modelo_equipo_actual { get; set; }
        public string apellido_actual { get; set; }

        public Equipos_Listados(string lista_actual, string codigo_equipo, string inst_actual, string tipo_actual, string cartel_actual, string modelo_actual, string modelo_equipo_actual, string apellido_actual)
        {
            this.lista_actual = lista_actual;
            this.codigo_equipo = codigo_equipo;
            this.inst_actual = inst_actual;
            this.tipo_actual = tipo_actual;
            this.cartel_actual = cartel_actual;
            this.modelo_actual = modelo_actual;
            this.modelo_equipo_actual = modelo_equipo_actual;
            this.apellido_actual = apellido_actual;
        }

        public Equipos_Listados(){}
    }
}
