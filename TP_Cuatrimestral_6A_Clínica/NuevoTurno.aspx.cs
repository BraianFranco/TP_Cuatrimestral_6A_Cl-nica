using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_Cuatrimestral_6A_Clínica
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void txtDNI_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtDNI.Text))
            {
                // Hacemos visibles los DropDownList y sus etiquetas
                especialidadGroup.Visible = true;
                consultaGroup.Visible = true;
            }
            else
            {
                // Ocultamos si el DNI está vacío
                especialidadGroup.Visible = false;
                consultaGroup.Visible = false;
            }
        }

    }
}