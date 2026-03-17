using CapaNegocio;

namespace CapaDatosPrueba
{
    // Liskov Substitution: reemplaza a ConexionSQLServer mediante la interfaz IFuenteDeDatos.
    // Permite ejecutar pruebas unitarias sin necesidad de la base de datos real.
    public class DatosMemoria : IFuenteDeDatos
    {
        private readonly Dictionary<(string tipoDoc, string nroDoc), int> datos;

        public DatosMemoria()
        {
            datos = new Dictionary<(string, string), int>
            {
                // Puntaje alto (>= 800): aprobado en cualquier franja
                { ("CC", "10000001"), 850 },

                // Puntaje medio-alto (750): aprobado si RC < 0.7, negado si RC >= 0.7
                { ("CC", "10000002"), 750 },

                // Puntaje medio (550): aprobado si RC < 0.4, negado si RC >= 0.4
                { ("CC", "10000003"), 550 },

                // Puntaje bajo (350): negado en cualquier franja
                { ("CC", "10000004"), 350 },
            };
        }

        public int consultarPuntaje(string tipoDoc, string nroDoc)
        {
            var clave = (tipoDoc, nroDoc);
            return datos.ContainsKey(clave) ? datos[clave] : 0;
        }
    }
}