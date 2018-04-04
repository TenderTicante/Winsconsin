using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

using StructLayer;

namespace UserLayer
{
    public partial class ArticuloLayer : Form
    {
        //Banderas para saber si es insercion o edicion
        private bool isNuevo = false;
        private bool isEditar = false;
        private static ArticuloLayer _Instancia;

        public static ArticuloLayer GetInstancia()
        {
            if(_Instancia == null)
            {
                _Instancia = new ArticuloLayer();

            }

            return _Instancia;
        }

        public void setProveedor(string ClaveP, string NombreP)
        {
            this.claveptxt.Text = ClaveP;
            this.nomptxt.Text = NombreP;
        }

        public ArticuloLayer()
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

            this.ttMensaje.SetToolTip(this.saptxt, "Capture el numero de SAP Number de la pieza");
            this.ttMensaje.SetToolTip(this.desctxt, "Ingrese la descripcion de la pieza");
            this.ttMensaje.SetToolTip(this.marcatxt, "Ingrese la marca de la pieza");
            this.ttMensaje.SetToolTip(this.umtxt, "Capture la unidad de medida de la pieza");
            this.ttMensaje.SetToolTip(this.loctxt, "Ingrese la Locacion Primaria de la pieza");
            this.ttMensaje.SetToolTip(this.subloc, "Ingrese la Sublocacion de la pieza");
            this.ttMensaje.SetToolTip(this.areatxt, "Ingrese el area en la que se utiliza la pieza");
            this.ttMensaje.SetToolTip(this.mintxt, "Ingrese el minimo definido para dicha pieza");
            this.ttMensaje.SetToolTip(this.maxtxt, "Ingrese el maximo definido para dicha pieza");
            this.ttMensaje.SetToolTip(this.stocktxt, "Ingrese el stock definido para dicha pieza");
            this.ttMensaje.SetToolTip(this.claveptxt, "Da click en el boton para buscar al proveedor de dicha pieza");
            this.ttMensaje.SetToolTip(this.costotxt, "Ingrese el costo de la pieza");
            this.ttMensaje.SetToolTip(this.cbtc, "Ingrese el tipo de cambio de la pieza (DLLS/Pesos)");
            this.ttMensaje.SetToolTip(this.mgtxt, "Capture el Materia Group de la pieza");
            this.ttMensaje.SetToolTip(this.cuentatxt, "Capture el numero de cuenta de la pieza");
            this.ttMensaje.SetToolTip(this.psatxt, "Capture el PSA de la pieza");
            this.ttMensaje.SetToolTip(this.cbnc, "Capture el Nation Code de la pieza (16 / 49)");
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
            this.saptxt.Text = "6082Y0";
            this.desctxt.Text = string.Empty;
            this.marcatxt.Text = string.Empty;
            this.umtxt.Text = string.Empty;
            this.loctxt.Text = string.Empty;
            this.subloc.Text = string.Empty;
            this.areatxt.Text = string.Empty;
            this.mintxt.Text = string.Empty;
            this.maxtxt.Text = string.Empty;
            this.stocktxt.Text = string.Empty;
            this.claveptxt.Text = string.Empty;
            this.costotxt.Text = string.Empty;
            this.cbtc.SelectedIndex = -1;
            this.mgtxt.Text = string.Empty;
            this.cuentatxt.Text = string.Empty;
            this.psatxt.Text = string.Empty;
            this.cbnc.SelectedIndex = -1;
            this.pxImg.Image = global::UserLayer.Properties.Resources.file;
            this.nomptxt.Text = string.Empty;
            this.dllstxt.Text = string.Empty;
        }

        //Calcular costo Dolares
        private void Dolar()
        {
            decimal tipocambio = Convert.ToDecimal(textBox20.Text);
            decimal costo = Convert.ToDecimal(costotxt.Text);
            

            if (cbtc.Text.Equals("MXP"))
            {
                //MessageBox.Show("C");
                dllstxt.Text = Convert.ToString(Math.Round(costo/tipocambio, 2));
            }
            else if (cbtc.Text.Equals("DLL")){
                //MessageBox.Show("B");
                dllstxt.Text = Convert.ToString(Math.Round(costo, 2));
            }
            else{
                //MessageBox.Show("A");
            }
        }

