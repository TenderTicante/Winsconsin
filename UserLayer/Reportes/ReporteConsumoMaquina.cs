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
    public partial class ReporteConsumoMaquina : Form
    {
        public ReporteConsumoMaquina()
        {
            InitializeComponent();
        }

        private void ReporteConsumoMaquina_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DataSetConsumo.ReporteMaq' Puede moverla o quitarla según sea necesario.
            //this.ReporteMaqTableAdapter.FillCompletly(this.DataSetConsumo.ReporteMaq);
            //this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(fechachk.Checked == true)
            {
                this.ReporteMaqTableAdapter.FillFecha(this.DataSetConsumo.ReporteMaq,dateTimePicker1.Value,dateTimePicker2.Value);
                this.reportViewer1.RefreshReport();
            }
            else if (ccchk.Checked == true)
            {
                this.ReporteMaqTableAdapter.FillByCC(this.DataSetConsumo.ReporteMaq, cctxt.Text);
                this.reportViewer1.RefreshReport();
            }
            else if (Maqchk.Checked == true)
            {
                this.ReporteMaqTableAdapter.FillByMaq(this.DataSetConsumo.ReporteMaq, maqtxt.Text);
                this.reportViewer1.RefreshReport();
            }
            else if (fechachk.Checked == true && ccchk.Checked == true)
            {
                this.ReporteMaqTableAdapter.FillByCCandFecha(this.DataSetConsumo.ReporteMaq, dateTimePicker1.Value, dateTimePicker2.Value, cctxt.Text);
                this.reportViewer1.RefreshReport();
            }
            else if (fechachk.Checked == true && Maqchk.Checked == true)
            {
                this.ReporteMaqTableAdapter.FillByMaqandFecha(this.DataSetConsumo.ReporteMaq, dateTimePicker1.Value, dateTimePicker2.Value, maqtxt.Text);
                this.reportViewer1.RefreshReport();
            }
            else if (ccchk.Checked == true && Maqchk.Checked )
            {
                this.ReporteMaqTableAdapter.FillByMaqandCC(this.DataSetConsumo.ReporteMaq, cctxt.Text, maqtxt.Text);
                this.reportViewer1.RefreshReport();
            }
            else if (ccchk.Checked == true && Maqchk.Checked && fechachk.Checked)
            {
                this.ReporteMaqTableAdapter.FillFully(this.DataSetConsumo.ReporteMaq, dateTimePicker1.Value, dateTimePicker2.Value, cctxt.Text, maqtxt.Text);
                this.reportViewer1.RefreshReport();
            }
        }
    }
}
