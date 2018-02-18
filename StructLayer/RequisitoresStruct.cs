using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Librerias para el manejo de datos
using DataLayer;
using System.Data;

namespace StructLayer
{
    class RequisitoresStruct
    {
        //Metodo para llamar a la funcion Insertar que esta en la capa de datos
        public static string Insertar(string idr, string nombrer, string apr, int ccc, string puesto)
        {
            RequisitoresData RD = new RequisitoresData();
            RD.ClaveRequisitor = idr;
            RD.Nombre = nombrer;
            RD.Apellidos = apr;
            RD.ClaveCentroCosto = ccc;
            RD.Puesto = puesto;

            return RD.Insertar(RD);
        }

        //Metodo para llamar a la funcion Editar que esta en la capa de datos

        public static string Editar(string idr, string nombrer, string apr, int ccc, string puesto)
        {
            RequisitoresData RD = new RequisitoresData();
            RD.ClaveRequisitor = idr;
            RD.Nombre = nombrer;
            RD.Apellidos = apr;
            RD.ClaveCentroCosto = ccc;
            RD.Puesto = puesto;

            return RD.Editar(RD);
        }

        //Metodo para llamar a la funcion Eliminar que esta en la capa de datos

        public static string Eliminar(string idr)
        {
            RequisitoresData RD = new RequisitoresData();
            RD.ClaveRequisitor = idr;

            return RD.Eliminar(RD);
        }

        //Metodo para llamar a la funcion Mostrar que esta en la capa de datos

        public static DataTable Mostrar()
        {

            return new RequisitoresData().Mostrar();
        }

        //Metodo de Busqueda de Nombre que esta en la capa de datos

        public static DataTable BuscarxNombre(string var)
        {
            RequisitoresData UD = new RequisitoresData();
            UD.AuxTxt = var;

            return UD.BusquedaxNombre(UD);
        }

        //Metodo de Busqueda de Apellido que esta en la capa de datos

        public static DataTable BuscarxApellido(string var)
        {
            RequisitoresData RD = new RequisitoresData();
            RD.AuxTxt = var;

            return RD.BusquedaxApellido(RD);
        }

        //Metodo de Filtrado por Centro de Costo que esta en la capa de datos

        public static DataTable BuscarxCC(string var)
        {
            RequisitoresData RD = new RequisitoresData();
            RD.AuxTxt = var;

            return RD.BusquedaxCC(RD);
        }

        //Metodo de Filtrado por Puesto que esta en la capa de datos

        public static DataTable BuscarxPuesto(string var)
        {
            RequisitoresData RD = new RequisitoresData();
            RD.AuxTxt = var;

            return RD.BusquedaxPuesto(RD);
        }
    }
}
