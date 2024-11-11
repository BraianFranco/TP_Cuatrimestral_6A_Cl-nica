using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Modelo;

namespace Controlador
{
    public class ControladorEspecialidad
    {
        public List<Especialidad> Listar()
        {
            List<Especialidad> lista = new List<Especialidad>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select Id, Nombre ,Descripcion from Especialidades");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {

                    Especialidad aux = new Especialidad();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    lista.Add(aux);


                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public bool EspecialidadExistente(string nombre)
        {
            AccesoDatos Ad = new AccesoDatos();
            Ad.setearConsulta("select count(*) from Especialidades where Nombre = @Nombre");
            Ad.setearParametro("@Nombre", nombre);

            try
            {
                Ad.ejecutarLectura();
                if (Ad.Lector.Read())
                {
                    return (int)Ad.Lector[0] > 0;
                }
            }
            catch (Exception ex) { throw ex; }
            finally { Ad.cerrarConexion(); }

            return false;
        }

        public Especialidad ObtenerPorId(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT Id, Nombre, Descripcion FROM Especialidades WHERE Id = @Id");
                datos.setearParametro("@Id", id);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    return new Especialidad
                    {
                        Id = Convert.ToInt32(datos.Lector["Id"]),
                        Nombre = datos.Lector["Nombre"].ToString(),
                        Descripcion = datos.Lector["Descripcion"].ToString()
                    };
                }
                return null;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void Actualizar(Especialidad especialidad)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE Especialidades SET Nombre = @Nombre, Descripcion = @Descripcion WHERE Id = @Id");
                datos.setearParametro("@Nombre", especialidad.Nombre);
                datos.setearParametro("@Descripcion", especialidad.Descripcion);
                datos.setearParametro("@Id", especialidad.Id);
                datos.ejecutarAccion();
            }
            finally
            {
                datos.cerrarConexion();
            }
        }


        public void InsertarEspecialidad(Especialidad especialidad)
        {

            AccesoDatos Ad = new AccesoDatos();
            Ad.setearConsulta("insert into Especialidades (Nombre , Descripcion) values (@Nombre, @Descripcion)");
            Ad.setearParametro("@Nombre", especialidad.Nombre);
            Ad.setearParametro("@Descripcion", especialidad.Descripcion);

            try
            {
                Ad.ejecutarAccion();
            }
            catch (Exception ex) { throw ex; }
            finally { Ad.cerrarConexion(); }


        }

        public void EliminarEspecialidad(int id)
        {
            AccesoDatos Ad = new AccesoDatos();
            Ad.setearConsulta("delete from Especialidades where Id = @ID");
            Ad.setearParametro("@ID", id);

            try
            {
                Ad.ejecutarAccion();
            }
            catch (Exception ex) { throw ex; }
            finally { Ad.cerrarConexion(); }
        }

        public List<Especialidad> FiltrarPorNombre(string nombre)
        {
            List<Especialidad> listaFiltrada = new List<Especialidad>();
            AccesoDatos datos = new AccesoDatos();

            try
            {

                string Consulta = "select Id, Nombre, Descripcion FROM Especialidades WHERE Nombre like '%" + nombre + "%'";

                datos.setearConsulta(Consulta);
                datos.ejecutarLectura();



                while (datos.Lector.Read())
                {
                    Especialidad aux = new Especialidad();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

                    listaFiltrada.Add(aux);
                }

                return listaFiltrada;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
