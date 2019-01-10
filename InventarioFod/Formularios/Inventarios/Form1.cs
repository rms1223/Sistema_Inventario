using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using System.Drawing;
using InventarioFod.Clases;
using System.Threading;
using System.Collections.Generic;
using InventarioFod.Clases.Entidades;

namespace InventarioFod
{
    public partial class principal : Form
    {

        private System.Data.DataTable dt;
        private string fecha_actual = String.Empty;
        private bool estado = false;
        private int contador = 1;
        //private BaseDatos datos;
        private MysqlDB datos;
        Lista_inventario lista_form;

        //Para el manejo de las listas a cargar por el usuario
        public List<string> acciones_user { get; set; }

        Form_Malas malas;
        Lista_Acciones acciones;
        Manejo_Documento_Excel excel;

        public principal()
        {
            InitializeComponent();
            label12.Visible = false;

            excel = new Manejo_Documento_Excel(dataGridView1);

            ToolTip tip_import = new ToolTip();
            ToolTip tip_refresh = new ToolTip();
            ToolTip tip_guardar = new ToolTip();
            ToolTip limpiar = new ToolTip();
            limpiar.SetToolTip(label13, "Limpiar Datos");

            lista_form = new Lista_inventario();

            tip_refresh.SetToolTip(button2,"Eliminar Datos");
            

            dt = new System.Data.DataTable();

            tip_guardar.SetToolTip(guardar,"Guardar Registros");

            //Deshabilitamos el sort del datagridview
            tipo.Text = "BUEN ESTADO";
            //cargamos los valores al combobox
            comboBox1.Items.Add("ESTUDIANTE");
            comboBox1.Items.Add("DOCENTE");
            comboBox1.Items.Add("PREESCOLAR");


            //se utiliza para seleccionar un valor por defecto
            
            //cargamos el numero de estacion actual y le desplegamos al usuario 
            numericUpDown1.Value = Convert.ToDecimal(contador.ToString());
            



            fecha_actual = DateTime.Today.ToString("MM/dd/yyyy");
            fecha_actual = fecha_actual.Split(' ')[0];

            datos = MysqlDB.getInstance;
            
            foreach (var item in datos.Get_Tecnicos())
            {
                comboBox3.Items.Add(item);
            }
            foreach (var item in datos.obtener_listas())
            {
                combo_listas.Items.Add(item);
            }
            comboBox1.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            combo_listas.SelectedIndex = 0;




            //dataGridView1.AllowUserToAddRows = false;

        }
        
       
        private void Importar_Click(object sender, EventArgs e)
        {
           
        }

