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
    public partial class ConsmoCCLayer : Form
    {
        private bool IsNuevo;
        private DataTable datadetalle;

        private decimal total = 0;

        private static ArticuloLayer _Articulo;

        public static ArticuloLayer GetInstancia()
        {
            if (_Articulo==null)
            {
                _Articulo = new ArticuloLayer();
            }
            return _Articulo;
        }

        public void setRequisitor(string idreq,string nombre)
        {
            this.idreq.Text = idreq;
            this.Nombrereq.Text = nombre;
        }

        public void setArticulo(string sapn, string desc, decimal precio, decimal stock)
        {

        }
        public ConsmoCCLayer()
        {
            InitializeComponent();
            //Se agrega el logo de Robert Bosch y la leyenda proveedor en funcion del picture box #1 es
            //decir la barra de color azul superior
            pictureBox1.Controls.Add(pictureBox2);
            pictureBox1.Dock = DockStyle.Top;
            pictureBox1.Controls.Add(label1);

            //Se fija el logo de Robert Bosch en la parte superior izquierda de la pantalla 
            pictureBox2.Top = 10;
            pictureBox2.Left = 10;

            //Se fija la leyenda Proveedor en la parte central superior
            label1.Top = (this.ClientSize.Height - label1.Height) / 16;
            label1.Left = (this.ClientSize.Width - label1.Width) / 2;

            //Se fija la barra azul inferior con fines esteticos
            pictureBox3.Dock = DockStyle.Bottom;

            //Se agregan las pestañas para visualizar los proveedores y/o modificarlos segun se requiera
            tabControl1.Left = ((this.ClientSize.Width - tabControl1.Width) / 2);
            tabControl1.Top = ((this.ClientSize.Height - tabControl1.Height) / 2) + 20;

            //Se agregan los grupos de botones a los tab pages correspondientes para asegurar un diseño
            //responsive
            tabPage2.Controls.Add(groupBox1);

            //Se alinea el group box a la medida
            groupBox1.Top = ((this.tabPage2.Height - groupBox1.Height) / 10) * 6;
            groupBox1.Left = ((this.tabPage2.Width - groupBox1.Width) / 2);
        }

        private void ConsmoCCLayer_Load(object sender, EventArgs e)
        {
            llenarCombo();
        }

        //Llenado del combo box
        private void llenarCombo()
        {
            this.cccb.DataSource = CentroCostoStruct.Mostrar();
            cccb.ValueMember = "ClaveCentroCosto";
            cccb.DisplayMember = "ClaveCentroCosto";
        }

        private void ConsmoCCLayer_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Articulo = null;
        }
    }
}
