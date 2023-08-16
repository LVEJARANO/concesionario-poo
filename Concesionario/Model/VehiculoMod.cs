using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model
{
    public class VehiculoMod
    {
        private int idVehiculo;
        private string marca;
        private string placa;
        private string modelo;

        public VehiculoMod(int idVehiculo, string marca, string placa, string modelo)
        {
            this.IdVehiculo = idVehiculo;
            this.Marca = marca;
            this.Placa = placa;
            this.Modelo = modelo;
        }

        public VehiculoMod()
        {
        }

        public int IdVehiculo { get => idVehiculo; set => idVehiculo = value; }
        public string Marca { get => marca; set => marca = value; }
        public string Placa { get => placa; set => placa = value; }
        public string Modelo { get => modelo; set => modelo = value; }
    }
}