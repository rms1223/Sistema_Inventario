

using InventarioFod.Clases.Entidades;
using InventarioFod.Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace InventarioFod.Clases
{
    class MysqlDB
    {

        //Parametros de conexion para 
        //Pruebas locales
        private MySqlConnection conn = null;
        private string servidor = Var_Name.Servidor;
        private string usuario = Var_Name.Usuario;
        private string pass = Var_Name.password;
        private string db = Var_Name.nombre_db;

        //Manejo de transacciones MYSQL
        MySqlTransaction trans;

        private Dictionary<string, string> totales;
        private MySqlCommand comando;
        //private MySqlDataReader lector;
        private MySqlDataAdapter adaptador;
        private int total_maquinas = 0;
        private static MysqlDB base_datos = null;


        //Metodos para almacenar los valores con ccodigo y valor de la base de datos
        private Dictionary<string, int> total_tecnico = new Dictionary<string, int>();
        private Dictionary<string, int> total_ubicaciones = new Dictionary<string, int>();
        private Dictionary<string, int> total_tipoinventarios = new Dictionary<string, int>();

        public bool Estado_Tecnicos { get; set; }

        private MysqlDB()
        {
            totales = new Dictionary<string, string>();
            establecer_conexion();
            comando = new MySqlCommand();
            comando.Connection = conn;
            
           
        }

        public static MysqlDB getInstance
        {
            get
            {
                if (base_datos == null)
                {
                    base_datos = new MysqlDB();
                }
                return base_datos;
            }
        }


        public void establecer_conexion()
        {
            try
            {
                string connexion = "Server=" + servidor + ";Database=" + db + ";port=3306;User Id=" + usuario + ";password=" + pass;
                conn = new MySqlConnection(connexion);
                conn.Open();
            }
            catch (MySqlException ex)
            {

                MessageBox.Show("Error al conectar\n" + ex);
            }

        }
        

        //METODOS AGREGADOS
        public bool eliminar_equipos_proveedor(string placa, string serie)
        {
            try
            {

                trans = conn.BeginTransaction();
                string sql = "DELETE FROM reparacion_proveedor  WHERE Serie='" + serie + "' AND Placa='" + placa + "'";
                comando = new MySqlCommand(sql, conn);
                comando.ExecuteNonQuery();
                trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                MessageBox.Show("Error\n" + ex);
                return false;

            }
        }


        public bool Insertar_Registros_Malas(Inventario_Malas inven_malas,string query) //METODO UTILIZADO PARA ACTUALIZAR E INSERTAR REGISTROS
        {
            trans = conn.BeginTransaction();
            using (MySqlCommand cmd = new MySqlCommand())
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = conn;
                        cmd.CommandText = "insertar_inventario_malas";
                        cmd.Parameters.AddWithValue("serie", inven_malas.Serie);
                        cmd.Parameters.AddWithValue("placa",inven_malas.Placa);
                        cmd.Parameters.AddWithValue("descripcion",inven_malas.Descripcion);
                        cmd.Parameters.AddWithValue("danos",inven_malas.Danos);
                        cmd.Parameters.AddWithValue("estado_equipo", total_ubicaciones[inven_malas.Estado_Equipo]);
                        cmd.Parameters.AddWithValue("fecha_inventario",inven_malas.Fecha);
                        cmd.Parameters.AddWithValue("tecnico",total_tecnico[inven_malas.Tecnico]);
                        cmd.Parameters.AddWithValue("accion",inven_malas.Accion);
                        cmd.Parameters.AddWithValue("estado",inven_malas.Estado);
                        cmd.Parameters.AddWithValue("tipo_consulta", query);

                        cmd.ExecuteNonQuery();
                        
                    }
                    catch (MySqlException)
                    {

                        throw ;
                    }
                }
            trans.Commit();
            return true;
        }

        public bool Eliminar_Registros_Malas(string serie, string placa,string accion)
        {
            try
            {
                trans = conn.BeginTransaction();
                string sql = "DELETE FROM inventario_malas WHERE Serie='" + serie + "' AND Placa='" + placa + "' AND Accion='" + accion + "'";
                comando = new MySqlCommand(sql, conn);
                comando.ExecuteNonQuery();
                trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                MessageBox.Show("Error\n" + ex);
                return false;

            }

        }


        public List<string> obtener_listas()
        {
            try
            {
                var lista = new List<string>();
                string sql = "SELECT DISTINCT Listado FROM requipamiento ORDER BY Listado ASC";
                comando = new MySqlCommand(sql, conn);
                using (MySqlDataReader lector = comando.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        lista.Add(lector["Listado"].ToString());
                    }
                    return lista;
                } 
            }
            catch (Exception)
            {

                throw;
            }



        }

        public DataTable Actualizar_Estado(string lista)
        {
            try
            {
                trans = conn.BeginTransaction();
                string sql = "UPDATE lista_inventarios SET Estado_Listado = 'ASIGNADO' WHERE Estado_Listado = 'NO ASIGNADO' AND Listado ='" + lista + "'";
                comando = new MySqlCommand(sql, conn);
                comando.ExecuteNonQuery();
                trans.Commit();
                return Obtener_Datos();
            }
            catch (Exception)
            {

                trans.Rollback();
                throw;
            }
        }

        public void Eliminar_Datos_Reequipamiento(string listado, string serie, string placa)
        {
            try
            {
                trans = conn.BeginTransaction();
                string consulta = "DELETE FROM lista_inventarios WHERE Listado ='" + listado + "' AND Serie='" + serie + "' AND Placa='" + placa + "';";
                comando = new MySqlCommand(consulta, conn);
                comando.ExecuteNonQuery();
                trans.Commit();
            }
            catch (Exception)
            {
                trans.Rollback();
                throw;
            }
        }

        public DataTable Obtener_Datos_Acciones(string valor, string accion)
        {
            try
            {
                string consulta = String.Empty;
                DataTable tabla2 = new DataTable();
                string sql = "SELECT COUNT(*) as Total  FROM inventario_malas WHERE Accion LIKE '%" + valor + "%'";
                comando.CommandText = sql;

                using (MySqlDataReader lector = comando.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        total_maquinas = lector.GetInt32("Total");
                    }
                    
                }
                switch (accion)
                {
                    
                    case "Placa":
                        tabla2 = procesar_datos_accion(valor,"PLACA");
                        break;
                    case "Serie":
                        tabla2 = procesar_datos_accion(valor, "SERIE");
                        break;
                    case "Accion":
                        consulta = "SELECT *  FROM inventario_malas WHERE Accion LIKE '%" + valor + "%' ORDER BY Placa";
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            try
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Connection = conn;
                                cmd.CommandText = "p_inventario_malas";
                                cmd.Parameters.AddWithValue("accion", valor);
                                adaptador = new MySqlDataAdapter(cmd);
                                adaptador.Fill(tabla2);
                            }
                            catch (Exception)
                            {

                                throw;
                            }
                        }
                        break;
                    case "Tecnico":
                        tabla2 = procesar_datos_accion(valor, "TECNICO");
                        break;
                    default:
                        consulta = "SELECT * FROM view_inventario_malas";
                        string sql2 = "SELECT COUNT(*) as Total FROM view_inventario_malas";
                        comando.CommandText = sql2;
                        using (MySqlDataReader lector = comando.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                total_maquinas = lector.GetInt32("Total");
                            }

                        }
                        adaptador = new MySqlDataAdapter(consulta, conn);
                        adaptador.Fill(tabla2);
                        break;
                }
                
                
                return tabla2;
            }
            catch (MySqlException ex)
            {

                MessageBox.Show("Error al Procesar Cliente\n"+ex);
                return new DataTable();
            }
            
        }


        private DataTable procesar_datos_accion(string placa_serie, string tipo)
        {
            DataTable tabla_datos_accion = new DataTable();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conn;
                    cmd.CommandText = "p_buscar_inventario_malas";
                    cmd.Parameters.AddWithValue("serie_placa", placa_serie);
                    cmd.Parameters.AddWithValue("tipo_consulta", tipo);
                    adaptador = new MySqlDataAdapter(cmd);
                    adaptador.Fill(tabla_datos_accion);
                    return tabla_datos_accion;
                }
                catch (Exception)
                {

                    throw;
                }
            }

        }

        public Dictionary<string, string> get_total_equiposAccion(string accion)//**********Falta Implementarle mejoras
        {
            try
            {
                totales.Clear();
                int buenas = 0;
                int malas = 0;
                int total = 0;
                string tecnico = String.Empty;
                string accion_usuario = String.Empty;
                string fecha = String.Empty;
                string sql = string.Empty;
                string estado_accion = String.Empty;
                if (accion.Equals("TODAS"))
                {
                    sql = "SELECT Estado,Tecnico,Accion,Fecha_Inventario,Estado_Accion FROM inventario_malas";

                }
                else
                {
                    sql = "SELECT Estado,Tecnico,Accion,Fecha_Inventario,Estado_Accion FROM inventario_malas WHERE Accion='" + accion + "';";
                }

                //comando = new MySqlCommand(sql, conn);
                comando.CommandText = sql;
                using (MySqlDataReader lector = comando.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        if (!tecnico.Contains(lector[Var_Name.Tecnico].ToString()))
                        {
                            tecnico += lector[Var_Name.Tecnico].ToString() + " ";
                        }
                        if (!accion_usuario.Contains(lector[Var_Name.Accion].ToString()))
                        {
                            accion_usuario += lector[Var_Name.Accion].ToString() + " ";
                        }
                        switch (lector["Estado"].ToString())
                        {
                            case "BUEN ESTADO":
                                buenas++;
                                break;
                            case "MAL ESTADO":
                                malas++;
                                break;
                            default:
                                break;
                        }
                        fecha = lector["Fecha_Inventario"].ToString();
                        estado_accion = lector["Estado_Accion"].ToString();
                        total++;
                    }
                    totales.Add("Buenas", buenas.ToString());
                    totales.Add("Malas", malas.ToString());
                    totales.Add("Total", total.ToString());
                    totales.Add("Tecnico", tecnico);
                    totales.Add("Fecha", fecha);
                    totales.Add("Accion", accion_usuario);
                    totales.Add("Ubicacion", estado_accion);
                }

            }
            catch (Exception)
            {

                throw;
            }



            return totales;
        }
        public DataTable Obtener_Datos_Lista_Reequipamiento(string comando, string accion)
        {
            try
            {
                DataTable tabla2 = new DataTable();

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conn;
                    if (accion.Equals("Listado"))
                    {
                        int valor = Convert.ToInt32(comando);
                        cmd.CommandText = "p_buscar_lista_inventarios_lista";
                        cmd.Parameters.AddWithValue("listado", valor);
                    }
                    else
                    {
                        cmd.CommandText = "p_buscar_lista_inventarios";
                        cmd.Parameters.AddWithValue("comando", comando);
                        cmd.Parameters.AddWithValue("accion", accion);
                    }
                    adaptador = new MySqlDataAdapter(cmd);
                    adaptador.Fill(tabla2);
                }
                

                return tabla2;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public DataTable Filtrar_Datos(string lista, string estado)
        {
            //filtrar_datos_listado
            DataTable tabla = new DataTable();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "filtrar_datos_listado";
                    cmd.Connection = conn;
                    cmd.Parameters.AddWithValue("listado",Convert.ToInt32(lista));
                    cmd.Parameters.AddWithValue("estado",estado);
                    adaptador = new MySqlDataAdapter(cmd);
                    adaptador.Fill(tabla);
                    return tabla;
                }
                catch (Exception)
                {

                    throw;
                }
            }

        }

        public DataTable Obtener_Datos()
        {
            try
            {
                DataTable tabla = new DataTable();
                string sql = "SELECT * FROM lista_inventarios ORDER BY Institucion ASC,Numero_Estacion ASC,Modalidad";
                adaptador = new MySqlDataAdapter(sql, conn);
                adaptador.Fill(tabla);
                return tabla;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public string Obtener_Institucion(string codigo)
        {
            string institucion = string.Empty;
            string sql = "select Centro_educativo from instituciones where Codigo = '" + codigo + "'";
            comando = new MySqlCommand(sql, conn);
            using (MySqlDataReader lector = comando.ExecuteReader())
            {
                if (lector.Read())
                {
                    institucion = lector["Centro_educativo"].ToString() + "(" + codigo + ")";
                }
                else
                {
                    institucion = "No existe";
                }

                return institucion;
            }
            
        }
        public void Actualizar_Estado_Accion(string accion)
        {
            try
            {
                string sql = "UPDATE inventario_malas SET Estado_Accion='BODEGA' WHERE Accion = '" + accion + "' AND Estado_Equipo = 'DEVOLUCION BODEGA';";
                comando = new MySqlCommand(sql, conn);
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable Obtener_Proveedor_Datos(string placa, string inventario)
        {
            try
            {
                string sql = string.Empty;
                DataTable tabla = new DataTable();
                switch (inventario)
                {
                    case "PROVEEDOR BUENAS":
                        sql = "SELECT * FROM reparacion_proveedor WHERE Placa ='" + placa + "'";
                        break;
                    case "PROVEEDOR MALAS":
                        sql = "SELECT * FROM reparacion_proveedor_malas WHERE Placa ='" + placa + "'";
                        break;
                    case "PROVEEDOR BODEGA":
                        sql = "SELECT * FROM reparacion_proveedor_bodega WHERE Placa ='" + placa + "'";
                        break;
                    default:
                        break;
                }
                adaptador = new MySqlDataAdapter(sql, conn);
                adaptador.Fill(tabla);
                return tabla;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable Obtener_Datos_Reparacion_Proveedor(String estado_accion)
        {
            try
            {

                string consulta = String.Empty;
                string consulta2 = string.Empty;
                DataTable tabla2 = new DataTable();
                switch (estado_accion)
                {
                    case "PROVEEDOR BUENAS":
                        consulta = "SELECT *  FROM reparacion_proveedor";
                        consulta2 = "SELECT COUNT(*) AS Total FROM reparacion_proveedor";
                        break;
                    case "PROVEEDOR MALAS":
                        consulta = "SELECT *  FROM reparacion_proveedor_malas";
                        consulta2 = "SELECT COUNT(*) AS Total FROM reparacion_proveedor_malas";
                        break;
                    case "PROVEEDOR BODEGA":
                        consulta = "SELECT *  FROM reparacion_proveedor_bodega";
                        consulta2 = "SELECT COUNT(*) AS Total FROM reparacion_proveedor_bodega";
                        break;
                    case "PROVEEDOR EN CENTRO SOPORTE":
                        consulta = "SELECT *  FROM reparacion_proveedor WHERE Ubicacion = 'CENTRO DE SOPORTE'";
                        consulta2 = "SELECT COUNT(*) AS Total FROM reparacion_proveedor WHERE Ubicacion = 'CENTRO DE SOPORTE'";

                        break;
                    default:
                        break;
                }
                adaptador = new MySqlDataAdapter(consulta, conn);
                adaptador.Fill(tabla2);
                comando = new MySqlCommand(consulta2, conn);
                using (MySqlDataReader lector = comando.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        total_maquinas = Convert.ToInt32(lector["Total"]);
                    }
                }
                return tabla2;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public DataTable Consulta_Personalizada(string consulta)
        {
            try
            {
                DataTable data = new DataTable();
                adaptador = new MySqlDataAdapter(consulta, conn);
                adaptador.Fill(data);
                return data;
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        public int Get_Codigo_Tecnico(string nombre)
        {
            return total_tecnico[nombre];
        }
        public int Get_Codigo_Ubicacion(string ubicacion)
        {

            return total_ubicaciones[ubicacion];
        }
        public int Get_Codigo_Inventario(string nombre_inventario)
        {
            return total_tipoinventarios[nombre_inventario];
        }
        public List<string> Ubicaciones_Inventario { get; } = new List<string>();
        public List<string> Tipos_Inventarios { get; } = new List<string>();


        public void GET_Ubicaciones()//Metodo para obtener las ubicaciones para los inventarios de acciones y proveedor
        {
            string sql = "SELECT Codigo,Nombre FROM ubicacion";
            comando = new MySqlCommand(sql, conn);
            using (MySqlDataReader lector = comando.ExecuteReader())
            {
                while (lector.Read())
                {
                    Ubicaciones_Inventario.Add(lector["Nombre"].ToString());
                    total_ubicaciones.Add(lector["Nombre"].ToString(), lector.GetInt32("Codigo"));

                }
            }
        }
        public void Get_Tipos_Inventarios()//Metodo para obtener los tipos de invenarios y almacenarlos en un diccionario para conversiones
        {
            string sql = "SELECT Codigo,Nombre FROM tipos_inventarios_equipos";
            comando = new MySqlCommand(sql,conn);
            using (MySqlDataReader reader = comando.ExecuteReader())
            {
                while (reader.Read())
                {
                    Tipos_Inventarios.Add(reader["Nombre"].ToString());
                    total_tipoinventarios.Add(reader["Nombre"].ToString(), reader.GetInt32("Codigo"));
                }
            }

        }
        public List<string> Get_Tecnicos()//Metodo para obtener listado de Tecnicos en la base de datos
        {
            List<string> tecnicos = new List<string>();
            string sql = "SELECT Codigo,Tecnico FROM tecnicos";
            comando = new MySqlCommand(sql,conn);
            using (MySqlDataReader lector = comando.ExecuteReader())
            {
                while (lector.Read())
                {
                    tecnicos.Add(lector["Tecnico"].ToString());
                    if (Estado_Tecnicos)
                    {
                        total_tecnico.Add(lector["Tecnico"].ToString(), lector.GetInt32("Codigo"));
                    }
                    
                }
            }
            Estado_Tecnicos = false;
            return tecnicos;
        }
        public List<string> Get_Danos()//Metodo para obtener listado de Daños de la base de datos
        {
            List<string> danos = new List<string>();
            string sql = "SELECT Dano FROM danos";
            comando = new MySqlCommand(sql, conn);
            using (MySqlDataReader lector = comando.ExecuteReader())
            {
                while (lector.Read())
                {
                    danos.Add(lector["Dano"].ToString());
                }
            }

            return danos;
        }

        


        //Aqui iniciamos  con los nuevos metodos para la integracion con el nuevo sistema

        //Metedo para cargar la accion segun su numero
        public DataTable Obtener_Acciones(int accion)
        {
            try
            {
                string consulata = "SELECT * FROM equipo_acciones WHERE Codigo_Accion = '"+accion+"'";
                DataTable tabla = new DataTable();
                adaptador = new MySqlDataAdapter(consulata, conn);
                adaptador.Fill(tabla);
                return tabla;
            }
            catch (MySqlException)
            {

                throw;
            }
        }
        //Metodo sobrecargado para buscar equipos en las acciones ya sea
        //por medio de la placa o la serie
        public DataTable Obtener_Acciones(string comando, string accion)
        {
            DataTable tabla = new DataTable();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "p_buscar_equipos_acciones";
                    cmd.Connection = conn;
                    cmd.Parameters.AddWithValue("comando",comando);
                    cmd.Parameters.AddWithValue("accion",accion);

                    adaptador = new MySqlDataAdapter(cmd);
                    adaptador.Fill(tabla);
                    return tabla;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
        public DataTable Importar_DB_Acciones(string accion)
        {
            try
            {
                DataTable tabla = new DataTable();
                string consulta = "SELECT Serie,Placa,Codigo_Accion,Descripcion FROM equipo_acciones WHERE ";
                consulta += accion;
                adaptador = new MySqlDataAdapter(consulta,conn);
                adaptador.Fill(tabla);
                return tabla;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void Guardar_Institucion(Institucion institucion)
        {
            //p_insertar_institucion
            using (MySqlCommand cmd = new MySqlCommand())
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "p_insertar_institucion";
                    cmd.Connection = conn;
                    cmd.Parameters.AddWithValue("codigo",institucion.codigo); 
                    cmd.Parameters.AddWithValue("centro_educativo",institucion.nombre);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
        public List<string> Seleccionar_Lista()
        {
            List<string> lista = new List<string>();
            string consulta = "select distinct Listado from requipamiento order by Listado asc ";
            MySqlCommand comando = new MySqlCommand(consulta, conn);
            using (MySqlDataReader lector = comando.ExecuteReader())
            {
                while (lector.Read())
                {
                    lista.Add(lector["Listado"].ToString());
                }
            }
            return lista;
        }
        public DataTable Listar_Registro(string num_lista)
        {
            string consulta = string.Empty;
            consulta = "SELECT r.Listado,r.Codigo,i.Centro_educativo,r.total_maquinas,r.total_paquetes,r.modalidad,r.tipo,r.equipo,r.cartel  from requipamiento r, instituciones i  WHERE r.Codigo = i.Codigo AND Listado = '" + num_lista + "' order by Codigo asc";
            DataTable tabla = new DataTable();
            adaptador = new MySqlDataAdapter(consulta, conn);
            adaptador.Fill(tabla);
            return tabla;
        }
        public MySqlDataReader Listar_Registro_Impresion(string num_lista, string tipo)
        {
            string consulta;
            if (tipo.Equals("pequenos"))
            {

                consulta = "SELECT r.Listado,r.Codigo,i.Centro_educativo,r.total_maquinas,r.total_paquetes,r.modalidad,r.tipo,r.equipo,r.cartel  from requipamiento r, instituciones i  WHERE r.Codigo = i.Codigo AND Listado = '" + num_lista + "' AND total_paquetes = '1' order by total_paquetes ASC ";
            }
            else
            {

                consulta = "SELECT r.Listado,r.Codigo,i.Centro_educativo,r.total_maquinas,r.total_paquetes,r.modalidad,r.tipo,r.equipo,r.cartel  from requipamiento r, instituciones i  WHERE r.Codigo = i.Codigo AND Listado = '" + num_lista + "' AND total_paquetes >= '2' order by total_paquetes ASC ";
            }

            comando = new MySqlCommand(consulta, conn);
            return comando.ExecuteReader();

        }
        public bool Guardar_Listado(Listado lista_requi)
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conn;
                    cmd.CommandText = "p_insertar_reequipamiento";
                    cmd.Parameters.AddWithValue("listado",lista_requi.lista);
                    cmd.Parameters.AddWithValue("codigo", lista_requi.codigo);
                    cmd.Parameters.AddWithValue("institucion", lista_requi.nombre);
                    cmd.Parameters.AddWithValue("totalE", lista_requi.total_maquinas);
                    cmd.Parameters.AddWithValue("totalP", lista_requi.total_paquetes);
                    cmd.Parameters.AddWithValue("modalidad", lista_requi.modalidad);
                    cmd.Parameters.AddWithValue("tipo", lista_requi.tipo);
                    cmd.Parameters.AddWithValue("equipo", lista_requi.equipo);
                    cmd.Parameters.AddWithValue("cartel", lista_requi.cartel);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (MySqlException ex)
                {

                    MessageBox.Show("Error al Guaradar el Listado\n"+ex);
                    return false;
                }

            }
        }
        public bool Insertar_Registros_Reequipamiento(Equipos_Reequipamiento equi_requi,string query)
        {
            try
            {
                trans = conn.BeginTransaction();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "p_insertar_equipos_reequipamiento";
                    cmd.Connection = conn;
                    cmd.Parameters.AddWithValue("listado", equi_requi.Listado);
                    cmd.Parameters.AddWithValue("serie", equi_requi.Serie);
                    cmd.Parameters.AddWithValue("placa", equi_requi.Placa);
                    cmd.Parameters.AddWithValue("numero_paquete", equi_requi.Numero_Paquete);
                    cmd.Parameters.AddWithValue("numero_estacion", equi_requi.NUmero_Maquina);
                    cmd.Parameters.AddWithValue("institucion", equi_requi.Institucion);
                    cmd.Parameters.AddWithValue("modalidad", equi_requi.Modalidad);
                    cmd.Parameters.AddWithValue("estado_equipo", equi_requi.Estado);
                    cmd.Parameters.AddWithValue("fecha_inventario", equi_requi.Fecha);
                    cmd.Parameters.AddWithValue("tecnico", equi_requi.Tecnico);
                    cmd.Parameters.AddWithValue("accion", equi_requi.Accion);
                    cmd.Parameters.AddWithValue("estado_listado", equi_requi.Estado_Listado);
                    cmd.Parameters.AddWithValue("tipo_consulta",query);
                    cmd.ExecuteNonQuery();

                }
                trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                MessageBox.Show("Error\n" + ex);
                return false;

            }

        }
        public bool Insertar_Equipos_Proveedor(Equipos_Proveedor equi_proveedor)
        {
            try
            {

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "p_insertar_equipos_proveedor";
                        cmd.Connection = conn;
                        cmd.Parameters.AddWithValue("serie", equi_proveedor.Serie);
                        cmd.Parameters.AddWithValue("placa", equi_proveedor.Placa);
                        cmd.Parameters.AddWithValue("accion", equi_proveedor.Accion);
                        cmd.Parameters.AddWithValue("descripcion", equi_proveedor.Descripcion);
                        cmd.Parameters.AddWithValue("fecha", equi_proveedor.Fecha);
                        cmd.Parameters.AddWithValue("tecnico", Get_Codigo_Tecnico(equi_proveedor.Tecnico));
                        cmd.Parameters.AddWithValue("ubicacion", Get_Codigo_Ubicacion(equi_proveedor.Ubicacion));
                        cmd.Parameters.AddWithValue("dano", equi_proveedor.Danos);
                        cmd.Parameters.AddWithValue("tipo_inventario", Get_Codigo_Inventario(equi_proveedor.Tipo_Inventario));
                        cmd.ExecuteNonQuery();

                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error\n" + ex);
                return false;

            }

        }
        public bool Insertar_Equipo_Acciones(Equipo_Acciones equi_ac)
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conn;
                    cmd.CommandText = "insertar_equipo_acciones";
                    cmd.Parameters.AddWithValue("accion", equi_ac.Codigo_Accion);
                    cmd.Parameters.AddWithValue("serie", equi_ac.Serie);
                    cmd.Parameters.AddWithValue("placa", equi_ac.Placa);
                    cmd.Parameters.AddWithValue("descrip_equipo", equi_ac.Descripcion);
                    cmd.ExecuteNonQuery();


                }
                catch (MySqlException)
                {

                    throw;
                }
            }

            return true;
        }
        public bool Insertar_Acciones(Acciones acciones)
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conn;
                    cmd.CommandText = "insertar_acciones";
                    cmd.Parameters.AddWithValue("accion", acciones.Codigo);
                    cmd.Parameters.AddWithValue("descripcion", acciones.Descripcion);
                    cmd.Parameters.AddWithValue("fecha", acciones.Fecha);
                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException)
                {

                    throw;
                }
            }
            return true;
        }



        public void Cerrar_Conexion()
        {
            try
            {
                conn.Close();
                base_datos = null;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al cerrar la base de datos\n" + ex);
            }
        }
    }
}
