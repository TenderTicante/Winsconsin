﻿using System;
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
    public partial class CentroCostoLayer : Form
    {
        public CentroCostoLayer()
        {
            InitializeComponent();
            //Se agrega el logo de Robert Bosch y la leyenda proveedor en funcion del picture box #1 es
            //decir la barra de color azul superior
            pictureBox1.Controls.Add(pictureBox2);
            pictureBox1.Dock = DockStyle.Top;
            pictureBox1.Controls.Add(label1);

            //Se fija el logo de Robert Bosch en la parte superior izquierda de la pantalla 
            pictureBox2.Top = 15;
            pictureBox2.Left = 20;

            //Se fija la leyenda Proveedor en la parte central superior
            label1.Top = (this.ClientSize.Height - label1.Height) / 16;
            label1.Left = (this.ClientSize.Width - label1.Width) / 2;

            //Se fija la barra azul inferior con fines esteticos
            pictureBox3.Dock = DockStyle.Bottom;

            //Se agregan las pestañas para visualizar los proveedores y/o modificarlos segun se requiera
            tabControl1.Left = ((this.ClientSize.Width - tabControl1.Width) / 2);
            tabControl1.Top = ((this.ClientSize.Height - tabControl1.Height) / 2);

            //Se agregan los grupos de botones a los tab pages correspondientes para asegurar un diseño
            //responsive
            tabPage2.Controls.Add(groupBox1);

            //Se alinea el group box a la medida
            groupBox1.Top = ((this.tabPage2.Height - groupBox1.Height) / 10) * 6;
            groupBox1.Left = ((this.tabPage2.Width - groupBox1.Width) / 2);

            this.ttMensaje.SetToolTip(this.txtclavep, "Ingrese el numero de cuenta del proveedor");
            this.ttMensaje.SetToolTip(this.nombreptxt, "Ingrese el nombre del proveedor");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void ttMensaje_Popup(object sender, PopupEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
