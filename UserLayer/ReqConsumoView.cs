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
    public partial class ReqConsumoView : Form
    {
        private void Limpiar()
        {
            
        }

        public ReqConsumoView()
        {
            InitializeComponent();
        }

        private void ReqConsumoView_Load(object sender, EventArgs e)
        {
            MostrarColumnas();
        }

        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
        }

        //Mostrar los Proveedores Registrados en la base de datos
        private void MostrarColumnas()
        {
            this.dataListado.DataSource = RequisitoresStruct.Mostrar();
            this.OcultarColumnas();
            Registroslbl.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);

        }

        //Buscar por Nombre de Requisitor
        private void BuscarxNombre()
        {
            this.dataListado.DataSource = RequisitoresStruct.BuscarxNom(this.txtBuscar.Text);
            this.OcultarColumnas();
            Registroslbl.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Buscar por Apellido Requisitor
        private void BuscarxAp()
        {
            this.dataListado.DataSource = RequisitoresStruct.BuscarxApel(this.txtBuscar.Text);
            this.OcultarColumnas();
            Registroslbl.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Filtrado por Centro de Costo del Requisitor
        private void BuscarxCC()
        {
            this.dataListado.DataSource = RequisitoresStruct.BuscarxCC(this.txtBuscar.Text);
            this.OcultarColumnas();
            Registroslbl.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Filtrar por Puesto del Requisitor
        private void BuscarxPuesto()
        {
            this.dataListado.DataSource = RequisitoresStruct.BuscarxPuesto(this.txtBuscar.Text);
            this.OcultarColumnas();
            Registroslbl.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void Buscarbtn_Click(object sender, EventArgs e)
        {
            if (cbBusqueda.Text.Equals("Nombre"))
            {
                BuscarxNombre();
            }
            else if (cbBusqueda.Text.Equals("CentroCosto"))
            {
                BuscarxCC();
            }
            else if (cbBusqueda.Text.Equals("Puesto"))
            {
                BuscarxPuesto();
            }
            else
                BuscarxAp();
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            ConsmoCCLayer layer = ConsmoCCLayer.GetInstancia();
            ConsumoMaqLayer layermaquina = ConsumoMaqLayer.GetInstancia();
            string string1;
            string1 = Convert.ToString(this.dataListado.CurrentRow.Cells["ClaveRequisitor"].Value);
            string string2;
            string2 = Convert.ToString(this.dataListado.CurrentRow.Cells["Nombre"].Value + " " + this.dataListado.CurrentRow.Cells["Apellidos"].Value);


            layer.setRequisitor(string1,string2);
            layermaquina.setRequisitor(string1,string2);
            this.Hide();
        }
    }
}
