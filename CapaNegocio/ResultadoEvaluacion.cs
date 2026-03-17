using System;
using System.Collections.Generic;
using System.Text;

namespace CapaNegocio
{
    public class ResultadoEvaluacion
    {
        public bool Aprobado { get; set; }
        public string Mensaje { get; set; }

        public ResultadoEvaluacion(bool aprobado, string mensaje)
        {
            Aprobado = aprobado;
            Mensaje = mensaje;
        }
    }
}