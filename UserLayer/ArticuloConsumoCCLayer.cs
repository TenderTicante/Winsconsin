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
            if (cbBusqueda.Text.Equals("SAP Number"))
            {
                BuscarxSAP();
            }
            else
                BuscarxDescripcion();
        }
    }
}
