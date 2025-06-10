using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace app_web
{
    public class Conexion
    {
        private static readonly string cadenaConexion = ConfigurationManager.ConnectionStrings["db_Software_connection"].ConnectionString;

        // Obtener la conexión SQL
        public static SqlConnection ObtenerConexion()
        {
            return new SqlConnection(cadenaConexion);
        }

        // Ejecutar procedimiento almacenado que devuelve datos (SELECT)
        public static DataTable EjecutarConsulta(string nombreSP, SqlParameter[] parametros = null)
        {
            using (SqlConnection conn = ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand(nombreSP, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (parametros != null)
                        cmd.Parameters.AddRange(parametros);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        // Ejecutar procedimiento almacenado que modifica datos (INSERT, UPDATE, DELETE)
        public static int EjecutarComando(string nombreSP, SqlParameter[] parametros = null)
        {
            using (SqlConnection conn = ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand(nombreSP, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (parametros != null)
                        cmd.Parameters.AddRange(parametros);

                    conn.Open();
                    return cmd.ExecuteNonQuery(); // Devuelve cantidad de filas afectadas
                }
            }
        }
    }
}
