using CapaAccesoDatos;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class Form1 : Form
    {
        // Inyección de dependencia: usa SQL Server en producción
        private readonly Logica logica = new Logica(new ConexionSQLServer());

        public Form1()
        {
            InitializeComponent();
            cbTipoDoc.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            // --- Validaciones de campos vacíos ---
            if (cbTipoDoc.Text == "")
            {
                MessageBox.Show(this, "Seleccione el tipo de documento.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (tbNroDoc.Text.Trim() == "")
            {
                MessageBox.Show(this, "Ingrese el número de documento.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // --- Parseo y validación de valores numéricos ---
            if (!double.TryParse(tbIngresos.Text, out double ingresos) || ingresos < 0)
            {
                MessageBox.Show(this, "Ingrese un valor válido para Ingresos Totales.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!double.TryParse(tbEgresos.Text, out double egresos) || egresos < 0)
            {
                MessageBox.Show(this, "Ingrese un valor válido para Egresos Totales.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!double.TryParse(tbMonto.Text, out double monto) || monto <= 0)
            {
                MessageBox.Show(this, "Ingrese un monto solicitado válido.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!int.TryParse(tbPlazo.Text, out int plazo))
            {
                MessageBox.Show(this, "Ingrese un plazo válido (número entero de meses).", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // --- Armar solicitud y evaluar ---
            SolicitudCredito solicitud = new SolicitudCredito(
                cbTipoDoc.Text,
                tbNroDoc.Text.Trim(),
                ingresos,
                egresos,
                monto,
                plazo
            );

            ResultadoEvaluacion resultado = logica.evaluarCredito(solicitud);

            MessageBoxIcon icono = resultado.Aprobado ? MessageBoxIcon.Information : MessageBoxIcon.Warning;
            string titulo = resultado.Aprobado ? "✅ Crédito Aprobado" : "❌ Crédito Negado";

            MessageBox.Show(this, resultado.Mensaje, titulo, MessageBoxButtons.OK, icono);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            cbTipoDoc.SelectedIndex = -1;
            tbNroDoc.Text = "";
            tbIngresos.Text = "";
            tbEgresos.Text = "";
            tbMonto.Text = "";
            tbPlazo.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}