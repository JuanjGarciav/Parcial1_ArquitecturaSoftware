using CapaDatosPrueba;
using CapaNegocio;

namespace PruebasUnitarias
{

    // CC-10000001 → puntaje 850  (>= 800, >= 600, >= 400)
    // CC-10000002 → puntaje 750  (>= 600, >= 400, pero < 800)
    // CC-10000003 → puntaje 550  (>= 400, pero < 600 y < 800)
    // CC-10000004 → puntaje 350  (< 400, < 600, < 800)
    //
    // Fórmulas usadas en los tests (Balanza=1000, Plazo=12):
    //   RC = Monto / (Plazo * Balanza)
    //   RC = 1.0  → Monto = 12000
    //   RC = 0.95 → Monto = 11400
    //   RC = 0.80 → Monto = 9600
    //   RC = 0.70 → Monto = 8400
    //   RC = 0.50 → Monto = 6000
    //   RC = 0.40 → Monto = 4800
    //   RC = 0.30 → Monto = 3600

    [TestClass]
    public sealed class LogicaTest
    {
        Logica logica = new Logica(new DatosMemoria());

   

        [TestMethod]
        public void plazoMenorA1_debeNegarCredito()
        {
            var solicitud = new SolicitudCredito("CC", "10000001", 2000, 1000, 3600, 0);
            var resultado = logica.evaluarCredito(solicitud);
            Assert.IsFalse(resultado.Aprobado);
        }

        [TestMethod]
        public void plazoMayorA72_debeNegarCredito()
        {
            var solicitud = new SolicitudCredito("CC", "10000001", 2000, 1000, 3600, 73);
            var resultado = logica.evaluarCredito(solicitud);
            Assert.IsFalse(resultado.Aprobado);
        }

        [TestMethod]
        public void plazoLimiteInferior1_esValido()
        {
            // RC = 3600 / (1 * 1000) = 3.6 → >= 0.95 → negado por RC, no por plazo
            // Usamos monto pequeño para que RC < 0.95
            var solicitud = new SolicitudCredito("CC", "10000001", 2000, 1000, 300, 1);
            var resultado = logica.evaluarCredito(solicitud);
            // RC = 300 / (1 * 1000) = 0.3 → puntajeMinimo=400, puntaje=850 → aprobado
            Assert.IsTrue(resultado.Aprobado);
        }

        [TestMethod]
        public void plazoLimiteSuperior72_esValido()
        {
            var solicitud = new SolicitudCredito("CC", "10000001", 2000, 1000, 21600, 72);
            var resultado = logica.evaluarCredito(solicitud);
            // RC = 21600 / (72 * 1000) = 0.3 → puntajeMinimo=400, puntaje=850 → aprobado
            Assert.IsTrue(resultado.Aprobado);
        }

        // ── VALIDACIÓN DE BALANZA ────────────────────────────────────────

        [TestMethod]
        public void balanzaCero_debeNegarCredito()
        {
            var solicitud = new SolicitudCredito("CC", "10000001", 1000, 1000, 3600, 12);
            var resultado = logica.evaluarCredito(solicitud);
            Assert.IsFalse(resultado.Aprobado);
        }

        [TestMethod]
        public void balanzaNegativa_debeNegarCredito()
        {
            var solicitud = new SolicitudCredito("CC", "10000001", 500, 1000, 3600, 12);
            var resultado = logica.evaluarCredito(solicitud);
            Assert.IsFalse(resultado.Aprobado);
        }


        [TestMethod]
        public void relacionIgualA95_debeNegarCredito()
        {
            // RC = 11400 / (12 * 1000) = 0.95
            var solicitud = new SolicitudCredito("CC", "10000001", 2000, 1000, 11400, 12);
            var resultado = logica.evaluarCredito(solicitud);
            Assert.IsFalse(resultado.Aprobado);
        }

        [TestMethod]
        public void relacionMayorA95_debeNegarCredito()
        {
            // RC = 12000 / (12 * 1000) = 1.0
            var solicitud = new SolicitudCredito("CC", "10000001", 2000, 1000, 12000, 12);
            var resultado = logica.evaluarCredito(solicitud);
            Assert.IsFalse(resultado.Aprobado);
        }



