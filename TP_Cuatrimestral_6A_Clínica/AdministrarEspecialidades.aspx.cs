using Controlador;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_Cuatrimestral_6A_Clínica
{
    public partial class AdministrarEspecialidades : System.Web.UI.Page
    {
        ControladorEspecialidad controladorEspecialidad = new ControladorEspecialidad();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarEspecialidades();
            }
        }

        private void CargarEspecialidades()
        {
            try
            {
            var listaEspecialidades = controladorEspecialidad.Listar();


             
            DataTable dtEspecialidades = new DataTable();
            dtEspecialidades.Columns.Add("Id", typeof(int));
            dtEspecialidades.Columns.Add("Nombre", typeof(string));
            dtEspecialidades.Columns.Add("Descripcion", typeof(string));

            foreach (var especialidad in listaEspecialidades)
            {
                dtEspecialidades.Rows.Add(
                    especialidad.Id,
                    especialidad.Nombre,
                    especialidad.Descripcion
                );
            }

            GridView1.DataSource = dtEspecialidades;
            GridView1.DataBind();
 
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al cargar especialidades: " + ex.Message;
            }
        }
    


    protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarEspecialidad.aspx");
        }
    }
}