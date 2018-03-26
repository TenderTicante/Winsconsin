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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Apbut = new System.Windows.Forms.Button();
            this.ReporteConsumoCCBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSetConsumo = new UserLayer.DataSetConsumo();
            this.ReporteConsumoCCTableAdapter = new UserLayer.DataSetConsumoTableAdapters.ReporteConsumoCCTableAdapter();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Apbtn2 = new System.Windows.Forms.Button();
            this.abertodos = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ReporteConsumoCCBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetConsumo)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.ReporteConsumoCCBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "UserLayer.Reportes.ReporteConsumoCC.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 24);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(984, 437);
            this.reportViewer1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2);
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(984, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(113, 2);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(95, 20);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(253, 2);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(95, 20);
            this.dateTimePicker2.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Filtrado por Fecha";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(223, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "a";
            // 
            // Apbut
            // 
            this.Apbut.Location = new System.Drawing.Point(373, 1);
            this.Apbut.Name = "Apbut";
            this.Apbut.Size = new System.Drawing.Size(75, 23);
            this.Apbut.TabIndex = 6;
            this.Apbut.Text = "Aplicar";
            this.Apbut.UseVisualStyleBackColor = true;
            this.Apbut.Click += new System.EventHandler(this.Apbut_Click);
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
            // ReporteConsumoCCTableAdapter
            // 
            this.ReporteConsumoCCTableAdapter.ClearBeforeFill = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(472, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Filtrado por Centro de Costo";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(621, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 8;
            // 
            // Apbtn2
            // 
            this.Apbtn2.Location = new System.Drawing.Point(734, 0);
            this.Apbtn2.Name = "Apbtn2";
            this.Apbtn2.Size = new System.Drawing.Size(75, 23);
            this.Apbtn2.TabIndex = 9;
            this.Apbtn2.Text = "Aplicar";
            this.Apbtn2.UseVisualStyleBackColor = true;
            // 
            // abertodos
            // 
            this.abertodos.Location = new System.Drawing.Point(841, 0);
            this.abertodos.Name = "abertodos";
            this.abertodos.Size = new System.Drawing.Size(127, 23);
            this.abertodos.TabIndex = 10;
            this.abertodos.Text = "Ver Todos las salidas";
            this.abertodos.UseVisualStyleBackColor = true;
            this.abertodos.Click += new System.EventHandler(this.abertodos_Click);
            // 
            // ReporteConsumoCC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 461);
            this.Controls.Add(this.abertodos);
            this.Controls.Add(this.Apbtn2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Apbut);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ReporteConsumoCC";
            this.Text = "Consumo Centro de Costo";
            this.Load += new System.EventHandler(this.ReporteConsumoCC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ReporteConsumoCCBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetConsumo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource ReporteConsumoCCBindingSource;
        private DataSetConsumo DataSetConsumo;
        private DataSetConsumoTableAdapters.ReporteConsumoCCTableAdapter ReporteConsumoCCTableAdapter;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Apbut;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button Apbtn2;
        private System.Windows.Forms.Button abertodos;
    }
}