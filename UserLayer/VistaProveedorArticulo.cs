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
    public partial class VistaProveedorArticulo : Form
    {
        public VistaProveedorArticulo()
        {
            //Se agrega el logo de Robert Bosch y la leyenda proveedor en funcion del picture box #1 es
            //decir la barra de color azul superior
            //pictureBox1.Controls.Add(pictureBox2);
            //pictureBox1.Dock = DockStyle.Top;
            //pictureBox1.Controls.Add(label1);

            //Se fija el logo de Robert Bosch en la parte superior izquierda de la pantalla 
            //pictureBox2.Top = 10;
           // pictureBox2.Left = 10;

            //Se fija la leyenda Proveedor en la parte central superior
            /*label1.Top = (this.ClientSize.Height - label1.Height) / 16;
            label1.Left = (this.ClientSize.Width - label1.Width) / 2;

            //Se fija la barra azul inferior con fines esteticos
            pictureBox3.Dock = DockStyle.Bottom;

            //Se agregan las pestañas para visualizar los proveedores y/o modificarlos segun se requiera
            tabControl1.Left = ((this.ClientSize.Width - tabControl1.Width) / 2);
            tabControl1.Top = ((this.ClientSize.Height - tabControl1.Height) / 2) + 20;*/
            InitializeComponent();
        }

        private void VistaProveedorArticulo_Load(object sender, EventArgs e)
        {
            MostrarColumnas();
        }

        private void BuscarNombre()
        {
            this.dataListado.DataSource = ProveedoresStruct.BuscarProveedor(this.txtBuscar.Text);
            this.OcultarColumnas();
            Registroslbl.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void BuscarCuenta()
        {
            this.dataListado.DataSource = ProveedoresStruct.BuscarClaveProv(this.txtBuscar.Text);
            this.OcultarColumnas();
            Registroslbl.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            ArticuloLayer Layer = ArticuloLayer.GetInstancia();
            string clavep;
            clavep = Convert.ToString(this.dataListado.CurrentRow.Cells["ClaveProveedor"].Value);
            string nombrep;
            nombrep = Convert.ToString(this.dataListado.CurrentRow.Cells["NombreProveedor"].Value);
            Layer.setProveedor(clavep,nombrep);
            this.Hide();
        }

        private void MostrarColumnas()
        {
            this.dataListado.DataSource = ProveedoresStruct.Mostrar();
            this.OcultarColumnas();
            Registroslbl.Text = "Total de Registo: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            BuscarNombre();
        }
    }
}
