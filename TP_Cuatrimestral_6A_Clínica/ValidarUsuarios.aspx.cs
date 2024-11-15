using Controlador;
using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_Cuatrimestral_6A_Clínica
{
    public partial class WebForm6 : System.Web.UI.Page
    {

        ControladorUsuarios controladorUsuarios = new ControladorUsuarios();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("Login.aspx");

            }

            if (!IsPostBack)

            {

                CargarUsuariosPendientes();

            }
           
        }


        private void CargarUsuariosPendientes()
        {
            try
            {
                var ListaUsuariosPendientes = controladorUsuarios.Listar();



                DataTable dtUsuariosPendientes = new DataTable();
                dtUsuariosPendientes.Columns.Add("Id", typeof(int));
                dtUsuariosPendientes.Columns.Add("Dni", typeof(string));
                dtUsuariosPendientes.Columns.Add("Correo", typeof(string));
                dtUsuariosPendientes.Columns.Add("IdRol", typeof(int));
                dtUsuariosPendientes.Columns.Add("Verificacion", typeof(string));

                foreach (var usuario in ListaUsuariosPendientes)
                {
                    if (usuario.Activo== true && usuario.Verificacion.Equals("Pendiente"))
                    {
                        dtUsuariosPendientes.Rows.Add(
                        usuario.IdUsuario,
                        usuario.Dni,
                        usuario.Correo,
                        usuario.IdRol,
                        usuario.Verificacion
                    );
                    }
                    
                }

                gvUsuariosPendientes.DataSource = dtUsuariosPendientes;
                gvUsuariosPendientes.DataBind();

            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al cargar Usuarios: " + ex.Message;
            }
        }


        protected void gvUsuariosPendientes_RowEditing(object sender, GridViewEditEventArgs e)
        {
              Usuario seleccionado = new Usuario();
              int indice = e.NewEditIndex;
              int IdAUX = Int32.Parse(gvUsuariosPendientes.Rows[indice].Cells[0].Text.ToString());

              controladorUsuarios.ValidarUsuario(IdAUX);
              

              Response.Redirect("ValidarUsuarios.aspx");
            
        }
    }
}