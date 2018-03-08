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
    public class ArticulosData
    {
        //Variables para hacer referencia a los de la tabla
        private string _SAPNumber;
        private string _Descripcion;
        private string _Marca;
        private string _UnidadMedida;
        private string _Locacion;
        private string _Sublocacion;
        private string _Area;
        private decimal _Minimo;
        private decimal _Maximo;
        private decimal _Stock;
        private string _ClaveProveedor;
        private decimal _PrecioUnitario;
        private string _TipoCambio;
        private string _MaterialGroup;
        private string _Cuenta;
        private string _AreaPSA;
        private string _NationCode;
        private byte[] _Imagen;

        //Variable auxiliar para busquedas
        private string _var;

        //Metodos de encapsulamiento de los datos
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

        public string Descripcion
        {
            get
            {
                return _Descripcion;
            }

            set
            {
                _Descripcion = value;
            }
        }

        public string Marca
        {
            get
            {
                return _Marca;
            }

            set
            {
                _Marca = value;
            }
        }

        public string UnidadMedida
        {
            get
            {
                return _UnidadMedida;
            }

            set
            {
                _UnidadMedida = value;
            }
        }

        public string Locacion
        {
            get
            {
                return _Locacion;
            }

            set
            {
                _Locacion = value;
            }
        }

        public string Sublocacion
        {
            get
            {
                return _Sublocacion;
            }

            set
            {
                _Sublocacion = value;
            }
        }

        public string Area
        {
            get
            {
                return _Area;
            }

            set
            {
                _Area = value;
            }
        }

        public decimal Minimo
        {
            get
            {
                return _Minimo;
            }

            set
            {
                _Minimo = value;
            }
        }

        public decimal Maximo
        {
            get
            {
                return _Maximo;
            }

            set
            {
                _Maximo = value;
            }
        }

        public decimal Stock
        {
            get
            {
                return _Stock;
            }

            set
            {
                _Stock = value;
            }
        }

        public string ClaveProveedor
        {
            get
            {
                return _ClaveProveedor;
            }

            set
            {
                _ClaveProveedor = value;
            }
        }

        public decimal PrecioUnitario
        {
            get
            {
                return _PrecioUnitario;
            }

            set
            {
                _PrecioUnitario = value;
            }
        }

        public string TipoCambio
        {
            get
            {
                return _TipoCambio;
            }

            set
            {
                _TipoCambio = value;
            }
        }

        public string MaterialGroup
        {
            get
            {
                return _MaterialGroup;
            }

            set
            {
                _MaterialGroup = value;
            }
        }

        public string Cuenta
        {
            get
            {
                return _Cuenta;
            }

            set
            {
                _Cuenta = value;
            }
        }

        public string AreaPSA
        {
            get
            {
                return _AreaPSA;
            }

            set
            {
                _AreaPSA = value;
            }
        }

        public string NationCode
        {
            get
            {
                return _NationCode;
            }

            set
            {
                _NationCode = value;
            }
        }

        public byte[] Imagen
        {
            get
            {
                return _Imagen;
            }

            set
            {
                _Imagen = value;
            }
        }

        public string Var
        {
            get
            {
                return _var;
            }

            set
            {
                _var = value;
            }
        }

        //Constructor vacio
        public ArticulosData()
        {

        }

        //Constructor para el acceso a datos
        public ArticulosData(string sap, string desc, string marca, string med, string loc, string sublocacion, string area, decimal min, decimal max, decimal stock, string cp, decimal pu, string tc, string mg, string cuenta, string psa, string nc, byte[] image, string var)
        {
            this.SAPNumber = sap;
            this.Descripcion = desc;
            this.Marca = marca;
            this.UnidadMedida = med;
            this.Locacion = loc;
            this.Sublocacion = sublocacion;
            this.Area = area;
            this.Minimo = min;
            this.Maximo = max;
            this.Stock = stock;
            this.ClaveProveedor = cp;
            this.PrecioUnitario = pu;
            this.TipoCambio = tc;
            this.MaterialGroup = mg;
            this.Cuenta = cuenta;
            this.AreaPSA = psa;
            this.NationCode = nc;
            this.Imagen = image;
            this.Var = var;
        }

        //Metodo Insertar
        public string Insertar(ArticulosData Articulo)
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
                SqlComd.CommandText = "spInsertarArt";
                SqlComd.CommandType = CommandType.StoredProcedure;

                //Definiendo atributos de la tabla Articulos

                SqlParameter ParSAPN = new SqlParameter();
                ParSAPN.ParameterName = "@SAPNumber";
                ParSAPN.SqlDbType = SqlDbType.VarChar;
                ParSAPN.Size = 16;
                ParSAPN.Value = Articulo.SAPNumber;
                SqlComd.Parameters.Add(ParSAPN);

                SqlParameter ParDesc = new SqlParameter();
                ParDesc.ParameterName = "@Descripcion";
                ParDesc.SqlDbType = SqlDbType.VarChar;
                ParDesc.Size = 250;
                ParDesc.Value = Articulo.Descripcion;
                SqlComd.Parameters.Add(ParDesc);

                SqlParameter ParMarca = new SqlParameter();
                ParMarca.ParameterName = "Marca";
                ParMarca.SqlDbType = SqlDbType.VarChar;
                ParMarca.Size = 50;
                ParMarca.Value = Articulo.Marca;
                SqlComd.Parameters.Add(ParMarca);

                SqlParameter ParUM = new SqlParameter();
                ParUM.ParameterName = "@UnidadMedida";
                ParUM.SqlDbType = SqlDbType.VarChar;
                ParMarca.Size = 50;
                ParUM.Value = Articulo.UnidadMedida;
                SqlComd.Parameters.Add(ParUM);

                SqlParameter ParLoc = new SqlParameter();
                ParLoc.ParameterName = "@Locacion";
                ParLoc.SqlDbType = SqlDbType.VarChar;
                ParLoc.Size = 50;
                ParLoc.Value = Articulo.Locacion;
                SqlComd.Parameters.Add(ParLoc);

                SqlParameter ParSubloc = new SqlParameter();
                ParSubloc.ParameterName = "@Sublocacion";
                ParSubloc.SqlDbType = SqlDbType.VarChar;
                ParSubloc.Size = 50;
                ParSubloc.Value = Articulo.Sublocacion;
                SqlComd.Parameters.Add(ParSubloc);

                SqlParameter ParArea = new SqlParameter();
                ParArea.ParameterName = "@Area";
                ParArea.SqlDbType = SqlDbType.VarChar;
                ParArea.Size = 50;
                ParArea.Value = Articulo.Area;
                SqlComd.Parameters.Add(ParArea);

                SqlParameter ParMin = new SqlParameter();
                ParMin.ParameterName = "@Minimo";
                ParMin.SqlDbType = SqlDbType.Decimal;
                ParMin.Precision = 8;
                ParMin.Scale = 3;
                ParMin.Value = Articulo.Minimo;
                SqlComd.Parameters.Add(ParMin);

                SqlParameter ParMax = new SqlParameter();
                ParMax.ParameterName = "@Maximo";
                ParMax.SqlDbType = SqlDbType.Decimal;
                ParMax.Precision = 8;
                ParMax.Scale = 3;
                ParMax.Value = Articulo.Maximo;
                SqlComd.Parameters.Add(ParMax);

                SqlParameter ParStock = new SqlParameter();
                ParStock.ParameterName = "@Stock";
                ParStock.SqlDbType = SqlDbType.Decimal;
                ParStock.Precision = 8;
                ParStock.Scale = 3;
                ParStock.Value = Articulo.Stock;
                SqlComd.Parameters.Add(ParStock);

                SqlParameter ParCCC = new SqlParameter();
                ParCCC.ParameterName = "@ClaveProveedor";
                ParCCC.SqlDbType = SqlDbType.VarChar;
                ParCCC.Size = 50;
                ParCCC.Value = Articulo.ClaveProveedor;
                SqlComd.Parameters.Add(ParCCC);

                SqlParameter ParMSE = new SqlParameter();
                ParMSE.ParameterName = "@PrecioUnitario";
                ParMSE.SqlDbType = SqlDbType.Money;
                ParMSE.Value = Articulo.PrecioUnitario;
                SqlComd.Parameters.Add(ParMSE);

                SqlParameter ParTipoC = new SqlParameter();
                ParTipoC.ParameterName = "@TipoCambio";
                ParTipoC.SqlDbType = SqlDbType.VarChar;
                ParTipoC.Size = 5;
                ParTipoC.Value = Articulo.TipoCambio;
                SqlComd.Parameters.Add(ParTipoC);

                SqlParameter ParMatG = new SqlParameter();
                ParMatG.ParameterName = "@MaterialGroup";
                ParMatG.SqlDbType = SqlDbType.VarChar;
                ParMatG.Size = 50;
                ParMatG.Value = Articulo.MaterialGroup;
                SqlComd.Parameters.Add(ParMatG);

                SqlParameter ParCuenta = new SqlParameter();
                ParCuenta.ParameterName = "@Cuenta";
                ParCuenta.SqlDbType = SqlDbType.VarChar;
                ParCuenta.Size = 50;
                ParCuenta.Value = Articulo.Cuenta;
                SqlComd.Parameters.Add(ParCuenta);

                SqlParameter ParAreaPSA = new SqlParameter();
                ParAreaPSA.ParameterName = "@AreaPSA";
                ParAreaPSA.SqlDbType = SqlDbType.VarChar;
                ParAreaPSA.Size = 50;
                ParAreaPSA.Value = Articulo.AreaPSA;
                SqlComd.Parameters.Add(ParAreaPSA);

                SqlParameter ParNatCode = new SqlParameter();
                ParNatCode.ParameterName = "@NationCode";
                ParNatCode.SqlDbType = SqlDbType.VarChar;
                ParNatCode.Size = 5;
                ParNatCode.Value = Articulo.NationCode;
                SqlComd.Parameters.Add(ParNatCode);

                SqlParameter ParImage = new SqlParameter();
                ParImage.ParameterName = "@Imagen";
                ParImage.SqlDbType = SqlDbType.Image;
                ParImage.Value = Articulo.Imagen;
                SqlComd.Parameters.Add(ParImage);


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
        public string Editar(ArticulosData Articulo)
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
                SqlComd.CommandText = "spModificarArt";
                SqlComd.CommandType = CommandType.StoredProcedure;

                //Definiendo atributos de la tabla Articulos

                SqlParameter ParSAPN = new SqlParameter();
                ParSAPN.ParameterName = "@SAPNumber";
                ParSAPN.SqlDbType = SqlDbType.VarChar;
                ParSAPN.Size = 16;
                ParSAPN.Value = Articulo.SAPNumber;
                SqlComd.Parameters.Add(ParSAPN);

                SqlParameter ParDesc = new SqlParameter();
                ParDesc.ParameterName = "@Descripcion";
                ParDesc.SqlDbType = SqlDbType.VarChar;
                ParDesc.Size = 250;
                ParDesc.Value = Articulo.Descripcion;
                SqlComd.Parameters.Add(ParDesc);

                SqlParameter ParMarca = new SqlParameter();
                ParMarca.ParameterName = "Marca";
                ParMarca.SqlDbType = SqlDbType.VarChar;
                ParMarca.Size = 50;
                ParMarca.Value = Articulo.Marca;
                SqlComd.Parameters.Add(ParMarca);

                SqlParameter ParUM = new SqlParameter();
                ParUM.ParameterName = "@UnidadMedida";
                ParUM.SqlDbType = SqlDbType.VarChar;
                ParMarca.Size = 50;
                ParUM.Value = Articulo.UnidadMedida;
                SqlComd.Parameters.Add(ParUM);

                SqlParameter ParLoc = new SqlParameter();
                ParLoc.ParameterName = "@Locacion";
                ParLoc.SqlDbType = SqlDbType.VarChar;
                ParLoc.Size = 50;
                ParLoc.Value = Articulo.Locacion;
                SqlComd.Parameters.Add(ParLoc);

                SqlParameter ParSubloc = new SqlParameter();
                ParSubloc.ParameterName = "@Sublocacion";
                ParSubloc.SqlDbType = SqlDbType.VarChar;
                ParSubloc.Size = 50;
                ParSubloc.Value = Articulo.Sublocacion;
                SqlComd.Parameters.Add(ParSubloc);

                SqlParameter ParArea = new SqlParameter();
                ParArea.ParameterName = "@Area";
                ParArea.SqlDbType = SqlDbType.VarChar;
                ParArea.Size = 50;
                ParArea.Value = Articulo.Area;
                SqlComd.Parameters.Add(ParArea);

                SqlParameter ParMin = new SqlParameter();
                ParMin.ParameterName = "@Minimo";
                ParMin.SqlDbType = SqlDbType.Decimal;
                ParMin.Precision = 8;
                ParMin.Scale = 3;
                ParMin.Value = Articulo.Minimo;
                SqlComd.Parameters.Add(ParMin);

                SqlParameter ParMax = new SqlParameter();
                ParMax.ParameterName = "@Maximo";
                ParMax.SqlDbType = SqlDbType.Decimal;
                ParMax.Precision = 8;
                ParMax.Scale = 3;
                ParMax.Value = Articulo.Maximo;
                SqlComd.Parameters.Add(ParMax);

                SqlParameter ParStock = new SqlParameter();
                ParStock.ParameterName = "@Stock";
                ParStock.SqlDbType = SqlDbType.Decimal;
                ParStock.Precision = 8;
                ParStock.Scale = 3;
                ParStock.Value = Articulo.Stock;
                SqlComd.Parameters.Add(ParStock);

                SqlParameter ParCCC = new SqlParameter();
                ParCCC.ParameterName = "@ClaveProveedor";
                ParCCC.SqlDbType = SqlDbType.VarChar;
                ParCCC.Size = 50;
                ParCCC.Value = Articulo.ClaveProveedor;
                SqlComd.Parameters.Add(ParCCC);

                SqlParameter ParMSE = new SqlParameter();
                ParMSE.ParameterName = "@PrecioUnitario";
                ParMSE.SqlDbType = SqlDbType.Money;
                ParMSE.Value = Articulo.PrecioUnitario;
                SqlComd.Parameters.Add(ParMSE);

                SqlParameter ParTipoC = new SqlParameter();
                ParTipoC.ParameterName = "@TipoCambio";
                ParTipoC.SqlDbType = SqlDbType.VarChar;
                ParTipoC.Size = 5;
                ParTipoC.Value = Articulo.TipoCambio;
                SqlComd.Parameters.Add(ParTipoC);

                SqlParameter ParMatG = new SqlParameter();
                ParMatG.ParameterName = "@MaterialGroup";
                ParMatG.SqlDbType = SqlDbType.VarChar;
                ParMatG.Size = 50;
                ParMatG.Value = Articulo.MaterialGroup;
                SqlComd.Parameters.Add(ParMatG);

                SqlParameter ParCuenta = new SqlParameter();
                ParCuenta.ParameterName = "@Cuenta";
                ParCuenta.SqlDbType = SqlDbType.VarChar;
                ParCuenta.Size = 50;
                ParCuenta.Value = Articulo.Cuenta;
                SqlComd.Parameters.Add(ParCuenta);

                SqlParameter ParAreaPSA = new SqlParameter();
                ParAreaPSA.ParameterName = "@AreaPSA";
                ParAreaPSA.SqlDbType = SqlDbType.VarChar;
                ParAreaPSA.Size = 50;
                ParAreaPSA.Value = Articulo.AreaPSA;
                SqlComd.Parameters.Add(ParAreaPSA);

                SqlParameter ParNatCode = new SqlParameter();
                ParNatCode.ParameterName = "@NationCode";
                ParNatCode.SqlDbType = SqlDbType.VarChar;
                ParNatCode.Size = 5;
                ParNatCode.Value = Articulo.NationCode;
                SqlComd.Parameters.Add(ParNatCode);

                SqlParameter ParImage = new SqlParameter();
                ParImage.ParameterName = "@Imagen";
                ParImage.SqlDbType = SqlDbType.Image;
                ParImage.Value = Articulo.Imagen;
                SqlComd.Parameters.Add(ParImage);


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

        public string Eliminar(ArticulosData Articulo)
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
                SqlComd.CommandText = "spEliminarArt";
                SqlComd.CommandType = CommandType.StoredProcedure;

                //Definiendo atributos de la tabla Articulos

                SqlParameter ParSAPN = new SqlParameter();
                ParSAPN.ParameterName = "@varaux";
                ParSAPN.SqlDbType = SqlDbType.VarChar;
                ParSAPN.Size = 16;
                ParSAPN.Value = Articulo.SAPNumber;
                SqlComd.Parameters.Add(ParSAPN);

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

        public DataTable Mostrar()
        {
            DataTable dataResultado = new DataTable("Articulo");
            SqlConnection SqlCxn = new SqlConnection();
            try
            {

               // Connection con = new Connection();


               // List<Articulo> articulos = con.Articulo.Take(100).ToList();

                SqlCxn.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCxn;
                SqlCmd.CommandText = "spMostrarArt";
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

        //Buscar x Area
        public DataTable BusquedaXArea(ArticulosData Articulo)
        {
            DataTable dataResultado = new DataTable("Articulo");
            SqlConnection SqlCxn = new SqlConnection();
            try
            {
                SqlCxn.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCxn;
                SqlCmd.CommandText = "spbuscarxArea";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter Paraux = new SqlParameter();
                Paraux.ParameterName = "@varaux";
                Paraux.SqlDbType = SqlDbType.VarChar;
                Paraux.Size = 50;
                Paraux.Value = Articulo.Var;
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

        //Buscar x Cuenta
        public DataTable BusquedaXCuenta(ArticulosData Articulo)
        {
            DataTable dataResultado = new DataTable("Articulo");
            SqlConnection SqlCxn = new SqlConnection();
            try
            {
                SqlCxn.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCxn;
                SqlCmd.CommandText = "spbuscarxCuenta";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter Paraux = new SqlParameter();
                Paraux.ParameterName = "@varaux";
                Paraux.SqlDbType = SqlDbType.VarChar;
                Paraux.Size = 50;
                Paraux.Value = Articulo.Var;
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

        //Buscar x Descripcion
        public DataTable BusquedaXDesc(ArticulosData Articulo)
        {
            DataTable dataResultado = new DataTable("Articulo");
            SqlConnection SqlCxn = new SqlConnection();
            try
            {
                SqlCxn.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCxn;
                SqlCmd.CommandText = "spbuscarxDesc";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter Paraux = new SqlParameter();
                Paraux.ParameterName = "@varaux";
                Paraux.SqlDbType = SqlDbType.VarChar;
                Paraux.Size = 50;
                Paraux.Value = Articulo.Var;
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

        //Buscar x Localizacion
        public DataTable BusquedaXLoc(ArticulosData Articulo)
        {
            DataTable dataResultado = new DataTable("Articulo");
            SqlConnection SqlCxn = new SqlConnection();
            try
            {
                SqlCxn.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCxn;
                SqlCmd.CommandText = "spbuscarxLoc";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter Paraux = new SqlParameter();
                Paraux.ParameterName = "@varaux";
                Paraux.SqlDbType = SqlDbType.VarChar;
                Paraux.Size = 50;
                Paraux.Value = Articulo.Var;
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

        //Buscar x Marca
        public DataTable BusquedaXMarca(ArticulosData Articulo)
        {
            DataTable dataResultado = new DataTable("Articulo");
            SqlConnection SqlCxn = new SqlConnection();
            try
            {
                SqlCxn.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCxn;
                SqlCmd.CommandText = "spbuscarxMarca";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter Paraux = new SqlParameter();
                Paraux.ParameterName = "@varaux";
                Paraux.SqlDbType = SqlDbType.VarChar;
                Paraux.Size = 50;
                Paraux.Value = Articulo.Var;
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

        //Buscar x Material Group
        public DataTable BusquedaXMatG(ArticulosData Articulo)
        {
            DataTable dataResultado = new DataTable("Articulo");
            SqlConnection SqlCxn = new SqlConnection();
            try
            {
                SqlCxn.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCxn;
                SqlCmd.CommandText = "spbuscarxMatG";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter Paraux = new SqlParameter();
                Paraux.ParameterName = "@varaux";
                Paraux.SqlDbType = SqlDbType.VarChar;
                Paraux.Size = 50;
                Paraux.Value = Articulo.Var;
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

        //Buscar x Medida
        public DataTable BusquedaXMedida(ArticulosData Articulo)
        {
            DataTable dataResultado = new DataTable("Articulo");
            SqlConnection SqlCxn = new SqlConnection();
            try
            {
                SqlCxn.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCxn;
                SqlCmd.CommandText = "spbuscarxMedida";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter Paraux = new SqlParameter();
                Paraux.ParameterName = "@varaux";
                Paraux.SqlDbType = SqlDbType.VarChar;
                Paraux.Size = 50;
                Paraux.Value = Articulo.Var;
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

        //Buscar x Localizacion
        public DataTable BusquedaXNC(ArticulosData Articulo)
        {
            DataTable dataResultado = new DataTable("Articulo");
            SqlConnection SqlCxn = new SqlConnection();
            try
            {
                SqlCxn.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCxn;
                SqlCmd.CommandText = "spbuscarxNC";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter Paraux = new SqlParameter();
                Paraux.ParameterName = "@varaux";
                Paraux.SqlDbType = SqlDbType.VarChar;
                Paraux.Size = 50;
                Paraux.Value = Articulo.Var;
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

        //Buscar x Proveedor
        public DataTable BusquedaXProv(ArticulosData Articulo)
        {
            DataTable dataResultado = new DataTable("Articulo");
            SqlConnection SqlCxn = new SqlConnection();
            try
            {
                SqlCxn.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCxn;
                SqlCmd.CommandText = "spbuscarxProv";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter Paraux = new SqlParameter();
                Paraux.ParameterName = "@varaux";
                Paraux.SqlDbType = SqlDbType.VarChar;
                Paraux.Size = 50;
                Paraux.Value = Articulo.Var;
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

        //Buscar x PSA
        public DataTable BusquedaXPSA(ArticulosData Articulo)
        {
            DataTable dataResultado = new DataTable("Articulo");
            SqlConnection SqlCxn = new SqlConnection();
            try
            {
                SqlCxn.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCxn;
                SqlCmd.CommandText = "spbuscarxPSA";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter Paraux = new SqlParameter();
                Paraux.ParameterName = "@varaux";
                Paraux.SqlDbType = SqlDbType.VarChar;
                Paraux.Size = 50;
                Paraux.Value = Articulo.Var;
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

        //Buscar x SAP
        public DataTable BusquedaXSAP(ArticulosData Articulo)
        {
            DataTable dataResultado = new DataTable("Articulo");
            SqlConnection SqlCxn = new SqlConnection();
            try
            {
                SqlCxn.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCxn;
                SqlCmd.CommandText = "spbuscarxSAP";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter Paraux = new SqlParameter();
                Paraux.ParameterName = "@varaux";
                Paraux.SqlDbType = SqlDbType.VarChar;
                Paraux.Size = 50;
                Paraux.Value = Articulo.Var;
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

        //Buscar x Localizacion
        public DataTable BusquedaXSubloc(ArticulosData Articulo)
        {
            DataTable dataResultado = new DataTable("Articulo");
            SqlConnection SqlCxn = new SqlConnection();
            try
            {
                SqlCxn.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCxn;
                SqlCmd.CommandText = "spbuscarxSubloc";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter Paraux = new SqlParameter();
                Paraux.ParameterName = "@varaux";
                Paraux.SqlDbType = SqlDbType.VarChar;
                Paraux.Size = 50;
                Paraux.Value = Articulo.Var;
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
