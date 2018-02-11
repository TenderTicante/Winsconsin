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
    public class ProveedoresStruct
    {
        //Metodo para llamar a la funcion Insertar que esta en la capa de datos
        public static string Insertar(string clavep,string nombrep,string contacto,string correo,string telefono,string direccion)
        {
            ProveedoresData PD = new ProveedoresData();
            PD.ClaveProveedor = clavep;
            PD.NombreProveedor = nombrep;
            PD.Contacto = contacto;
            PD.Correo = correo;
            PD.Telefono = telefono;
            PD.Direccion = direccion;

            return PD.Insertar(PD);
        }

        //Metodo para llamar a la funcion Editar que esta en la capa de datos

        public static string Editar(string clavep, string nombrep, string contacto, string correo, string telefono, string direccion)
        {
            ProveedoresData PD = new ProveedoresData();
            PD.ClaveProveedor = clavep;
            PD.NombreProveedor = nombrep;
            PD.Contacto = contacto;
            PD.Correo = correo;
            PD.Telefono = telefono;
            PD.Direccion = direccion;

            return PD.Editar(PD);
        }

        //Metodo para llamar a la funcion Eliminar que esta en la capa de datos

        public static string Eliminar(string clavep)
        {
            ProveedoresData PD = new ProveedoresData();
            PD.ClaveProveedor = clavep;

            return PD.Eliminar(PD);
        }

       //Metodo para llamar a la funcion Mostrar que esta en la capa de datos

        public static DataTable Mostrar()
        {

            return new ProveedoresData().Mostrar();
        }

        //Metodo de Busqueda que esta en la capa de datos

        public static DataTable BuscarProveedor(string var)
        {
            ProveedoresData PD = new ProveedoresData();
            PD.AuxTxt = var;

            return PD.Busqueda(PD);
        } 

        //Metodo de Busqueda de Clave en la capa de datos

        public static DataTable BuscarClaveProv(string var)
        {
            ProveedoresData PD = new ProveedoresData();
            PD.AuxTxt = var;
            return PD.BuscarxClave(PD);
        }
    }
}
