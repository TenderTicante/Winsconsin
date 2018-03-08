using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace DataLayer
{
    public class DetalleConsumoCCData
    {
        private int _IDDetalle;
        private string _SAPNumber;
        private decimal _Cantidad;
        private decimal _Subtotal;

        public int IDDetalle
        {
            get
            {
                return _IDDetalle;
            }

            set
            {
                _IDDetalle = value;
            }
        }

        public string SAPNumber
        {
            get
            {
                return _SAPNumber;
            }

            set
            {
                _SAPNumber = value;
            }
        }

        public decimal Cantidad
        {
            get
            {
                return _Cantidad;
            }

            set
            {
                _Cantidad = value;
            }
        }

        public decimal Subtotal
        {
            get
            {
                return _Subtotal;
            }

            set
            {
                _Subtotal = value;
            }
        }

        //Constructores
        public DetalleConsumoCCData()
        {

        }

        public DetalleConsumoCCData(int iddetalle,string sap,decimal cant, decimal subtotal)
        {
            this.IDDetalle = iddetalle;
            this.SAPNumber = sap;
            this.Cantidad = cant;
            this.Subtotal = subtotal;

        }

        //Metetodo Insertar
        public string Insertar(DetalleConsumoCCData ConsumoCC,
            ref SqlConnection SqlCon, ref SqlTransaction SqlTra)
        {
            string respuesta = "";
            try
            {

                //Establecer Comando
                SqlCommand SqlComd = new SqlCommand();
                SqlComd.Connection = SqlCon;
                SqlComd.Transaction = SqlTra;
                SqlComd.CommandText = "spinsertardetcc";
                SqlComd.CommandType = CommandType.StoredProcedure;

                //Definiendo atributos de la tabla Articulos

                SqlParameter ParIDDetalle = new SqlParameter();
                ParIDDetalle.ParameterName = "@IDDetalle";
                ParIDDetalle.SqlDbType = SqlDbType.Int;
                ParIDDetalle.Value = ConsumoCC.IDDetalle;
                SqlComd.Parameters.Add(ParIDDetalle);

                SqlParameter ParSAPN = new SqlParameter();
                ParSAPN.ParameterName = "@SAPNumber";
                ParSAPN.SqlDbType = SqlDbType.VarChar;
                ParSAPN.Size = 16;
                ParSAPN.Value = ConsumoCC.SAPNumber;
                SqlComd.Parameters.Add(ParSAPN);

                SqlParameter ParCantidad = new SqlParameter();
                ParCantidad.ParameterName = "@Cantidad";
                ParCantidad.SqlDbType = SqlDbType.Decimal;
                ParCantidad.Precision = 5;
                ParCantidad.Scale = 2;
                ParCantidad.Value = ConsumoCC.Cantidad;
                SqlComd.Parameters.Add(ParCantidad);

                SqlParameter ParSubtotal = new SqlParameter();
                ParSubtotal.ParameterName = "@Subtotal";
                ParSubtotal.SqlDbType = SqlDbType.Money;
                ParSubtotal.Value = ConsumoCC.Subtotal;
                SqlComd.Parameters.Add(ParSubtotal);

                //Se hace la condicion para saber si se inserto correctamente el registro

                respuesta = SqlComd.ExecuteNonQuery() == 1 ? "KK" : "Error en Insercion la Matrix";
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
    }
}
