using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Librerias para el manejo de datos
using System.Data;
using System.Data.SqlClient;

namespace DataLayer
{
    class CentroCostosData
    {
        //Variables para hacer referencia a los de la tabla
        private int _ClaveCC;
        private string _Nombre;
        private string _MSE;

        //Variable auxiliar para busquedas
        private string _AuxTxt;

        //Metodos de encapsulamiento de los datos

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

        public string Nombre
        {
            get
            {
                return _Nombre;
            }

            set
            {
                _Nombre = value;
            }
        }

        public string MSE
        {
            get
            {
                return _MSE;
            }

            set
            {
                _MSE = value;
            }
        }

        public string AuxTxt
        {
            get
            {
                return _AuxTxt;
            }

            set
            {
                _AuxTxt = value;
            }
        }

        //Constructor vacio
        public CentroCostosData()
        {

        }

        //Constructor para el acceso a datos
        public CentroCostosData(int clavecc,string nombre,string mse,string varaux)
        {
            this.ClaveCC = clavecc;
            this.Nombre = nombre;
            this.MSE = mse;
            this.AuxTxt = varaux;
        }

        //Metodo Insertar
        public string Insertar(CentroCostosData CentroCosto)
        {
            string respuesta = "";

            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Codigo para recibir datos de SQL
                SqlCon.ConnectionString = Conexion.CadenaConexion;

                //Apertura Conexion
                SqlCon.Open();

                //Establecer Comando
                SqlCommand SqlComd = new SqlCommand();
                SqlComd.Connection = SqlCon;
                SqlComd.CommandText = "spinsertarCC";
                SqlComd.CommandType = CommandType.StoredProcedure;

                //Definiendo atributos de la tabla CentroCostos

                SqlParameter ParClaveCC = new SqlParameter();
                ParClaveCC.ParameterName = "@ClaveCentroCosto";
                ParClaveCC.SqlDbType = SqlDbType.Int;
                ParClaveCC.Value = CentroCosto.ClaveCC;
                SqlComd.Parameters.Add(ParClaveCC);

                SqlParameter ParNomCC = new SqlParameter();
                ParNomCC.ParameterName = "@Nombre";
                ParNomCC.SqlDbType = SqlDbType.VarChar;
                ParNomCC.Size = 50;
                ParNomCC.Value = CentroCosto.Nombre;
                SqlComd.Parameters.Add(ParNomCC);

                SqlParameter ParMSE = new SqlParameter();
                ParMSE.ParameterName = "@MSE";
                ParMSE.SqlDbType = SqlDbType.VarChar;
                ParMSE.Size = 6;
                ParMSE.Value = CentroCosto.MSE;
                SqlComd.Parameters.Add(ParMSE);
                               
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

        //Metodo Editar
        public string Editar(CentroCostosData CentroCosto)
        {
            string respuesta = "";

            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Codigo para recibir datos de SQL
                SqlCon.ConnectionString = Conexion.CadenaConexion;

                //Apertura Conexion
                SqlCon.Open();

                //Establecer Comando
                SqlCommand SqlComd = new SqlCommand();
                SqlComd.Connection = SqlCon;
                SqlComd.CommandText = "spmodificarCC";
                SqlComd.CommandType = CommandType.StoredProcedure;

                //Definiendo atributos de la tabla CentroCosto

                SqlParameter ParClaveCC = new SqlParameter();
                ParClaveCC.ParameterName = "@ClaveCentroCosto";
                ParClaveCC.SqlDbType = SqlDbType.Int;
                ParClaveCC.Value = CentroCosto.ClaveCC;
                SqlComd.Parameters.Add(ParClaveCC);

                SqlParameter ParNomCC = new SqlParameter();
                ParNomCC.ParameterName = "@Nombre";
                ParNomCC.SqlDbType = SqlDbType.VarChar;
                ParNomCC.Size = 50;
                ParNomCC.Value = CentroCosto.Nombre;
                SqlComd.Parameters.Add(ParNomCC);

                SqlParameter ParMSE = new SqlParameter();
                ParMSE.ParameterName = "@MSE";
                ParMSE.SqlDbType = SqlDbType.VarChar;
                ParMSE.Size = 6;
                ParMSE.Value = CentroCosto.MSE;
                SqlComd.Parameters.Add(ParMSE);

                //Se hace la condicion para saber si se inserto correctamente el registro

                respuesta = SqlComd.ExecuteNonQuery() == 1 ? "KK" : "Error en Edicion la Matrix";
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

        public string Eliminar(CentroCostosData CentroCosto)
        {
            string respuesta = "";

            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Codigo para recibir datos de SQL
                SqlCon.ConnectionString = Conexion.CadenaConexion;

                //Apertura Conexion
                SqlCon.Open();

                //Establecer Comando
                SqlCommand SqlComd = new SqlCommand();
                SqlComd.Connection = SqlCon;
                SqlComd.CommandText = "speliminarCC";
                SqlComd.CommandType = CommandType.StoredProcedure;

                //Definiendo atributos de la tabla CentroCosto

                SqlParameter ParClaveCC = new SqlParameter();
                ParClaveCC.ParameterName = "@ClaveCentroCosto";
                ParClaveCC.SqlDbType = SqlDbType.Int;
                ParClaveCC.Value = CentroCosto.ClaveCC;
                SqlComd.Parameters.Add(ParClaveCC);

                //Se hace la condicion para saber si se inserto correctamente el registro

                respuesta = SqlComd.ExecuteNonQuery() == 1 ? "KK" : "Error en Eliminacion de la Matrix";
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

        //Mostrar los proveedores
        public DataTable Mostrar()
        {
            DataTable dataResultado = new DataTable("CentroCostos");
            SqlConnection SqlCxn = new SqlConnection();
            try
            {
                SqlCxn.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCxn;
                SqlCmd.CommandText = "spmostrarCC";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlData = new SqlDataAdapter(SqlCmd);
                SqlData.Fill(dataResultado);
            }
            catch (Exception e)
            {
                dataResultado = null;
            }

            return dataResultado;
        }

        //Buscar Centro de Costo
        public DataTable Busqueda(CentroCostosData CentroCosto)
        {
            DataTable dataResultado = new DataTable("CentroCostos");
            SqlConnection SqlCxn = new SqlConnection();
            try
            {
                SqlCxn.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCxn;
                SqlCmd.CommandText = "spbuscarCC";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter Paraux = new SqlParameter();
                Paraux.ParameterName = "@txtaux";
                Paraux.SqlDbType = SqlDbType.VarChar;
                Paraux.Size = 50;
                Paraux.Value = CentroCosto.AuxTxt;
                SqlCmd.Parameters.Add(Paraux);

                SqlDataAdapter SqlData = new SqlDataAdapter(SqlCmd);
                SqlData.Fill(dataResultado);
            }
            catch (Exception e)
            {
                dataResultado = null;
            }

            return dataResultado;
        }
    }
}
