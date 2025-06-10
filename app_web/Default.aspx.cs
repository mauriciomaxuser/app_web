using System;
using System.Data;
using System.Data.SqlClient;

namespace app_web
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDesarrolladores();
            }
        }

        private void CargarDesarrolladores()
        {
            gvDesarrolladores.DataSource = Conexion.EjecutarConsulta("ObtenerDesarrolladores");
            gvDesarrolladores.DataBind();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@Nombre", txtNombre.Text.Trim()),
                new SqlParameter("@Apellido", txtApellido.Text.Trim()),
                new SqlParameter("@Especialidad", txtEspecialidad.Text.Trim())
            };

            Conexion.EjecutarComando("InsertarDesarrollador", parametros);
            LimpiarFormulario();
            CargarDesarrolladores();
        }

        private void LimpiarFormulario()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtEspecialidad.Text = "";
        }

        protected void gvDesarrolladores_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            gvDesarrolladores.EditIndex = e.NewEditIndex;
            CargarDesarrolladores();
        }

        protected void gvDesarrolladores_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            gvDesarrolladores.EditIndex = -1;
            CargarDesarrolladores();
        }

        protected void gvDesarrolladores_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(gvDesarrolladores.DataKeys[e.RowIndex].Value);
            string nombre = ((System.Web.UI.WebControls.TextBox)gvDesarrolladores.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
            string apellido = ((System.Web.UI.WebControls.TextBox)gvDesarrolladores.Rows[e.RowIndex].Cells[2].Controls[0]).Text;
            string especialidad = ((System.Web.UI.WebControls.TextBox)gvDesarrolladores.Rows[e.RowIndex].Cells[3].Controls[0]).Text;

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@IdDesarrollador", id),
                new SqlParameter("@NuevoNombre", nombre),
                new SqlParameter("@NuevoApellido", apellido),
                new SqlParameter("@NuevaEspecialidad", especialidad)
            };

            Conexion.EjecutarComando("ActualizarDesarrollador", parametros);
            gvDesarrolladores.EditIndex = -1;
            CargarDesarrolladores();
        }

        protected void gvDesarrolladores_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gvDesarrolladores.DataKeys[e.RowIndex].Value);
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@IdDesarrollador", id)
            };

            Conexion.EjecutarComando("EliminarDesarrollador", parametros);
            CargarDesarrolladores();
        }
    }
}
