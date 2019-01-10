using System;

namespace InventarioFod.Clases.Entidades
{
    public class Equipos_Proveedor : Inventario_Base
    {
        public string Ubicacion { get; set; }
        public string Tipo_Inventario { get; set; }

        public Equipos_Proveedor(string danos, string fecha_Inventario, string tecnico, int accion, string serie, string placa, string descripcion,
            string ubicacion, string tipo_Inventario)
            :base(serie,placa,descripcion,accion,fecha_Inventario,tecnico,danos)
        {
            Ubicacion = ubicacion;
            Tipo_Inventario = tipo_Inventario;
        }
        public Equipos_Proveedor() : base() { }
    }
}
