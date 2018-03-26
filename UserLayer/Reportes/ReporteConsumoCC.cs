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
            // TODO: esta línea de código carga datos en la tabla 'DataSetConsumo.ReporteConsumoCC' Puede moverla o quitarla según sea necesario.
            this.ReporteConsumoCCTableAdapter.Fill(this.DataSetConsumo.ReporteConsumoCC);

            this.reportViewer1.RefreshReport();
        }
    }
}
