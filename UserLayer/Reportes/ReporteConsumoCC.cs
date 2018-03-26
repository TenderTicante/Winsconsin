using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserLayer
{
    public partial class ReporteConsumoCC : Form
    {
        public ReporteConsumoCC()
        {
            InitializeComponent();
        }

        private void ReporteConsumoCC_Load(object sender, EventArgs e)
        {

        }

        private void Apbut_Click(object sender, EventArgs e)
        {
            this.ReporteConsumoCCTableAdapter.FillFecha(this.DataSetConsumo.ReporteConsumoCC,dateTimePicker1.Value,dateTimePicker2.Value);

            this.reportViewer1.RefreshReport();
        }

        private void abertodos_Click(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DataSetConsumo.ReporteConsumoCC' Puede moverla o quitarla según sea necesario.
            this.ReporteConsumoCCTableAdapter.ConsumoFull(this.DataSetConsumo.ReporteConsumoCC);

            this.reportViewer1.RefreshReport();
        }
    }
}
