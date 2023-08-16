using Data;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Web;

namespace Logic
{
    public class TaxiLog
    {
        TaxiDat objTax = new TaxiDat();

        public List<Taxi> mostrarTaxis()
        {
            return objTax.mostrarTaxis();
        }
        public bool guardarTaxi(Taxi tax)
        {
            return objTax.guardarTaxi(tax);
        }
        public bool actualizarTaxi(Taxi tax)
        {
            return objTax.actualizarTaxi(tax);
        }
        public bool eliminarTaxi(int idTaxi)
        {
            return objTax.eliminarTaxi(idTaxi);
        }
    }
}