using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Data.Model
{
    public class Taxi:Vehiculo
    {
        private int idTaxi;
        private int numPasajeros;
        private int fkVehiculo;

        public int IdTaxi { get => idTaxi; set => idTaxi = value; }
        public int NumPasajeros { get => numPasajeros; set => numPasajeros = value; }
        public int FkVehiculo { get => fkVehiculo; set => fkVehiculo = value; }

        public Taxi(int idTaxi, int numPasajeros, int fkVehiculo)
        {
            this.idTaxi = idTaxi;
            this.numPasajeros = numPasajeros;
            this.fkVehiculo = fkVehiculo;
        }

        public Taxi(int numPasajeros, int fkVehiculo)
        {
            this.numPasajeros = numPasajeros;
            this.fkVehiculo = fkVehiculo;
        }
        public Taxi(int idTaxi, string marca, string placa, int modelo,int numPasajeros, int fkVehiculo)
            :base(marca, placa,modelo)
        {
            this.idTaxi = idTaxi;
            this.numPasajeros = numPasajeros;
            this.fkVehiculo = fkVehiculo;
        }


        public Taxi()
        {
        }
    }
}