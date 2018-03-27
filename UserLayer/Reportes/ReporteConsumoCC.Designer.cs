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
            this.panel1 = new System.Windows.Forms.Panel();
            this.ccchk = new System.Windows.Forms.CheckBox();
            this.fechachk = new System.Windows.Forms.CheckBox();
            this.button3 = new System.Windows.Forms.Button();
            this.Apbtn = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.ReporteConsumoCCTableAdapter = new UserLayer.DataSetConsumoTableAdapters.ReporteConsumoCCTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.ReporteConsumoCCBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetConsumo)).BeginInit();
            this.panel1.SuspendLayout();
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
            this.reportViewer1.Location = new System.Drawing.Point(0, 70);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(834, 391);
            this.reportViewer1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ccchk);
            this.panel1.Controls.Add(this.fechachk);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.Apbtn);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dateTimePicker2);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(834, 70);
            this.panel1.TabIndex = 1;
            // 
            // ccchk
            // 
            this.ccchk.AutoSize = true;
            this.ccchk.Location = new System.Drawing.Point(12, 35);
            this.ccchk.Name = "ccchk";
            this.ccchk.Size = new System.Drawing.Size(157, 17);
            this.ccchk.TabIndex = 14;
            this.ccchk.Text = "Filtrado por Centro de Costo";
            this.ccchk.UseVisualStyleBackColor = true;
            // 
            // fechachk
            // 
            this.fechachk.AutoSize = true;
            this.fechachk.Location = new System.Drawing.Point(13, 12);
            this.fechachk.Name = "fechachk";
            this.fechachk.Size = new System.Drawing.Size(111, 17);
            this.fechachk.TabIndex = 13;
            this.fechachk.Text = "Filtrado por Fecha";
            this.fechachk.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(750, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 48);
            this.button3.TabIndex = 11;
            this.button3.Text = "Ver \r\nTodo";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Apbtn
            // 
            this.Apbtn.Location = new System.Drawing.Point(345, 37);
            this.Apbtn.Name = "Apbtn";
            this.Apbtn.Size = new System.Drawing.Size(75, 23);
            this.Apbtn.TabIndex = 15;
            this.Apbtn.Text = "Filtrar";
            this.Apbtn.Click += new System.EventHandler(this.Apbtn_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(637, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(98, 20);
            this.textBox1.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(502, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Filtrar por Centro de Costo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(371, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "a";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(392, 11);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(97, 20);
            this.dateTimePicker2.TabIndex = 5;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(264, 11);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(95, 20);
            this.dateTimePicker1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(175, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Filtrar por Fecha";
            // 
            // ReporteConsumoCCTableAdapter
            // 
            this.ReporteConsumoCCTableAdapter.ClearBeforeFill = true;
            // 
            // ReporteConsumoCC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 461);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ReporteConsumoCC";
            this.Text = "Consumo Centro de Costo";
            this.Load += new System.EventHandler(this.ReporteConsumoCC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ReporteConsumoCCBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetConsumo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource ReporteConsumoCCBindingSource;
        private DataSetConsumo DataSetConsumo;
        private DataSetConsumoTableAdapters.ReporteConsumoCCTableAdapter ReporteConsumoCCTableAdapter;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Apbtn;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.CheckBox ccchk;
        private System.Windows.Forms.CheckBox fechachk;
    }
}