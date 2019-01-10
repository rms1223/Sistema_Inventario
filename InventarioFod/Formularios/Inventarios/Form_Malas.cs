using InventarioFod.Clases;
using InventarioFod.Clases.Entidades;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace InventarioFod
{
    public partial class Form_Malas : Form
    {
        principal prin;
        Manejo_Documento_Excel excel;
        private string fecha_actual;
        private MysqlDB datos;
        private int contador = 0;

        public List<string> acciones { get; set; }


        public Form_Malas()
        {
            InitializeComponent();
            datos = MysqlDB.getInstance;
            cargar_estados();
            cargar_tecnicos();
            cargar_danos();

            excel = new Manejo_Documento_Excel(dataGridView1);
            fecha_actual = DateTime.Today.ToString("MM/dd/yyyy");
            fecha_actual = fecha_actual.Split(' ')[0];

            label8.Text = " " + contador;
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            buscar_placa(placa.Text,Var_Name.Placa);
        }


        private void cargar_danos()
        {
            foreach (var item in datos.Get_Danos())
            {
                lista_malas.Items.Add(item);
            }
            lista_malas.Sorted = true;
        }

        private void cargar_estados()
        {
            foreach (var item in datos.Ubicaciones_Inventario)
            {
                comboBox2.Items.Add(item);
            }

            comboBox3.Items.Add("BUEN ESTADO");
            comboBox3.Items.Add("MAL ESTADO");

            //comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;

        }

        private void cargar_tecnicos()
        {
            foreach (var item in datos.Get_Tecnicos())
            {
                comboBox1.Items.Add(item);
            }
            comboBox1.SelectedIndex = 0;
            foreach (var item in datos.Tipos_Inventarios)
            {
                comboBox4.Items.Add(item);
            }
            
        }

        private void importarExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            excel.importar_excel_acciones();
        }

        private bool estado;
        private void buscar_placa(string valor,string tipo_busqueda)
        {
            
            dataGridView1.AllowUserToAddRows = false;
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {

                estado = false;

                if (item.Cells[tipo_busqueda].Value.ToString().Equals(valor))
                {
                    dataGridView1.FirstDisplayedScrollingRowIndex = item.Index;
                    item.Selected = true;
                    if (String.IsNullOrEmpty(item.Cells[Var_Name.Tecnico].Value.ToString()))
                    {

                        dataGridView1.Rows[item.Index].DefaultCellStyle.BackColor = Color.LightBlue;
                        estado = true;
                        //esta instruccion se utiliza para seleccionar la placa buscada
                        item.Selected = true;
                        //Con esta instruccion colocamos el scroll del datagridview en el valor que buscamos
                        dataGridView1.FirstDisplayedScrollingRowIndex = item.Index;
                        //Estas instrucciones lo que hacen es agregar los valores a los campos 
                        //Correspondientes en el datagridview

                        string danos = String.Empty;
                        if (lista_malas.SelectedItems.Count>0)
                        {
                            foreach (var item_lista in lista_malas.SelectedItems)
                            {
                                danos += item_lista + "-";
                            }
                        }
                        item.Cells["Daños"].Value = danos;
                        item.Cells["Estado_Equipo"].Value = comboBox2.SelectedItem.ToString();
                        item.Cells["Condicion"].Value = comboBox3.SelectedItem.ToString();
                        item.Cells["Fecha_Inventario"].Value = fecha_actual;
                        item.Cells[Var_Name.Tecnico].Value = comboBox1.SelectedItem.ToString();
                        if (!comboBox4.SelectedItem.ToString().Equals(Var_Name.Acciones.ToUpper()))
                        {
                            if (!textBox1.Text.Equals("0000"))
                            {
                                item.Cells[Var_Name.Accion].Value = textBox1.Text;
                            }
                        }
                        placa.Text = "";
                        txtserie.Text = "";
                        //Establece el foco de control para ingresar nuevas placas.
                        placa.Focus();
                        contador++;
                        label8.Text = " "+contador;
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
            if (!estado)
            {
                MessageBox.Show("La Serie o Placa" +valor+ " No existe");
            }
            //lista_malas.ClearSelected();
            dataGridView1.AllowUserToAddRows = true;
        }

        private void placa_TextChanged(object sender, EventArgs e)
        {
            if (placa.Text.Length == 6)
            {
                button2.Focus();
            }
        }

        private void exportarExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            excel.exportar_a_excel();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool estado_ope = true;
            dataGridView1.AllowUserToAddRows = false;
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {

                if (!String.IsNullOrEmpty(item.Cells[Var_Name.Tecnico].Value.ToString()))
                {
                    string serie = item.Cells[Var_Name.Serie].Value.ToString();
                    string placa = item.Cells[Var_Name.Placa].Value.ToString();
                    int accion = Convert.ToInt32(item.Cells[Var_Name.Codigo_Accion].Value);
                    string condicion = item.Cells["Condicion"].Value.ToString();
                    string descripcion = item.Cells[Var_Name.Descripcion].Value.ToString();
                    string danos = item.Cells["DaÑos"].Value.ToString();
                    string estado = item.Cells["Estado_Equipo"].Value.ToString();
                    string fecha = item.Cells["Fecha_Inventario"].Value.ToString();
                    string tecnico = item.Cells[Var_Name.Tecnico].Value.ToString();

                    if (comboBox4.SelectedItem.ToString().Equals(Var_Name.Acciones.ToUpper()))
                    {
                        estado_ope = excel.Insertar_Inventarios_Malas_Acciones(new Inventario_Malas(serie,placa,descripcion,danos,condicion,fecha,tecnico,accion,estado),Query.Insert);
                    }
                    else
                    {
                       estado_ope = excel.Insertar_Inventarios_Malas_Proveedor(new Equipos_Proveedor(danos,fecha,tecnico,accion,serie,placa,descripcion, "CENTRO DE SOPORTE", comboBox4.SelectedItem.ToString()));
                    }
                }
            }
            if (estado_ope)
            {
                MessageBox.Show("Datos Guardados....");
            }
            dataGridView1.AllowUserToAddRows = true;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedItem.ToString().Equals("BUEN ESTADO"))
            {
                lista_malas.Enabled = false;
            }
            else
            {
                lista_malas.Enabled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            

        }

        private void button4_Click(object sender, EventArgs e)
        {
            buscar_placa(txtserie.Text,Var_Name.Serie);
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!comboBox4.SelectedItem.ToString().Equals(Var_Name.Serie.ToUpper()))
            {
                label10.Visible = true;
                textBox1.Visible = true;
                textBox1.Text = "0000";
            }
            else
            {
                label10.Visible = false;
                textBox1.Visible = false;
            }
            
        }

        private void Form_Malas_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void cargarAccionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cargar_Equipos_Acciones cargar = new Cargar_Equipos_Acciones();
            cargar.tipo_formulario = "INVENTARIO_MALAS";
            cargar.principal_malas = this;
            cargar.Show();
        }

        public void cargar_datos_accion()
        {
            excel.importar_db_acciones(acciones);
        }
        public int Accion { get; set; }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(datos.get_codigo_tecnico(comboBox1.SelectedItem.ToString()).ToString());
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(datos.get_codigo_ubicacion(comboBox2.SelectedItem.ToString()).ToString());
        }

        private void label13_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }

}
