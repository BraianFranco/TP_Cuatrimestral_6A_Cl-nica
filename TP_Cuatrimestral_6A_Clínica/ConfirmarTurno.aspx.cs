using Controlador;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_Cuatrimestral_6A_Clínica
{
    public partial class ConfirmarTurno : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Turno"] != null)
                {
                    Turno turno = (Turno)Session["Turno"];
                    lblDniPaciente.Text = turno.DniPaciente.ToString();
                    lblEspecialidad.Text = turno.IdEspecialidad.ToString(); 
                    lblFechaHora.Text = turno.FechaTurno.ToString("dd/MM/yyyy HH:mm");
                    lblMedico.Text = turno.DniMedico.ToString();
                }
                else
                {
                    Response.Redirect("SeleccionarTurno.aspx");
                }
            }
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (Session["Turno"] != null)
            {
                Turno turno = (Turno)Session["Turno"];
                turno.Observaciones = txtObservaciones.Text;

                // Guardar el turno en la base de datos
                ControladorTurno controladorTurno = new ControladorTurno();


                if (controladorTurno.AgregarNuevoTurno(turno))
                {
                    Session.Remove("Turno");

                    ScriptManager.RegisterStartupScript(this, GetType(), "modalConfirmacion", "$('#modalConfirmacion').modal('show');", true);

                }
                else
                {
                    // a manejar
                }


            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            // Limpiar sesión y redirigir.

            Session.Remove("Turno");

            Response.Redirect("NuevoTurno.aspx");
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx"); 
        }






    }
}