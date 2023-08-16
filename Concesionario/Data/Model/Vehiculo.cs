using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Data.Model
{
    public class Vehiculo
    {
        private int idVehiculo;
        private string marca;
        private string placa;
        private int modelo;

        public Vehiculo(int idVehiculo, string marca, string placa, int modelo)
        {
            this.IdVehiculo = idVehiculo;
            this.Marca = marca;
            this.Placa = placa;
            this.Modelo = modelo;
        }

        public Vehiculo(string marca, string placa, int modelo)
        {
            this.marca = marca;
            this.placa = placa;
            this.modelo = modelo;
            
        }

        public Vehiculo(int idVehiculo, string placa)
        {
            this.idVehiculo = idVehiculo;
            this.placa = placa;
        }

        public Vehiculo()
        {
        }

        public int IdVehiculo { get => idVehiculo; set => idVehiculo = value; }
        public string Marca { get => marca; set => marca = value; }
        public string Placa { get => placa; set => placa = value; }
        public int Modelo { get => modelo; set => modelo = value; }
    }
}