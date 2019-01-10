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
    public partial class ConsultaAvanzada : Form
    {
        MysqlDB database = MysqlDB.getInstance;
        Manejo_Documento_Excel excel;
        public ConsultaAvanzada()
        {
            InitializeComponent();
            excel = new Manejo_Documento_Excel(dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = database.Consulta_Personalizada(textBox1.Text);
        }

        private void exportarDatosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            excel.exportar_a_excel();
            MessageBox.Show("Datos Exportados", "Exportar Acción", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
