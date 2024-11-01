using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_Cuatrimestral_6A_Clínica
{
    public partial class AdministrarPacientes : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarPacientes();
            }
        }

        private void CargarPacientes()
        {

            DataTable dtPacientes = new DataTable();

            dtPacientes.Columns.Add("Id", typeof(int));
            dtPacientes.Columns.Add("Dni", typeof(long));
            dtPacientes.Columns.Add("Nombre", typeof(string));
            dtPacientes.Columns.Add("Apellido", typeof(string));
            dtPacientes.Columns.Add("Correo", typeof(string));
            dtPacientes.Columns.Add("NroTelefono", typeof(string));
            dtPacientes.Columns.Add("FechaNac", typeof(DateTime));
            dtPacientes.Columns.Add("IdPais", typeof(int));
            dtPacientes.Columns.Add("Direccion", typeof(string));
            dtPacientes.Columns.Add("FechaAlta", typeof(DateTime));
            dtPacientes.Columns.Add("Activo", typeof(bool));

            
            dtPacientes.Rows.Add(1,12345678, "Juan", "Pérez", "juan.perez@example.com", "123456789", DateTime.Parse("1980-05-15"), 1, "Calle Falsa 123", DateTime.Parse("2023-01-15"), true);
            dtPacientes.Rows.Add(2,87654321, "María", "García", "maria.garcia@example.com", "987654321", DateTime.Parse("1990-08-25"), 2, "Av. Siempre Viva 742", DateTime.Parse("2023-02-10"), true);
            dtPacientes.Rows.Add(3,11223344, "Carlos", "López", "carlos.lopez@example.com", "456123789", DateTime.Parse("1975-03-05"), 1, "Calle Los Álamos 456", DateTime.Parse("2023-03-05"), false);

            
            GridView1.DataSource = dtPacientes;
            GridView1.DataBind();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarPaciente.aspx");
        }
    }
}