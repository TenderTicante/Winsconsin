﻿using System;
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
    public partial class UsuarioLayer : Form
    {
        //Banderas para saber si es insercion o edicion
        private bool isNuevo = false;
        private bool isEditar = false;
        public UsuarioLayer()
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

            this.ttMensaje.SetToolTip(this.idutxt, "Ingrese el usuario para inicio de sesion");
            this.ttMensaje.SetToolTip(this.nombreutxt, "Ingrese el nombre(s) de la persona");
            this.ttMensaje.SetToolTip(this.apeutxt, "Ingrese el apellido(s) de la persona");
            this.ttMensaje.SetToolTip(this.passwordtxt, "Ingrese su clave para el inicio de sesion");
            this.ttMensaje.SetToolTip(this.accesocb, "Ingrese el nivel de privilegios");
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
            this.idutxt.Text = string.Empty;
            this.nombreutxt.Text = string.Empty;
            this.apeutxt.Text = string.Empty;
            this.passwordtxt.Text = string.Empty;
            this.accesocb.SelectedIndex = -1;
        }

        //Habilitar controles del formulario
        private void Habilitar(bool valor)
        {
            this.idutxt.ReadOnly = !valor;
            this.nombreutxt.ReadOnly = !valor;
            this.apeutxt.ReadOnly = !valor;
            this.passwordtxt.ReadOnly = !valor;
            this.accesocb.Enabled = valor;
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
            this.dataListado.DataSource = UsuariosStruct.Mostrar();
            Registroslbl.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);

        }

        //Buscar por Nombre de Usuario
        private void BuscarxNombre()
        {
            this.dataListado.DataSource = UsuariosStruct.BuscarxNombre(this.txtBuscar.Text);
            
            this.OcultarColumnas();
            Registroslbl.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Buscar por Clave del Usuario
        private void BuscarxClave()
        {
            this.dataListado.DataSource = UsuariosStruct.BuscarxID(this.txtBuscar.Text);
            this.OcultarColumnas();
            Registroslbl.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Buscar por Apellido Usuario
        private void BuscarxApellido()
        {
            this.dataListado.DataSource = UsuariosStruct.BuscarxApellido(this.txtBuscar.Text);
            this.OcultarColumnas();
            Registroslbl.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void UsuarioLayer_Load(object sender, EventArgs e)
        {
            this.MostrarColumnas();
            this.OcultarColumnas();
            this.Habilitar(false);
            this.Botones();
        }

        private void Buscarbtn_Click(object sender, EventArgs e)
        {
            if (cbBusqueda.Text.Equals("IDUsuario"))
            {
                BuscarxClave();
            }
            else if (cbBusqueda.Text.Equals("Nombre")){
                BuscarxNombre();
            }
            else
                BuscarxApellido();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarxApellido();
        }

        private void nuevobtn_Click(object sender, EventArgs e)
        {
            this.isNuevo = true;
            this.isEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.idutxt.Focus();
            this.nombreutxt.Focus();
            this.apeutxt.Focus();
            this.passwordtxt.Focus();
            this.cbBusqueda.Focus();
        }

        private void guardarbtn_Click(object sender, EventArgs e)
        {
            try
            {
                string respuesta = "";
                if (this.idutxt.Text == string.Empty || this.nombreutxt.Text == string.Empty || this.apeutxt.Text == string.Empty || this.passwordtxt.Text == string.Empty)
                {
                    MensajeError("Datos ingresados erroneamente, favor de revisar");
                    if (this.idutxt.Text == string.Empty)
                    {
                        errorIcono.SetError(idutxt, "Clave de Usuario vacia");
                    }
                    if (this.nombreutxt.Text == string.Empty)
                    {
                        errorIcono.SetError(nombreutxt, "Nombre de Usuario vacio");
                    }
                    if (this.apeutxt.Text == string.Empty)
                    {
                        errorIcono.SetError(apeutxt, "Apellido de Usuario vacio");
                    }
                    if (this.passwordtxt.Text == string.Empty)
                    {
                        errorIcono.SetError(passwordtxt, "Contraseña de usuario vacia");
                    }
                    if (this.accesocb.Text == string.Empty)
                    {
                        errorIcono.SetError(accesocb, "Nivel de permisos no definidos");
                    }
                }
                else
                {
                    if (this.isNuevo)
                    {
                        respuesta = UsuariosStruct.Insertar(this.idutxt.Text.Trim(), this.nombreutxt.Text.Trim(), this.apeutxt.Text.Trim(), this.accesocb.Text.Trim(), this.passwordtxt.Text.Trim());
                    }
                    else
                    {
                        respuesta = UsuariosStruct.Editar(this.idutxt.Text.Trim(), this.nombreutxt.Text.Trim(), this.apeutxt.Text.Trim(), this.accesocb.Text.Trim(), this.passwordtxt.Text.Trim());
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
            this.idutxt.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["IDUsuario"].Value);
            this.nombreutxt.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Nombre"].Value);
            this.apeutxt.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Apellido"].Value);
            this.accesocb.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Acceso"].Value);
            this.passwordtxt.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Password"].Value);
            
            this.tabControl1.SelectedIndex = 1;
        }

        private void editarbtn_Click(object sender, EventArgs e)
        {
            if (!this.idutxt.Text.Equals(""))
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
                            respuesta = UsuariosStruct.Eliminar(codigo);
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
