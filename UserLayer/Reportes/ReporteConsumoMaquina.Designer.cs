namespace UserLayer
{
    partial class ReporteConsumoMaquina
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
            this.ReporteMaqBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSetConsumo = new UserLayer.DataSetConsumo();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.Maqchk = new System.Windows.Forms.CheckBox();
            this.ccchk = new System.Windows.Forms.CheckBox();
            this.fechachk = new System.Windows.Forms.CheckBox();
            this.maqtxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.cctxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.ReporteMaqTableAdapter = new UserLayer.DataSetConsumoTableAdapters.ReporteMaqTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.ReporteMaqBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetConsumo)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ReporteMaqBindingSource
            // 
            this.ReporteMaqBindingSource.DataMember = "ReporteMaq";
            this.ReporteMaqBindingSource.DataSource = this.DataSetConsumo;
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
            reportDataSource1.Value = this.ReporteMaqBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "UserLayer.Reportes.ReporteConsumoMaquina.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 60);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(934, 401);
            this.reportViewer1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.Maqchk);
            this.panel1.Controls.Add(this.ccchk);
            this.panel1.Controls.Add(this.fechachk);
            this.panel1.Controls.Add(this.maqtxt);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.cctxt);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dateTimePicker2);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(934, 60);
            this.panel1.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(808, 8);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(114, 46);
            this.button2.TabIndex = 21;
            this.button2.Text = "Ver Todo";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // Maqchk
            // 
            this.Maqchk.AutoSize = true;
            this.Maqchk.Location = new System.Drawing.Point(4, 40);
            this.Maqchk.Name = "Maqchk";
            this.Maqchk.Size = new System.Drawing.Size(122, 17);
            this.Maqchk.TabIndex = 20;
            this.Maqchk.Text = "Filtrado por Maquina";
            this.Maqchk.UseVisualStyleBackColor = true;
            // 
            // ccchk
            // 
            this.ccchk.AutoSize = true;
            this.ccchk.Location = new System.Drawing.Point(4, 23);
            this.ccchk.Name = "ccchk";
            this.ccchk.Size = new System.Drawing.Size(157, 17);
            this.ccchk.TabIndex = 19;
            this.ccchk.Text = "Filtrado por Centro de Costo";
            this.ccchk.UseVisualStyleBackColor = true;
            // 
            // fechachk
            // 
            this.fechachk.AutoSize = true;
            this.fechachk.Location = new System.Drawing.Point(4, 6);
            this.fechachk.Name = "fechachk";
            this.fechachk.Size = new System.Drawing.Size(111, 17);
            this.fechachk.TabIndex = 18;
            this.fechachk.Text = "Filtrado por Fecha";
            this.fechachk.UseVisualStyleBackColor = true;
            // 
            // maqtxt
            // 
            this.maqtxt.Location = new System.Drawing.Point(704, 8);
            this.maqtxt.Name = "maqtxt";
            this.maqtxt.Size = new System.Drawing.Size(98, 20);
            this.maqtxt.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(654, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Maquina";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(490, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "Filtrar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cctxt
            // 
            this.cctxt.Location = new System.Drawing.Point(526, 8);
            this.cctxt.Name = "cctxt";
            this.cctxt.Size = new System.Drawing.Size(98, 20);
            this.cctxt.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(442, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Centro de Costo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(313, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "a";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(329, 8);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(97, 20);
            this.dateTimePicker2.TabIndex = 5;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(210, 8);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(97, 20);
            this.dateTimePicker1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(167, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Fecha";
            // 
            // ReporteMaqTableAdapter
            // 
            this.ReporteMaqTableAdapter.ClearBeforeFill = true;
            // 
            // ReporteConsumoMaquina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 461);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ReporteConsumoMaquina";
            this.Text = "Consumo por Maquina";
            this.Load += new System.EventHandler(this.ReporteConsumoMaquina_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ReporteMaqBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetConsumo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox maqtxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox cctxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox Maqchk;
        private System.Windows.Forms.CheckBox ccchk;
        private System.Windows.Forms.CheckBox fechachk;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.BindingSource ReporteMaqBindingSource;
        private DataSetConsumo DataSetConsumo;
        private DataSetConsumoTableAdapters.ReporteMaqTableAdapter ReporteMaqTableAdapter;
    }
}