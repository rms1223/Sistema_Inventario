using InventarioFod.Clases;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventarioFod.Clases
{
    class Impresion_Datos
    {
        //SQLITE conexion_basedatos;
        MysqlDB conexion_basedatos;

        public Impresion_Datos()
        {
            conexion_basedatos = MysqlDB.getInstance;
            
        }

        Label label_institucion;
        Label label_tipo;
        Label label_modelo;
        Label label_lista;
        Label label_paquete;
        Label label_modalidad;

        Label label_institucion2;
        Label label_tipo2;
        Label label_modelo2;
        Label label_lista2;
        Label label_paquete2;
        Label label_modalidad2;

        PrintDocument documento;

        public void Set_controles(Label li1, Label lt1 , Label lm1, Label ll1, Label lp1, Label lmod1 ,Label li2, Label lt2, Label lm2, Label ll2, Label lp2,Label lmod2,PrintDocument doc)
        {
            label_institucion = li1;
            label_tipo = lt1;
            label_modelo = lm1;
            label_lista = ll1;
            label_paquete = lp1;
            label_modalidad = lmod1;

            label_institucion2 = li2;
            label_tipo2 = lt2;
            label_modelo2 = lm2;
            label_lista2 = ll2;
            label_paquete2 = lp2;
            label_modalidad2 = lmod2;
            documento = doc;
        }
        

        private string lista = String.Empty;
        public void imprimir_lista()
        {
            imprimir();
        }
        public string set_lista
        {
            set
            {
                lista = value;
            }
        }
        private void imprimir()
        {

           
            using (MySqlDataReader lector = conexion_basedatos.Listar_Registro_Impresion(lista, "grandes"))
            {
                
                while (lector.Read())
                {

                    int total_paquetes = Convert.ToInt32(lector["total_paquetes"].ToString());
                    for (int i = 1; i <= total_paquetes; i += 2)
                    {
                        //Thread.Sleep(2000);
                        //documento.Print();
                        label_institucion.Text = lector["Centro_educativo"].ToString();
                        label_tipo.Text = lector["tipo"].ToString();
                        label_modelo.Text = "MODELO " + lector["equipo"].ToString();
                        label_lista.Text = "L" + lector["Listado"].ToString() + " - " + lector["Codigo"].ToString();
                        label_paquete.Text = "PAQUETE " + i + " DE " + total_paquetes;
                        label_modalidad.Text = "Modalidad: " + lector["modalidad"].ToString();
                        //delegado(lector["Centro_educativo"].ToString(), lector["tipo"].ToString(), "MODELO " + lector["equipo"].ToString(), "L" + lector["Listado"].ToString() + " - " + lector["Codigo"].ToString(), "PAQUETE " + i + " DE " + total_paquetes);
                        if ((i + 1) <= total_paquetes)
                        {
                            label_institucion2.Text = lector["Centro_educativo"].ToString();
                            label_tipo2.Text = lector["tipo"].ToString();
                            label_modelo2.Text = "MODELO " + lector["equipo"].ToString();
                            label_lista2.Text = "L" + lector["Listado"].ToString() + " - " + lector["Codigo"].ToString();
                            label_paquete2.Text = "PAQUETE " + (i + 1) + " DE " + total_paquetes;
                            label_modalidad2.Text = "Modalidad: " + lector["modalidad"].ToString();
                        }
                        else
                        {
                            label_institucion2.Text = String.Empty;
                            label_tipo2.Text = String.Empty;
                            label_modelo2.Text = String.Empty;
                            label_lista2.Text = String.Empty;
                            label_paquete2.Text = String.Empty;
                            label_modalidad2.Text = String.Empty;
                        }

                        documento.Dispose();
                        documento.DefaultPageSettings.Landscape = true;
                        documento.Print();
                        Thread.Sleep(2000);

                    }
                }
            }
            using (MySqlDataReader lector = conexion_basedatos.Listar_Registro_Impresion(lista, "pequenos"))
            {
                PrintPreviewDialog prev = new PrintPreviewDialog();
                int contador = 0;
                while (lector.Read())
                {
                    if (contador == 0)
                    {
                        label_institucion.Text = lector["Centro_educativo"].ToString();
                        label_tipo.Text = lector["tipo"].ToString();
                        label_modelo.Text = "MODELO " + lector["equipo"].ToString();
                        label_lista.Text = "L" + lector["Listado"].ToString() + " - " + lector["Codigo"].ToString();
                        label_paquete.Text = "PAQUETE " + lector["total_paquetes"].ToString() + " DE " + lector["total_paquetes"].ToString();
                        label_modalidad.Text = "Modalidad: " + lector["modalidad"].ToString();
                        contador = 1;

                    }
                    else
                    {

                        label_institucion2.Text = lector["Centro_educativo"].ToString();
                        label_tipo2.Text = lector["tipo"].ToString();
                        label_modelo2.Text = "MODELO " + lector["equipo"].ToString();
                        label_lista2.Text = "L" + lector["Listado"].ToString() + " - " + lector["Codigo"].ToString();
                        label_paquete2.Text = "PAQUETE " + lector["total_paquetes"].ToString() + " DE " + lector["total_paquetes"].ToString();
                        label_modalidad2.Text = "Modalidad: " + lector["modalidad"].ToString();
                        documento.Dispose();
                        Thread.Sleep(2000);
                        documento.DefaultPageSettings.Landscape = true;
                        documento.Print();
                        contador = 0;
                    }

                }
            }

        }
    }
}
