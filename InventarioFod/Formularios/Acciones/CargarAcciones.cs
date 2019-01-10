using InventarioFod.Clases;
using InventarioFod.Entidades;
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
    public partial class CargarAcciones : Form
    {
        principal princi;
        Manejo_Documento_Excel excel;
        MysqlDB db;

        public CargarAcciones()
        {
            InitializeComponent();
            excel = new Manejo_Documento_Excel(dataGridView1);
            db = MysqlDB.getInstance;
            comboBox1.Items.Add(Var_Name.Acciones);
            comboBox1.Items.Add(Var_Name.Serie);
            comboBox1.Items.Add(Var_Name.Placa);
            comboBox1.SelectedIndex = 0;
        }
        private void importarExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            excel.importar_excel_accionesprincipal();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime fecha = DateTime.Now;
            int cod_accion = Convert.ToInt32(textBox1.Text);
            excel.insertar_acciones(new Acciones(cod_accion,textBox2.Text, fecha));
            excel.guaradar_equipos_acciones(cod_accion);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //int cod_accion = Convert.ToInt32(textBox3.Text);
            excel.obtener_equipo_acciones(textBox4.Text,comboBox1.SelectedItem.ToString());

        }

        private void exportarExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            excel.exportar_a_excel();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            princi.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ConsultaAvanzada consulta_avan = new ConsultaAvanzada();
            consulta_avan.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
