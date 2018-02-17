using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataLayer;
using System.Data;

namespace StructLayer
{
    public class MaquinaStruct
    {
        //Metodo para llamar a la funcion Insertar que esta en la capa de datos
        public static string Insertar(string nomaq, int cc, string tipo, string loc)
        {
            MaquinaData MD = new MaquinaData();
            MD.NoMaquina = nomaq;
            MD.ClaveCentroCosto = cc;
            MD.TipoMaquina = tipo;
            MD.Localizacion = loc;

            return MD.Insertar(MD);
        }

        //Metodo para llamar a la funcion Editar que esta en la capa de datos

        public static string Editar(string nomaq, int cc, string tipo, string loc)
        {
            MaquinaData MD = new MaquinaData();
            MD.NoMaquina = nomaq;
            MD.ClaveCentroCosto = cc;
            MD.TipoMaquina = tipo;
            MD.Localizacion = loc;

            return MD.Editar(MD);
        }

        //Metodo para llamar a la funcion Eliminar que esta en la capa de datos

        public static string Eliminar(string nomaq)
        {
            MaquinaData MD = new MaquinaData();
            MD.NoMaquina = nomaq;

            return MD.Eliminar(MD);
        }

        //Metodo para llamar a la funcion Mostrar que esta en la capa de datos

        public static DataTable Mostrar()
        {

            return new MaquinaData().Mostrar();
        }

        //Metodo de Busqueda de Numero de Maquina en la capa de datos

        public static DataTable BuscarxNoMaq(string var)
        {
            MaquinaData MD = new MaquinaData();
            MD.AuxTxt = var;

            return MD.BuscarxNoMaq(MD);
        }
    }
}
