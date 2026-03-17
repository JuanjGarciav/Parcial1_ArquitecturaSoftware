namespace CapaPresentacion
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTipoDoc = new Label();
            lblNroDoc = new Label();
            lblIngresos = new Label();
            lblEgresos = new Label();
            lblMonto = new Label();
            lblPlazo = new Label();
            cbTipoDoc = new ComboBox();
            tbNroDoc = new TextBox();
            tbIngresos = new TextBox();
            tbEgresos = new TextBox();
            tbMonto = new TextBox();
            tbPlazo = new TextBox();
            btnConsultar = new Button();
            btnLimpiar = new Button();
            SuspendLayout();

            // lblTipoDoc
            lblTipoDoc.AutoSize = true;
            lblTipoDoc.Location = new Point(20, 20);
            lblTipoDoc.Text = "Tipo Documento:";

            // cbTipoDoc
            cbTipoDoc.Location = new Point(170, 17);
            cbTipoDoc.Size = new Size(200, 28);
            cbTipoDoc.Items.AddRange(new object[] { "CC", "CE", "NIT", "PAS" });

            // lblNroDoc
            lblNroDoc.AutoSize = true;
            lblNroDoc.Location = new Point(20, 60);
            lblNroDoc.Text = "Número Documento:";

            // tbNroDoc
            tbNroDoc.Location = new Point(170, 57);
            tbNroDoc.Size = new Size(200, 27);

            // lblIngresos
            lblIngresos.AutoSize = true;
            lblIngresos.Location = new Point(20, 100);
            lblIngresos.Text = "Ingresos Totales ($):";

            // tbIngresos
            tbIngresos.Location = new Point(170, 97);
            tbIngresos.Size = new Size(200, 27);

            // lblEgresos
            lblEgresos.AutoSize = true;
            lblEgresos.Location = new Point(20, 140);
            lblEgresos.Text = "Egresos Totales ($):";

            // tbEgresos
            tbEgresos.Location = new Point(170, 137);
            tbEgresos.Size = new Size(200, 27);

            // lblMonto
            lblMonto.AutoSize = true;
            lblMonto.Location = new Point(20, 180);
            lblMonto.Text = "Monto Solicitado ($):";

            // tbMonto
            tbMonto.Location = new Point(170, 177);
            tbMonto.Size = new Size(200, 27);

            // lblPlazo
            lblPlazo.AutoSize = true;
            lblPlazo.Location = new Point(20, 220);
            lblPlazo.Text = "Plazo (meses, 1-72):";

            // tbPlazo
            tbPlazo.Location = new Point(170, 217);
            tbPlazo.Size = new Size(200, 27);

            // btnConsultar
            btnConsultar.Location = new Point(20, 265);
            btnConsultar.Size = new Size(350, 35);
            btnConsultar.Text = "Consultar Preaprobación";
            btnConsultar.Click += btnConsultar_Click;

            // btnLimpiar
            btnLimpiar.Location = new Point(20, 308);
            btnLimpiar.Size = new Size(350, 35);
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.Click += btnLimpiar_Click;

            // Form1
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 365);
            Controls.AddRange(new Control[] {
                lblTipoDoc, cbTipoDoc, lblNroDoc, tbNroDoc,
                lblIngresos, tbIngresos, lblEgresos, tbEgresos,
                lblMonto, tbMonto, lblPlazo, tbPlazo,
                btnConsultar, btnLimpiar
            });
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Text = "Consultar Preaprobación de Crédito";
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblTipoDoc, lblNroDoc, lblIngresos, lblEgresos, lblMonto, lblPlazo;
        private ComboBox cbTipoDoc;
        private TextBox tbNroDoc, tbIngresos, tbEgresos, tbMonto, tbPlazo;
        private Button btnConsultar, btnLimpiar;
    }
}