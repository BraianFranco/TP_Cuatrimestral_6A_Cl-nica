using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

    namespace Modelo
    {
        public class AccesoDatos
        {
            private SqlConnection conexion;
            public SqlCommand comando { get; set; }
            private SqlDataReader lector;

            public SqlDataReader Lector
            {
                get { return lector; }
            }
            

            public AccesoDatos()
            {

                 //conexion = new SqlConnection("server=.\\SQLEXPRESS; database=Clinica_6A_DB; integrated security=true");
                conexion = new SqlConnection("server=.\\SQLEXPRESS; database=ClinicaMedica; integrated security=true");
                //conexion = new SqlConnection("server=.\\GONZA; database=ClinicaMedica; integrated security=true");


                comando = new SqlCommand();
            }


            public void setearConsulta(string consulta)
            {
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = consulta;
            }

          


        public void ejecutarLectura()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (lector == null || lector.IsClosed)
                {
                    cerrarConexion();
                }
            }
        }

        public void ejecutarAccion()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cerrarConexion();
            }
        }


        public void setearParametro(string nombre, object valor)
            {
                comando.Parameters.AddWithValue(nombre, valor);
            }

            public void cerrarConexion()
            {
                if (lector != null)
                    lector.Close();
                conexion.Close();
            }

            public void limpiarParametros()
            {
                comando.Parameters.Clear();
            }

    }
    }
