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
    public class ControladorPaciente
    {


        public List<Paciente> Listar()
        {
            List<Paciente> lista = new List<Paciente>();

            AccesoDatos Ad = new AccesoDatos();

            Ad.setearConsulta("select Dni, Nombre , Apellido , NroTelefono , FechaNac , Correo , IdPais, Direccion , Activo from Paciente");

            try
            {

                Ad.ejecutarLectura();

                while (Ad.Lector.Read())
                {

                    Paciente aux = new Paciente();

                    aux.dni = (int)Convert.ToInt64(Ad.Lector["Dni"]); 
                    aux.nombre = Ad.Lector["Nombre"].ToString(); 
                    aux.apellido = Ad.Lector["Apellido"].ToString();
                    aux.tel = Ad.Lector["NroTelefono"].ToString(); 
                    aux.fechanacimiento = Convert.ToDateTime(Ad.Lector["FechaNac"]); 
                    aux.correo = Ad.Lector["Correo"].ToString(); 
                    aux.idPais = Convert.ToInt32(Ad.Lector["IdPais"]); 
                    aux.direccion = Ad.Lector["Direccion"].ToString(); 
                    aux.activo = Convert.ToBoolean(Ad.Lector["Activo"]); 

                    lista.Add(aux);
                }

            }
            catch (Exception ex) { throw ex; }

            finally { Ad.cerrarConexion(); }

            return lista;

        }
        public Paciente ObtenerPorDni(long dni)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT Dni, Nombre, Apellido, NroTelefono, Correo, FechaNac, Direccion FROM Paciente WHERE Dni = @Dni");
                datos.setearParametro("@Dni", dni);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    return new Paciente
                    {
                        dni = (int)Convert.ToInt64(datos.Lector["Dni"]),
                        nombre = datos.Lector["Nombre"].ToString(),
                        apellido = datos.Lector["Apellido"].ToString(),
                        tel = datos.Lector["NroTelefono"].ToString(),   
                        correo = datos.Lector["Correo"].ToString(),
                        fechanacimiento = Convert.ToDateTime(datos.Lector["FechaNac"]),
                        direccion = datos.Lector["Direccion"].ToString()
                    };
                }
                return null;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void Actualizar(Paciente paciente)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE Paciente SET Nombre = @Nombre, Apellido = @Apellido, NroTelefono = @NroTelefono, Correo = @Correo, FechaNac = @FechaNac, Direccion = @Direccion WHERE Dni = @Dni");
                datos.setearParametro("@Nombre", paciente.nombre);
                datos.setearParametro("@Apellido", paciente.apellido);
                datos.setearParametro("@NroTelefono", paciente.tel);
                datos.setearParametro("@Correo", paciente.correo);
                datos.setearParametro("@Dni", paciente.dni);
                datos.setearParametro("@FechaNac",paciente.fechanacimiento);
                datos.setearParametro("@Direccion", paciente.direccion);
                datos.ejecutarAccion();
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public bool PacienteExiste(int dni)
        {
            AccesoDatos Ad = new AccesoDatos();
            Ad.setearConsulta("select count(*) from Paciente where Dni = @DNI");
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

        public void InsertarPaciente(Paciente paciente)
        {

            ControladorPaciente ControladorPaciente = new ControladorPaciente();


            AccesoDatos Ad = new AccesoDatos();
            Ad.setearConsulta("insert into Paciente (Dni, Nombre , Apellido , NroTelefono , FechaNac , Correo , IdPais, Direccion , Activo) values (@Dni, @Nombre , @Apellido , @NroTelefono , @FechaNac ,@Correo , @IdPais, @Direccion , @Activo)");
            Ad.setearParametro("@Dni", paciente.dni);
            Ad.setearParametro("@Nombre", paciente.nombre);
            Ad.setearParametro("@Apellido", paciente.apellido);
            Ad.setearParametro("@NroTelefono", paciente.tel);
            Ad.setearParametro("@FechaNac", paciente.fechanacimiento);
            Ad.setearParametro("@Correo", paciente.correo);
            Ad.setearParametro("@IdPais", paciente.idPais);
            Ad.setearParametro("@Direccion", paciente.direccion);
            Ad.setearParametro("@Activo", true);

            try
            {
                Ad.ejecutarAccion();
            }
            catch (Exception ex) { throw ex; }
            finally { Ad.cerrarConexion(); }



        }


        //public int ObtenerIdCliente(Paciente cliente)
        //{
        //    AccesoDatos Ad = new AccesoDatos();
        //    Ad.setearConsulta("Select Id from clientes where Documento = @dni");
        //    Ad.setearParametro("@dni", cliente.Documento);

        //    try
        //    {
        //        Ad.ejecutarLectura();

        //        if (Ad.Lector.Read())
        //        {
        //            return (int)Ad.Lector["Id"];
        //        }
        //        else
        //        {
        //            return -1;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        Ad.cerrarConexion();
        //    }
        //}

        //    public void ActualizarVoucher(string codigoVoucher, int idCliente, DateTime fechaCanje, int idArticulo)
        //    {
        //        AccesoDatos Ad = new AccesoDatos();
        //        Ad.setearConsulta("UPDATE Vouchers SET IdCliente = @IdCliente, FechaCanje = @FechaCanje, IdArticulo = @IdArticulo WHERE CodigoVoucher = @CodigoVoucher");
        //        Ad.setearParametro("@CodigoVoucher", codigoVoucher);
        //        Ad.setearParametro("@IdCliente", idCliente);
        //        Ad.setearParametro("@FechaCanje", fechaCanje);
        //        Ad.setearParametro("@IdArticulo", idArticulo);

        //        try
        //        {
        //            Ad.ejecutarAccion();
        //        }
        //        catch (Exception ex) { throw ex; }
        //        finally { Ad.cerrarConexion(); }
        //    }

        //    public int ObtenerMaxIdCliente()
        //    {
        //        AccesoDatos Ad = new AccesoDatos();
        //        Ad.setearConsulta("SELECT MAX(Id) FROM Clientes");

        //        try
        //        {
        //            Ad.ejecutarLectura();
        //            if (Ad.Lector.Read())
        //            {
        //                return Ad.Lector.IsDBNull(0) ? 0 : Ad.Lector.GetInt32(0);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //        finally
        //        {
        //            Ad.cerrarConexion();
        //        }

        //        return 0;
        //    }



    }
}
