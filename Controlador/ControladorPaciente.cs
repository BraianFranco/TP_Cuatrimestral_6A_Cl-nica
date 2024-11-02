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

                    aux.dni = (int)Ad.Lector["Dni"];
                    aux.nombre = (string)Ad.Lector["Nombre"];
                    aux.apellido = (string)Ad.Lector["Apellido"];
                    aux.tel = (string)Ad.Lector["NroTelefono"];
                    aux.fechanacimiento = (DateTime)Ad.Lector["FechaNac"];
                    aux.correo = (string)Ad.Lector["Correo"];
                    aux.idPais = (int)Ad.Lector["IdPais"];
                    aux.direccion = (string)Ad.Lector["Direccion"];
                    aux.activo = (bool)Ad.Lector["Activo"];


                    lista.Add(aux);
                }

            }
            catch (Exception ex) { throw ex; }

            finally { Ad.cerrarConexion(); }

            return lista;

        }

        //    public Paciente ObtenerPorDni(string dni)
        //    {
        //        Paciente cliente = null;
        //        AccesoDatos Ad = new AccesoDatos();

        //        Ad.setearConsulta("select Id, Documento, Nombre , Apellido , Email , Direccion , Ciudad ,CP from Clientes where Documento = @DNI");
        //        Ad.setearParametro("@DNI", dni);

        //        try
        //        {
        //            Ad.ejecutarLectura();

        //            if (Ad.Lector.Read())
        //            {
        //                cliente = new Paciente
        //                {
        //                    Id = (int)Ad.Lector["Id"],
        //                    Documento = (string)Ad.Lector["Documento"],
        //                    Nombre = (string)Ad.Lector["Nombre"],
        //                    Apellido = (string)Ad.Lector["Apellido"],
        //                    Ciudad = (string)Ad.Lector["Ciudad"],
        //                    Email = (string)Ad.Lector["Email"],
        //                    Direccion = (string)Ad.Lector["Direccion"],
        //                    CP = (int)Ad.Lector["CP"]
        //                };
        //            }
        //        }
        //        catch (Exception ex) { throw ex; }
        //        finally { Ad.cerrarConexion(); }

        //        return cliente;
        //    }

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
