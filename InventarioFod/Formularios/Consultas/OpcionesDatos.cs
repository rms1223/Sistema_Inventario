using InventarioFod.Clases;
using InventarioFod.Clases.Entidades;
using System;
using System.Windows.Forms;

namespace InventarioFod
{
    public partial class OpcionesDatos : Form
    {

        //private BaseDatos datos;
        private MysqlDB datos;

        private Manejo_Documento_Excel excel = new Manejo_Documento_Excel();
        DataGridView datos_grid;
        public OpcionesDatos()
        {
            InitializeComponent();
            ToolTip b_update = new ToolTip();
            ToolTip b_delete = new ToolTip();
            txt_lista.Enabled = false;
            txt_placa.Enabled = false;
            txt_serie.Enabled = false;
            b_update.SetToolTip(button1,"Actualizar Registro");
            b_delete.SetToolTip(button2,"Eliminar Registro");
            datos = MysqlDB.getInstance;
            
        }

        public void establecer_datos(DataGridView dta, string listado,string placa, string serie, string paquete, string estacion, string institucion, string modalidad, string estado_equipo, string fecha, string accion, string estado,string tecnico)
        {
            datos_grid = dta;
            txt_lista.Text = listado;
            txt_placa.Text = placa;
            txt_serie.Text = serie;
            txt_paquete.Text = paquete;
            txt_estacion.Text = estacion;
            txt_institucion.Text = institucion;
            txt_modalidad.Text = modalidad;
            txt_estadoequipo.Text = estado_equipo;
            txt_fecha.Text = fecha;
            txt_accion.Text = accion;
            txt_estadoregistro.Text = estado;
            txt_tecnico.Text = tecnico;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Equipos_Reequipamiento equi_requi = new Equipos_Reequipamiento();
            equi_requi.Listado = Convert.ToInt32(txt_lista.Text);
            equi_requi.Serie = txt_serie.Text;
            equi_requi.Placa = txt_placa.Text;
            equi_requi.Accion = Convert.ToInt32(txt_accion.Text);
            equi_requi.Numero_Paquete = Convert.ToInt32(txt_paquete.Text);
            equi_requi.NUmero_Maquina = Convert.ToInt32(txt_estacion.Text);
            equi_requi.Institucion = txt_institucion.Text;
            equi_requi.Modalidad = txt_modalidad.Text;
            equi_requi.Estado = txt_estadoequipo.Text;
            equi_requi.Fecha = txt_fecha.Text;
            equi_requi.Tecnico = txt_tecnico.Text;
            equi_requi.Estado_Listado = txt_estadoregistro.Text.ToUpper();

            excel.Inventario_Equipos_Reequipamiento(equi_requi,Query.Update);
            MessageBox.Show("Registro modificado", "Modificacion de registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult resultado =  MessageBox.Show("Eliminar Registros","Desea Eliminar el registro",MessageBoxButtons.YesNo,MessageBoxIcon.Stop);
            if (resultado == DialogResult.Yes)
            {
                datos.Eliminar_Datos_Reequipamiento(txt_lista.Text, txt_serie.Text, txt_placa.Text);
            }
            MessageBox.Show("Registro Eliminado");
            datos_grid.DataSource = datos.Obtener_Datos();
            this.Close();
        }
    }
}
