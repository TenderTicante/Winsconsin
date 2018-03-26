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
            //this.ReporteConsumoCCTableAdapter.ConsumoFull(this.DataSetConsumo.ReporteConsumoCC);

            //this.reportViewer1.RefreshReport();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.ReporteConsumoCCTableAdapter.ConsumoFull(this.DataSetConsumo.ReporteConsumoCC);

            this.reportViewer1.RefreshReport();
        }

        private void Apbtn_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                this.ReporteConsumoCCTableAdapter.FillFecha(this.DataSetConsumo.ReporteConsumoCC, dateTimePicker1.Value, dateTimePicker2.Value);

                this.reportViewer1.RefreshReport();
            }
        }

        private void Apbtn2_Click(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                if (textBox1.Text != string.Empty)
                {
                    this.ReporteConsumoCCTableAdapter.fillbyCC(this.DataSetConsumo.ReporteConsumoCC, Convert.ToInt32(textBox1.Text));
                    //MessageBox.Show(textBox1.Text);
                    this.reportViewer1.RefreshReport();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                this.ReporteConsumoCCTableAdapter.FillBoth(this.DataSetConsumo.ReporteConsumoCC, dateTimePicker1.Value, dateTimePicker2.Value, textBox1.Text);
                this.reportViewer1.RefreshReport();
            }
        }
    }
}
