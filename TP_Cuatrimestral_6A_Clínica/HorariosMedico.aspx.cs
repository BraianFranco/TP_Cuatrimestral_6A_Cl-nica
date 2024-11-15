using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Modelo;

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
                if (Request.QueryString["Dni"] == null)
                {
                    Response.Redirect("AgregarMedico.aspx");
                }
            }

        }

        protected void BtnGuardarHorarios_Click(object sender, EventArgs e)
        {
            long dniMedico = long.Parse(Request.QueryString["Dni"]);
            List<HorarioMedico> horarios = new List<HorarioMedico>();

            // Según los check que tildaste son los dias que trabaja cada medico
            if (chkLunes.Checked)
                horarios.Add(new HorarioMedico { DniMedico = dniMedico, DiaSemana = 1, IdTurno = int.Parse(ddlTurnoLunes.SelectedValue) });
            if (chkMartes.Checked)
                horarios.Add(new HorarioMedico { DniMedico = dniMedico, DiaSemana = 2, IdTurno = int.Parse(ddlTurnoMartes.SelectedValue) });
            if (chkMiercoles.Checked)
                horarios.Add(new HorarioMedico { DniMedico = dniMedico, DiaSemana = 3, IdTurno = int.Parse(ddlTurnoMiercoles.SelectedValue) });
            if (chkJueves.Checked)
                horarios.Add(new HorarioMedico { DniMedico = dniMedico, DiaSemana = 4, IdTurno = int.Parse(ddlTurnoJueves.SelectedValue) });
            if (chkViernes.Checked)
                horarios.Add(new HorarioMedico { DniMedico = dniMedico, DiaSemana = 5, IdTurno = int.Parse(ddlTurnoViernes.SelectedValue) });
            if (chkSabado.Checked)
                horarios.Add(new HorarioMedico { DniMedico = dniMedico, DiaSemana = 6, IdTurno = int.Parse(ddlTurnoSabado.SelectedValue) });
            if (chkDomingo.Checked)
                horarios.Add(new HorarioMedico { DniMedico = dniMedico, DiaSemana = 7, IdTurno = int.Parse(ddlTurnoDomingo.SelectedValue) });

            // Guarda los horarios en la sesión
            Session["HorariosMedico"] = horarios;

            
            Response.Redirect("AgregarMedico.aspx");
        }


    }
}