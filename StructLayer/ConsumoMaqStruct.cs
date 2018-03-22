using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using DataLayer;

namespace StructLayer
{
    public class ConsumoMaqStruct
    {
        public static string Insertar(string maq, string idreq, DateTime fecha, decimal total, DataTable dtDetalle)
        {
            ConsumoMaqData ConsumoMaq = new ConsumoMaqData();
            ConsumoMaq.NoMaq = maq;
            ConsumoMaq.IDRequisitor = idreq;
            ConsumoMaq.Fecha = fecha;
            ConsumoMaq.Total = total;
            List<DetalleCMaqData> detalle = new List<DetalleCMaqData>();

            foreach (DataRow raw in dtDetalle.Rows)
            {
                DetalleCMaqData detail = new DetalleCMaqData();
                detail.SAPNumber = Convert.ToString(raw["SAPNumber"].ToString());
                detail.Cantidad = Convert.ToDecimal(raw["Cantidad"].ToString());
                detail.Subtotal = Convert.ToDecimal(raw["Subtotal"].ToString());
                detalle.Add(detail);
            }
            return ConsumoMaq.Insertar(ConsumoMaq, detalle);
        }

        //Metodo para Eliminar salidas
        public static string Eliminar(int iddetalle)
        {
            ConsumoMaqData ConsumoMaq = new ConsumoMaqData();
            ConsumoMaq.IDConsumo = iddetalle;
            return ConsumoMaq.Eliminar(ConsumoMaq);
        }

        //Metodo Mostrar que llama al metodo mostrar de la clase 
        //Data Consumo de la capa de datos
        public static DataTable Mostrar()
        {
            return new ConsumoMaqData().Mostrar();
        }

        //Metodo Buscarfecha que llama al metodo buscar fecha
        //de la clase ConsumoData de la capa de datos
        public static DataTable BuscarFechas(DateTime varaux, DateTime varaux2)
        {
            ConsumoMaqData ConsumoMaq = new ConsumoMaqData();
            ConsumoMaq.Fecha1 = varaux;
            ConsumoMaq.Fecha2 = varaux2;
            return ConsumoMaq.BusquedaFechas(ConsumoMaq);
        }

        //Metodo para mostrar el detalle de las salidas
        public static DataTable MostrarDetalle(int varaux)
        {
            ConsumoMaqData Consumo = new ConsumoMaqData();
            Consumo.Halpme = varaux;
            return Consumo.MostrarDetalles(varaux);
        }

        public static DataTable BuscarArtNombre(string varaux)
        {
            ConsumoMaqData Consumo = new ConsumoMaqData();
            Consumo.VarAux = varaux;
            return Consumo.MostrarDescripcionArt(Consumo);
        }

        public static DataTable BuscarArtSAP(string varaux)
        {
            ConsumoMaqData Consumo = new ConsumoMaqData();
            Consumo.VarAux = varaux;
            return Consumo.MostrarSAPArt(Consumo);
        }
    }
}
