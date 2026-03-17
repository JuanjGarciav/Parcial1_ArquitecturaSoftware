namespace CapaNegocio
{
    public class SolicitudCredito
    {
        public string TipoDoc { get; set; }
        public string NroDoc { get; set; }
        public double IngresosTotales { get; set; }
        public double EgresosTotales { get; set; }
        public double MontoSolicitado { get; set; }
        public int PlazoSolicitado { get; set; }  // en meses

        public SolicitudCredito() { }

        public SolicitudCredito(string tipoDoc, string nroDoc,
                                double ingresosTotales, double egresosTotales,
                                double montoSolicitado, int plazoSolicitado)
        {
            TipoDoc = tipoDoc;
            NroDoc = nroDoc;
            IngresosTotales = ingresosTotales;
            EgresosTotales = egresosTotales;
            MontoSolicitado = montoSolicitado;
            PlazoSolicitado = plazoSolicitado;
        }
    }
}