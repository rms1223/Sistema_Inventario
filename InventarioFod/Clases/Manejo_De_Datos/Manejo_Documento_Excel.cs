
using InventarioFod.Clases.Entidades;
using InventarioFod.Entidades;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventarioFod.Clases
{
    class Manejo_Documento_Excel
    {
        DataGridView datos;
        private string hoja_reequipamiento = Var_Name.Nombre_Hoja_Reequipamiento;

        MysqlDB db;
        

        public Manejo_Documento_Excel(DataGridView datos_usuario)
        {
            datos = datos_usuario;
            db = MysqlDB.getInstance;
            
        }
        public Manejo_Documento_Excel()
        {
            db = MysqlDB.getInstance;
        }

        private bool isColumnAuth(string nombre_columna)
        {
            bool estado;
            switch (nombre_columna)
            {
                case "Placa":
                    estado = true;
                    break;
                case "Codigo":
                    estado = true;
                    break;
                case "Serie":
                    estado = true;
                    break;
                case "Número_Estación":
                    estado = true;
                    break;
                case "Modalidad":
                    estado = true;
                    break;
                case "Estado_Equipo":
                    estado = true;
                    break;
                case "Institucion":
                    estado = true;
                    break;
                case "Fecha_Inventario":
                    estado = true;
                    break;
                case "Fecha":
                    estado = true;
                    break;
                case "Numero_Paquete":
                    estado = true;
                    break;
                case "Accion":
                    estado = true;
                    break;
                case "Codigo_Accion":
                    estado = true;
                    break;
                case "Tecnico":
                    estado = true;
                    break;
                case "Estado":
                    estado = true;
                    break;
                case "Daños":
                    estado = true;
                    break;
                case "Condicion":
                    estado = true;
                    break;
                case "Número_Serie":
                    estado = true;
                    break;
                case "Danos":
                    estado = true;
                    break;
                case "Descripcion":
                    estado = true;
                    break;
                case "Estado_Accion":
                    estado = true;
                    break;
                default:
                    estado = false;
                    break;
            }
            return estado;
        }

        public void exportar_a_excel()
        {
            try
            {
                SaveFileDialog exportar = new SaveFileDialog();
                exportar.Filter = "Excel (*.xls)| *.xls";
                //exportar.FileName = "ArchivoNuevo";
                if (exportar.ShowDialog() == DialogResult.OK)
                {


                    Microsoft.Office.Interop.Excel.Application aplication;
                    Microsoft.Office.Interop.Excel.Workbook libro;
                    Microsoft.Office.Interop.Excel.Worksheet hoja;

                    aplication = new Microsoft.Office.Interop.Excel.Application();
                    libro = aplication.Workbooks.Add();
                    hoja = (Worksheet)libro.Worksheets[1];
                    int indexColumn = 0;
                    string nombre = String.Empty;
                    
                    foreach (DataGridViewColumn item in datos.Columns)
                    {

                        if (isColumnAuth(item.Name))
                        {
                            indexColumn++;
                            switch (item.Name)
                            {
                                case "Serie":
                                    nombre = "Número_Serie";
                                    hoja.Cells[1, indexColumn] = nombre;
                                    break;
                                case "Modalidad":
                                    nombre = "Estudiante/Docente";
                                    hoja.Cells[1, indexColumn] = nombre;
                                    break;
                                case "Danos":
                                    nombre = "Daños";
                                    hoja.Cells[1, indexColumn] = nombre;
                                    break;
                                case "Estado_Accion":
                                    nombre = "Ubicación";
                                    hoja.Cells[1, indexColumn] = nombre;
                                    break;
                                default:
                                    hoja.Cells[1, indexColumn] = item.Name;
                                    break;
                                
                            }
                            //.Style.Alignment.WrapText = true; 
                            hoja.Cells[1, indexColumn].Interior.Color = XlRgbColor.rgbLightGreen;
                            Range rango = hoja.Cells[1, indexColumn];
                            rango.EntireColumn.AutoFit();
                            Borders border = rango.Borders;
                            //rango.Cells.WrapText = true;
                            border.LineStyle = XlLineStyle.xlContinuous;
                            border.Weight = 2d;

                        }
                    }
                    int indexFila = 0;
                    foreach (DataGridViewRow row in datos.Rows)
                    {
                        indexFila++;
                        indexColumn = 0;
                        foreach (DataGridViewColumn col in datos.Columns)
                        {

                            if (isColumnAuth(col.Name))
                            {
                                indexColumn++;
                                hoja.Cells[indexFila + 1, indexColumn] = row.Cells[col.Name].Value;
                                Range rango = hoja.Cells[indexFila + 1, indexColumn];
                                //Este comando permite ajustar el tamaño de las celdas del excel
                                rango.EntireColumn.AutoFit();
                                Borders border = rango.Borders;
                                //rango.Cells.WrapText = true;
                                border.LineStyle = XlLineStyle.xlContinuous;
                                border.Weight = 2d;
                            }

                        }
                    }

                    libro.SaveAs(exportar.FileName, XlFileFormat.xlWorkbookNormal);
                    libro.Close(true);
                    aplication.Quit();


                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al exportar el Archivo " + ex);
            }

        }

        private string ruta_archivo= string.Empty;
        private OleDbConnection conn;
        private OleDbDataAdapter dataAdapter;
        private string nombre_hoja = Var_Name.Nombre_Hoja;

        //private string nombre_hoja = "Sheet1";
        private System.Data.DataTable dt;

        public void importar_db_acciones(List<string> acciones)
        {
            StringBuilder cadena = new StringBuilder();
            for (int i = 0; i < acciones.Count; i++)
            {

                cadena.Append("Codigo_Accion=" + acciones[i]);
                if (acciones.Count > 1 && i != (acciones.Count - 1))
                {
                    cadena.Append(" OR ");
                }
            }
            dt = db.Importar_DB_Acciones(cadena.ToString());
            DataColumn colum3 = dt.Columns.Add("Estado_Equipo", typeof(String));
            DataColumn column6 = dt.Columns.Add("Condicion", typeof(string));
            DataColumn colum7 = dt.Columns.Add("Daños", typeof(String));
            DataColumn colum6 = dt.Columns.Add("Fecha_Inventario", typeof(String));
            DataColumn colum8 = dt.Columns.Add("Tecnico", typeof(String));
            datos.DataSource = dt;

        }
        public void importar_db_acciones_requipamiento(List<string> acciones)
        {
            StringBuilder cadena = new StringBuilder();
            for (int i = 0; i < acciones.Count; i++)
            {

                cadena.Append("Codigo_Accion=" + acciones[i]);
                if (acciones.Count > 1 && i != (acciones.Count - 1))
                {
                    cadena.Append(" OR ");
                }
            }
            dt = db.Importar_DB_Acciones(cadena.ToString());
            DataColumn column6 = dt.Columns.Add("Numero_Paquete", typeof(string));
            DataColumn colum = dt.Columns.Add("Número_Estación", typeof(Int32));
            DataColumn colum2 = dt.Columns.Add("Estudiante/Docente", typeof(String));
            DataColumn colum3 = dt.Columns.Add("Estado", typeof(String));
            DataColumn colum4 = dt.Columns.Add("Institucion", typeof(String));
            DataColumn colum5 = dt.Columns.Add("Fecha_Inventario", typeof(String));
            DataColumn colum6 = dt.Columns.Add("Tecnico", typeof(String));
            DataColumn colum7 = dt.Columns.Add("Lista", typeof(String));
            datos.DataSource = dt;

        }

        
        public void importar_excel_acciones() {

            if (importar_excel()) {
                try
                {
                    dataAdapter = new OleDbDataAdapter(@"SELECT [Número Serie],Placa,Accion,Descripción FROM [" + nombre_hoja + "$]", conn);
                    dt = new System.Data.DataTable();
                    dataAdapter.Fill(dt);
                    dt.Columns[0].ColumnName = Var_Name.Serie;
                    dt.Columns[3].ColumnName = Var_Name.Descripcion;
                    dt.Columns[2].ColumnName = Var_Name.Codigo_Accion;
                    DataColumn colum3 = dt.Columns.Add("Estado_Equipo", typeof(String));
                    DataColumn column6 = dt.Columns.Add("Condicion", typeof(string));
                    DataColumn colum7 = dt.Columns.Add("Daños", typeof(String));
                    DataColumn colum6 = dt.Columns.Add("Fecha_Inventario", typeof(String));
                    DataColumn colum8 = dt.Columns.Add("Tecnico", typeof(String));
                    datos.DataSource = dt;
                }
                catch (Exception)
                {

                    throw;
                    //MessageBox.Show("Nombre de la Hoja no es el correcto\nVerifique el Excel");
                }
                
            }
            
        }

        public void importar_excel_requipamiento()
        {
            if (importar_excel())
            {
                dataAdapter = new OleDbDataAdapter(@"SELECT [Número Serie],Placa,Accion FROM [" + nombre_hoja + "$]", conn);
                dt = new System.Data.DataTable();
                dataAdapter.Fill(dt);
                DataColumn column6 = dt.Columns.Add("Numero_Paquete", typeof(string));
                DataColumn colum = dt.Columns.Add("Número_Estación", typeof(Int32));
                DataColumn colum2 = dt.Columns.Add("Estudiante/Docente", typeof(String));
                DataColumn colum3 = dt.Columns.Add("Estado", typeof(String));
                DataColumn colum4 = dt.Columns.Add("Institucion", typeof(String));
                DataColumn colum5 = dt.Columns.Add("Fecha_Inventario", typeof(String));
                DataColumn colum6 = dt.Columns.Add("Tecnico", typeof(String));
                DataColumn colum7 = dt.Columns.Add("Lista", typeof(String));

                dt.Columns[0].ColumnName = Var_Name.Serie;
                datos.DataSource = dt;
            }
        }
        public void importar_excel_accionesprincipal() {
            if (importar_excel())
            {
                try
                {
                    dataAdapter = new OleDbDataAdapter(@"SELECT [Número Serie],Placa,Descripción FROM [" + nombre_hoja + "$]", conn);
                    dt = new System.Data.DataTable();
                    dataAdapter.Fill(dt);
                    dt.Columns[0].ColumnName = Var_Name.Serie;
                    dt.Columns[2].ColumnName = Var_Name.Descripcion;
                    datos.DataSource = dt;
                }
                catch (Exception)
                {

                    throw new Exception("El nombre de la Hoja no es el Correcto Ingrese uno nuevo");
                }
                
            }
        }

        private Boolean importar_excel()
        {
            Boolean estado = false;
            try
            {
                OpenFileDialog file = new OpenFileDialog();
                file.Filter = "Archivos excel (*.xls)|*.xls|All files (*.*)|*.*";
                //file.Filter = "Archivos excel |*.xls";
                file.Title = "Seleccione la acción a cargar";
                if (file.ShowDialog() == DialogResult.OK)
                {
                    if (file.FileName.Equals("") == false)
                    {
                        ruta_archivo = file.FileName;
                        conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + ruta_archivo + "; Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=1;MAXSCANROWS=0'");
                       
                        estado = true;
                    }
                }
 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al procesar\n" + ex);
            }
            return estado;
        }


        

        public void obtener_equipo_acciones(string comando,string accion)
        {
            if (accion.Equals(Var_Name.Acciones.ToUpper()))
            {
                int valor = Convert.ToInt32(comando);
                datos.DataSource = db.Obtener_Acciones(valor);
            }
            else
            {
                datos.DataSource = db.Obtener_Acciones(comando, accion);
            }
            
        }

        //Metodos agregados para el Manejo de las listas
        public void importar_excel_listas()
        {
            if (importar_excel())
            {
                try
                {
                    conn.Open();
                    //
                    int contador = 0;
                    int total_estu = 0;
                    int total_docen = 0;
                    int total_prescolar = 0;
                    System.Data.DataTable tabla = new System.Data.DataTable();
                    string sql = @"SELECT [Listado No],Código,[Nombre del Centro Educativo],Cartel,[Modelo Equipamiento],Beneficiado,[Primer Apellido] FROM [" + hoja_reequipamiento + "$]";
                    DataColumn col4 = tabla.Columns.Add(Var_Name.Listado, typeof(String));
                    DataColumn col5 = tabla.Columns.Add(Var_Name.Codigo_Institucion, typeof(String));
                    DataColumn col6 = tabla.Columns.Add(Var_Name.Nombre_Institucion, typeof(String));
                    DataColumn col7 = tabla.Columns.Add(Var_Name.Tipo_Modalidad, typeof(String));
                    DataColumn col8 = tabla.Columns.Add(Var_Name.Tipo_Cartel, typeof(String));
                    DataColumn col3 = tabla.Columns.Add(Var_Name.Tipo_Equipo, typeof(String));
                    DataColumn col1 = tabla.Columns.Add(Var_Name.Total_Equipos, typeof(int));
                    DataColumn col2 = tabla.Columns.Add(Var_Name.Total_Paquetes, typeof(int));
                    DataColumn col10 = tabla.Columns.Add(Var_Name.Modelo_Equipo, typeof(String));
                    using (OleDbCommand comando = new OleDbCommand(sql, conn))
                    {

                        using (OleDbDataReader reader = comando.ExecuteReader())
                        {
                            Equipos_Listados equipo_lis = new Equipos_Listados();
                            while (reader.Read())
                            {
                                string codigo_siguiente = reader[Var_Name.Codigo_Requi].ToString();

                                if (String.IsNullOrEmpty(equipo_lis.codigo_equipo))
                                {

                                    equipo_lis.lista_actual = reader[Var_Name.Listado_Requi].ToString();
                                    equipo_lis.codigo_equipo = reader[Var_Name.Codigo_Requi].ToString();
                                    equipo_lis.inst_actual = reader[Var_Name.Institucion_Requi].ToString();
                                    equipo_lis.tipo_actual = reader[Var_Name.Beneficiario_Requi].ToString();
                                    equipo_lis.cartel_actual = reader[Var_Name.Cartel_Requi].ToString();
                                    equipo_lis.modelo_actual = reader[Var_Name.Modelo_Requi].ToString();
                                    equipo_lis.modelo_equipo_actual = obtener_maquina(reader[Var_Name.Cartel_Requi].ToString());
                                    if (reader[Var_Name.Apellido_Requi].ToString().ToUpper().Contains("PREESCOLAR"))
                                    {
                                        equipo_lis.apellido_actual = reader[Var_Name.Apellido_Requi].ToString();
                                    }

                                }
                                if (codigo_siguiente.Equals(equipo_lis.codigo_equipo))
                                {
                                    if (reader[Var_Name.Beneficiario_Requi].ToString().Equals("Docente") || reader[Var_Name.Beneficiario_Requi].ToString().Equals("Docentes"))
                                    {
                                        total_docen += 1;
                                    }
                                    else if (reader[Var_Name.Beneficiario_Requi].ToString().Equals("Estudiantes") && !reader[Var_Name.Apellido_Requi].ToString().ToUpper().Contains("PREESCOLAR"))
                                    {

                                        total_estu += 1;
                                    }
                                    if (reader[Var_Name.Apellido_Requi].ToString().ToUpper().Contains("PREESCOLAR"))
                                    {

                                        total_prescolar += 1;
                                    }

                                    contador += 1;

                                }
                                else
                                {

                                    tabla.Rows.Add(equipo_lis.lista_actual, equipo_lis.codigo_equipo, equipo_lis.inst_actual, equipo_lis.modelo_actual, equipo_lis.cartel_actual, validar_totales(total_estu, total_docen, total_prescolar), contador, Reequipamiento.get_paquetes(contador), equipo_lis.modelo_equipo_actual);

                                    equipo_lis.lista_actual = reader[Var_Name.Listado_Requi].ToString();
                                    equipo_lis.codigo_equipo = reader[Var_Name.Codigo_Requi].ToString();
                                    equipo_lis.inst_actual = reader[Var_Name.Institucion_Requi].ToString(); ;
                                    equipo_lis.tipo_actual = reader[Var_Name.Beneficiario_Requi].ToString();
                                    equipo_lis.cartel_actual = reader[Var_Name.Cartel_Requi].ToString(); ;
                                    equipo_lis.modelo_actual = reader[Var_Name.Modelo_Requi].ToString(); ;
                                    equipo_lis.modelo_equipo_actual = obtener_maquina(reader[Var_Name.Cartel_Requi].ToString()); ;
                                    equipo_lis.apellido_actual = reader[Var_Name.Apellido_Requi].ToString();

                                    contador = 0;
                                    total_docen = 0;
                                    total_prescolar = 0;
                                    total_estu = 0;

                                    if (reader[Var_Name.Beneficiario_Requi].ToString().Equals("Docente") || reader[Var_Name.Beneficiario_Requi].ToString().Equals("Docentes"))
                                    {
                                        total_docen += 1;
                                    }
                                    else if (reader[Var_Name.Beneficiario_Requi].ToString().Equals("Estudiantes") && !reader[Var_Name.Apellido_Requi].ToString().ToUpper().Contains("PREESCOLAR"))
                                    {
                                        total_estu += 1;
                                    }
                                    if (reader[Var_Name.Apellido_Requi].ToString().ToUpper().Contains("PREESCOLAR"))
                                    {
                                        total_prescolar += 1;
                                    }

                                    contador += 1;

                                }

                            }
                            if (!String.IsNullOrEmpty(equipo_lis.codigo_equipo))
                            {
                                tabla.Rows.Add(equipo_lis.lista_actual, equipo_lis.codigo_equipo, equipo_lis.inst_actual, equipo_lis.modelo_actual, equipo_lis.cartel_actual, validar_totales(total_estu, total_docen, total_prescolar), contador, Reequipamiento.get_paquetes(contador), equipo_lis.modelo_equipo_actual);

                            }

                        }
                        datos.DataSource = tabla;
                        conn.Close();


                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al importar el archivo\n" + ex);
                }
            }
        }
        string cartel_maquina = String.Empty;
        private string obtener_maquina(string maquina)
        {

            if (maquina.StartsWith("2012"))
            {
                cartel_maquina = "DELL LATITUDE 2120";
            }
            else if (maquina.StartsWith("2013"))
            {
                cartel_maquina = "DELL 3330";
            }
            else if (maquina.StartsWith("2014"))
            {
                cartel_maquina = "HP 430 G2";
            }
            else if (maquina.StartsWith("2015"))
            {
                cartel_maquina = "HP 11 G1";
            }
            else
            {
                cartel_maquina = "HP 440 G3";
            }
            return cartel_maquina;
        }

        private string validar_totales(int estudiantes, int docentes, int prescolar)
        {
            string tipo = String.Empty;
            if (docentes == 0 && prescolar == 0 && estudiantes != 0)
            {
                tipo = estudiantes + " ESTUDIANTE(S)";
            }
            else if (estudiantes == 0 && prescolar == 0 && docentes != 0)
            {
                tipo = docentes + " DOCENTE(S)";
            }
            else if (estudiantes == 0 && docentes == 0 && prescolar != 0)
            {
                tipo = prescolar + " PREESCOLAR";
            }
            else if (estudiantes != 0 && docentes != 0 && prescolar == 0)
            {
                tipo = estudiantes + " ESTUDIANTE(S) " + docentes + " DOCENTE(S)";
            }
            else if (estudiantes != 0 && prescolar != 0 && docentes == 0)
            {
                tipo = estudiantes + " ESTUDIANTE(S) " + prescolar + " PRESCOLAR";
            }
            else
            {
                tipo = estudiantes + " ESTUDIANTE(S) " + docentes + " DOCENTE(S) " + prescolar + " PRESCOLAR";
            }
            return tipo;
        }


        //Metodo Utilizado para Buscar Codigo de la institucion
        //DENTRO DEL DATAGRIDVIEW
        public void buscar_codigo(string codigo)
        {
            bool estado = false;
            datos.AllowUserToAddRows = false;
            foreach (DataGridViewRow item in datos.Rows)
            {
                if (item.Cells[Var_Name.Codigo_Institucion].Value.Equals(codigo))
                {
                    datos.Rows[item.Index].DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;
                    datos.FirstDisplayedScrollingRowIndex = item.Index;
                    item.Selected = true;
                    estado = true;
                    break;
                }
            }
            datos.AllowUserToAddRows = true;
            if (!estado)
            {
                MessageBox.Show("No existe el codigo " + codigo);
            }
        }



        //Metodo Utilizado para guardar el listado
        public void guardar_listado()
        {
            bool estado = false;
            datos.AllowUserToAddRows = false;
            Listado listado_acciones = new Listado();
            foreach (DataGridViewRow item in datos.Rows)
            {


                listado_acciones.lista = Convert.ToInt32(item.Cells[Var_Name.Listado].Value);
                listado_acciones.codigo = item.Cells[Var_Name.Codigo_Institucion].Value.ToString();
                listado_acciones.nombre = item.Cells[Var_Name.Nombre_Institucion].Value.ToString();
                listado_acciones.modalidad = item.Cells[Var_Name.Tipo_Modalidad].Value.ToString();
                listado_acciones.cartel = item.Cells[Var_Name.Tipo_Cartel].Value.ToString();
                listado_acciones.equipo = item.Cells[Var_Name.Tipo_Equipo].Value.ToString();
                listado_acciones.total_maquinas = Convert.ToInt32(item.Cells[Var_Name.Total_Equipos].Value);
                listado_acciones.total_paquetes = Convert.ToInt32(item.Cells[Var_Name.Total_Paquetes].Value);
                listado_acciones.tipo = item.Cells[Var_Name.Modelo_Equipo].Value.ToString();

                estado = db.Guardar_Listado(listado_acciones);
                if (!estado)
                {
                    break;
                }

            }
            if (estado)
            {
                MessageBox.Show("Datos Guardados Correctamente.........");
            }
            datos.AllowUserToAddRows = true;
        }


        public void get_listado_por_codigo(string codigo)
        {
            datos.DataSource = db.Listar_Registro(codigo);
        }



        //Metodos utilizados para guaradar las acciones y los 
        //Equipos asociados a esta.
        public void guaradar_equipos_acciones(int accion)
        {
            bool estado_ope = true;
            datos.AllowUserToAddRows = false;
            foreach (DataGridViewRow item in datos.Rows)
            {

                if (!String.IsNullOrEmpty(item.Cells[Var_Name.Placa].Value.ToString()))
                {
                    db.Insertar_Equipo_Acciones(new Equipo_Acciones(accion, item.Cells[Var_Name.Serie].Value.ToString(), item.Cells[Var_Name.Placa].Value.ToString(), item.Cells[Var_Name.Descripcion].Value.ToString()));
                }
            }
            if (estado_ope)
            {
                MessageBox.Show("Datos Guardados....");
            }
            datos.AllowUserToAddRows = true;
        }

        //Metodos para guarar los inventarios de proveedor asi como
        // El de las acciones

        public bool Insertar_Inventarios_Malas_Acciones(Inventario_Malas inven_malas,string query)
        {
            return db.Insertar_Registros_Malas(inven_malas,query);
        }

        public bool Insertar_Inventarios_Malas_Proveedor(Equipos_Proveedor equi_proveedor)
        {
            return db.Insertar_Equipos_Proveedor(equi_proveedor);
        }

        public bool Inventario_Equipos_Reequipamiento(Equipos_Reequipamiento equi_requi,string query)
        {
            return db.Insertar_Registros_Reequipamiento(equi_requi,query);
        }
        public void Insertar_Institucion(Institucion institucion)
        {
            db.Guardar_Institucion(institucion);
        }
        public void insertar_acciones(Acciones accion)
        {
            db.Insertar_Acciones(accion);
        }
    }
}
