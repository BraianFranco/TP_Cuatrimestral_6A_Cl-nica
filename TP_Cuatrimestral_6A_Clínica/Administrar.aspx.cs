using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_Cuatrimestral_6A_Clínica
{
    public partial class Administrar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("Login.aspx");

            }
        }

        protected void Especilidades_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdministrarEspecialidades.aspx");

        }

        protected void Medicos_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdministrarMedicos.aspx");
        }

        protected void Pacientes_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdministrarPacientes.aspx");

        }


        public int ObtenerRolUsuarioSession()
        {
            int rol = ((Usuario)Session["Usuario"]).IdRol;

            return rol;
        }
    }
}