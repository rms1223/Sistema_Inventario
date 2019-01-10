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
    public partial class Informacion_Acciones : Form
    {
        private Dictionary<string, string> valores;
        public Informacion_Acciones(Dictionary<string,string> inf_accion)
        {
            InitializeComponent();
            valores = inf_accion;
            cargar_datos_formulario();
        }


        private void cargar_datos_formulario()
        {
            foreach (KeyValuePair<string,string> item in valores)
            {
                switch (item.Key)
                {
                    case "Accion":
                        textBox1.Text = item.Value;
                        break;
                    case "Buenas":
                        label9.Text = item.Value;
                        break;
                    case "Malas":
                        label10.Text = item.Value;
                        break;
                    case "Total":
                        label8.Text = item.Value;
                        break;
                    case "Fecha":
                        label12.Text = item.Value;
                        break;
                    case "Tecnico":
                        label11.Text = item.Value;
                        break;
                    case "Ubicacion":
                        label7.Text = item.Value;
                        break;
                    default:
                        break;
                }
            }
        }


    }
}
