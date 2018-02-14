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
    public class CentroCostoStruct
    {
        //Metodo para llamar a la funcion Insertar que esta en la capa de datos
        public static string Insertar(int clavecc, string nombrecc, string mse)
        {
            CentroCostosData CCD = new CentroCostosData();

            CCD.ClaveCC = clavecc;
            CCD.Nombre = nombrecc;
            CCD.MSE = mse;
         
            return CCD.Insertar(CCD);
        }

        //Metodo para llamar a la funcion Editar que esta en la capa de datos

        public static string Editar(int clavecc, string nombrecc, string mse)
        {
            CentroCostosData CCD = new CentroCostosData();

            CCD.ClaveCC = clavecc;
            CCD.Nombre = nombrecc;
            CCD.MSE = mse;

            return CCD.Editar(CCD);
        }

        //Metodo para llamar a la funcion Eliminar que esta en la capa de datos

        public static string Eliminar(int clavecc)
        {
            CentroCostosData CCD = new CentroCostosData();

            CCD.ClaveCC = clavecc;

            return CCD.Eliminar(CCD);
        }

        //Metodo para llamar a la funcion Mostrar que esta en la capa de datos

        public static DataTable Mostrar()
        {

            return new CentroCostosData().Mostrar();
        }

        //Metodo de Busqueda de Clave en la capa de datos

        public static DataTable BuscarClaveCC(string var)
        {
            CentroCostosData CCD = new CentroCostosData();
            CCD.AuxTxt = var;
            return CCD.Busqueda(CCD);
        }
    }
}
