using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controlador
{
    public class ControladorMedico
    {

        public List<Medico> Listar()
        {
            List<Medico> lista = new List<Medico>();

            AccesoDatos Ad = new AccesoDatos();

            Ad.setearConsulta("select Dni, NroTelefono , Nombre , Apellido , Correo , Activo , IdPais from Medico");

            try
            {

                Ad.ejecutarLectura();

                while (Ad.Lector.Read())
                {
                    
                    Medico aux = new Medico();

                    aux.Dni = Convert.ToInt32(Ad.Lector["Dni"]);
                    aux.Nombre = Ad.Lector["Nombre"].ToString();
                    aux.Apellido = Ad.Lector["Apellido"].ToString();
                    aux.Telefono = Ad.Lector["NroTelefono"].ToString();
                    aux.Correo = Ad.Lector["Correo"].ToString();
                    aux.IdPais = Convert.ToInt32(Ad.Lector["IdPais"]);
                    aux.Activo = Convert.ToBoolean(Ad.Lector["Activo"]);

                    lista.Add(aux);
                }

            }
            catch (Exception ex) { throw ex; }

            finally { Ad.cerrarConexion(); }

            return lista;

        }

        public Medico ObtenerMedicoPorDni(long dni)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT Dni, Nombre, Apellido, NroTelefono, Correo, IdPais, Activo FROM Medico WHERE Dni = @Dni");
                datos.setearParametro("@Dni", dni);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    return new Medico
                    {
                        Dni = (int)Convert.ToInt64(datos.Lector["Dni"]),
                        Nombre = datos.Lector["Nombre"].ToString(),
                        Apellido = datos.Lector["Apellido"].ToString(),
                        Telefono = datos.Lector["NroTelefono"].ToString(),
                        Correo = datos.Lector["Correo"].ToString(),
                        IdPais = Convert.ToInt32(datos.Lector["IdPais"]),
                        Activo = Convert.ToBoolean(datos.Lector["Activo"])
                    };
                }
                return null;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }


        public void ActualizarMedico(Medico medico)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE Medico SET Nombre = @Nombre, Apellido = @Apellido, NroTelefono = @NroTelefono, Correo = @Correo, IdPais = @IdPais, Activo = @Activo WHERE Dni = @Dni");
                datos.setearParametro("@Nombre", medico.Nombre);
                datos.setearParametro("@Apellido", medico.Apellido);
                datos.setearParametro("@NroTelefono", medico.Telefono);
                datos.setearParametro("@Correo", medico.Correo);
                datos.setearParametro("@IdPais", medico.IdPais);
                datos.setearParametro("@Activo", medico.Activo);
                datos.setearParametro("@Dni", medico.Dni);
                datos.ejecutarAccion();
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public bool MedicoExiste(int dni)
        {
            AccesoDatos Ad = new AccesoDatos();
            Ad.setearConsulta("select count(*) from Medico where Dni = @DNI AND Activo = 1");
            Ad.setearParametro("@DNI", dni);

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

        public void InsertarMedico(Medico medico)
        {

            AccesoDatos Ad = new AccesoDatos();
            Ad.setearConsulta("insert into Medico (Dni, Nombre , Apellido , NroTelefono , Correo , IdPais, Activo) values (@Dni, @Nombre , @Apellido , @NroTelefono , @Correo , @IdPais, @Activo)");
            Ad.setearParametro("@Dni", medico.Dni);
            Ad.setearParametro("@Nombre", medico.Nombre);
            Ad.setearParametro("@Apellido", medico.Apellido);
            Ad.setearParametro("@NroTelefono", medico.Telefono);
            Ad.setearParametro("@Correo", medico.Correo);
            Ad.setearParametro("@IdPais", medico.IdPais);
            Ad.setearParametro("@Activo", true);

            try
            {
                Ad.ejecutarAccion();
            }
            catch (Exception ex) { throw ex; }
            finally { Ad.cerrarConexion(); }


        }

        public void EliminarMedico(int dni)
        {
            AccesoDatos Ad = new AccesoDatos();
            ControladorHorarioMedico controladorHorario = new ControladorHorarioMedico();
            controladorHorario.EliminarHorariosMedico(dni);


            Ad.setearConsulta("UPDATE Medico SET Activo = 0 WHERE Dni= @DNI");
            Ad.setearParametro("@DNI", dni);

            try
            {
                Ad.ejecutarAccion();
            }
            catch (Exception ex) { throw ex; }
            finally { Ad.cerrarConexion(); }
        }


        public Medico FiltrarPorDni(int dni)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {

                string Consulta = "select Dni, Nombre, Apellido , NroTelefono , Correo , Activo , IdPais FROM Medico WHERE Dni like " + dni;

                datos.setearConsulta(Consulta);
                datos.ejecutarLectura();


                datos.Lector.Read();

                Medico aux = new Medico();

                aux.Nombre = (string)datos.Lector["Nombre"];
                aux.Dni = (int)(long)datos.Lector["Dni"];
                aux.Apellido = (string)datos.Lector["Apellido"];
                aux.Telefono = (string)datos.Lector["NroTelefono"];
                aux.Correo = (string)datos.Lector["Correo"];
                aux.IdPais = (int)datos.Lector["IdPais"];
                aux.Activo = (bool)datos.Lector["Activo"];


                return aux;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        public List<Medico> ObtenerMedicosDisponiblesSP(int idEspecialidad, DateTime fechaTurno)
        {
            List<Medico> medicosDisponibles = new List<Medico>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                // Configurar el nombre del Stored Procedure
                datos.setearConsulta("SP_ObtenerMedicosDisponibles");
                datos.comando.CommandType = System.Data.CommandType.StoredProcedure;


                // Configurar parámetros
                datos.setearParametro("@IdEspecialidad", idEspecialidad);
                datos.setearParametro("@FechaTurno", fechaTurno);

                // Ejecutar lectura
                datos.ejecutarLectura();

                // Leer los resultados
                while (datos.Lector.Read())
                {
                    Medico medico = new Medico
                    {
                        Dni = Int32.Parse(datos.Lector["Dni"].ToString()),
                        Nombre = datos.Lector["Nombre"].ToString(),
                        Apellido = datos.Lector["Apellido"].ToString()
                    };
                    medicosDisponibles.Add(medico);
                }
            }
            catch (Exception ex)
            {
                throw ex; 
            }
            finally
            {
                datos.cerrarConexion();
            }

            return medicosDisponibles;
        }







    }
}
