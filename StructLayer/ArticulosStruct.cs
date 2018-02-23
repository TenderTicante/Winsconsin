using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Importacion de los recursos de la capa de Datos
using DataLayer;
using System.Data;

namespace StructLayer
{
    public class ArticulosStruct
    {
            //Metodo para llamar a la funcion Insertar que esta en la capa de datos
            public static string Insertar(string sap, string desc, string marca, string med, string loc, string sublocacion, string area, decimal min, decimal max, decimal stock, string cp, decimal pu, string tc, string mg, string cuenta, string psa, string nc, byte[] image)
            {
                ArticulosData AD = new ArticulosData();

                AD.SAPNumber = sap;
                AD.Descripcion = desc;
                AD.Marca = marca;
                AD.UnidadMedida = med;
                AD.Locacion = loc;
                AD.Sublocacion = sublocacion;
                AD.Area = area;
                AD.Minimo = min;
                AD.Maximo = max;
                AD.Stock = stock;
                AD.ClaveProveedor = cp;
                AD.PrecioUnitario = pu;
                AD.TipoCambio = tc;
                AD.MaterialGroup = mg;
                AD.Cuenta = cuenta;
                AD.AreaPSA = psa;
                AD.NationCode = nc;
                AD.Imagen = image;

                return AD.Insertar(AD);
            }

        //Metodo para llamar a la funcion Editar que esta en la capa de datos
        public static string Editar(string sap, string desc, string marca, string med, string loc, string sublocacion, string area, decimal min, decimal max, decimal stock, string cp, decimal pu, string tc, string mg, string cuenta, string psa, string nc, byte[] image)
        {
            ArticulosData AD = new ArticulosData();

            AD.SAPNumber = sap;
            AD.Descripcion = desc;
            AD.Marca = marca;
            AD.UnidadMedida = med;
            AD.Locacion = loc;
            AD.Sublocacion = sublocacion;
            AD.Area = area;
            AD.Minimo = min;
            AD.Maximo = max;
            AD.Stock = stock;
            AD.ClaveProveedor = cp;
            AD.PrecioUnitario = pu;
            AD.TipoCambio = tc;
            AD.MaterialGroup = mg;
            AD.Cuenta = cuenta;
            AD.AreaPSA = psa;
            AD.NationCode = nc;
            AD.Imagen = image;

            return AD.Editar(AD);
        }

        //Metodo para llamar a la funcion Eliminar que esta en la capa de datos

        public static string Eliminar(string sapnumber)
        {
            ArticulosData AD = new ArticulosData();
            AD.SAPNumber = sapnumber;

            return AD.Eliminar(AD);
        }

        //Metodo para llamar a la funcion Mostrar que esta en la capa de datos

        public static DataTable Mostrar()
        {

            return new ArticulosData().Mostrar();
        }

        //Metodo de Filtrado por Area en la capa de datos

        public static DataTable BuscarxArea(string var)
        {
            ArticulosData AD = new ArticulosData();
            AD.Var = var;
            return AD.BusquedaXArea(AD);
        }

        //Metodo de Filtrado por Cuenta en la capa de datos

        public static DataTable BuscarxCuenta(string var)
        {
            ArticulosData AD = new ArticulosData();
            AD.Var = var;
            return AD.BusquedaXCuenta(AD);
        }

        //Metodo de Busqueda por Descripcion en la capa de datos

        public static DataTable BuscarxDesc(string var)
        {
            ArticulosData AD = new ArticulosData();
            AD.Var = var;
            return AD.BusquedaXDesc(AD);
        }

        //Metodo de Filtrado por Loc en la capa de datos
        public static DataTable BuscarxLoc(string var)
        {
            ArticulosData AD = new ArticulosData();
            AD.Var = var;
            return AD.BusquedaXLoc(AD);
        }

        //Metodo de Filtrado por Marca en la capa de datos
        public static DataTable BuscarxMarca(string var)
        {
            ArticulosData AD = new ArticulosData();
            AD.Var = var;
            return AD.BusquedaXMarca(AD);
        }

        //Metodo de Filtrado por Material Group en la capa de datos
        public static DataTable BuscarxMatG(string var)
        {
            ArticulosData AD = new ArticulosData();
            AD.Var = var;
            return AD.BusquedaXMatG(AD);
        }

        //Metodo de Filtrado por Unidad de Medida en la capa de datos
        public static DataTable BuscarxMedida(string var)
        {
            ArticulosData AD = new ArticulosData();
            AD.Var = var;
            return AD.BusquedaXMedida(AD);
        }

        //Metodo de Filtrado por NationCode en la capa de datos
        public static DataTable BuscarxNC(string var)
        {
            ArticulosData AD = new ArticulosData();
            AD.Var = var;
            return AD.BusquedaXNC(AD);
        }

        //Metodo de Filtrado por Proveedor en la capa de datos
        public static DataTable BuscarxProveedor(string var)
        {
            ArticulosData AD = new ArticulosData();
            AD.Var = var;
            return AD.BusquedaXProv(AD);
        }

        //Metodo de Filtrado por PSA en la capa de datos
        public static DataTable BuscarxPSA(string var)
        {
            ArticulosData AD = new ArticulosData();
            AD.Var = var;
            return AD.BusquedaXPSA(AD);
        }

        //Metodo de Filtrado por SAP Number en la capa de datos
        public static DataTable BuscarxSAP(string var)
        {
            ArticulosData AD = new ArticulosData();
            AD.Var = var;
            return AD.BusquedaXSAP(AD);
        }

        //Metodo de Filtrado por Sublocacion en la capa de datos
        public static DataTable BuscarxSublocacion(string var)
        {
            ArticulosData AD = new ArticulosData();
            AD.Var = var;
            return AD.BusquedaXSubloc(AD);
        }
    }
}
