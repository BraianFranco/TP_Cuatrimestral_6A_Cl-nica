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
    public partial class AdministrarMedicos : System.Web.UI.Page
    {
        ControladorMedico controladorMedico = new ControladorMedico();

        protected void Page_Load(object sender, EventArgs e)
        {
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
    }
}