        [TestMethod]
        public void relacionEntre70y95_puntajeSuficiente_debeAprobar()
        {
            // RC = 8400 / (12 * 1000) = 0.70, puntaje 850 >= 800
            var solicitud = new SolicitudCredito("CC", "10000001", 2000, 1000, 8400, 12);
            var resultado = logica.evaluarCredito(solicitud);
            Assert.IsTrue(resultado.Aprobado);
        }

        [TestMethod]
        public void relacionEntre70y95_puntajeInsuficiente_debeNegarCredito()
        {
            // RC = 8400 / (12 * 1000) = 0.70, puntaje 750 < 800
            var solicitud = new SolicitudCredito("CC", "10000002", 2000, 1000, 8400, 12);
            var resultado = logica.evaluarCredito(solicitud);
            Assert.IsFalse(resultado.Aprobado);
        }

   

        [TestMethod]
        public void relacionEntre40y70_puntajeSuficiente_debeAprobar()
        {
            // RC = 4800 / (12 * 1000) = 0.40, puntaje 750 >= 600
            var solicitud = new SolicitudCredito("CC", "10000002", 2000, 1000, 4800, 12);
            var resultado = logica.evaluarCredito(solicitud);
            Assert.IsTrue(resultado.Aprobado);
        }

        [TestMethod]
        public void relacionEntre40y70_puntajeInsuficiente_debeNegarCredito()
        {
            // RC = 4800 / (12 * 1000) = 0.40, puntaje 550 < 600
            var solicitud = new SolicitudCredito("CC", "10000003", 2000, 1000, 4800, 12);
            var resultado = logica.evaluarCredito(solicitud);
            Assert.IsFalse(resultado.Aprobado);
        }


        [TestMethod]
        public void relacionMenorA40_puntajeSuficiente_debeAprobar()
        {
            // RC = 3600 / (12 * 1000) = 0.30, puntaje 550 >= 400
            var solicitud = new SolicitudCredito("CC", "10000003", 2000, 1000, 3600, 12);
            var resultado = logica.evaluarCredito(solicitud);
            Assert.IsTrue(resultado.Aprobado);
        }

        [TestMethod]
        public void relacionMenorA40_puntajeInsuficiente_debeNegarCredito()
        {
            // RC = 3600 / (12 * 1000) = 0.30, puntaje 350 < 400
            var solicitud = new SolicitudCredito("CC", "10000004", 2000, 1000, 3600, 12);
            var resultado = logica.evaluarCredito(solicitud);
            Assert.IsFalse(resultado.Aprobado);
        }



        [TestMethod]
        public void calcularBalanza_debeRestarCorrectamente()
        {
            double balanza = logica.calcularBalanza(3000, 1000);
            Assert.AreEqual(2000, balanza);
        }

        [TestMethod]
        public void calcularRelacion_debeCalcularCorrectamente()
        {
            double rc = logica.calcularRelacionCreditoBalanza(4800, 12, 1000);
            Assert.AreEqual(0.4, rc, 0.0001);
        }

        [TestMethod]
        public void determinarPuntajeMinimo_relacionAlta_debe800()
        {
            Assert.AreEqual(800, logica.determinarPuntajeMinimo(0.70));
            Assert.AreEqual(800, logica.determinarPuntajeMinimo(0.80));
        }

        [TestMethod]
        public void determinarPuntajeMinimo_relacionMedia_debe600()
        {
            Assert.AreEqual(600, logica.determinarPuntajeMinimo(0.40));
            Assert.AreEqual(600, logica.determinarPuntajeMinimo(0.55));
        }

        [TestMethod]
        public void determinarPuntajeMinimo_relacionBaja_debe400()
        {
            Assert.AreEqual(400, logica.determinarPuntajeMinimo(0.39));
            Assert.AreEqual(400, logica.determinarPuntajeMinimo(0.10));
        }
    }
}