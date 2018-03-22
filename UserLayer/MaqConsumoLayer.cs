using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using StructLayer;

namespace UserLayer
{
    public partial class MaqConsumoLayer : Form
    {
        public MaqConsumoLayer()
        {
            InitializeComponent();
        }
        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
        }
        //Mostrar los Proveedores Registrados en la base de datos
        private void MostrarColumnas()
        {
            this.dataListado.DataSource = MaquinaStruct.Mostrar();
            this.OcultarColumnas();
            Registroslbl.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);

        }
        //Buscar por Numero de Maquina
        private void BuscarxNoMaq()
        {
            this.dataListado.DataSource = MaquinaStruct.BuscarxNoMaq(this.txtBuscar.Text);
            this.OcultarColumnas();
            Registroslbl.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            ConsumoMaqLayer layer = ConsumoMaqLayer.GetInstancia();
            string string1;
            string1 = Convert.ToString(this.dataListado.CurrentRow.Cells["NoMaquina"].Value);
            layer.setMaq(string1);
            this.Hide();
        }

        private void MaqConsumoLayer_Load(object sender, EventArgs e)
        {
            MostrarColumnas();
        }
    }
}
