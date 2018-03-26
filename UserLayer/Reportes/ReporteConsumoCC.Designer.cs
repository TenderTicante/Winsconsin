namespace UserLayer
{
    partial class ReporteConsumoCC
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.ReporteConsumoCCBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSetConsumo = new UserLayer.DataSetConsumo();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ReporteConsumoCCTableAdapter = new UserLayer.DataSetConsumoTableAdapters.ReporteConsumoCCTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.ReporteConsumoCCBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetConsumo)).BeginInit();
            this.SuspendLayout();
            // 
            // ReporteConsumoCCBindingSource
            // 
            this.ReporteConsumoCCBindingSource.DataMember = "ReporteConsumoCC";
            this.ReporteConsumoCCBindingSource.DataSource = this.DataSetConsumo;
            // 
            // DataSetConsumo
            // 
            this.DataSetConsumo.DataSetName = "DataSetConsumo";
            this.DataSetConsumo.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.ReporteConsumoCCBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "UserLayer.Reportes.ReporteConsumoCC.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(641, 461);
            this.reportViewer1.TabIndex = 0;
            // 
            // ReporteConsumoCCTableAdapter
            // 
            this.ReporteConsumoCCTableAdapter.ClearBeforeFill = true;
            // 
            // ReporteConsumoCC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 461);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ReporteConsumoCC";
            this.Text = "Consumo Centro de Costo";
            this.Load += new System.EventHandler(this.ReporteConsumoCC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ReporteConsumoCCBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetConsumo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource ReporteConsumoCCBindingSource;
        private DataSetConsumo DataSetConsumo;
        private DataSetConsumoTableAdapters.ReporteConsumoCCTableAdapter ReporteConsumoCCTableAdapter;
    }
}