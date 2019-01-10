using InventarioFod.Clases;
using InventarioFod.Clases.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventarioFod
{
    public partial class OpcionesEdicion : Form
    {
        private string tipo_inventario = String.Empty;
        MysqlDB datos = MysqlDB.getInstance;
        Manejo_Documento_Excel archivo = new Manejo_Documento_Excel();

        public OpcionesEdicion(Inventario_Malas inven_malas, string tipo_busqueda)
        {
            InitializeComponent();
            ToolTip b_update = new ToolTip();
            ToolTip b_delete = new ToolTip();

            b_update.SetToolTip(button1, "Actualizar Registro");
            b_delete.SetToolTip(button2, "Eliminar Registro");

            txt_serie.Text = inven_malas.Serie;
            txt_placa.Text = inven_malas.Placa;
            txt_accion.Text = Convert.ToString(inven_malas.Accion);
            txt_descripcion.Text = inven_malas.Descripcion;
            txt_fecha.Text = inven_malas.Fecha;
            txt_tecnico.Text = inven_malas.Tecnico;
            txt_ubicacion.Text = inven_malas.Estado;
            txt_danos.Text = inven_malas.Danos;
            txt_estado.Text = inven_malas.Estado_Equipo;
            tipo_inventario = tipo_busqueda;
            if (tipo_busqueda.Equals("Proveedor"))
            {
                txt_danos.Visible = false;
                txt_estado.Visible = false;
                txt_estado.Visible = false;
                l_danos.Visible = false;
                l_estado.Visible = false;
                l_estado.Visible = false;
            }
            else
            {
                txt_tecnicoInventario.Visible = false;
                l_tecnicoinventario.Visible = false;
            }

        }

        public OpcionesEdicion(Equipos_Proveedor inven_provee, string tipo_busqueda)
        {
            InitializeComponent();
            ToolTip b_update = new ToolTip();
            ToolTip b_delete = new ToolTip();

            b_update.SetToolTip(button1, "Actualizar Registro");
            b_delete.SetToolTip(button2, "Eliminar Registro");

            txt_serie.Text = inven_provee.Serie;
            txt_placa.Text = inven_provee.Placa;
            txt_accion.Text = Convert.ToString(inven_provee.Accion);
            txt_descripcion.Text = inven_provee.Descripcion;
            txt_fecha.Text = inven_provee.Fecha;
            txt_tecnico.Text = inven_provee.Tecnico;
            txt_ubicacion.Text = inven_provee.Ubicacion;
            txt_danos.Text = inven_provee.Danos;
            txt_estado.Text = inven_provee.Tipo_Inventario;
            tipo_inventario = tipo_busqueda;
            if (tipo_busqueda.Equals("Proveedor"))
            {
                txt_danos.Visible = false;
                txt_estado.Visible = false;
                txt_estado.Visible = false;
                l_danos.Visible = false;
                l_estado.Visible = false;
                l_estado.Visible = false;
            }
            else
            {
                txt_tecnicoInventario.Visible = false;
                l_tecnicoinventario.Visible = false;
            }

        }


        public OpcionesEdicion(string serie, string placa, string accion, string descripcion, string fecha, string tecnico, string ubicacion, string tecnico_inventario,
            string danos, string Estado_equipo, string estado, string tipo_busqueda)
        {
            InitializeComponent();
            ToolTip b_update = new ToolTip();
            ToolTip b_delete = new ToolTip();

            b_update.SetToolTip(button1, "Actualizar Registro");
            b_delete.SetToolTip(button2, "Eliminar Registro");

            txt_serie.Text = serie;
            txt_placa.Text = placa;
            txt_accion.Text = accion;
            txt_descripcion.Text = descripcion;
            txt_fecha.Text = fecha;
            txt_tecnico.Text = tecnico;
            txt_ubicacion.Text = ubicacion;
            txt_tecnicoInventario.Text = tecnico_inventario;
            txt_danos.Text = danos;
            //txt_estadoequipo.Text = Estado_equipo;
            txt_estado.Text = estado;
            tipo_inventario = tipo_busqueda;
            if (tipo_busqueda.Equals("Proveedor"))
            {
                txt_danos.Visible = false;
                //txt_estadoequipo.Visible = false;
                txt_estado.Visible = false;
                l_danos.Visible = false;
                l_estado.Visible = false;
                //l_estadoequipo.Visible = false;
            }
            else
            {
                txt_tecnicoInventario.Visible = false;
                l_tecnicoinventario.Visible = false;
            }

        }

        private bool estado_respuesta = false;
        private void button1_Click(object sender, EventArgs e)
        {
            switch (tipo_inventario)
            {
                case "Proveedor":
                    //estado_respuesta=datos.actualizar_equipos_proveedor(txt_placa.Text, txt_serie.Text, txt_descripcion.Text, txt_accion.Text, txt_tecnico.Text, txt_fecha.Text, txt_tecnicoInventario.Text, txt_ubicacion.Text);
                    
                    break;
                case "Acciones":
                    estado_respuesta = archivo.Insertar_Inventarios_Malas_Acciones(new Inventario_Malas(txt_serie.Text, txt_placa.Text, txt_descripcion.Text, txt_danos.Text, txt_ubicacion.Text, txt_fecha.Text, txt_tecnico.Text,Convert.ToInt32(txt_accion.Text),txt_estado.Text),Query.Update);
                    break;
                default:
                    break;
            }
            if (estado_respuesta)
            {
                MessageBox.Show("Registro modificado", "Modificacion de registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error al modificar el Registro", "Modificacion de registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            switch (tipo_inventario)
            {
                case "Proveedor":
                    estado_respuesta = datos.eliminar_equipos_proveedor(txt_placa.Text, txt_serie.Text);
                    
                    break;
                case "Acciones":
                    estado_respuesta = datos.Eliminar_Registros_Malas(txt_serie.Text, txt_placa.Text, txt_accion.Text);
                    break;
                default:
                    break;
            }
            if (estado_respuesta)
            {
                MessageBox.Show("Registro modificado", "Modificacion de registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error al modificar el Registro", "Modificacion de registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.Close();
        }

        private void txt_estado_TextChanged(object sender, EventArgs e)
        {

        }

        private void OpcionesEdicion_Load(object sender, EventArgs e)
        {

        }
    }
}
