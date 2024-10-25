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

        }

        protected void btnAgregarEspecialidad_Click(object sender, EventArgs e)
        {
           
            Response.Redirect("~/AgregarEspecialidad.aspx"); 
        }

        protected void btnAgregarMedico_Click(object sender, EventArgs e)
        {
        
            Response.Redirect("~/AgregarMedico.aspx"); 
        }

        protected void btnAgregarPaciente_Click(object sender, EventArgs e)
        {
           
            Response.Redirect("~/AgregarPaciente.aspx"); 
        }






    }
}