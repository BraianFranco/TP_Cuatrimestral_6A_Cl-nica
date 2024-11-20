using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Controlador
{
    public class ControladorHorarioMedico
    {


        public bool InsertarHorario(List<HorarioMedico> horarios)
        {
            AccesoDatos AD = new AccesoDatos();
            bool resultado = false;

            try
            {
                
               

                foreach (var horario in horarios)
                {
                    AD.setearConsulta("SP_Insertar_Horarios");
                    AD.comando.CommandType = CommandType.StoredProcedure;

                    AD.setearParametro("@DniMedico", horario.DniMedico);
                    AD.setearParametro("@DiaSemana", horario.DiaSemana);
                    AD.setearParametro("@HoraInicio", horario.HoraInicio);
                    AD.setearParametro("@HoraFin", horario.HoraFin);
                   

                    AD.ejecutarAccion();

                    AD.limpiarParametros();
                }

                resultado = true;
            }
            catch (Exception ex)
            {
               
                Console.WriteLine("Error al insertar horarios: " + ex.Message);
            }
            finally
            {
                AD.cerrarConexion();
            }

            return resultado;
        }

        public List<HorarioMedico> ObtenerHorariosPorMedico(long dniMedico)
        {
            List<HorarioMedico> horarios = new List<HorarioMedico>();
            AccesoDatos AD = new AccesoDatos();

            try
            {
                AD.comando.CommandType = CommandType.Text;
                AD.setearConsulta("SELECT DiaSemana, HoraInicio, HoraFin FROM HorariosMedicos WHERE DniMedico = @DniMedico");
                AD.setearParametro("@DniMedico", dniMedico);

                AD.ejecutarLectura();

                while (AD.Lector.Read())
                {
                    HorarioMedico horario = new HorarioMedico
                    {
                        DniMedico = dniMedico,
                        DiaSemana = AD.Lector.GetInt32(0),
                        HoraInicio = AD.Lector.GetTimeSpan(1),
                        HoraFin = AD.Lector.GetTimeSpan(2)
                    };

                    horarios.Add(horario);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener horarios: " + ex.Message);
            }
            finally
            {
                AD.cerrarConexion();
            }

            return horarios;
        }






        public string ObtenerNombreDiaSemana(int diaSemana)
        {
            string[] dias = { "Domingo", "Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado" };
            return dias[diaSemana % 7];
        }


    }
}