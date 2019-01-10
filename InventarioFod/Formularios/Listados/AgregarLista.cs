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
    public partial class AgregarLista : Form
    {
        Manejo_Documento_Excel excel;
        public AgregarLista()
        {
            InitializeComponent();
            excel = new Manejo_Documento_Excel(this.dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            excel.buscar_codigo(textBox1.Text);
        }

        private void importarListaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            excel.importar_excel_listas();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            excel.guardar_listado();
        }
    }
}
