using System;
using System.Collections.Generic;
using System.Text;

namespace CapaNegocio
{
    // Open/Closed: esta clase está cerrada para modificación.
    // Para cambiar la fuente de datos se inyecta una nueva implementación (abierta para extensión).
    public class Logica
    {
        private readonly IFuenteDeDatos fuenteDeDatos;

        public Logica(IFuenteDeDatos fuenteDeDatos)
        {
            this.fuenteDeDatos = fuenteDeDatos;
        }

        // Método principal que orquesta las reglas de negocio
        public ResultadoEvaluacion evaluarCredito(SolicitudCredito solicitud)
        {
            if (!plazoEsValido(solicitud.PlazoSolicitado))
                return new ResultadoEvaluacion(false, "El plazo debe estar entre 1 y 72 meses.");

            double balanza = calcularBalanza(solicitud.IngresosTotales, solicitud.EgresosTotales);

            if (balanza <= 0)
                return new ResultadoEvaluacion(false, "Crédito negado: la balanza es cero o negativa.");

            double relacionCB = calcularRelacionCreditoBalanza(
                solicitud.MontoSolicitado, solicitud.PlazoSolicitado, balanza);

            if (relacionCB >= 0.95)
                return new ResultadoEvaluacion(false, "Crédito negado: relación crédito/balanza demasiado alta.");

            int puntajeMinimo = determinarPuntajeMinimo(relacionCB);
            int puntajeCliente = fuenteDeDatos.consultarPuntaje(solicitud.TipoDoc, solicitud.NroDoc);

            if (puntajeCliente >= puntajeMinimo)
                return new ResultadoEvaluacion(true,
                    $"Crédito APROBADO. Puntaje: {puntajeCliente} (mínimo requerido: {puntajeMinimo}).");
            else
                return new ResultadoEvaluacion(false,
                    $"Crédito negado: puntaje insuficiente. Tiene {puntajeCliente}, necesita {puntajeMinimo}.");
        }

  

        public bool plazoEsValido(int plazo)
        {
            return plazo >= 1 && plazo <= 72;
        }

        public double calcularBalanza(double ingresos, double egresos)
        {
            return ingresos - egresos;
        }

        public double calcularRelacionCreditoBalanza(double monto, int plazo, double balanza)
        {
            return monto / (plazo * balanza);
        }

        public int determinarPuntajeMinimo(double relacionCB)
        {
            if (relacionCB >= 0.7) return 800;
            if (relacionCB >= 0.4) return 600;
            return 400;
        }
    }
}
