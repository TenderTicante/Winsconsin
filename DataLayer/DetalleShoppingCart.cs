using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace DataLayer
{
    class DetalleShoppingCart
    {
        private int _IDShopping;
        private string _SAPNumber;
        private decimal _CantidadOrdenada;
        private decimal _CantidadRecibida;
        private decimal _PrecioCompra;
        private decimal _Total;

        public int IDShopping
        {
            get{return _IDShopping;}
            set{_IDShopping = value;}
        }

        public string SAPNumber
        {
            get{return _SAPNumber;}
            set {_SAPNumber = value;}
        }

        public decimal CantidadOrdenada
        {
            get{return _CantidadOrdenada;}
            set {_CantidadOrdenada = value;}
        }

        public decimal CantidadRecibida
        {
            get{return _CantidadRecibida;}
            set {_CantidadRecibida = value;}
        }

        public decimal PrecioCompra
        {
            get{return _PrecioCompra;}
            set {_PrecioCompra = value;}
        }

        public decimal Total
        {
            get{return _Total;}
            set{_Total = value;}
        }
    }
}
