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
    public partial class ProveedoresLayer : Form
    {
        //Banderas para saber si es insercion o edicion
        private bool isNuevo = false;
        private bool isEditar = false;
        public ProveedoresLayer()
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
            label1.Top=(this.ClientSize.Height -label1.Height)/16;
            label1.Left=(this.ClientSize.Width - label1.Width) / 2;

            //Se fija la barra azul inferior con fines esteticos
            pictureBox3.Dock = DockStyle.Bottom;

            //Se agregan las pestañas para visualizar los proveedores y/o modificarlos segun se requiera
            tabControl1.Left = ((this.ClientSize.Width-tabControl1.Width)/2);
            tabControl1.Top = ((this.ClientSize.Height - tabControl1.Height)/2)+20;

            //Se agregan los grupos de botones a los tab pages correspondientes para asegurar un diseño
            //responsive
            tabPage2.Controls.Add(groupBox1);

            //Se alinea el group box a la medida
            groupBox1.Top = ((this.tabPage2.Height - groupBox1.Height) / 10) * 6;
            groupBox1.Left = ((this.tabPage2.Width - groupBox1.Width) / 2);

            this.ttMensaje.SetToolTip(this.txtclavep, "Ingrese el numero de cuenta del proveedor");
            this.ttMensaje.SetToolTip(this.nombreptxt,"Ingrese el nombre del proveedor");
        }

        //Mensaje de confirmacion
        private void MensajeKK(string mensaje)
        {
            MessageBox.Show(mensaje,"Sistema Tool Crib",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
         
        //Mensaje de Error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje,"Sistemas Tool Crib",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }

        //Limpiar Controles del Formulario
        private void Limpiar()
        {
            this.txtclavep.Text = string.Empty;
            this.nombreptxt.Text = string.Empty;
            this.contactotxt.Text = string.Empty;
            this.correotxt.Text = string.Empty;
            this.telefonotxt.Text = string.Empty;
            this.direcciontxt.Text = string.Empty;
        }

        //Habilitar controles del formulario
        private void Habilitar(bool valor)
        {
            this.txtclavep.ReadOnly = !valor;
            this.nombreptxt.ReadOnly = !valor;
            this.contactotxt.ReadOnly = !valor;
            this.correotxt.ReadOnly = !valor;
            this.telefonotxt.ReadOnly = !valor;
            this.direcciontxt.ReadOnly = !valor;
        }

        //Habilitar Botones

        private void Botones()
        {
            if (this.isNuevo || this.isEditar)
            {
                this.Habilitar(true);
                this.nuevobtn.Enabled = false;
                this.guardarbtn.Enabled = true;
                this.editarbtn.Enabled = false;
                this.cancelarbtn.Enabled = true;
            }

            else
            {
                this.Habilitar(false);
                this.nuevobtn.Enabled = true;
                this.guardarbtn.Enabled = false;
                this.editarbtn.Enabled = true;
                this.cancelarbtn.Enabled = false;
            }
        }

        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
        }

        //Mostrar los Proveedores Registrados en la base de datos
        private void MostrarColumnas()
        {
            this.dataListado.DataSource = ProveedoresStruct.Mostrar();
            Registroslbl.Text = "Total de Registros: "+Convert.ToString(dataListado.Rows.Count);

        }

        //Buscar por Nombre de Proveedor
        private void BuscarxNombre()
        {
            this.dataListado.DataSource = ProveedoresStruct.BuscarProveedor(this.txtBuscar.Text);
            this.OcultarColumnas();
            Registroslbl.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Buscar por Clave del Proveedor
        private void BuscarxClave()
        {
            this.dataListado.DataSource = ProveedoresStruct.BuscarClaveProv(this.txtBuscar.Text);
           this.OcultarColumnas();
            Registroslbl.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }
        private void ProveedoresLayer_Load(object sender, EventArgs e)
        {
            this.MostrarColumnas();
            this.OcultarColumnas();
            this.Habilitar(false);
            this.Botones();
        }

        private void Buscarbtn_Click(object sender, EventArgs e)
        {
            if (cbBusqueda.Text.Equals("Numero Cuenta"))
            {
                BuscarxClave();
            }
            else
                BuscarxNombre();

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarxNombre();
        }

        private void nuevobtn_Click(object sender, EventArgs e)
        {
            this.isNuevo = true;
            this.isEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtclavep.Focus();
            this.nombreptxt.Focus();
        }

        private void guardarbtn_Click(object sender, EventArgs e)
        {
            try
            {
                string respuesta = "";
                if (this.txtclavep.Text == string.Empty || this.nombreptxt.Text == string.Empty)
                {
                    MensajeError("Datos ingresados erroneamente, favor de revisar");
                    if(this.txtclavep.Text == string.Empty)
                    {
                        errorIcono.SetError(txtclavep,"Clave de Proveedor vacia");
                    }
                    if (this.nombreptxt.Text == string.Empty)
                    {
                        errorIcono.SetError(nombreptxt,"Nombre de proveedor vacio");
                    }
                }
                else
                {
                    if (this.isNuevo)
                    {
                        respuesta = ProveedoresStruct.Insertar(this.txtclavep.Text.Trim(),this.nombreptxt.Text.Trim(),this.contactotxt.Text.Trim(),this.correotxt.Text.Trim(),this.telefonotxt.Text.Trim(),this.direcciontxt.Text.Trim());
                    }
                    else
                    {
                        respuesta = ProveedoresStruct.Editar(this.txtclavep.Text.Trim(), this.nombreptxt.Text.Trim(), this.contactotxt.Text.Trim(), this.correotxt.Text.Trim(), this.telefonotxt.Text.Trim(), this.direcciontxt.Text.Trim());
                    }

                    if (respuesta.Equals("KK"))
                    {
                        if (this.isNuevo)
                        {
                            this.MensajeKK("Registro guardado exitosamente");
                        }
                        else
                        {
                            this.MensajeKK("Se actualizo el registro correctamente");
                        }
                    }
                    else
                    {
                        this.MensajeError(respuesta);
                    }
                    this.isNuevo = false;
                    this.isEditar = false;
                    this.Botones();
                    this.Limpiar();
                    this.MostrarColumnas();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            this.txtclavep.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["ClaveProveedor"].Value);
            this.nombreptxt.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["NombreProveedor"].Value);
            this.contactotxt.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Contacto"].Value);
            this.correotxt.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Correo"].Value);
            this.telefonotxt.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Telefono"].Value);
            this.direcciontxt.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Direccion"].Value);

            this.tabControl1.SelectedIndex = 1;
        }

        private void editarbtn_Click(object sender, EventArgs e)
        {
            if (!this.txtclavep.Text.Equals(""))
            {
                this.isEditar = true;
                this.Botones();
                this.Habilitar(true);
            }
            else
            {
                this.MensajeError("Seleccionar el registro a modificar");
            }
        }

        private void cancelarbtn_Click(object sender, EventArgs e)
        {
            this.isNuevo = false;
            this.isEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
        }

        private void Eliminarchk_CheckedChanged(object sender, EventArgs e)
        {
            if (Eliminarchk.Checked)
            {
                this.dataListado.Columns[0].Visible = true;
            }
            else
            {
                this.dataListado.Columns[0].Visible = false;
            }
        }

        private void Eliminarbtn_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Esta seguro de eliminar los registros de la base de datos?", "Tool Crib Management System",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
                if (Opcion == DialogResult.OK)
                {
                    string codigo;
                    string respuesta = "";

                    foreach (DataGridViewRow Row in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(Row.Cells[0].Value))
                        {
                            codigo = Convert.ToString(Row.Cells[1].Value);
                            respuesta = ProveedoresStruct.Eliminar(codigo);
                            if (respuesta.Equals("KK"))
                            {
                                this.MensajeKK("Se elimino correctamente el registro");
                            }
                            else
                            {
                                this.MensajeError(respuesta);
                            }
                        }
                    }
                    this.MostrarColumnas();
                    Eliminarchk.Checked = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Registroslbl_Click(object sender, EventArgs e)
        {
            cowpic1.Visible = true;
            cowpic2.Visible = true;
            cowpic3.Visible = true;
        }
    }
}
