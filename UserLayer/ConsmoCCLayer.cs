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

        private static ConsmoCCLayer _Consumo;

        public static ConsmoCCLayer GetInstancia()
        {
            if (_Consumo == null)
            {
                _Consumo = new ConsmoCCLayer();
            }
            return _Consumo;
        }

        public void setRequisitor(string idreq,string nombre)
        {
            this.Idreq.Text = idreq;
            this.Nombrereq.Text = nombre;
            
        }

        public void setArticulo(string sapn, string desc, string unme, decimal stock, decimal preun, string tica)
        {
            this.sapntxt.Text = sapn;
            this.desctxt.Text = desc;
            this.umtxt.Text = unme;
            this.stocktxt.Text = Convert.ToString(stock);
            this.putxt.Text = Convert.ToString(preun);
            this.tctxt.Text = tica;
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

        private void Limpiar()
        {
            this.cccb.SelectedIndex = 1;
            this.Idreq.Text = string.Empty;
            this.Nombrereq.Text = string.Empty;
            this.label6.Text = "0.0";
            this.crearTabla();
        }

        private void LimpiarDetalle()
        {
            this.sapntxt.Text = string.Empty;
            this.desctxt.Text = string.Empty;
            this.cant.Value = 0;
            this.umtxt.Text = string.Empty;
            this.stocktxt.Text = string.Empty;
            this.putxt.Text = string.Empty;
            this.tctxt.Text = string.Empty;
            this.subtxt.Text = string.Empty;
        }

        //Habilitar controles del formulario
        private void Habilitar(bool valor)
        {
            this.fechasalidapick.Enabled = valor;
            this.cccb.Enabled = valor;
            this.cant.Enabled = valor;
            this.cant.DecimalPlaces = 2;
            this.additem.Enabled = valor;
            this.addreq.Enabled = valor;
            this.adddetail.Enabled = valor;
            this.deldetail.Enabled = valor;
        }

        //Habilitar Botones
        private void Botones()
        {
            if (this.IsNuevo)
            {
                this.Habilitar(true);
                this.nuevobtn.Enabled = false;
                this.guardabtn.Enabled = true;
                this.cancelarbtn.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.nuevobtn.Enabled = true;
                this.guardabtn.Enabled = false;
                this.cancelarbtn.Enabled = false;
            }
        }

        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
        }

        private void Mostrar()
        {
            this.dataListado.DataSource = ConsumoCCStruct.Mostrar();
            this.OcultarColumnas();
            lbltotalreg.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void BuscarFechas()
        {
            this.dataListado.DataSource = ConsumoCCStruct.BuscarFechas(this.fecha1.Value, this.fecha2.Value);
            this.OcultarColumnas();
            lbltotalreg.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void MostrarDetalle()
        {
            this.dataListadoDetalle.DataSource = ConsumoCCStruct.MostrarDetalle(Convert.ToInt32(idConsumo.Text));
        }

        private void crearTabla()
        {
            this.datadetalle = new DataTable("Detalle");
            this.datadetalle.Columns.Add("IDConsumo", System.Type.GetType("System.Int32"));
            this.datadetalle.Columns.Add("SAPNumber", System.Type.GetType("System.String"));
            this.datadetalle.Columns.Add("Descripcion", System.Type.GetType("System.String"));
            this.datadetalle.Columns.Add("Cantidad", System.Type.GetType("System.Decimal"));
            this.datadetalle.Columns.Add("UnidadMedida", System.Type.GetType("System.String"));
            this.datadetalle.Columns.Add("Stock", System.Type.GetType("System.Decimal"));
            this.datadetalle.Columns.Add("PrecioUnitario", System.Type.GetType("System.Decimal"));
            this.datadetalle.Columns.Add("TipoCambio", System.Type.GetType("System.String"));
            this.datadetalle.Columns.Add("Subtotal", System.Type.GetType("System.Decimal"));

            this.dataListadoDetalle.DataSource = this.datadetalle;
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
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
            this.crearTabla();
            this.ttMensaje.SetToolTip(this.Nombrereq,"Seleccione un requisitor");
            this.ttMensaje.SetToolTip(this.cccb, "Seleccione un Centro de Costo");
            this.ttMensaje.SetToolTip(this.cant, "Ingrese una cantidad");
            this.ttMensaje.SetToolTip(this.sapntxt, "Seleccione un Articulo");
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
            _Consumo = null;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ArticuloConsumoCCLayer Requisitor = new ArticuloConsumoCCLayer();
            Requisitor.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ReqConsumoView Requisitor = new ReqConsumoView();
            Requisitor.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(fecha1.Value.ToString("dd/MM/yyyy"));
            this.BuscarFechas();
        }

        private void button3_Click(object sender, EventArgs e) 
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Esta seguro de eliminar los registros de la base de datos?", "Tool Crib Management System", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Opcion == DialogResult.OK)
                {
                    int codigo;
                    string respuesta = "";

                    foreach (DataGridViewRow Row in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(Row.Cells[0].Value))
                        {
                            codigo = Convert.ToInt32(Row.Cells[1].Value);
                            respuesta = ConsumoCCStruct.Eliminar(codigo);
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
                    this.Mostrar();
                    Eliminarchk.Checked = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            this.idConsumo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["IDConsumo"].Value);
            this.fechasalidapick.Value = Convert.ToDateTime(this.dataListado.CurrentRow.Cells["Fecha"].Value);
            this.cccb.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["ClaveCentroCosto"].Value);
            this.Idreq.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["IDRequisitor"].Value);
            this.Nombrereq.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Requisitor"].Value);
            this.label6.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Total"].Value);
            MostrarDetalle();
            tabControl1.SelectedIndex = 1;
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

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void cancelarbtn_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.Botones();
            this.Limpiar();
            this.LimpiarDetalle();
            this.Habilitar(false);
        }

        private void nuevobtn_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.Botones();
            this.Limpiar();
            this.LimpiarDetalle();
            this.Habilitar(true);
        }

        private void guardabtn_Click(object sender, EventArgs e)
        {
            try
            {
                string respuesta = "";
                if (this.cccb.Text == string.Empty || this.Idreq.Text == string.Empty )
                {
                    MensajeError("Datos ingresados erroneamente, favor de revisar");
                    if (this.cccb.Text == string.Empty)
                    {
                        errorIcono.SetError(cccb, "Centro de Costo no definido");
                    }
                    if (this.Idreq.Text == string.Empty)
                    {
                        errorIcono.SetError(desctxt, "Requisitor no definido");
                    }

                }
                else
                {
                    if (this.IsNuevo)
                    {
                        respuesta = ConsumoCCStruct.Insertar(Convert.ToDateTime(fecha1.Value.ToString("dd/MM/yyyy")), Convert.ToInt32(cccb.Text), Idreq.Text, Convert.ToDecimal(label6.Text), datadetalle);
                    }

                    if (respuesta.Equals("KK"))
                    {
                        if (this.IsNuevo)
                        {
                            this.MensajeKK("Registro guardado exitosamente");
                        }
                    }
                    else
                    {
                        this.MensajeError(respuesta);
                    }
                    this.IsNuevo = false;
                    this.Botones();
                    this.Limpiar();
                    this.LimpiarDetalle();
                    this.Mostrar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void adddetail_Click(object sender, EventArgs e)
        {
            try
            {
                if(this.sapntxt.Text == string.Empty)
                {
                    MensajeError("No se han seleccionado articulos ");
                }
                else
                {
                    bool registrar = true;

                    foreach (DataRow raw in datadetalle.Rows)
                    {
                        if (Convert.ToString(raw["SAPNumber"]) == Convert.ToString(this.sapntxt.Text))
                        {
                            registrar = false;
                            this.MensajeError("El articulo ya se ha registrado previamente");
                        }
                    }
                        if (registrar && Convert.ToDecimal(cant.Value)<=Convert.ToDecimal(stocktxt.Text) && cant.Value>0)
                        {
                            decimal subtotal = Convert.ToDecimal(this.cant.Value) * Convert.ToDecimal(this.putxt.Text);
                            total = total + subtotal;
                            this.label6.Text = total.ToString("#0.00#");
                            //Agregar detalle al listado
                            DataRow row = this.datadetalle.NewRow();
                            row["SAPNumber"]=Convert.ToString(this.sapntxt.Text);
                            row["Descripcion"]=Convert.ToString(this.desctxt.Text);
                            row["Cantidad"]=Convert.ToDecimal(this.cant.Value);
                            row["UnidadMedida"] = Convert.ToString(this.umtxt.Text);
                            row["Stock"] =Convert.ToDecimal(this.stocktxt.Text);
                            row["PrecioUnitario"] =Convert.ToDecimal(this.putxt.Text);
                            row["TipoCambio"] =Convert.ToString(this.tctxt.Text);
                            row["Subtotal"] = subtotal;
                            this.datadetalle.Rows.Add(row);
                            this.LimpiarDetalle();
                        }
                        else
                        {
                            MensajeError("No hay stock suficiente");
                        }
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message+ex.StackTrace);
            }
        }

        private void deldetail_Click(object sender, EventArgs e)
        {
            try
            {
                int indicefila = this.dataListadoDetalle.CurrentCell.RowIndex;
                DataRow row = this.datadetalle.Rows[indicefila];
                //Disminir el total de la salida
                this.total = this.total- Convert.ToDecimal(row["SubTotal"].ToString());
                this.label6.Text = total.ToString("#0.00#");
                //Se remueve la fila
                this.datadetalle.Rows.Remove(row);
            }
            catch(Exception ex)
            {
                MensajeError("No hay fila para Remover");
            }
        }
    }
}
