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
    public partial class Agregar_imp_list : Form
    {
        MysqlDB datos;
        public Agregar_imp_list()
        {
            InitializeComponent();
            datos = MysqlDB.getInstance;
            foreach (var item in datos.Seleccionar_Lista())
            {
                comboBox1.Items.Add(item);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource=datos.Listar_Registro(comboBox1.SelectedItem.ToString());
        }

        private void label9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void imprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Impresion imp = new Impresion();
            imp.Set_lista = comboBox1.SelectedItem.ToString();
            imp.procesar_impresion();
            imp.Show();
        }
    }
}
