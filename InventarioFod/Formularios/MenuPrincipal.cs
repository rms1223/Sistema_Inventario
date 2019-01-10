using InventarioFod.Clases;
using InventarioFod.Formularios.Consultas;
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
    public partial class MenuPrincipal : Form
    {
        private MysqlDB datos;
        public MenuPrincipal()
        {
            InitializeComponent();
            datos = MysqlDB.getInstance;
            datos.Estado_Tecnicos = true;
            datos.GET_Ubicaciones();
            datos.Get_Tipos_Inventarios();
            datos.Get_Tecnicos();
            label3.Text = "RMS " + DateTime.Now.ToString("yyyy");
            treeView1.ExpandAll();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            datos.Cerrar_Conexion();
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cargar_panel(new principal());
        }

        private void cargar_panel(Object panel)
        {
            
            if (this.panelPrincipal.Controls.Count > 0)
            {
                this.panelPrincipal.Controls.RemoveAt(0);
            }

            
            Form panel_in = panel as Form;
            panel_in.TopLevel = false;
            panel_in.Dock = DockStyle.Fill;
            this.panelPrincipal.Controls.Add(panel_in);
            this.panelPrincipal.Tag = panel_in;
            panel_in.Show();
            
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Name.Equals("inven_reeequi"))
            {
                cargar_panel(new principal());
            }
            else if (e.Node.Name.Equals("inven_acciones"))
            {
                cargar_panel(new Form_Malas());
            } else if (e.Node.Name.Equals("addAccion"))
            {
                cargar_panel(new CargarAcciones());
            } else if (e.Node.Name.Equals("list_reequi"))
            {
                cargar_panel(new Lista_inventario());
            } else if (e.Node.Name.Equals("add_lista"))
            {
                cargar_panel(new AgregarLista());
            } else if (e.Node.Name.Equals("list_accion"))
            {
                cargar_panel(new Lista_Acciones());
            } else if (e.Node.Name.Equals("print_list"))
            {
                cargar_panel(new Agregar_imp_list());
            } else if (e.Node.Name.Equals("consul_List"))
            {
                cargar_panel(new Consulta_Listado());
            }
        }
    }
}
