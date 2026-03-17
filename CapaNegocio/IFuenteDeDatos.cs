using System;
using System.Collections.Generic;
using System.Text;

namespace CapaNegocio
{
    // Principio de Inversión de Dependencias:
    // Logica depende de esta abstracción, no de implementaciones concretas.
    public interface IFuenteDeDatos
    {
        int consultarPuntaje(string tipoDoc, string nroDoc);
    }
}