using InventarioFod.Clases;
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
    public partial class Lista_inventario : Form
    {
        public principal formulario_principal;

        //private BaseDatos datos;
        private MysqlDB datos;
        private Manejo_Documento_Excel excel;
        private OpcionesDatos opciones;


        public Lista_inventario()
        {
            InitializeComponent();
            //datos = BaseDatos.get_instancia;
            datos = MysqlDB.getInstance;
            ToolTip regresar = new ToolTip();

            comboBox1.Items.Add("TODOS");
            comboBox1.Items.Add("NO ASIGNADO");
            comboBox1.Items.Add("ASIGNADO");
            comboBox1.SelectedIndex = 0;

            opciones = new OpcionesDatos();
            excel = new Manejo_Documento_Excel(dataGridView1);
            //comboBox1.SelectedIndex = 0;
            comboBox2.Items.Add("TODAS");
            foreach (var item in datos.obtener_listas())
            {
                comboBox2.Items.Add(item);
            }
            //comboBox2.SelectedIndex = 0;
            dataGridView1.DataSource = datos.Obtener_Datos_Lista_Reequipamiento("0", Var_Name.Listado);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            formulario_principal.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = datos.obtener_datos(textBox1.Text,"Placa");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = datos.Obtener_Datos_Lista_Reequipamiento(textBox1.Text, Var_Name.Placa);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = datos.Obtener_Datos_Lista_Reequipamiento(textBox2.Text, Var_Name.Serie);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = datos.Obtener_Datos_Lista_Reequipamiento(textBox3.Text, Var_Name.Institucion);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = datos.obtener_datos(maskedTextBox1.Text, "Fecha");
        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            opciones = new OpcionesDatos();
            string lista = String.Empty;
            string placa = String.Empty;
            string serie = String.Empty;
            string estacion = String.Empty;
            string modalidad = String.Empty;
            string estado_equipo = String.Empty;
            string institucion = String.Empty;
            string fecha = String.Empty;
            string paquete = String.Empty;
            string accion = String.Empty;
            string tecnico = String.Empty;
            string estado_ope = String.Empty;

            foreach (DataGridViewRow item in dataGridView1.SelectedRows)
            {
                lista = item.Cells[Var_Name.Listado].Value.ToString();
                placa = item.Cells[Var_Name.Placa].Value.ToString();
                serie = item.Cells[Var_Name.Serie].Value.ToString();
                estacion = item.Cells["Numero_Estacion"].Value.ToString();
                modalidad = item.Cells["Modalidad"].Value.ToString();
                estado_equipo = item.Cells["Estado_Equipo"].Value.ToString();
                institucion = item.Cells[Var_Name.Institucion].Value.ToString();
                fecha = item.Cells["Fecha_Inventario"].Value.ToString();
                paquete = item.Cells["Numero_Paquete"].Value.ToString();
                accion = item.Cells[Var_Name.Accion].Value.ToString();
                tecnico = item.Cells[Var_Name.Tecnico].Value.ToString();
                estado_ope = item.Cells["Estado_Listado"].Value.ToString();
            }
            opciones.establecer_datos(dataGridView1,lista, placa, serie, paquete, estacion, institucion, modalidad, estado_equipo, fecha, accion, estado_ope, tecnico);
            opciones.Show();
            
        }

        private void exportarArchivoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            excel.exportar_a_excel();
            dataGridView1.DataSource = datos.Actualizar_Estado(comboBox2.SelectedItem.ToString());
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox1.SelectedItem.ToString().Equals("TODOS"))
            {
                dataGridView1.DataSource = datos.Obtener_Datos_Lista_Reequipamiento("0",Var_Name.Listado);
            }
            else if (comboBox2.SelectedItem.ToString().Equals("TODAS"))
            {
                dataGridView1.DataSource = datos.Obtener_Datos_Lista_Reequipamiento(comboBox1.SelectedItem.ToString(), "Estado_inventario");
            }
            else
            {
                dataGridView1.DataSource = datos.Filtrar_Datos(comboBox2.SelectedItem.ToString(),comboBox1.SelectedItem.ToString());
            }
            
        }

        private void label6_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = datos.Obtener_Datos_Lista_Reequipamiento(maskedTextBox1.Text, "Fecha");
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem.ToString().Equals("TODAS"))
            {
                //dataGridView1.DataSource = datos.obtener_datos();
                dataGridView1.DataSource = datos.Obtener_Datos_Lista_Reequipamiento("0",  Var_Name.Listado);

            }
            else
            {
                dataGridView1.DataSource = datos.Obtener_Datos_Lista_Reequipamiento(comboBox2.SelectedItem.ToString(), Var_Name.Listado);
            }
            
        }

        private void Lista_inventario_FormClosed(object sender, FormClosedEventArgs e)
        {
            //formulario_principal.Close();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