        private void eliminar_sort()
        {
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void verificar_datos(string valor,string tipo_buscar)
        {
                dataGridView1.AllowUserToAddRows = false;
                foreach (DataGridViewRow item in dataGridView1.Rows)
                {

                    estado = false;

                    if (item.Cells[tipo_buscar].Value.ToString().Equals(valor))
                    {
                        dataGridView1.FirstDisplayedScrollingRowIndex = item.Index;
                        item.Selected = true;
                        if (String.IsNullOrEmpty(item.Cells["Número_Estación"].Value.ToString()))
                        {
                            if (local_contador > 3)
                            {
                                local_contador = 1;
                                contador_paquetes++;
                            }
                            dataGridView1.Rows[item.Index].DefaultCellStyle.BackColor = Color.LightBlue;
                            estado = true;
                            //esta instruccion se utiliza para seleccionar la placa buscada
                            item.Selected = true;
                            //Con esta instruccion colocamos el scroll del datagridview en el valor que buscamos
                            dataGridView1.FirstDisplayedScrollingRowIndex = item.Index;
                            //Estas instrucciones lo que hacen es agregar los valores a los campos 
                            //Correspondientes en el datagridview
                            item.Cells["Número_Estación"].Value = contador;
                            item.Cells["Estudiante/Docente"].Value = comboBox1.SelectedItem;
                            item.Cells["Estado"].Value = tipo.Text;
                            item.Cells[Var_Name.Institucion].Value = institucion.Text;
                            item.Cells["Fecha_Inventario"].Value = fecha_actual;
                            item.Cells["Numero_Paquete"].Value = contador_paquetes;
                            item.Cells[Var_Name.Tecnico].Value = comboBox3.SelectedItem.ToString();
                            item.Cells[Var_Name.Lista].Value = combo_listas.SelectedItem.ToString();
                            //Incrementa contador de maquinas
                            contador++;
                            numericUpDown1.Value = Convert.ToDecimal(contador.ToString());
                            placa.Text = String.Empty;
                            //Establece el foco de control para ingresar nuevas placas.
                            placa.Focus();
                            local_contador++;
                            break;
                        }
                        else
                        {
                            MessageBox.Show("Equipo ya fue asignado");
                            estado = true;
                            break;
                        }

                    }
                }
                dataGridView1.AllowUserToAddRows = true;
            if (!estado)
            {
                MessageBox.Show("No existe la placa o Serie: " + valor, "Error al Buscar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            placa.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            verificar_datos(placa.Text,Var_Name.Placa);
        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            contador = 1;
            contador_paquetes = 1;
            local_contador = 1;
            institucion.Text = "";
            placa.Focus();
            numericUpDown1.Value = Convert.ToDecimal(contador);
        }

        private void placa_TextChanged(object sender, EventArgs e)
        {
            if (placa.Text.Length==6)
            {
                button1.Focus();
            }
            
        }
        int contador_paquetes = 1;
        int local_contador = 1;

        private void button3_Click_1(object sender, EventArgs e)
        {

            verificar_datos(serie.Text.ToUpper(), Var_Name.Serie);
            serie.Text = String.Empty;
        }

        private void serie_TextChanged(object sender, EventArgs e)
        {
            if (serie.Text.Length >=10)
            {
                buscar_serie.Focus();
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            contador = Convert.ToInt32(numericUpDown1.Value);
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            //MessageBox.Show("Has salido del foco");
            string valor = datos.Obtener_Institucion(textBox1.Text);
            institucion.Text = valor;
            placa.Focus();
            textBox1.Text = String.Empty;
        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            bool estado_ope = true;
            dataGridView1.AllowUserToAddRows = false;
            Equipos_Reequipamiento equi_requi = new Equipos_Reequipamiento();
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {

                if (!String.IsNullOrEmpty(item.Cells[Var_Name.Institucion].Value.ToString()))
                {

                    equi_requi.Listado = Convert.ToInt32(item.Cells[Var_Name.Lista].Value.ToString());
                    equi_requi.Serie = item.Cells[Var_Name.Serie].Value.ToString();
                    equi_requi.Placa = item.Cells[Var_Name.Placa].Value.ToString();
                    equi_requi.Accion = Convert.ToInt32(item.Cells[Var_Name.Codigo_Accion].Value.ToString());
                    equi_requi.Numero_Paquete = Convert.ToInt32(item.Cells["Numero_Paquete"].Value);
                    equi_requi.NUmero_Maquina = Convert.ToInt32(item.Cells["Número_Estación"].Value);
                    equi_requi.Institucion = item.Cells[Var_Name.Institucion].Value.ToString();
                    equi_requi.Modalidad = item.Cells["Estudiante/Docente"].Value.ToString();
                    equi_requi .Estado= item.Cells["Estado"].Value.ToString();
                    equi_requi.Fecha = item.Cells["Fecha_Inventario"].Value.ToString();
                    equi_requi.Tecnico = item.Cells[Var_Name.Tecnico].Value.ToString();
                    equi_requi.Estado_Listado = "NO ASIGNADO";

                    estado_ope = excel.Inventario_Equipos_Reequipamiento(equi_requi,Query.Insert);
                    if (!estado_ope)
                    {
                        break;
                    }
                }
            }
            if (estado_ope)
            {
                MessageBox.Show("Datos Guardados....");
            }
            dataGridView1.AllowUserToAddRows = true;

        }

        private void exportar_Click(object sender, EventArgs e)
        {

        }
        
        
        private void label13_Click(object sender, EventArgs e)
        {
            dt = new System.Data.DataTable();
            dataGridView1.DataSource = dt;
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AgregarInstitucion add_institu = new AgregarInstitucion();
            add_institu.Show();
        }

        private void agregarAccionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CargarAcciones cargar_acciones = new CargarAcciones();
            this.Hide();
            cargar_acciones.Show();
        }

        public void cargar_datos_requipamiento()
        {
            excel.importar_db_acciones_requipamiento(acciones_user);
        }

        private void importarAccionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void importarAccionExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            excel.importar_excel_requipamiento();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void cargarAcciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cargar_Equipos_Acciones cargar = new Cargar_Equipos_Acciones();
            cargar.tipo_formulario = "INVENTARIO_REQUIPAMIENTO";
            cargar.principal_requi = this;
            cargar.Show();
        }

        private void exportarExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            excel.exportar_a_excel();
        }

        private void importarExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            excel.importar_excel_requipamiento();
        }
    }
}
