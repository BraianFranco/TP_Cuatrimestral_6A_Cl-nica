using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Modelo;
using Controlador;

namespace TP_Cuatrimestral_6A_Clínica
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("Login.aspx");

            }

            // Chequear que antes tengo el DNI
            if (!IsPostBack)
            {

        /*
                if (Request.QueryString["DniMedico"] == null)
                {
                    Response.Redirect("AgregarMedico.aspx");
                }

                */

                long dniMedico = Int32.Parse(Session["DniMedico"].ToString());
                
             CargarHorarios(dniMedico);

            }

        }



        private void CargarHorarios(long dniMedico)
        {
            ControladorHorarioMedico controladorHorario = new ControladorHorarioMedico();
            List<HorarioMedico> horariosMedico = controladorHorario.ObtenerHorariosPorMedico(dniMedico);

     
            foreach (var horario in horariosMedico)
            {
                switch (horario.DiaSemana)
                {
                    case 1: 
                        chkLunes.Checked = true;
                        horaInicioLunes.Value = horario.HoraInicio.ToString(@"hh\:mm");
                        horaFinLunes.Value = horario.HoraFin.ToString(@"hh\:mm");
                        break;

                    case 2: 
                        chkMartes.Checked = true;
                        horaInicioMartes.Value = horario.HoraInicio.ToString(@"hh\:mm");
                        horaFinMartes.Value = horario.HoraFin.ToString(@"hh\:mm");
                        break;

                    case 3: 
                        chkMiercoles.Checked = true;
                        horaInicioMiercoles.Value = horario.HoraInicio.ToString(@"hh\:mm");
                        horaFinMiercoles.Value = horario.HoraFin.ToString(@"hh\:mm");
                        break;

                    case 4: 
                        chkJueves.Checked = true;
                        horaInicioJueves.Value = horario.HoraInicio.ToString(@"hh\:mm");
                        horaFinJueves.Value = horario.HoraFin.ToString(@"hh\:mm");
                        break;

                    case 5: 
                        chkViernes.Checked = true;
                        horaInicioViernes.Value = horario.HoraInicio.ToString(@"hh\:mm");
                        horaFinViernes.Value = horario.HoraFin.ToString(@"hh\:mm");
                        break;

                    case 6:
                        chkSabado.Checked = true;
                        horaInicioSabado.Value = horario.HoraInicio.ToString(@"hh\:mm");
                        horaFinSabado.Value = horario.HoraFin.ToString(@"hh\:mm");
                        break;

                    case 7: 
                        chkDomingo.Checked = true;
                        horaInicioDomingo.Value = horario.HoraInicio.ToString(@"hh\:mm");
                        horaFinDomingo.Value = horario.HoraFin.ToString(@"hh\:mm");
                        break;
                }
            }

        }




        protected void btnGuardarHorarios_Click(object sender, EventArgs e)
        {
           

            int dniMedico = Convert.ToInt32(Session["DniMedico"]);

          
            List<HorarioMedico> horarios = new List<HorarioMedico>();


          
            if (chkLunes.Checked)
            {
                horarios.Add(new HorarioMedico
                {
                    DniMedico = dniMedico,
                    DiaSemana = 1, // Lunes
                    HoraInicio = TimeSpan.Parse(horaInicioLunes.Value),
                    HoraFin = TimeSpan.Parse(horaFinLunes.Value)
                });
            }

            if (chkMartes.Checked)
            {
                horarios.Add(new HorarioMedico
                {
                    DniMedico = dniMedico,
                    DiaSemana = 2, 
                    HoraInicio = TimeSpan.Parse(horaInicioMartes.Value),
                    HoraFin = TimeSpan.Parse(horaFinMartes.Value)
                });
            }

            if (chkMiercoles.Checked)
            {
                horarios.Add(new HorarioMedico
                {
                    DniMedico = dniMedico,
                    DiaSemana = 3,
                    HoraInicio = TimeSpan.Parse(horaInicioMiercoles.Value),
                    HoraFin = TimeSpan.Parse(horaFinMiercoles.Value)
                });
            }

            if (chkJueves.Checked)
            {
                horarios.Add(new HorarioMedico
                {
                    DniMedico = dniMedico,
                    DiaSemana = 4,
                    HoraInicio = TimeSpan.Parse(horaInicioJueves.Value),
                    HoraFin = TimeSpan.Parse(horaFinJueves.Value)
                });
            }

            if (chkViernes.Checked)
            {
                horarios.Add(new HorarioMedico
                {
                    DniMedico = dniMedico,
                    DiaSemana = 5,
                    HoraInicio = TimeSpan.Parse(horaInicioViernes.Value),
                    HoraFin = TimeSpan.Parse(horaFinViernes.Value)
                });
            }

            if (chkSabado.Checked)
            {
                horarios.Add(new HorarioMedico
                {
                    DniMedico = dniMedico,
                    DiaSemana = 6,
                    HoraInicio = TimeSpan.Parse(horaInicioSabado.Value),
                    HoraFin = TimeSpan.Parse(horaFinSabado.Value)
                });
            }

            if (chkDomingo.Checked)
            {
                horarios.Add(new HorarioMedico
                {
                    DniMedico = dniMedico,
                    DiaSemana = 7,
                    HoraInicio = TimeSpan.Parse(horaInicioDomingo.Value),
                    HoraFin = TimeSpan.Parse(horaFinDomingo.Value)
                });
            }


            if (!GuardarHorariosEnBD(horarios))
            {
                lblMensaje.Text = "No se pudo guardar el Horario";
            }


            Session["IdMedico"] = null;
            lblMensaje.Text = "Horarios guardados exitosamente.";


        }

        



        private bool GuardarHorariosEnBD(List<HorarioMedico> horarios)
        {

            ControladorHorarioMedico CHM = new ControladorHorarioMedico();
            return CHM.InsertarHorario(horarios);
  
        }









    }
}