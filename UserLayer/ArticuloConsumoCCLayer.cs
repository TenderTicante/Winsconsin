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
    public partial class ArticuloConsumoCCLayer : Form
    {
        public ArticuloConsumoCCLayer()
        {
            InitializeComponent();
        }
        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
        }

        //Buscar por Descripcion
        private void BuscarxDescripcion()
        {
            this.dataListado.DataSource = ConsumoCCStruct.BuscarArtNombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            Registroslbl.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Buscar por SAP
        private void BuscarxSAP()
        {
            this.dataListado.DataSource = ConsumoCCStruct.BuscarArtSAP(this.txtBuscar.Text);
            this.OcultarColumnas();
            Registroslbl.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }
        private void ArticuloConsumoCCLayer_Load(object sender, EventArgs e)
        {

        }

        private void Buscarbtn_Click(object sender, EventArgs e)
        {
            if (cbBusqueda.Text.Equals("Descripcion"))
            {
                BuscarxDescripcion();
            }
            else
                BuscarxSAP();
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            ConsmoCCLayer layer = ConsmoCCLayer.GetInstancia();
            ConsumoMaqLayer maquinalayer = ConsumoMaqLayer.GetInstancia();
            string sap, desc, tc, um;
            decimal pu, stock;

            sap = Convert.ToString(this.dataListado.CurrentRow.Cells["SAPNumber"].Value);
            desc = Convert.ToString(this.dataListado.CurrentRow.Cells["Descripcion"].Value);
            um = Convert.ToString(this.dataListado.CurrentRow.Cells["UnidadMedida"].Value);
            stock = Convert.ToDecimal(this.dataListado.CurrentRow.Cells["Stock"].Value);
            pu = Convert.ToDecimal(this.dataListado.CurrentRow.Cells["PrecioUnitario"].Value);
            tc = Convert.ToString(this.dataListado.CurrentRow.Cells["TipoCambio"].Value);
            layer.setArticulo(sap,desc,um,stock,pu,tc);
            maquinalayer.setArticulo(sap, desc, um, stock, pu, tc);
            this.Hide();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            BuscarxDescripcion();
        }
    }
}
