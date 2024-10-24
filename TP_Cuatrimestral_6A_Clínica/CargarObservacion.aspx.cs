using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_Cuatrimestral_6A_Clínica
{
    public partial class CargarObservacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAgregarObservacion_Click(object sender, EventArgs e)
        {
            Response.Redirect("MailObservacion.aspx");
        }

        protected void btnCancelarObservacion_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}