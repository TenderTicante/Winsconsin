using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace DataLayer
{
    public class ConsumoCCData
    {
        private DateTime _Fecha;
        private int _IDConsumo;
        private int _ClaveCC;
        private string _IDRequisitor;
        private decimal _Total;

        //Textos de Busqueda
        private string _VarAux;
        private string _VarAux2;

        private DateTime _Fecha1;
        private DateTime _Fecha2;

        private int _halpme;
        public DateTime Fecha
        {
            get
            {
                return _Fecha;
            }

            set
            {
                _Fecha = value;
            }
        }

        public int IDConsumo
        {
            get
            {
                return _IDConsumo;
            }

            set
            {
                _IDConsumo = value;
            }
        }

        public int ClaveCC
        {
            get
            {
                return _ClaveCC;
            }

            set
            {
                _ClaveCC = value;
            }
        }

        public string IDRequisitor
        {
            get
            {
                return _IDRequisitor;
            }

            set
            {
                _IDRequisitor = value;
            }
        }

        public decimal Total
        {
            get
            {
                return _Total;
            }

            set
            {
                _Total = value;
            }
        }

        public string VarAux
        {
            get
            {
                return _VarAux;
            }

            set
            {
                _VarAux = value;
            }
        }

        public string VarAux2
        {
            get
            {
                return _VarAux2;
            }

            set
            {
                _VarAux2 = value;
            }
        }

        public int Halpme
        {
            get
            {
                return _halpme;
            }

            set
            {
                _halpme = value;
            }
        }

        public DateTime Fecha1
        {
            get
            {
                return _Fecha1;
            }

            set
            {
                _Fecha1 = value;
            }
        }

        public DateTime Fecha2
        {
            get
            {
                return _Fecha2;
            }

            set
            {
                _Fecha2 = value;
            }
        }

        //Constructores
        public ConsumoCCData()
        {

        }

        public ConsumoCCData(DateTime fecha, int idconsumo, int ccc, string idreq, decimal total, string varaux, string varaux2,int halpme,DateTime fecha1,DateTime fecha2)
        {
            this.Fecha = fecha;
            this.IDConsumo = idconsumo;
            this.ClaveCC = ccc;
            this.IDRequisitor = idreq;
            this.Total = total;
            this.VarAux = varaux;
            this.VarAux2 = varaux2;
            this.Halpme = halpme;
            this.Fecha1 = fecha1;
            this.Fecha2 = fecha2;
        }

        //Metodos
        public string DisminuirStock(string SAPNumber, decimal cantidad)
        {
            string respuesta = "";

            SqlConnection SqlCon = new SqlConnection();

            try
            {
                //Codigo
                SqlCon.ConnectionString = Conexion.CadenaConexion;
                SqlCon.Open();
                //establecer comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spdistock";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParSAPN = new SqlParameter();
                ParSAPN.ParameterName = "@SAPNumber";
                ParSAPN.SqlDbType = SqlDbType.VarChar;
                ParSAPN.Size = 16;
                ParSAPN.Value = SAPNumber;
                SqlCmd.Parameters.Add(ParSAPN);

                SqlParameter ParCantidad = new SqlParameter();
                ParCantidad.ParameterName = "@Cantidad";
                ParCantidad.SqlDbType = SqlDbType.Decimal;
                ParCantidad.Precision = 8;
                ParCantidad.Scale = 3;
                ParCantidad.Value = cantidad;
                SqlCmd.Parameters.Add(ParCantidad);

                //Se hace la condicion para saber si se disminuyo correctamente el stock

                respuesta = SqlCmd.ExecuteNonQuery() == 1 ? "KK" : "Error en la actualizacion del stock de la Matrix";
            }
            catch (Exception e)
            {
                //Mensaje de Errores
                respuesta = e.Message;
            }
            //Cierre de la conexion
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return respuesta;
        }

        public string Insertar(ConsumoCCData Consumo, List<DetalleConsumoCCData> Detalle)
        {
            string respuesta = "";

            SqlConnection SqlCon = new SqlConnection();

            try
            {
                //Codigo
                SqlCon.ConnectionString = Conexion.CadenaConexion;
                SqlCon.Open();
                //establecer transaccion
                SqlTransaction SqlTra = SqlCon.BeginTransaction();
                //establecer comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.Transaction = SqlTra;
                SqlCmd.CommandText = "spsalidacc";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIDConsumo = new SqlParameter();
                ParIDConsumo.ParameterName = "@IDConsumo";
                ParIDConsumo.SqlDbType = SqlDbType.Int;
                ParIDConsumo.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIDConsumo);

                SqlParameter ParFecha = new SqlParameter();
                ParFecha.ParameterName = "@Fecha";
                ParFecha.SqlDbType = SqlDbType.Date;
                ParFecha.Value = Fecha;
                SqlCmd.Parameters.Add(ParFecha);

                SqlParameter ParClaveCC = new SqlParameter();
                ParClaveCC.ParameterName = "@ClaveCentroCosto";
                ParClaveCC.SqlDbType = SqlDbType.Int;
                ParClaveCC.Value = Consumo.ClaveCC;
                SqlCmd.Parameters.Add(ParClaveCC);

                SqlParameter ParIdReq = new SqlParameter();
                ParIdReq.ParameterName = "@IDRequisitor";
                ParIdReq.SqlDbType = SqlDbType.VarChar;
                ParIdReq.Size = 32;
                ParIdReq.Value = Consumo.IDRequisitor;
                SqlCmd.Parameters.Add(ParIdReq);

                SqlParameter ParTotal = new SqlParameter();
                ParTotal.ParameterName = "@Total";
                ParTotal.SqlDbType = SqlDbType.Money;
                ParTotal.Value = Consumo.Total;
                SqlCmd.Parameters.Add(ParTotal);

                //Se hace la condicion para saber si se disminuyo correctamente el stock

                respuesta = SqlCmd.ExecuteNonQuery() == 1 ? "KK" : "No se ingreso el registro";

                if (respuesta.Equals("KK"))
                {
                    //Se obtiene el codigo de la salida genreada
                    this.IDConsumo = Convert.ToInt32(SqlCmd.Parameters["@IDConsumo"].Value);
                    foreach (DetalleConsumoCCData det in Detalle)
                    {
                        det.IDDetalle = this.IDConsumo;
                        //Se llama al metodo Insertar de la clase Detalle de Consumo
                        respuesta = det.Insertar(det, ref SqlCon, ref SqlTra);
                        if (!respuesta.Equals("KK"))
                        {
                            break;

                        }
                        else
                        {
                            //Se actualiza el stock
                            respuesta = DisminuirStock(det.SAPNumber, det.Cantidad);
                            if (!respuesta.Equals("KK"))
                            {
                                break;
                            }
                        }
                    }
                }
                if (respuesta.Equals("KK"))
                {
                    SqlTra.Commit();
                }
                else
                {
                    SqlTra.Rollback();
                }
            }
            catch (Exception e)
            {
                //Mensaje de Errores
                respuesta = e.Message;
            }
            //Cierre de la conexion
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return respuesta;
        }

        //Metodo Eliminar
        public string Eliminar(ConsumoCCData Consumo)
        {
            string respuesta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Codigo
                SqlCon.ConnectionString = Conexion.CadenaConexion;
                SqlCon.Open();
                //Establecer Comando
                SqlCommand SqlComd = new SqlCommand();
                SqlComd.Connection = SqlCon;
                SqlComd.CommandText = "speliminarsalida";
                SqlComd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdConsumo = new SqlParameter();
                ParIdConsumo.ParameterName = "@IDConsumo";
                ParIdConsumo.SqlDbType = SqlDbType.Int;
                ParIdConsumo.Value = Consumo.IDConsumo;
                SqlComd.Parameters.Add(ParIdConsumo);

                //Se ejecuta el comando
                respuesta = SqlComd.ExecuteNonQuery() == 1 ? "KK" : "No se elimino el consumo correctamente";
            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return respuesta;
        }

        public DataTable Mostrar()
        {
            DataTable DataResultado = new DataTable("ConsumoCC");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrarsalidascc";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlData = new SqlDataAdapter(SqlCmd);
                SqlData.Fill(DataResultado);
            }
            catch (Exception ex)
            {
                DataResultado = null;
            }
            return DataResultado;
        }
        //Metodo para buscar entre fechas
        public DataTable BusquedaFechas(string varaux1, string varaux2)
        {
            DataTable DataResult = new DataTable("ConsumoCC");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlComd = new SqlCommand();
                SqlComd.Connection = SqlCon;
                SqlComd.CommandText = "spbuscarsalidaccfecha"; 
                SqlComd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParVarAux = new SqlParameter();
                ParVarAux.ParameterName = "@varaux1";
                ParVarAux.SqlDbType = SqlDbType.VarChar;
                ParVarAux.Size = 50;
                ParVarAux.Value = Fecha1;
                SqlComd.Parameters.Add(ParVarAux);

                SqlParameter ParVarAux2 = new SqlParameter();
                ParVarAux2.ParameterName = "@varaux2";
                ParVarAux.Size = 50;
                ParVarAux2.SqlDbType = SqlDbType.VarChar;
                ParVarAux.Value = Fecha2;
                SqlComd.Parameters.Add(ParVarAux2);

                SqlDataAdapter SqlData = new SqlDataAdapter(SqlComd);
                SqlData.Fill(DataResult);
            }
            catch (Exception ex)
            {
                DataResult = null;
            }
            return DataResult;
        }

        //Mostrar detalles de la salida

        public DataTable MostrarDetalles(int TextoBusqueda)
        {
            DataTable DataResult = new DataTable("DetalleConsumoCC");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlComd = new SqlCommand();
                SqlComd.Connection = SqlCon;
                SqlComd.CommandText = "spmostrardetasalida";
                SqlComd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBusqueda = new SqlParameter();
                ParTextoBusqueda.ParameterName = "@varaux";
                ParTextoBusqueda.SqlDbType = SqlDbType.Int;
                ParTextoBusqueda.Value = Halpme;
                SqlComd.Parameters.Add(ParTextoBusqueda);

                SqlDataAdapter SqlData = new SqlDataAdapter(SqlComd);
                SqlData.Fill(DataResult);
            }
            catch (Exception ex)
            {
                DataResult = null;
            }
            return DataResult;
        }

        //Mostrar Articulos por su Descripcion
        public DataTable MostrarDescripcionArt(ConsumoCCData Consumo)
        {
            DataTable DataResult = new DataTable("Articulo");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlComd = new SqlCommand();
                SqlComd.Connection = SqlCon;
                SqlComd.CommandText = "spbusqartsalnom";
                SqlComd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBusqueda = new SqlParameter();
                ParTextoBusqueda.ParameterName = "@varaux";
                ParTextoBusqueda.SqlDbType = SqlDbType.VarChar;
                ParTextoBusqueda.Size = 50;
                ParTextoBusqueda.Value = VarAux;
                SqlComd.Parameters.Add(ParTextoBusqueda);

                SqlDataAdapter SqlData = new SqlDataAdapter(SqlComd);
                SqlData.Fill(DataResult);
            }
            catch (Exception ex)
            {
                DataResult = null;
            }
            return DataResult;
        }

        //Mostrar Articulos por su SAPNumber
        public DataTable MostrarSAPArt(ConsumoCCData Consumo)
        {
            DataTable DataResult = new DataTable("Articulo");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlComd = new SqlCommand();
                SqlComd.Connection = SqlCon;
                SqlComd.CommandText = "spbusqartsalsap";
                SqlComd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBusqueda = new SqlParameter();
                ParTextoBusqueda.ParameterName = "@varaux";
                ParTextoBusqueda.SqlDbType = SqlDbType.VarChar;
                ParTextoBusqueda.Size = 50;
                ParTextoBusqueda.Value = VarAux;
                SqlComd.Parameters.Add(ParTextoBusqueda);

                SqlDataAdapter SqlData = new SqlDataAdapter(SqlComd);
                SqlData.Fill(DataResult);
            }
            catch (Exception ex)
            {
                DataResult = null;
            }
            return DataResult;
        }
    }
}
