using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioFod.Clases.Entidades
{
    public class Equipos_Reequipamiento
    {
        public int Listado { get; set; }
        public string Serie { get; set; }
        public string Placa { get; set; }
        public int Numero_Paquete { get; set; }
        public int NUmero_Maquina { get; set; }
        public int Accion { get; set; }
        public string Institucion { get; set; }
        public string Modalidad { get; set; }
        public string Estado { get; set; }
        public string Fecha { get; set; }
        public string Tecnico { get; set; }
        public string Estado_Listado { get; set; }

        public Equipos_Reequipamiento(int listado, string serie, string placa, int numero_Paquete, int nUmero_Maquina, int accion, string institucion, string modalidad, string estado, string fecha, string tecnico, string estado_Listado)
        {
            Listado = listado;
            Serie = serie;
            Placa = placa;
            Numero_Paquete = numero_Paquete;
            NUmero_Maquina = nUmero_Maquina;
            Accion = accion;
            Institucion = institucion;
            Modalidad = modalidad;
            Estado = estado;
            Fecha = fecha;
            Tecnico = tecnico;
            Estado_Listado = estado_Listado;
        }
        public Equipos_Reequipamiento() { }
    }
}
