using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace app_web
{
    public partial class Contact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarProyectos();
                CargarResponsables();
            }
        }

        private void CargarProyectos()
        {
            DataTable proyectos = Conexion.EjecutarConsulta("ObtenerProyectosConResponsable");
            gvProyectos.DataSource = proyectos;
            gvProyectos.DataBind();
        }

        private void CargarResponsables()
        {
            DataTable responsables = Conexion.EjecutarConsulta("ObtenerDesarrolladores");

            ddlResponsable.DataSource = responsables;
            ddlResponsable.DataTextField = "Nombre"; // Podrías combinar Nombre + Apellido si deseas
            ddlResponsable.DataValueField = "IdDesarrollador";
            ddlResponsable.DataBind();

            ddlResponsable.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Sin responsable", ""));
        }

        protected void btnAgregarProyecto_Click(object sender, EventArgs e)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@Nombre", txtNombreProyecto.Text),
                new SqlParameter("@Descripcion", txtDescripcionProyecto.Text),
                new SqlParameter("@FechaInicio", DateTime.Parse(txtFechaInicio.Text)),
                new SqlParameter("@IdResponsable", string.IsNullOrEmpty(ddlResponsable.SelectedValue) ? (object)DBNull.Value : ddlResponsable.SelectedValue)
            };

            Conexion.EjecutarComando("InsertarProyecto", parametros);

            CargarProyectos();
            txtNombreProyecto.Text = "";
            txtDescripcionProyecto.Text = "";
            txtFechaInicio.Text = "";
            ddlResponsable.SelectedIndex = 0;
        }

        protected void gvProyectos_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            gvProyectos.EditIndex = e.NewEditIndex;
            CargarProyectos();
        }

        protected void gvProyectos_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            gvProyectos.EditIndex = -1;
            CargarProyectos();
        }

        protected void gvProyectos_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            GridViewRow row = gvProyectos.Rows[e.RowIndex];

            int idProyecto = Convert.ToInt32(gvProyectos.DataKeys[e.RowIndex].Value);
            string nuevoNombre = ((System.Web.UI.WebControls.TextBox)row.Cells[1].Controls[0]).Text;
            string nuevaDescripcion = ((System.Web.UI.WebControls.TextBox)row.Cells[2].Controls[0]).Text;
            DateTime nuevaFecha = DateTime.Parse(((System.Web.UI.WebControls.TextBox)row.Cells[3].Controls[0]).Text);

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@IdProyecto", idProyecto),
                new SqlParameter("@NuevoNombre", nuevoNombre),
                new SqlParameter("@NuevaDescripcion", nuevaDescripcion),
                new SqlParameter("@NuevaFechaInicio", nuevaFecha),
                new SqlParameter("@NuevoIdResponsable", DBNull.Value) // Solo actualizamos campos básicos
            };

            Conexion.EjecutarComando("ActualizarProyecto", parametros);

            gvProyectos.EditIndex = -1;
            CargarProyectos();
        }

        protected void gvProyectos_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            int idProyecto = Convert.ToInt32(gvProyectos.DataKeys[e.RowIndex].Value);

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@IdProyecto", idProyecto)
            };

            Conexion.EjecutarComando("EliminarProyecto", parametros);
            CargarProyectos();
        }
    }
}
