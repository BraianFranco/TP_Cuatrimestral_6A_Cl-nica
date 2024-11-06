using Controlador;
using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;


namespace TP_Cuatrimestral_6A_Clínica
{
    public partial class AdministrarMedicos : System.Web.UI.Page
    {
        ControladorMedico controladorMedico = new ControladorMedico();
        public bool ConfirmaEliminacion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ConfirmaEliminacion = false;

            if (!IsPostBack)
            {
               
                CargarMedicos();
            }
        }

        private void CargarMedicos()
        {
            {
                try
                {
                    
                    var listaMedicos = controladorMedico.Listar();

   
                    DataTable dtMedicos = new DataTable();

                    dtMedicos.Columns.Add("Dni", typeof(long));
                    dtMedicos.Columns.Add("Nombre", typeof(string));
                    dtMedicos.Columns.Add("Apellido", typeof(string));
                    dtMedicos.Columns.Add("NroTelefono", typeof(string));
                    dtMedicos.Columns.Add("Correo", typeof(string));
                    dtMedicos.Columns.Add("IdPais", typeof(int));
                    dtMedicos.Columns.Add("Activo", typeof(bool));

                        
                    foreach (var medico in listaMedicos)
                    {
                        dtMedicos.Rows.Add(
                            medico.Dni,
                            medico.Nombre,
                            medico.Apellido,
                            medico.Telefono,
                            medico.Correo,
                            medico.IdPais,
                            medico.Activo
                        );
                    }

                    GridView1.DataSource = dtMedicos;
                    GridView1.DataBind();


                }
                catch (Exception ex)
                {
                    lblMensaje.Text = "Error al cargar médicos: " + ex.Message;
                }
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarMedico.aspx");
        }

        protected void GridView1_RowDeleting1(object sender, GridViewDeleteEventArgs e)
        {          

            try
            {
                int indice = Convert.ToInt32(e.RowIndex);
                int dniAux = Int32.Parse(GridView1.Rows[indice].Cells[0].Text);

                controladorMedico.EliminarMedico(dniAux);

                Response.Redirect("AdministrarMedicos.aspx");

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        protected void ConfirmarEliminacionMedico_Click(object sender, EventArgs e)
        {
            ConfirmaEliminacion = true;
        }

        protected void btnCancelarEliminacionMedico_Click(object sender, EventArgs e)
        {
            ConfirmaEliminacion = false;
        }
    }
   
}