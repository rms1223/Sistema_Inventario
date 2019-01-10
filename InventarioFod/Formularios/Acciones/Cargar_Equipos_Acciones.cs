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
    public partial class Cargar_Equipos_Acciones : Form
    {
        public Form_Malas principal_malas { get; set; }
        public principal principal_requi { get; set; }
        public string tipo_formulario { get; set; }
        public Cargar_Equipos_Acciones()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            List<string> valores = textBox1.Text.Split('-').ToList();
            //principal.Accion = Convert.ToInt32(textBox1.Text);
            if (tipo_formulario.Equals("INVENTARIO_MALAS"))
            {
                principal_malas.acciones = valores;
                principal_malas.cargar_datos_accion();
            }
            else
            {
                principal_requi.acciones_user = valores;
                principal_requi.cargar_datos_requipamiento();
            }
            
            this.Close();
        }
    }
}
