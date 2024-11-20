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
using System.Net;


namespace TP_Cuatrimestral_6A_Clínica
{
    public partial class AdministrarMedicos : System.Web.UI.Page
    {
        ControladorMedico controladorMedico = new ControladorMedico();
        public bool ConfirmaEliminacion { get; set; }
        private static int DNIAUX;
        protected void Page_Load(object sender, EventArgs e)
        {
            ConfirmaEliminacion = false;


            if (Session["Usuario"] == null)
            {
                Response.Redirect("Login.aspx");

            }

            if (!IsPostBack)
            {

                CargarMedicos();


            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            

            if (e.CommandName == "Edit")
            {
                long medicoDni = Convert.ToInt64(e.CommandArgument);

                Response.Redirect($"AgregarMedico.aspx?Dni={medicoDni}");


            }
            

             if (e.CommandName == "Horarios")
            {
                long medicoDni = Convert.ToInt64(e.CommandArgument);

                
                Session["DniMedico"] = medicoDni;

             
                Response.Redirect("HorariosMedico.aspx");
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
                        if (medico.Activo == true)
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


        public int ObtenerRolUsuarioSession()
        {
            int rol = ((Usuario)Session["Usuario"]).IdRol;

            return rol;
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

                DNIAUX = dniAux;

                ConfirmaEliminacion = true;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        protected void ConfirmarEliminacionMedico_Click(object sender, EventArgs e)
        {
            if (DNIAUX.ToString() != string.Empty)
            {
                controladorMedico.EliminarMedico(DNIAUX);

                Response.Redirect("AdministrarMedicos.aspx");
            }
        }

        protected void btnCancelarEliminacionMedico_Click(object sender, EventArgs e)
        {
            ConfirmaEliminacion = false;
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {


            if (!string.IsNullOrEmpty(txtFiltrar.Text))
            {
                try
                {

                    DataTable dtMedicosFiltrada = new DataTable();

                    dtMedicosFiltrada.Columns.Add("Dni", typeof(long));
                    dtMedicosFiltrada.Columns.Add("Nombre", typeof(string));
                    dtMedicosFiltrada.Columns.Add("Apellido", typeof(string));
                    dtMedicosFiltrada.Columns.Add("NroTelefono", typeof(string));
                    dtMedicosFiltrada.Columns.Add("Correo", typeof(string));
                    dtMedicosFiltrada.Columns.Add("IdPais", typeof(int));
                    dtMedicosFiltrada.Columns.Add("Activo", typeof(bool));

                    Medico medico = controladorMedico.FiltrarPorDni(Int32.Parse(txtFiltrar.Text));

                    if (medico.Activo == true)
                    {
                        dtMedicosFiltrada.Rows.Add(
                        medico.Dni,
                        medico.Nombre,
                        medico.Apellido,
                        medico.Telefono,
                        medico.Correo,
                        medico.IdPais,
                        medico.Activo
                        );

                    }

                    GridView1.DataSource = dtMedicosFiltrada;
                    GridView1.DataBind();

                    lblMensaje.Text = "";


                }
                catch (Exception)
                {
                    lblMensaje.Text = "ERROR - NO EXISTE MÉDICO CON ESE DNI";
                }
            }
            else
            {
                CargarMedicos();
            }

        }
    }

}