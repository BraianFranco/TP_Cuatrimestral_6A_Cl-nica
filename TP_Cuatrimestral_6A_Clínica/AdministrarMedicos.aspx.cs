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


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                CargarMedicos();
            }
        }

        private void CargarMedicos()
        {
          
            DataTable dtMedicos = new DataTable();

           
            dtMedicos.Columns.Add("Id", typeof(int));
            dtMedicos.Columns.Add("Dni", typeof(long));
            dtMedicos.Columns.Add("Nombre", typeof(string));
            dtMedicos.Columns.Add("Apellido", typeof(string));
            dtMedicos.Columns.Add("Correo", typeof(string));
            dtMedicos.Columns.Add("IdPais", typeof(int));
            dtMedicos.Columns.Add("FechaAlta", typeof(DateTime));

          
            dtMedicos.Rows.Add(1, 12345678, "Juan", "Pérez", "juan.perez@example.com", 1, DateTime.Parse("2023-01-15"));
            dtMedicos.Rows.Add(2, 87654321, "María", "García", "maria.garcia@example.com", 2, DateTime.Parse("2023-02-10"));
            dtMedicos.Rows.Add(3, 11223344, "Carlos", "López", "carlos.lopez@example.com", 1, DateTime.Parse("2023-03-05"));

            
            GridView1.DataSource = dtMedicos;
            GridView1.DataBind();
        }

      
    }
}