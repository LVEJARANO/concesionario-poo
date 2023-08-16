using Data;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Logic
{
    public class VehiculoLog
    {
        VehiculoDat objVeh = new VehiculoDat();

        public List<Vehiculo> mostrarVehiculos()
        {
            return objVeh.mostrarVehiculos();
        }
        public List<Vehiculo> llenarDDLVehiculos()
        {
            return objVeh.llenarDDLVehiculos();
        }
        public bool guardarVehiculo(Vehiculo veh)
        { 
            return objVeh.guardarVehiculo(veh);
        }
        public bool actualizarVehiculo(Vehiculo veh)
        {
            return objVeh.actualizarVehiculo(veh);
        }
        public bool eliminarVehiculo(int idVehiculo)
        {
            return objVeh.eliminarVehiculo(idVehiculo);
        }
    }
}