        //Habilitar controles del formulario
        private void Habilitar(bool valor)
        {
            this.saptxt.ReadOnly = !valor;
            this.desctxt.ReadOnly = !valor;
            this.marcatxt.ReadOnly = !valor;
            this.umtxt.ReadOnly = !valor;
            this.loctxt.ReadOnly = !valor;
            this.subloc.ReadOnly = !valor;
            this.areatxt.ReadOnly = !valor;
            this.mintxt.ReadOnly = !valor;
            this.maxtxt.ReadOnly = !valor;
            this.stocktxt.ReadOnly = !valor;
            //this.claveptxt.ReadOnly = !valor;
            this.costotxt.ReadOnly = !valor;
            this.cbtc.Enabled = valor;
            this.mgtxt.ReadOnly = !valor;
            this.cuentatxt.ReadOnly = !valor;
            this.psatxt.ReadOnly = !valor;
            this.cbnc.Enabled = valor;
            this.bprovbtn.Enabled = valor;
            this.loadimg.Enabled = valor;
            this.delimg.Enabled = valor;
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
            this.dataListado.Columns[11].Visible = false;
        }

        //Mostrar los Proveedores Registrados en la base de datos
        private void MostrarColumnas()
        {
            this.dataListado.DataSource = ArticulosStruct.Mostrar();
            this.OcultarColumnas();
            Registroslbl.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);

        }

        //Filtrado por Area
        private void BuscarxArea()
        {
            this.dataListado.DataSource = ArticulosStruct.BuscarxArea(this.txtBuscar.Text);
            this.OcultarColumnas();
            Registroslbl.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Filtrado por Cuenta
        private void BuscarxCuenta()
        {
            this.dataListado.DataSource = ArticulosStruct.BuscarxCuenta(this.txtBuscar.Text);
            this.OcultarColumnas();
            Registroslbl.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Buscar por Descripcion
        private void BuscarxDesc()
        {
            this.dataListado.DataSource = ArticulosStruct.BuscarxDesc(this.txtBuscar.Text);
            this.OcultarColumnas();
            Registroslbl.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Filtrado por Localizacion
        private void BuscarxLoc()
        {
            this.dataListado.DataSource = ArticulosStruct.BuscarxLoc(this.txtBuscar.Text);
            this.OcultarColumnas();
            Registroslbl.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Filtrado por Marca
        private void BuscarxMarca()
        {
            this.dataListado.DataSource = ArticulosStruct.BuscarxMarca(this.txtBuscar.Text);
            this.OcultarColumnas();
            Registroslbl.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Filtrado por Material Group
        private void BuscarxMatG()
        {
            this.dataListado.DataSource = ArticulosStruct.BuscarxMatG(this.txtBuscar.Text);
            this.OcultarColumnas();
            Registroslbl.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Filtrado por Unidad de Medida
        private void BuscarxMedida()
        {
            this.dataListado.DataSource = ArticulosStruct.BuscarxMedida(this.txtBuscar.Text);
            this.OcultarColumnas();
            Registroslbl.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Filtrado por Nation Code
        private void BuscarxNC()
        {
            this.dataListado.DataSource = ArticulosStruct.BuscarxNC(this.txtBuscar.Text);
            this.OcultarColumnas();
            Registroslbl.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Filtrado por Proveedor
        private void BuscarxProv()
        {
            this.dataListado.DataSource = ArticulosStruct.BuscarxProveedor(this.txtBuscar.Text);
            this.OcultarColumnas();
            Registroslbl.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Filtrado por PSA
        private void BuscarxPSA()
        {
            this.dataListado.DataSource = ArticulosStruct.BuscarxPSA(this.txtBuscar.Text);
            this.OcultarColumnas();
            Registroslbl.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Busqueda por SAPNumber
        private void BuscarxSAP()
        {
            this.dataListado.DataSource = ArticulosStruct.BuscarxSAP(this.txtBuscar.Text);
            this.OcultarColumnas();
            Registroslbl.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Filtrado por SubLocacion
        private void BuscarxSubloc()
        {
            this.dataListado.DataSource = ArticulosStruct.BuscarxSublocacion(this.txtBuscar.Text);
            this.OcultarColumnas();
            Registroslbl.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void ArticuloLayer_Load(object sender, EventArgs e)
        {
            this.MostrarColumnas();
            this.OcultarColumnas();
            this.Habilitar(false);
            this.Botones();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarxDesc();
        }

        private void Buscarbtn_Click(object sender, EventArgs e)
        {
            if (cbBusqueda.Text.Equals("Area"))
            {
                this.BuscarxArea();
            }
            else if (cbBusqueda.Text.Equals("Cuenta"))
            {
                this.BuscarxCuenta();
            }
            else if (cbBusqueda.Text.Equals("Descripcion"))
            {
                this.BuscarxDesc();
            }
            else if (cbBusqueda.Text.Equals("Locacion"))
            {
                this.BuscarxLoc();
            }
            else if (cbBusqueda.Text.Equals("Marca"))
            {
                this.BuscarxMarca();
            }
            else if (cbBusqueda.Text.Equals("Material Group"))
            {
                this.BuscarxMatG();
            }
            else if (cbBusqueda.Text.Equals("Medida"))
            {
                this.BuscarxMedida();
            }
            else if (cbBusqueda.Text.Equals("Nation Code"))
            {
                this.BuscarxNC();
            }
            else if (cbBusqueda.Text.Equals("Proveedor"))
            {
                this.BuscarxProv();
            }
            else if (cbBusqueda.Text.Equals("PSA"))
            {
                this.BuscarxPSA();
            }
            else if (cbBusqueda.Text.Equals("SAP Number"))
            {
                this.BuscarxSAP();
            }
            else if (cbBusqueda.Text.Equals("Sublocacion"))
            {
                this.BuscarxSubloc();
            }
        }

        private void nuevobtn_Click(object sender, EventArgs e)
        {
            this.isNuevo = true;
            this.isEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.saptxt.Focus();
            this.desctxt.Focus();
            this.marcatxt.Focus();
            this.umtxt.Focus();
            this.loctxt.Focus();
            this.subloc.Focus();
            this.areatxt.Focus();
            this.mintxt.Focus();
            this.maxtxt.Focus();
            this.stocktxt.Focus();
            this.claveptxt.Focus();
            this.costotxt.Focus();
            this.cbtc.Focus();
            this.mgtxt.Focus();
            this.cuentatxt.Focus();
            this.psatxt.Focus();
            this.cbnc.Focus();
        }

        private void guardarbtn_Click(object sender, EventArgs e)
        {
            try
            {
                string respuesta = "";
                if (this.saptxt.Text == string.Empty || this.desctxt.Text == string.Empty ||
                    this.marcatxt.Text == string.Empty || this.umtxt.Text == string.Empty || this.loctxt.Text == string.Empty ||
                    this.areatxt.Text == string.Empty || this.mintxt.Text == string.Empty ||
                    this.maxtxt.Text == string.Empty || this.stocktxt.Text == string.Empty || this.claveptxt.Text == string.Empty ||
                    this.costotxt.Text == string.Empty || this.cbtc.Text == string.Empty || this.cbnc.Text == string.Empty)
                {
                    MensajeError("Datos ingresados erroneamente, favor de revisar");
                    if (this.saptxt.Text == string.Empty)
                    {
                        errorIcono.SetError(saptxt, "SAP Number no definido");
                    }
                    if (this.desctxt.Text == string.Empty)
                    {
                        errorIcono.SetError(desctxt, "Descripcion no definida");
                    }
                    if (this.marcatxt.Text == string.Empty)
                    {
                        errorIcono.SetError(marcatxt, "Marca no definido");
                    }
                    if (this.umtxt.Text == string.Empty)
                    {
                        errorIcono.SetError(umtxt, "Unidad de meidida no definida");
                    }
                    if (this.loctxt.Text == string.Empty)
                    {
                        errorIcono.SetError(loctxt, "Locacion no definida");
                    }
                    if (this.areatxt.Text == string.Empty)
                    {
                        errorIcono.SetError(areatxt, "Area no definida");
                    }
                    if (this.mintxt.Text == string.Empty)
                    {
                        errorIcono.SetError(mintxt, "Cantidad Minima no definida");
                    }
                    if (this.maxtxt.Text == string.Empty)
                    {
                        errorIcono.SetError(maxtxt, "Cantidad Maxima no definida");
                    }
                    if (this.stocktxt.Text == string.Empty)
                    {
                        errorIcono.SetError(stocktxt, "Stock no definido");
                    }
                    if (this.claveptxt.Text == string.Empty)
                    {
                        errorIcono.SetError(claveptxt, "Proveedor no definido");
                    }
                    if (this.costotxt.Text == string.Empty)
                    {
                        errorIcono.SetError(costotxt, "Precio no definido");
                    }
                    if (this.cbtc.Text == string.Empty)
                    {
                        errorIcono.SetError(cbtc, "Tipo de Cambio no definido");
                    }
                    if (this.cbnc.Text == string.Empty)
                    {
                        errorIcono.SetError(cbnc, "Nation Code no definido");
                    }
                }
                else
                {
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    this.pxImg.Image.Save(ms,System.Drawing.Imaging.ImageFormat.Png);
                    byte[] imagen = ms.GetBuffer();
                    if (this.isNuevo)
                    {
                        respuesta = ArticulosStruct.Insertar(this.saptxt.Text.Trim().ToUpper(), this.desctxt.Text.Trim(), this.marcatxt.Text.Trim(), this.umtxt.Text.Trim(), this.loctxt.Text.Trim(), this.subloc.Text.Trim(), this.areatxt.Text.Trim(), Convert.ToDecimal(this.mintxt.Text),Convert.ToDecimal(this.maxtxt.Text),Convert.ToDecimal(this.stocktxt.Text),this.claveptxt.Text.Trim(),Convert.ToDecimal(this.costotxt.Text.Trim()), this.cbtc.Text.Trim(), this.mgtxt.Text.Trim(), this.cuentatxt.Text.Trim(), this.psatxt.Text.Trim(), this.cbnc.Text.Trim(),imagen);
                    }
                    else
                    {
                        respuesta = ArticulosStruct.Editar(this.saptxt.Text.Trim().ToUpper(), this.desctxt.Text.Trim(), this.marcatxt.Text.Trim(), this.umtxt.Text.Trim(), this.loctxt.Text.Trim(), this.subloc.Text.Trim(), this.areatxt.Text.Trim(), Convert.ToDecimal(this.mintxt.Text), Convert.ToDecimal(this.maxtxt.Text), Convert.ToDecimal(this.stocktxt.Text), this.claveptxt.Text.Trim(), Convert.ToDecimal(this.costotxt.Text.Trim()), this.cbtc.Text.Trim(), this.mgtxt.Text.Trim(), this.cuentatxt.Text.Trim(), this.psatxt.Text.Trim(), this.cbnc.Text.Trim(), imagen);
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
            this.saptxt.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["SAPNumber"].Value);
            this.desctxt.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Descripcion"].Value);
            this.marcatxt.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Marca"].Value);
            this.umtxt.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["UnidadMedida"].Value);
            this.loctxt.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Locacion"].Value);
            this.subloc.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Sublocacion"].Value);
            this.areatxt.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Area"].Value);
            this.mintxt.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Minimo"].Value);
            this.maxtxt.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Maximo"].Value);
            this.stocktxt.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Stock"].Value);
            this.claveptxt.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["ClaveProveedor"].Value);
            this.nomptxt.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["NombreProveedor"].Value);
            this.costotxt.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["PrecioUnitario"].Value);
            this.cbtc.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["TipoCambio"].Value);
            this.mgtxt.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["MaterialGroup"].Value);
            this.cuentatxt.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Cuenta"].Value);
            this.psatxt.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["AreaPSA"].Value);
            this.cbnc.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["NationCode"].Value);
                /*byte[] imgnBuffer = (byte[])this.dataListado.CurrentRow.Cells["Imagen"].Value;
                System.IO.MemoryStream ms = new System.IO.MemoryStream(imgnBuffer);
                this.pxImg.Image = Image.FromStream(ms);
                this.pxImg.SizeMode = PictureBoxSizeMode.StretchImage;*/
            this.tabControl1.SelectedIndex = 1;
            this.Dolar();
        }

        private void editarbtn_Click(object sender, EventArgs e)
        {
            if (!this.saptxt.Text.Equals(""))
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
                            respuesta = ArticulosStruct.Eliminar(codigo);
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

        private void bprovbtn_Click(object sender, EventArgs e)
        {
            VistaProveedorArticulo Vista = new VistaProveedorArticulo();
            Vista.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            DialogResult result = dialog.ShowDialog();

            if (result==DialogResult.OK)
            {
                this.pxImg.SizeMode = PictureBoxSizeMode.StretchImage;
                this.pxImg.Image = Image.FromFile(dialog.FileName);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.pxImg.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pxImg.Image = global::UserLayer.Properties.Resources.file;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox20.ReadOnly = true;
        }

        private void pxImg_DoubleClick(object sender, EventArgs e)
        {
            Form previewForm = new Form()
            {
                WindowState = FormWindowState.Maximized,
                FormBorderStyle = FormBorderStyle.FixedSingle
            };
            PictureBox picture = new PictureBox()
            {
                Image = pxImg.Image,
                Dock = DockStyle.Fill,
                SizeMode = PictureBoxSizeMode.Zoom
            };
            previewForm.Controls.Add(picture);
            previewForm.ShowDialog();
        }

        private void textBox20_DoubleClick(object sender, EventArgs e)
        {
            textBox20.ReadOnly = false;

        }

        private void textBox20_KeyPress(object sender, KeyPressEventArgs e)
        {
            CultureInfo cc = System.Threading.Thread.CurrentThread.CurrentCulture;

            if (char.IsNumber(e.KeyChar) ||

                e.KeyChar.ToString() == cc.NumberFormat.NumberDecimalSeparator || e.KeyChar == 8

                )

                e.Handled = false;

            else

                e.Handled = true;
        }

        private void ArticuloLayer_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }

        private void Registroslbl_Click(object sender, EventArgs e)
        {
            kawaiipig.Visible = true;
            kawaiipig2.Visible = true;
            kawaiipig3.Visible = true;
        }
    }
}
