﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using DataLayer;

namespace StructLayer
{
    public class ConsumoCCStruct
    {
        //Metodo para insertar un consumo en la tabla de Consumo de Maquina
        public static string Insertar(DateTime fecha, int clavecc, string idreq, decimal total,DataTable dtDetalle)
        {
            ConsumoCCData Consumo = new ConsumoCCData();
            Consumo.Fecha = fecha;
            Consumo.ClaveCC = clavecc;
            Consumo.IDRequisitor = idreq;
            Consumo.Total = total;
            List<DetalleConsumoCCData> detalle = new List<DetalleConsumoCCData>();

            foreach(DataRow raw in dtDetalle.Rows)
            {
                DetalleConsumoCCData detail = new DetalleConsumoCCData();
                detail.SAPNumber = Convert.ToString(raw["SAPNumber"].ToString());
                detail.Cantidad = Convert.ToDecimal(raw["Cantidad"].ToString());
                detail.Subtotal = Convert.ToDecimal(raw["Subtotal"].ToString());
                detalle.Add(detail);
            }
            return Consumo.Insertar(Consumo,detalle);
        }

        //Metodo para Eliminar salidas
        public static string Eliminar(int iddetalle)
        {
            ConsumoCCData Consumo = new ConsumoCCData();
            Consumo.IDConsumo = iddetalle;
            return Consumo.Eliminar(Consumo);
        }

        //Metodo Mostrar que llama al metodo mostrar de la clase 
        //Data Consumo de la capa de datos
        public static DataTable Mostrar()
        {
            return new ConsumoCCData().Mostrar();
        }

        //Metodo Buscarfecha que llama al metodo buscar fecha
        //de la clase ConsumoData de la capa de datos
        public static DataTable BuscarFechas(DateTime varaux, DateTime varaux2)
        {
            ConsumoCCData Consumo = new ConsumoCCData();
            Consumo.Fecha1 = varaux;
            Consumo.Fecha2 = varaux2;
            return Consumo.BusquedaFechas(Consumo);
        }

        public static DataTable MostrarDetalle(int varaux)
        {
            ConsumoCCData Consumo = new ConsumoCCData();
            Consumo.Halpme = varaux;
            return Consumo.MostrarDetalles(varaux);
        }

        public static DataTable BuscarArtNombre(string varaux)
        {
            ConsumoCCData Consumo = new ConsumoCCData();
            Consumo.VarAux = varaux;
            return Consumo.MostrarDescripcionArt(Consumo);
        }

        public static DataTable BuscarArtSAP(string varaux)
        {
            ConsumoCCData Consumo = new ConsumoCCData();
            Consumo.VarAux = varaux;
            return Consumo.MostrarSAPArt(Consumo);
        }
    }
}
