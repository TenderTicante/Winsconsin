using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataLayer;
using System.Data;

namespace StructLayer
{
    class UsuariosStruct
    {
        //Metodo para llamar a la funcion Insertar que esta en la capa de datos
        public static string Insertar(string idu, string nombreu, string apu, string acceso, string password)
        {
            UsuarioData UD = new UsuarioData();
            UD.IDUsuario = idu;
            UD.Nombre = nombreu;
            UD.Apellido = apu;
            UD.Acceso = acceso;
            UD.Password = password;

            return UD.Insertar(UD);
        }

        //Metodo para llamar a la funcion Editar que esta en la capa de datos

        public static string Editar(string idu, string nombreu, string apu, string acceso, string password)
        {
            UsuarioData UD = new UsuarioData();
            UD.IDUsuario = idu;
            UD.Nombre = nombreu;
            UD.Apellido = apu;
            UD.Acceso = acceso;
            UD.Password = password;

            return UD.Editar(UD);
        }

        //Metodo para llamar a la funcion Eliminar que esta en la capa de datos

        public static string Eliminar(string idu)
        {
            UsuarioData UD = new UsuarioData();
            UD.IDUsuario = idu;

            return UD.Eliminar(UD);
        }

        //Metodo para llamar a la funcion Mostrar que esta en la capa de datos

        public static DataTable Mostrar()
        {

            return new UsuarioData().Mostrar();
        }

        //Metodo de Busqueda de ID en la capa de datos

        public static DataTable BuscarxID(string var)
        {
            UsuarioData UD = new UsuarioData();
            UD.AuxTxt = var;

            return UD.BuscarxID(UD);
        }

        //Metodo de Busqueda de Nombre que esta en la capa de datos

        public static DataTable BuscarxNombre(string var)
        {
            UsuarioData UD = new UsuarioData();
            UD.AuxTxt = var;

            return UD.BusquedaxNombre(UD);
        }

        //Metodo de Busqueda de Apellido que esta en la capa de datos

        public static DataTable BuscarxApellido(string var)
        {
            UsuarioData UD = new UsuarioData();
            UD.AuxTxt = var;

            return UD.BusquedaxApellido(UD);
        }
    }
}
