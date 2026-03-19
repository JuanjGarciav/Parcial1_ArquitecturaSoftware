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
          
            lblTipoDoc.AutoSize = true;
            lblTipoDoc.Location = new Point(20, 20);
            lblTipoDoc.Name = "lblTipoDoc";
            lblTipoDoc.Size = new Size(124, 20);
            lblTipoDoc.TabIndex = 0;
            lblTipoDoc.Text = "Tipo Documento:";
         
            lblNroDoc.AutoSize = true;
            lblNroDoc.Location = new Point(20, 60);
            lblNroDoc.Name = "lblNroDoc";
            lblNroDoc.Size = new Size(148, 20);
            lblNroDoc.TabIndex = 2;
            lblNroDoc.Text = "Número Documento:";
          
            lblIngresos.AutoSize = true;
            lblIngresos.Location = new Point(20, 100);
            lblIngresos.Name = "lblIngresos";
            lblIngresos.Size = new Size(140, 20);
            lblIngresos.TabIndex = 4;
            lblIngresos.Text = "Ingresos Totales ($):";
          
            lblEgresos.AutoSize = true;
            lblEgresos.Location = new Point(20, 140);
            lblEgresos.Name = "lblEgresos";
            lblEgresos.Size = new Size(136, 20);
            lblEgresos.TabIndex = 6;
            lblEgresos.Text = "Egresos Totales ($):";
           
            lblMonto.AutoSize = true;
            lblMonto.Location = new Point(20, 180);
            lblMonto.Name = "lblMonto";
            lblMonto.Size = new Size(149, 20);
            lblMonto.TabIndex = 8;
            lblMonto.Text = "Monto Solicitado ($):";
          
            lblPlazo.AutoSize = true;
            lblPlazo.Location = new Point(20, 220);
            lblPlazo.Name = "lblPlazo";
            lblPlazo.Size = new Size(140, 20);
            lblPlazo.TabIndex = 10;
            lblPlazo.Text = "Plazo (meses, 1-72):";
          
            cbTipoDoc.Items.AddRange(new object[] { "CC", "CE", "NIT", "PAS" });
            cbTipoDoc.Location = new Point(170, 17);
            cbTipoDoc.Name = "cbTipoDoc";
            cbTipoDoc.Size = new Size(200, 28);
            cbTipoDoc.TabIndex = 1;
           
            tbNroDoc.Location = new Point(170, 57);
            tbNroDoc.Name = "tbNroDoc";
            tbNroDoc.Size = new Size(200, 27);
            tbNroDoc.TabIndex = 3;
           
            tbIngresos.Location = new Point(170, 97);
            tbIngresos.Name = "tbIngresos";
            tbIngresos.Size = new Size(200, 27);
            tbIngresos.TabIndex = 5;
           
            tbEgresos.Location = new Point(170, 137);
            tbEgresos.Name = "tbEgresos";
            tbEgresos.Size = new Size(200, 27);
            tbEgresos.TabIndex = 7;
            
            tbMonto.Location = new Point(170, 177);
            tbMonto.Name = "tbMonto";
            tbMonto.Size = new Size(200, 27);
            tbMonto.TabIndex = 9;
           
            tbPlazo.Location = new Point(170, 217);
            tbPlazo.Name = "tbPlazo";
            tbPlazo.Size = new Size(200, 27);
            tbPlazo.TabIndex = 11;
           
            btnConsultar.Location = new Point(20, 265);
            btnConsultar.Name = "btnConsultar";
            btnConsultar.Size = new Size(350, 35);
            btnConsultar.TabIndex = 12;
            btnConsultar.Text = "Consultar Preaprobación";
            btnConsultar.Click += btnConsultar_Click;
            
            btnLimpiar.Location = new Point(20, 308);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(350, 35);
            btnLimpiar.TabIndex = 13;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.Click += btnLimpiar_Click;
            
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 365);
            Controls.Add(lblTipoDoc);
            Controls.Add(cbTipoDoc);
            Controls.Add(lblNroDoc);
            Controls.Add(tbNroDoc);
            Controls.Add(lblIngresos);
            Controls.Add(tbIngresos);
            Controls.Add(lblEgresos);
            Controls.Add(tbEgresos);
            Controls.Add(lblMonto);
            Controls.Add(tbMonto);
            Controls.Add(lblPlazo);
            Controls.Add(tbPlazo);
            Controls.Add(btnConsultar);
            Controls.Add(btnLimpiar);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            Text = "Consultar Preaprobación de Crédito";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblTipoDoc, lblNroDoc, lblIngresos, lblEgresos, lblMonto, lblPlazo;
        private ComboBox cbTipoDoc;
        private TextBox tbNroDoc, tbIngresos, tbEgresos, tbMonto, tbPlazo;
        private Button btnConsultar, btnLimpiar;
    }
}