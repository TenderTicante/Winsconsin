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

        private void button3_Click(object sender, EventArgs e)
        {
            this.ReporteConsumoCCTableAdapter.ConsumoFull(this.DataSetConsumo.ReporteConsumoCC);
            this.reportViewer1.RefreshReport();
        }

        private void Apbtn_Click(object sender, EventArgs e)
        {
            if (fechachk.Checked == true)
            {
                this.ReporteConsumoCCTableAdapter.FillFecha(this.DataSetConsumo.ReporteConsumoCC,dateTimePicker1.Value,dateTimePicker2.Value);
                this.reportViewer1.RefreshReport();
            }
            else if (ccchk.Checked == true)
            {
                this.ReporteConsumoCCTableAdapter.fillbyCC(this.DataSetConsumo.ReporteConsumoCC,Convert.ToInt32(textBox1.Text));
                this.reportViewer1.RefreshReport();
            }
            else if(fechachk.Checked == true && ccchk.Checked == true)
            {
                this.ReporteConsumoCCTableAdapter.FillBoth(this.DataSetConsumo.ReporteConsumoCC, dateTimePicker1.Value, dateTimePicker2.Value,textBox1.Text);
                this.reportViewer1.RefreshReport();
            }
        }
    }
}
