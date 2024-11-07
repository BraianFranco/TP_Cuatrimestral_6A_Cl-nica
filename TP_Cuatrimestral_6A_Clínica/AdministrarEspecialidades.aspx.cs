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

        public bool ConfirmaEliminacion { get; set; }
        private static int IDAUX;

        ControladorEspecialidad controladorEspecialidad = new ControladorEspecialidad();

        protected void Page_Load(object sender, EventArgs e)
        {   
            ConfirmaEliminacion = false;

            if (!IsPostBack)
            {
                CargarEspecialidades();
            }
        }

        protected void gvEspecialidades_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvEspecialidades.Rows[index];

                int especialidadId = Convert.ToInt32(gvEspecialidades.DataKeys[index].Value);

                Response.Redirect($"AgregarEspecialidad.aspx?Id={especialidadId}");
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

            gvEspecialidades.DataSource = dtEspecialidades;
            gvEspecialidades.DataBind();
 
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


        protected void GridView1_RowDeleting1(object sender, GridViewDeleteEventArgs e)
        {

            try
            {
                int indice = Convert.ToInt32(e.RowIndex);
                int idAux = Int32.Parse(gvEspecialidades.Rows[indice].Cells[0].Text);

                IDAUX = idAux;

                ConfirmaEliminacion = true;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        protected void btnConfirmarEliminacionEspecialidad_Click(object sender, EventArgs e)
        {
            if (IDAUX.ToString() != string.Empty)
            {
                controladorEspecialidad.EliminarEspecialidad(IDAUX);

                Response.Redirect("AdministrarEspecialidades.aspx");
            }
        }

        protected void btnCancelarEliminacionEspecialidad_Click(object sender, EventArgs e)
        {
            ConfirmaEliminacion = false;
        }
    }
}