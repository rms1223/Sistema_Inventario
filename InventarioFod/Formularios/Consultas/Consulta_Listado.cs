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

namespace InventarioFod.Formularios.Consultas
{
    public partial class Consulta_Listado : Form
    {
        MysqlDB datos;
        Manejo_Documento_Excel excel;
        public Consulta_Listado()
        {
            InitializeComponent();
            excel = new Manejo_Documento_Excel(this.dataGridView1);
            datos = MysqlDB.getInstance;
            foreach (var item in datos.Seleccionar_Lista())
            {
                comboBox1.Items.Add(item);
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void Consulta_Listado_Load(object sender, EventArgs e)
        {

        }

        private void label9_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            excel.get_listado_por_codigo(comboBox1.SelectedItem.ToString());
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ConsultaAvanzada consulta_avan = new ConsultaAvanzada();
            consulta_avan.Show();
        }
    }
}
