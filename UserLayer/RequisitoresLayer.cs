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
    public partial class RequisitoresLayer : Form
    {
        //Banderas para saber si es insercion o edicion
        private bool isNuevo = false;
        private bool isEditar = false;
        public RequisitoresLayer()
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

            this.ttMensaje.SetToolTip(this.idrtxt, "Ingrese el usuario para inicio de sesion");
            this.ttMensaje.SetToolTip(this.nombrertxt, "Ingrese el nombre(s) de la persona");
            this.ttMensaje.SetToolTip(this.apertxt, "Ingrese el apellido(s) de la persona");
            this.ttMensaje.SetToolTip(this.cccb, "Ingrese su clave para el inicio de sesion");
            this.ttMensaje.SetToolTip(this.puestocb, "Ingrese el nivel de privilegios");
        }

        //Mensaje de confirmacion
        private void MensajeKK(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema Tool Crib", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Mensaje de Error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistemas Tool Crib", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Limpiar Controles del Formulario
        private void Limpiar()
        {
            this.idrtxt.Text = string.Empty;
            this.nombrertxt.Text = string.Empty;
            this.apertxt.Text = string.Empty;
            this.cccb.SelectedIndex = 1;
            this.puestocb.SelectedIndex = -1;
        }

        //Habilitar controles del formulario
        private void Habilitar(bool valor)
        {
            this.idrtxt.ReadOnly = !valor;
            this.nombrertxt.ReadOnly = !valor;
            this.apertxt.ReadOnly = !valor;
            this.cccb.Enabled = valor;
            this.puestocb.Enabled = valor;
        }

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
            this.dataListado.DataSource = RequisitoresStruct.Mostrar();
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

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void RequisitoresLayer_Load(object sender, EventArgs e)
        {
            this.MostrarColumnas();
            this.OcultarColumnas();
            this.Habilitar(false);
            this.Botones();
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

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            BuscarxAp();
        }

        private void nuevobtn_Click(object sender, EventArgs e)
        {
            this.isNuevo = true;
            this.isEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.idrtxt.Focus();
            this.nombrertxt.Focus();
            this.cccb.Focus();
            this.puestocb.Focus();
        }

        private void guardarbtn_Click(object sender, EventArgs e)
        {
            try
            {
                string respuesta = "";
                if (this.idrtxt.Text == string.Empty || this.nombrertxt.Text == string.Empty || this.apertxt.Text == string.Empty || this.cccb.Text == string.Empty || this.puestocb.Text == string.Empty)
                {
                    MensajeError("Datos ingresados erroneamente, favor de revisar");
                    if (this.idrtxt.Text == string.Empty)
                    {
                        errorIcono.SetError(idrtxt, "Clave de Requisitor vacia");
                    }
                    if (this.nombrertxt.Text == string.Empty)
                    {
                        errorIcono.SetError(nombrertxt, "Nombre de Requisittor vacio");
                    }
                    if (this.apertxt.Text == string.Empty)
                    {
                        errorIcono.SetError(apertxt, "Apellido de Requisitor vacio");
                    }
                    if (this.cccb.Text == string.Empty)
                    {
                        errorIcono.SetError(cccb, "Centro de Costo vacio");
                    }
                    if (this.puestocb.Text == string.Empty)
                    {
                        errorIcono.SetError(puestocb, "Puesto no definido");
                    }
                }
                else
                {
                    if (this.isNuevo)
                    {
                        respuesta = RequisitoresStruct.Insertar(this.idrtxt.Text.Trim(), this.nombrertxt.Text.Trim(), this.apertxt.Text.Trim(), Convert.ToInt32(this.cccb.Text.Trim()), this.puestocb.Text.Trim());
                    }
                    else
                    {
                        respuesta = RequisitoresStruct.Editar(this.idrtxt.Text.Trim(), this.nombrertxt.Text.Trim(), this.apertxt.Text.Trim(), Convert.ToInt32(this.cccb.Text.Trim()), this.puestocb.Text.Trim());
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
            this.idrtxt.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["ClaveRequisitor"].Value);
            this.nombrertxt.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Nombre"].Value);
            this.apertxt.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Apellidos"].Value);
            this.cccb.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["CentroCosto"].Value);
            this.puestocb.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Puesto"].Value);

            this.tabControl1.SelectedIndex = 1;
        }

        private void editarbtn_Click(object sender, EventArgs e)
        {
            if (!this.idrtxt.Text.Equals(""))
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
                Opcion = MessageBox.Show("Esta seguro de eliminar los registros de la base de datos?", "Tool Crib Management System", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Opcion == DialogResult.OK)
                {
                    string codigo;
                    string respuesta = "";

                    foreach (DataGridViewRow Row in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(Row.Cells[0].Value))
                        {
                            codigo = Convert.ToString(Row.Cells[1].Value);
                            respuesta = RequisitoresStruct.Eliminar(codigo);
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
    }
}
