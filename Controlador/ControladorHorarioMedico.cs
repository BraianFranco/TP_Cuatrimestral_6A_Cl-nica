using Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Controlador
{
    public class ControladorHorarioMedico
    {

        public void InsertarHorariosMedico(long dniMedico, List<HorarioMedico> horarios)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                foreach (var horario in horarios)
                {
                    string query = "INSERT INTO HorariosMedicos (DniMedico, DiaSemana, IdTurno) VALUES (@DniMedico, @DiaSemana, @IdTurno)";
                    datos.setearConsulta(query);
                    datos.setearParametro("@DniMedico", dniMedico);
                    datos.setearParametro("@DiaSemana", horario.DiaSemana);
                    datos.setearParametro("@IdTurno", horario.IdTurno);
                    datos.ejecutarAccion();

                    // Limpiar los parámetros después de cada ejecución
                    datos.limpiarParametros();
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
        }


        public void EliminarHorariosMedico(long dniMedico)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string query = "DELETE FROM HorariosMedicos WHERE DniMedico = @DniMedico";
                datos.setearConsulta(query);
                datos.setearParametro("@DniMedico", dniMedico);
                datos.ejecutarAccion();
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


        public void ActualizarHorariosMedico(long dniMedico, List<HorarioMedico> horarios)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                EliminarHorariosMedico(dniMedico);

                foreach (var horario in horarios)
                {
                    string query = "INSERT INTO HorariosMedicos (DniMedico, DiaSemana, IdTurno) VALUES (@DniMedico, @DiaSemana, @IdTurno)";
                    datos.setearConsulta(query);
                    datos.setearParametro("@DniMedico", dniMedico);
                    datos.setearParametro("@DiaSemana", horario.DiaSemana);
                    datos.setearParametro("@IdTurno", horario.IdTurno);
                    datos.ejecutarAccion();
                    datos.cerrarConexion(); 
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
        }

    }
}