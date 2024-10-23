using System;
using Modelo;
using Controlador;
using System.Collections.Generic;


namespace TP_Cuatrimestral_6A_Clínica
{
    public partial class AgregarMedico : System.Web.UI.Page
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