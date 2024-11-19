using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_Cuatrimestral_6A_Clínica
{
    public partial class Opciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("Login.aspx");

            }

        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
           Dispose();
            Response.Redirect("Login.aspx");
        }

        protected void btnAdministrarCuenta_Click(object sender, EventArgs e)
        {
        
            Response.Redirect("AdministrarCuenta.aspx");
        }

      

        protected void btnSoporte_Click(object sender, EventArgs e)
        {
            lblSoporteTel.Text = "TELEFONO : 03484 12345";
            lblSoporteMAIL.Text = "CORREO  : SWISSCLINICALSOPORTE@SWISSCLINICAL.COM";
        }

        protected void btnAjustes_Click(object sender, EventArgs e)
        {

        }
    }
}