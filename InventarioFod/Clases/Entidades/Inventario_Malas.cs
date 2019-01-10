using System;

namespace InventarioFod.Clases.Entidades
{
    public class Inventario_Malas : Inventario_Base
    {
        public string Estado_Equipo { get; set; }
        public string Estado { get; set; }

        public Inventario_Malas()
            :base()
        {
            
        }

        public Inventario_Malas(string serie,string placa,string descripcion, string danos, string estado_Equipo, string fecha_Inventario, string tecnico, int accion, string estado)
            : base(serie,placa,descripcion,accion,fecha_Inventario,tecnico,danos)
        {
            Estado_Equipo = estado_Equipo;
            Estado = estado;
        }
    }
}
