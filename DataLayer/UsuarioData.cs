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
    public class UsuarioData
    {
        //Variables para hacer referencia a los de la tabla
        private string _IDUsuario;
        private string _Nombre;
        private string _Apellido;
        private string _Acceso;
        private string _Password;


        //Variable auxiliar para busquedas
        private string _AuxTxt;

        //Encapsulamiento de datos
        public string IDUsuario
        {
            get
            {
                return _IDUsuario;
            }

            set
            {
                _IDUsuario = value;
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

        public string Apellido
        {
            get
            {
                return _Apellido;
            }

            set
            {
                _Apellido = value;
            }
        }

        public string Acceso
        {
            get
            {
                return _Acceso;
            }

            set
            {
                _Acceso = value;
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

        public string Password
        {
            get
            {
                return _Password;
            }

            set
            {
                _Password = value;
            }
        }

        //Constructor vacio
        public UsuarioData()
        {

        }
        //Constructor para el acceso a datos
        public UsuarioData(string iduser, string nombres, string apellidos, string acceso, string password,string aux)
        {
            this.IDUsuario = iduser;
            this.Nombre = nombres;
            this.Apellido = apellidos;
            this.Acceso = acceso;
            this.Password = password;
            this.AuxTxt = aux;
        }

        //Metodo Insertar
        public string Insertar(UsuarioData Usuario)
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
                SqlComd.CommandText = "spinsertarUsuario";
                SqlComd.CommandType = CommandType.StoredProcedure;

                //Definiendo atributos de la tabla Proveedores

                SqlParameter ParIDUser = new SqlParameter();
                ParIDUser.ParameterName = "@IDUsuario";
                ParIDUser.SqlDbType = SqlDbType.VarChar;
                ParIDUser.Size = 16;
                ParIDUser.Value = Usuario.IDUsuario;
                SqlComd.Parameters.Add(ParIDUser);

                SqlParameter ParNomUser = new SqlParameter();
                ParNomUser.ParameterName = "@Nombre";
                ParNomUser.SqlDbType = SqlDbType.VarChar;
                ParNomUser.Size = 32;
                ParNomUser.Value = Usuario.Nombre;
                SqlComd.Parameters.Add(ParNomUser);

                SqlParameter ParApUser = new SqlParameter();
                ParApUser.ParameterName = "@Apellido";
                ParApUser.SqlDbType = SqlDbType.VarChar;
                ParApUser.Size = 32;
                ParApUser.Value = Usuario.Apellido;
                SqlComd.Parameters.Add(ParApUser);

                SqlParameter ParAcceso = new SqlParameter();
                ParAcceso.ParameterName = "@Acceso";
                ParAcceso.SqlDbType = SqlDbType.VarChar;
                ParAcceso.Size = 16;
                ParAcceso.Value = Usuario.Acceso;
                SqlComd.Parameters.Add(ParAcceso);

                SqlParameter ParPassword = new SqlParameter();
                ParPassword.ParameterName = "@Password";
                ParPassword.SqlDbType = SqlDbType.VarChar;
                ParPassword.Size = 8;
                ParPassword.Value = Usuario.Password;
                SqlComd.Parameters.Add(ParPassword);

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
        public string Editar(UsuarioData Usuario)
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
                SqlComd.CommandText = "spmodificarUsuario";
                SqlComd.CommandType = CommandType.StoredProcedure;

                //Definiendo atributos de la tabla Proveedores

                SqlParameter ParIDUser = new SqlParameter();
                ParIDUser.ParameterName = "@IDUsuario";
                ParIDUser.SqlDbType = SqlDbType.VarChar;
                ParIDUser.Size = 16;
                ParIDUser.Value = Usuario.IDUsuario;
                SqlComd.Parameters.Add(ParIDUser);

                SqlParameter ParNomUser = new SqlParameter();
                ParNomUser.ParameterName = "@Nombre";
                ParNomUser.SqlDbType = SqlDbType.VarChar;
                ParNomUser.Size = 32;
                ParNomUser.Value = Usuario.Nombre;
                SqlComd.Parameters.Add(ParNomUser);

                SqlParameter ParApUser = new SqlParameter();
                ParApUser.ParameterName = "@Apellido";
                ParApUser.SqlDbType = SqlDbType.VarChar;
                ParApUser.Size = 32;
                ParApUser.Value = Usuario.Apellido;
                SqlComd.Parameters.Add(ParApUser);

                SqlParameter ParAcceso = new SqlParameter();
                ParAcceso.ParameterName = "@Acceso";
                ParAcceso.SqlDbType = SqlDbType.VarChar;
                ParAcceso.Size = 16;
                ParAcceso.Value = Usuario.Acceso;
                SqlComd.Parameters.Add(ParAcceso);

                SqlParameter ParPassword = new SqlParameter();
                ParPassword.ParameterName = "@Password";
                ParPassword.SqlDbType = SqlDbType.VarChar;
                ParPassword.Size = 8;
                ParPassword.Value = Usuario.Password;
                SqlComd.Parameters.Add(ParPassword);

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

        public string Eliminar(UsuarioData Usuario)
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
                SqlComd.CommandText = "spEliminarUsuario";
                SqlComd.CommandType = CommandType.StoredProcedure;

                //Definiendo atributos de la tabla Proveedores

                SqlParameter ParIDUser = new SqlParameter();
                ParIDUser.ParameterName = "@IDUsuario";
                ParIDUser.SqlDbType = SqlDbType.VarChar;
                ParIDUser.Size = 16;
                ParIDUser.Value = Usuario.IDUsuario;
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
            DataTable dataResultado = new DataTable("Usuario");
            SqlConnection SqlCxn = new SqlConnection();
            try
            {
                SqlCxn.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCxn;
                SqlCmd.CommandText = "spmostrarUsuarios";
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

        //Metodo Buscar usuario por ID
        public DataTable BuscarxID(UsuarioData Usuario)
        {
            DataTable DataResultado = new DataTable("Usuario");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon.ConnectionString = Conexion.CadenaConexion;
                SqlCommand Sqlcmd = new SqlCommand();
                Sqlcmd.Connection = Sqlcon;
                Sqlcmd.CommandText = "spbuscarUsuario";
                Sqlcmd.CommandType = CommandType.StoredProcedure;

                SqlParameter Paraux = new SqlParameter();
                Paraux.ParameterName = "@txtaux";
                Paraux.SqlDbType = SqlDbType.VarChar;
                Paraux.Size = 50;
                Paraux.Value = Usuario.AuxTxt;
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

        //Buscar por Nombre
        public DataTable BusquedaxNombre(UsuarioData Usuario)
        {
            DataTable dataResultado = new DataTable("Usuario");
            SqlConnection SqlCxn = new SqlConnection();
            try
            {
                SqlCxn.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCxn;
                SqlCmd.CommandText = "spbuscarUsuarioNom";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter Paraux = new SqlParameter();
                Paraux.ParameterName = "@txtaux";
                Paraux.SqlDbType = SqlDbType.VarChar;
                Paraux.Size = 50;
                Paraux.Value = Usuario.AuxTxt;
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

        //Buscar por Apellido
        public DataTable BusquedaxApellido(UsuarioData Usuario)
        {
            DataTable dataResultado = new DataTable("Usuario");
            SqlConnection SqlCxn = new SqlConnection();
            try
            {
                SqlCxn.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCxn;
                SqlCmd.CommandText = "spbuscarUsuarioAp";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter Paraux = new SqlParameter();
                Paraux.ParameterName = "@txtaux";
                Paraux.SqlDbType = SqlDbType.VarChar;
                Paraux.Size = 50;
                Paraux.Value = Usuario.AuxTxt;
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
