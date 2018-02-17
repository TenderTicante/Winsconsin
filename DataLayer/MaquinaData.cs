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
    public class MaquinaData
    {
        //Variables para hacer referencia a los de la tabla
        private string _NoMaquina;
        private int _ClaveCentroCosto;
        private string _TipoMaquina;
        private string _Localizacion;

        //Variable auxiliar para busquedas
        private string _AuxTxt;

        //Encapsulamiento de datos

        public string NoMaquina
        {
            get
            {
                return _NoMaquina;
            }

            set
            {
                _NoMaquina = value;
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

        public string TipoMaquina
        {
            get
            {
                return _TipoMaquina;
            }

            set
            {
                _TipoMaquina = value;
            }
        }

        public string Localizacion
        {
            get
            {
                return _Localizacion;
            }

            set
            {
                _Localizacion = value;
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
        public MaquinaData()
        {

        }

        //Constructor para el acceso a datos
        public MaquinaData(string nomaq, int cc, string tipo, string loc, string aux)
        {
            this.NoMaquina = nomaq;
            this.ClaveCentroCosto = cc;
            this.TipoMaquina = tipo;
            this.Localizacion = loc;
            this.AuxTxt = aux;
        }

        //Metodo Insertar
        public string Insertar(MaquinaData Maquina)
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
                SqlComd.CommandText = "spinsertarMaquina";
                SqlComd.CommandType = CommandType.StoredProcedure;

                //Definiendo atributos de la tabla Maquina

                SqlParameter ParNoMaq = new SqlParameter();
                ParNoMaq.ParameterName = "@NoMaquina";
                ParNoMaq.SqlDbType = SqlDbType.VarChar;
                ParNoMaq.Size = 16;
                ParNoMaq.Value = Maquina.NoMaquina;
                SqlComd.Parameters.Add(ParNoMaq);

                SqlParameter ParCC = new SqlParameter();
                ParCC.ParameterName = "@ClaveCentroCosto";
                ParCC.SqlDbType = SqlDbType.Int;
                ParCC.Value = Maquina.ClaveCentroCosto;
                SqlComd.Parameters.Add(ParCC);

                SqlParameter ParTipo = new SqlParameter();
                ParTipo.ParameterName = "@TipoMaquina";
                ParTipo.SqlDbType = SqlDbType.VarChar;
                ParTipo.Size = 64;
                ParTipo.Value = Maquina.TipoMaquina;
                SqlComd.Parameters.Add(ParTipo);

                SqlParameter ParLocalizacion = new SqlParameter();
                ParLocalizacion.ParameterName = "@Localizacion";
                ParLocalizacion.SqlDbType = SqlDbType.VarChar;
                ParLocalizacion.Size = 32;
                ParLocalizacion.Value = Maquina.Localizacion;
                SqlComd.Parameters.Add(ParLocalizacion);

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
        public string Editar(MaquinaData Maquina)
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
                SqlComd.CommandText = "spmodificarMaq";
                SqlComd.CommandType = CommandType.StoredProcedure;

                //Definiendo atributos de la tabla Maquina

                SqlParameter ParNoMaq = new SqlParameter();
                ParNoMaq.ParameterName = "@NoMaquina";
                ParNoMaq.SqlDbType = SqlDbType.VarChar;
                ParNoMaq.Size = 16;
                ParNoMaq.Value = Maquina.NoMaquina;
                SqlComd.Parameters.Add(ParNoMaq);

                SqlParameter ParCC = new SqlParameter();
                ParCC.ParameterName = "@ClaveCentroCosto";
                ParCC.SqlDbType = SqlDbType.Int;
                ParCC.Value = Maquina.ClaveCentroCosto;
                SqlComd.Parameters.Add(ParCC);

                SqlParameter ParTipo = new SqlParameter();
                ParTipo.ParameterName = "@TipoMaquina";
                ParTipo.SqlDbType = SqlDbType.VarChar;
                ParTipo.Size = 64;
                ParTipo.Value = Maquina.TipoMaquina;
                SqlComd.Parameters.Add(ParTipo);

                SqlParameter ParLocalizacion = new SqlParameter();
                ParLocalizacion.ParameterName = "@Localizacion";
                ParLocalizacion.SqlDbType = SqlDbType.VarChar;
                ParLocalizacion.Size = 32;
                ParLocalizacion.Value = Maquina.Localizacion;
                SqlComd.Parameters.Add(ParLocalizacion);

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

        public string Eliminar(MaquinaData Maquina)
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
                SqlComd.CommandText = "speliminarMaq";
                SqlComd.CommandType = CommandType.StoredProcedure;

                //Definiendo atributos de la tabla Maquina

                SqlParameter ParIDUser = new SqlParameter();
                ParIDUser.ParameterName = "@txtaux";
                ParIDUser.SqlDbType = SqlDbType.VarChar;
                ParIDUser.Size = 16;
                ParIDUser.Value = Maquina.AuxTxt;
                SqlComd.Parameters.Add(ParIDUser);

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

        //Mostrar los Usuarios
        public DataTable Mostrar()
        {
            DataTable dataResultado = new DataTable("Maquina");
            SqlConnection SqlCxn = new SqlConnection();
            try
            {
                SqlCxn.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCxn;
                SqlCmd.CommandText = "spmostrarmaquina";
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

        //Metodo Buscar Maquina por Numero de Maquina
        public DataTable BuscarxNoMaq(MaquinaData Maquina)
        {
            DataTable DataResultado = new DataTable("Maquina");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon.ConnectionString = Conexion.CadenaConexion;
                SqlCommand Sqlcmd = new SqlCommand();
                Sqlcmd.Connection = Sqlcon;
                Sqlcmd.CommandText = "spbuscarmaq";
                Sqlcmd.CommandType = CommandType.StoredProcedure;

                SqlParameter Paraux = new SqlParameter();
                Paraux.ParameterName = "@txtaux";
                Paraux.SqlDbType = SqlDbType.VarChar;
                Paraux.Size = 50;
                Paraux.Value = Maquina.AuxTxt;
                Sqlcmd.Parameters.Add(Paraux);

                SqlDataAdapter Sqldatadpt = new SqlDataAdapter(Sqlcmd);
                Sqldatadpt.Fill(DataResultado);
            }
            catch (Exception ex)
            {
                DataResultado = null;
            }

            return DataResultado;
        }
    }
}
