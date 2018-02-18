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
    class RequisitoresData
    {
        //Variables para hacer referencia a los de la tabla

        private string _ClaveRequisitor;
        private string _Nombre;
        private string _Apellidos;
        private int _ClaveCentroCosto;
        private string _Puesto;

        //Variable auxiliar para busquedas
        private string _AuxTxt;

        //Encapsulamiento de datos
        public string ClaveRequisitor
        {
            get
            {
                return _ClaveRequisitor;
            }

            set
            {
                _ClaveRequisitor = value;
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

        public string Apellidos
        {
            get
            {
                return _Apellidos;
            }

            set
            {
                _Apellidos = value;
            }
        }

        public int ClaveCentroCosto
        {
            get
            {
                return _ClaveCentroCosto;
            }

            set
            {
                _ClaveCentroCosto = value;
            }
        }

        public string Puesto
        {
            get
            {
                return _Puesto;
            }

            set
            {
                _Puesto = value;
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

        public RequisitoresData()
        {

        }

        public RequisitoresData(string claver,string nom,string ap, int ccc, string puesto,string var)
        {
            claver = this.ClaveRequisitor;
            nom = this.Nombre;
            ap = this.Apellidos;
            ccc = this.ClaveCentroCosto;
            puesto = this.Puesto;
        }

        //Metodo Insertar
        public string Insertar(RequisitoresData Requisitor)
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
                SqlComd.CommandText = "spInsertarReq";
                SqlComd.CommandType = CommandType.StoredProcedure;

                //Definiendo atributos de la tabla Requisitores

                SqlParameter ParClavReq = new SqlParameter();
                ParClavReq.ParameterName = "@ClaveRequisitor";
                ParClavReq.SqlDbType = SqlDbType.VarChar;
                ParClavReq.Size = 32;
                ParClavReq.Value = Requisitor.ClaveRequisitor;
                SqlComd.Parameters.Add(ParClavReq);

                SqlParameter ParNom = new SqlParameter();
                ParNom.ParameterName = "@Nombre";
                ParNom.SqlDbType = SqlDbType.VarChar;
                ParNom.Size = 32;
                ParNom.Value = Requisitor.Nombre;
                SqlComd.Parameters.Add(ParNom);

                SqlParameter ParAp = new SqlParameter();
                ParAp.ParameterName = "@Apellidos";
                ParAp.SqlDbType = SqlDbType.VarChar;
                ParAp.Size = 32;
                ParAp.Value = Requisitor.Apellidos;
                SqlComd.Parameters.Add(ParAp);

                SqlParameter ParCCC = new SqlParameter();
                ParCCC.ParameterName = "@ClaveCentroCosto";
                ParCCC.SqlDbType = SqlDbType.Int;
                ParCCC.Value = Requisitor.ClaveCentroCosto;
                SqlComd.Parameters.Add(ParCCC);

                SqlParameter ParPuesto = new SqlParameter();
                ParPuesto.ParameterName = "@Puesto";
                ParPuesto.SqlDbType = SqlDbType.VarChar;
                ParPuesto.Size = 32;
                ParPuesto.Value = Requisitor.Puesto;
                SqlComd.Parameters.Add(ParPuesto);

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
        public string Editar(RequisitoresData Requisitor)
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
                SqlComd.CommandText = "spMdificarReq";
                SqlComd.CommandType = CommandType.StoredProcedure;

                //Definiendo atributos de la tabla Requisitores

                SqlParameter ParClavReq = new SqlParameter();
                ParClavReq.ParameterName = "@ClaveRequisitor";
                ParClavReq.SqlDbType = SqlDbType.VarChar;
                ParClavReq.Size = 32;
                ParClavReq.Value = Requisitor.ClaveRequisitor;
                SqlComd.Parameters.Add(ParClavReq);

                SqlParameter ParNom = new SqlParameter();
                ParNom.ParameterName = "@Nombre";
                ParNom.SqlDbType = SqlDbType.VarChar;
                ParNom.Size = 32;
                ParNom.Value = Requisitor.Nombre;
                SqlComd.Parameters.Add(ParNom);

                SqlParameter ParAp = new SqlParameter();
                ParAp.ParameterName = "@Apellidos";
                ParAp.SqlDbType = SqlDbType.VarChar;
                ParAp.Size = 32;
                ParAp.Value = Requisitor.Apellidos;
                SqlComd.Parameters.Add(ParAp);

                SqlParameter ParCCC = new SqlParameter();
                ParCCC.ParameterName = "@ClaveCentroCosto";
                ParCCC.SqlDbType = SqlDbType.Int;
                ParCCC.Value = Requisitor.ClaveCentroCosto;
                SqlComd.Parameters.Add(ParCCC);

                SqlParameter ParPuesto = new SqlParameter();
                ParPuesto.ParameterName = "@Puesto";
                ParPuesto.SqlDbType = SqlDbType.VarChar;
                ParPuesto.Size = 32;
                ParPuesto.Value = Requisitor.Puesto;
                SqlComd.Parameters.Add(ParPuesto);

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

        //Metodo Eliminar

        public string Eliminar(RequisitoresData Requisitor)
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
                SqlComd.CommandText = "spEliminarReq";
                SqlComd.CommandType = CommandType.StoredProcedure;

                //Definiendo atributos de la tabla Proveedores

                SqlParameter ParIDReq = new SqlParameter();
                ParIDReq.ParameterName = "@aux";
                ParIDReq.SqlDbType = SqlDbType.VarChar;
                ParIDReq.Size = 32;
                ParIDReq.Value = Requisitor.ClaveRequisitor;
                SqlComd.Parameters.Add(ParIDReq);

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

        //Mostrar los Requisitores
        public DataTable Mostrar()
        {
            DataTable dataResultado = new DataTable("Requisitores");
            SqlConnection SqlCxn = new SqlConnection();
            try
            {
                SqlCxn.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCxn;
                SqlCmd.CommandText = "spMostrarRequisitores";
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

        //Buscar por Apellido
        public DataTable BusquedaxApellido(RequisitoresData Requisitor)
        {
            DataTable dataResultado = new DataTable("Requisitor");
            SqlConnection SqlCxn = new SqlConnection();
            try
            {
                SqlCxn.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCxn;
                SqlCmd.CommandText = "spbuscarApReq";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter Paraux = new SqlParameter();
                Paraux.ParameterName = "@txtaux";
                Paraux.SqlDbType = SqlDbType.VarChar;
                Paraux.Size = 50;
                Paraux.Value = Requisitor.AuxTxt;
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

        //Buscar por Nombre
        public DataTable BusquedaxNombre(RequisitoresData Requisitor)
        {
            DataTable dataResultado = new DataTable("Requisitores");
            SqlConnection SqlCxn = new SqlConnection();
            try
            {
                SqlCxn.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCxn;
                SqlCmd.CommandText = "spbuscarNomReq";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter Paraux = new SqlParameter();
                Paraux.ParameterName = "@txtaux";
                Paraux.SqlDbType = SqlDbType.VarChar;
                Paraux.Size = 50;
                Paraux.Value = Requisitor.AuxTxt;
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

        //Buscar por Centro de Costo
        public DataTable BusquedaxCC(RequisitoresData Requisitor)
        {
            DataTable dataResultado = new DataTable("Requisitor");
            SqlConnection SqlCxn = new SqlConnection();
            try
            {
                SqlCxn.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCxn;
                SqlCmd.CommandText = "spbuscarCCReq";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter Paraux = new SqlParameter();
                Paraux.ParameterName = "@txtaux";
                Paraux.SqlDbType = SqlDbType.VarChar;
                Paraux.Size = 50;
                Paraux.Value = Requisitor.AuxTxt;
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

        //Buscar por Puesto
        public DataTable BusquedaxPuesto(RequisitoresData Requisitor)
        {
            DataTable dataResultado = new DataTable("Requisitor");
            SqlConnection SqlCxn = new SqlConnection();
            try
            {
                SqlCxn.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCxn;
                SqlCmd.CommandText = "spbuscarPReq";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter Paraux = new SqlParameter();
                Paraux.ParameterName = "@txtaux";
                Paraux.SqlDbType = SqlDbType.VarChar;
                Paraux.Size = 50;
                Paraux.Value = Requisitor.AuxTxt;
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
