using InventarioFod.Clases;
using System;
using System.Windows.Forms;

namespace InventarioFod
{
    public partial class AgregarInstitucion : Form
    {

        public AgregarInstitucion()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Manejo_Documento_Excel excel = new Manejo_Documento_Excel();
            excel.Insertar_Institucion(new Clases.Entidades.Institucion(textBox1.Text, textBox2.Text));
            this.Close();
        }
    }
}
