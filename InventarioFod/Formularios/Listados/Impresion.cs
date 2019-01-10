using InventarioFod.Clases;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace InventarioFod
{
    public partial class Impresion : Form
    {
        private Impresion_Datos imprimir;
        private string lista;

        
        public Impresion()
        {
            InitializeComponent();
            imprimir = new Impresion_Datos();
            printDocument1.PrinterSettings.DefaultPageSettings.Landscape = true;
            imprimir.Set_controles(l_institucion, l_cantidaEstudiante,l_modelo, l_lista, l_paquete, l_modalidad, l2_institucion, l2_cantEstudiante, l2_modelo, l2_lista, l2_paquete,l2_modalidad, printDocument1);
        }


        private void PrintDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap map = new Bitmap(panel1.Width, panel1.Height);

            panel1.DrawToBitmap(map, new Rectangle(0, 0, panel1.Width + 10, panel1.Height + 10));
            //codigo agregado
            Graphics g = e.Graphics;
            g.PageUnit = GraphicsUnit.Display;
            //AJUSTA LOS MARGENES DE LA PAGINA 
            e.Graphics.DrawImage(map,e.MarginBounds);
           //e.Graphics.DrawImage(map, new RectangleF(0, 0, panel1.Width, panel1.Height));

        }

        public void procesar_impresion()
        {
            imprimir.set_lista = lista;
            Thread hilo = new Thread(imprimir.imprimir_lista);
            hilo.Start();
            Control.CheckForIllegalCrossThreadCalls = false;
        }
        public string Set_lista
        {
            set
            {
                lista = value;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            imprimir.set_lista = lista;
            Thread hilo = new Thread(imprimir.imprimir_lista);
            hilo.Start();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Impresion_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
