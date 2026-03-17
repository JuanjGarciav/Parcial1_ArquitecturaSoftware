using CapaNegocio;
using Microsoft.Data.SqlClient;

namespace CapaAccesoDatos
{
    // Liskov Substitution: esta clase puede reemplazar a IFuenteDeDatos en cualquier contexto.
    public class ConexionSQLServer : IFuenteDeDatos
    {
        private readonly SqlConnection conexion;

        public ConexionSQLServer()
        {
            conexion = new SqlConnection(
                @"Data Source=HP-PAVILION-GAM\SQLEXPRESS;" +
                @"Initial Catalog=PreaprobacionCredito;" +
                @"Persist Security Info=True;" +
                @"User ID=sa;" +
                @"Password=Juanjose4021;" +
                @"TrustServerCertificate=True;" +
                @"Encrypt=True;"
            );
        }

        public int consultarPuntaje(string tipoDoc, string nroDoc)
        {
            string query = string.Format(
                "SELECT puntaje FROM central_riesgo WHERE tipoDoc = '{0}' AND nroDoc = '{1}'",
                tipoDoc, nroDoc);

            conexion.Open();
            SqlCommand comando = new SqlCommand(query, conexion);
            object resultado = comando.ExecuteScalar();
            conexion.Close();

            return resultado != null ? Convert.ToInt32(resultado) : 0;
        }
    }
}