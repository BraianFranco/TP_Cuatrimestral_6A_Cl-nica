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
    public partial class AgregarPaciente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (!IsPostBack)
                {
                    ControladorPais CP = new ControladorPais();
                    List<Pais> ListaPaises = new List<Pais>();
                    ListaPaises = CP.Listar();

                    ddlPais.DataSource = ListaPaises;
                    ddlPais.DataBind();

                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }

}