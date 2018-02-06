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
    class ProveedoresData
    {
        //Variables para hacer referencia a los de la tabla
        private string _ClaveProveedor;
        private string _NombreProveedor;
        private string _Contacto;
        private string _Correo;
        private string _Telefono;
        private string _Direccion;

        //Variable auxiliar para busquedas
        private string _AuxTxt;

        //Metodos de encapsulamiento de los datos
        public string ClaveProveedor
        {
            get
            {
                return ClaveProveedor;
            }

            set
            {
                ClaveProveedor = value;
            }
        }

        public string NombreProveedor
        {
            get
            {
                return _NombreProveedor;
            }

            set
            {
                _NombreProveedor = value;
            }
        }

        public string Contacto
        {
            get
            {
                return _Contacto;
            }

            set
            {
                _Contacto = value;
            }
        }

        public string Correo
        {
            get
            {
                return _Correo;
            }

            set
            {
                _Correo = value;
            }
        }

        public string Telefono
        {
            get
            {
                return _Telefono;
            }

            set
            {
                _Telefono = value;
            }
        }

        public string Direccion
        {
            get
            {
                return _Direccion;
            }

            set
            {
                _Direccion = value;
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

        //Constructor para el acceso a datos
        public ProveedoresData(string clavep,string nombrep,string contacto,string correo,string telefono,string direccion,string aux)
        {
            this.ClaveProveedor = clavep;
            this.NombreProveedor = nombrep;
            this.Contacto = contacto;
            this.Correo = correo;
            this.Telefono = telefono;
            this.Direccion = direccion;
            this.AuxTxt = aux;
        }

        //Metodo Insertar
        public string Insertar(ProveedoresData Proveedor)
        {
            string respuesta="";

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
                SqlComd.CommandText = "spinsertarProv";
                SqlComd.CommandType = CommandType.StoredProcedure;

                //Definiendo atributos de la tabla Proveedores
                
                SqlParameter ParClaveProv = new SqlParameter();
                ParClaveProv.ParameterName = "@ClaveProveedor";
                ParClaveProv.SqlDbType = SqlDbType.VarChar;
                ParClaveProv.Size = 50;
                SqlComd.Parameters.Add(ParClaveProv);

                SqlParameter ParNomProv = new SqlParameter();
                ParNomProv.ParameterName = "@NombreProveedor";
                ParNomProv.SqlDbType = SqlDbType.VarChar;
                ParNomProv.Size = 50;
                ParNomProv.Value = Proveedor.NombreProveedor;
                SqlComd.Parameters.Add(ParNomProv);

                SqlParameter ParContact = new SqlParameter();
                ParContact.ParameterName = "@Contacto";
                ParContact.SqlDbType = SqlDbType.VarChar;
                ParContact.Size = 50;
                ParContact.Value = Proveedor.Contacto;
                SqlComd.Parameters.Add(ParContact);

                SqlParameter ParCorreo = new SqlParameter();
                ParCorreo.ParameterName = "@Correo";
                ParCorreo.SqlDbType = SqlDbType.VarChar;
                ParCorreo.Size = 50;
                ParCorreo.Value = Proveedor.Correo;
                SqlComd.Parameters.Add(ParCorreo);

                SqlParameter ParTel = new SqlParameter();
                ParTel.ParameterName = "@Telefono";
                ParTel.SqlDbType = SqlDbType.VarChar;
                ParTel.Size = 50;
                ParTel.Value = Proveedor.Telefono;
                SqlComd.Parameters.Add(ParTel);

                SqlParameter ParDir = new SqlParameter();
                ParDir.ParameterName = "@Direccion";
                ParDir.SqlDbType = SqlDbType.VarChar;
                ParDir.Size = 50;
                ParDir.Value = Proveedor.Direccion;
                SqlComd.Parameters.Add(ParDir);

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
        public string Editar(ProveedoresData Proveedor)
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
                SqlComd.CommandText = "speditarProv";
                SqlComd.CommandType = CommandType.StoredProcedure;

                //Definiendo atributos de la tabla Proveedores

                SqlParameter ParClaveProv = new SqlParameter();
                ParClaveProv.ParameterName = "@ClaveProveedor";
                ParClaveProv.SqlDbType = SqlDbType.VarChar;
                ParClaveProv.Size = 50;
                SqlComd.Parameters.Add(ParClaveProv);

                SqlParameter ParNomProv = new SqlParameter();
                ParNomProv.ParameterName = "@NombreProveedor";
                ParNomProv.SqlDbType = SqlDbType.VarChar;
                ParNomProv.Size = 50;
                ParNomProv.Value = Proveedor.NombreProveedor;
                SqlComd.Parameters.Add(ParNomProv);

                SqlParameter ParContact = new SqlParameter();
                ParContact.ParameterName = "@Contacto";
                ParContact.SqlDbType = SqlDbType.VarChar;
                ParContact.Size = 50;
                ParContact.Value = Proveedor.Contacto;
                SqlComd.Parameters.Add(ParContact);

                SqlParameter ParCorreo = new SqlParameter();
                ParCorreo.ParameterName = "@Correo";
                ParCorreo.SqlDbType = SqlDbType.VarChar;
                ParCorreo.Size = 50;
                ParCorreo.Value = Proveedor.Correo;
                SqlComd.Parameters.Add(ParCorreo);

                SqlParameter ParTel = new SqlParameter();
                ParTel.ParameterName = "@Telefono";
                ParTel.SqlDbType = SqlDbType.VarChar;
                ParTel.Size = 50;
                ParTel.Value = Proveedor.Telefono;
                SqlComd.Parameters.Add(ParTel);

                SqlParameter ParDir = new SqlParameter();
                ParDir.ParameterName = "@Direccion";
                ParDir.SqlDbType = SqlDbType.VarChar;
                ParDir.Size = 50;
                ParDir.Value = Proveedor.Direccion;
                SqlComd.Parameters.Add(ParDir);

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

        public string Eliminar(ProveedoresData Proveedor)
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
                SqlComd.CommandText = "speliminarProv";
                SqlComd.CommandType = CommandType.StoredProcedure;

                //Definiendo atributos de la tabla Proveedores

                SqlParameter ParClaveProv = new SqlParameter();
                ParClaveProv.ParameterName = "@ClaveProveedor";
                ParClaveProv.SqlDbType = SqlDbType.VarChar;
                ParClaveProv.Size = 50;
                SqlComd.Parameters.Add(ParClaveProv);

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
            DataTable dataResultado = new DataTable("Proveedores");
            SqlConnection SqlCxn = new SqlConnection();
            try
            {
                SqlCxn.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCxn;
                SqlCmd.CommandText = "spmostrarProveedores";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlData = new SqlDataAdapter(SqlCmd);
                SqlData.Fill(dataResultado);
            }
            catch(Exception e)
            {
                dataResultado = null;
            }

            return dataResultado;
        }

        //Buscar Nombre
        public DataTable Busqueda(ProveedoresData Proveedor)
        {
            DataTable dataResultado = new DataTable("Proveedores");
            SqlConnection SqlCxn = new SqlConnection();
            try
            {
                SqlCxn.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCxn;
                SqlCmd.CommandText = "spbuscarNombreProv";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter Paraux = new SqlParameter();
                Paraux.ParameterName = "@txtaux";
                Paraux.SqlDbType = SqlDbType.VarChar;
                Paraux.Size = 50;
                Paraux.Value = Proveedor.AuxTxt;
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
