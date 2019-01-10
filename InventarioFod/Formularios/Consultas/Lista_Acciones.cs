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
    public partial class Lista_Acciones : Form
    {
        private principal prin;
        //private BaseDatos datos;
        private MysqlDB datos;
        private Manejo_Documento_Excel excel;
        private String tipo_busqueda = String.Empty;
        
        public Lista_Acciones()
        {
            InitializeComponent();
            //datos = BaseDatos.get_instancia;
            datos = MysqlDB.getInstance;
            excel = new Manejo_Documento_Excel(dataGridView1);
            dataGridView1.DataSource = datos.Obtener_Datos_Acciones("Todos", "Todos");
            
            comboBox1.Items.Add(Var_Name.Proveedor_Buenas);
            comboBox1.Items.Add(Var_Name.Proveedor_Malas);
            comboBox1.Items.Add(Var_Name.Proveedor_Bodega);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            tipo_busqueda = Var_Name.Acciones;
            dataGridView1.DataSource = datos.Obtener_Datos_Acciones(txtplaca.Text, Var_Name.Placa);
           
        }

        private void txtaccion_TextChanged(object sender, EventArgs e)
        {
            tipo_busqueda = Var_Name.Acciones;
            dataGridView1.DataSource = datos.Obtener_Datos_Acciones(txtaccion.Text, Var_Name.Accion);
            
        }

        private void txtserie_TextChanged(object sender, EventArgs e)
        {
            tipo_busqueda = Var_Name.Acciones;
            dataGridView1.DataSource = datos.Obtener_Datos_Acciones(txtserie.Text, Var_Name.Serie);
            
        }

        private void exportarAExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            excel.exportar_a_excel();
            //datos.actualizar_estado_accion(txtaccion.Text);
            MessageBox.Show("Datos Exportados","Exportar Acción",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void txttecnico_TextChanged(object sender, EventArgs e)
        {
            tipo_busqueda = Var_Name.Acciones;
            dataGridView1.DataSource = datos.Obtener_Datos_Acciones(txttecnico.Text, Var_Name.Tecnico);
            
        }

        private Informacion_Acciones acciones;

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string valor = String.Empty;
            if (checkBox1.Checked)
            {
                valor = "TODAS";
            }
            else
            {
                valor = txtaccion.Text;
            }
            acciones = new Informacion_Acciones(datos.get_total_equiposAccion(valor));
            acciones.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            tipo_busqueda = Var_Name.Proveedor;
            if (checkBox1.Checked)
            {
                dataGridView1.DataSource = datos.Obtener_Datos_Reparacion_Proveedor(Var_Name.Proveedor_Centro_Soporte);
            }
            else
            {
                dataGridView1.DataSource = datos.Obtener_Datos_Reparacion_Proveedor(comboBox1.SelectedItem.ToString());
            }
            
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            tipo_busqueda = Var_Name.Proveedor;
            dataGridView1.DataSource = datos.Obtener_Proveedor_Datos(buscar_placa.Text,comboBox1.SelectedItem.ToString());
            
        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
            string placa = String.Empty;
            string serie = String.Empty;
            string accion = String.Empty;
            string descripcion = String.Empty;
            string fecha = String.Empty;
            string tecnico = String.Empty;
            string ubicacion = String.Empty;
            string tecnicoInventario = String.Empty;
            string danos = String.Empty;
            string Estado_equipo = String.Empty;
            string estado = String.Empty;
            Inventario_Malas inven_malas = new Inventario_Malas();
            foreach (DataGridViewRow item in dataGridView1.SelectedRows)
            {
                inven_malas.Placa = item.Cells[Var_Name.Placa].Value.ToString();
                inven_malas.Serie = item.Cells[Var_Name.Serie].Value.ToString();
                inven_malas.Descripcion = item.Cells[Var_Name.Descripcion].Value.ToString();
                inven_malas.Accion = Convert.ToInt32(item.Cells[Var_Name.Accion].Value.ToString());
                inven_malas.Tecnico = item.Cells[Var_Name.Tecnico].Value.ToString();

                switch (tipo_busqueda)
                {
                    case "Acciones":
                        inven_malas.Estado = item.Cells["Ubicacion"].Value.ToString();
                        inven_malas.Fecha = item.Cells["Fecha_Inventario"].Value.ToString();
                        inven_malas.Estado_Equipo = item.Cells["Estado"].Value.ToString();
                        inven_malas.Danos = item.Cells["Danos"].Value.ToString();
                        break;
                    case "Proveedor":
                        ubicacion = item.Cells["Ubicacion"].Value.ToString();
                        fecha = item.Cells["Fecha"].Value.ToString();
                        tecnicoInventario = item.Cells["Tecnico_inventario"].Value.ToString();
                        break;
                    default:
                        break;
                }
            }
            //OpcionesEdicion editar = new OpcionesEdicion(serie, placa, accion, descripcion, fecha, tecnico, ubicacion, tecnicoInventario,danos,Estado_equipo,estado,tipo_busqueda);
            OpcionesEdicion editar2 = new OpcionesEdicion(inven_malas, tipo_busqueda);
            editar2.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ConsultaAvanzada consulta_avan = new ConsultaAvanzada();
            consulta_avan.Show();
        }

        private void Lista_Acciones_FormClosed(object sender, FormClosedEventArgs e)
        {
            //prin.Close();
        }

        private void menúPrincipalToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
