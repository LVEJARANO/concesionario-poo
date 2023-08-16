using Data.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Data
{
    public class VehiculoDat
    {
        Persistence objPer = new Persistence();

        //Metodo para mostrar todas las Categorias
        public List<Vehiculo> mostrarVehiculos()
        {
            
            List<Vehiculo> lista = new List<Vehiculo>();

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "select veh_id, veh_marca, veh_placa, veh_modelo from vehiculo;";
            MySqlDataReader reader = objSelectCmd.ExecuteReader();

            if (!reader.HasRows)
                return lista;

            while (reader.Read())
            {
                lista.Add(new Vehiculo(int.Parse(reader["veh_id"].ToString()), reader["veh_marca"].ToString(),reader["veh_placa"].ToString(),int.Parse(reader["veh_modelo"].ToString())));
            }
            objPer.closeConnection();

            return lista;
        }
        public List<Vehiculo> llenarDDLVehiculos()
        {

            List<Vehiculo> lista = new List<Vehiculo>();

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "SELECT veh_id, veh_placa FROM vehiculo;";
            MySqlDataReader reader = objSelectCmd.ExecuteReader();

            if (!reader.HasRows)
                return lista;

            while (reader.Read())
            {
                lista.Add(new Vehiculo(int.Parse(reader["veh_id"].ToString()), reader["veh_placa"].ToString()));
            }
            objPer.closeConnection();

            return lista;
        }
        public bool guardarVehiculo(Vehiculo veh)
        {
            bool ejecuto = false;
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "INSERT INTO vehiculo(veh_marca, veh_placa, veh_modelo) VALUES ('"+veh.Marca+"', '"+veh.Placa+"', '"+veh.Modelo+"');";

            try
            {
                if (objSelectCmd.ExecuteNonQuery() != 0)
                {
                    ejecuto = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            objPer.closeConnection();
            return ejecuto;
        }
        public bool actualizarVehiculo(Vehiculo veh)
        {
            bool ejecuto = false;
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "UPDATE vehiculo SET veh_marca = '"+veh.Marca+"', veh_placa = '"+veh.Placa+"', veh_modelo = '"+veh.Modelo+"' WHERE (veh_id = '"+veh.IdVehiculo+"');";

            try
            {
                if (objSelectCmd.ExecuteNonQuery() != 0)
                {
                    ejecuto = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            objPer.closeConnection();
            return ejecuto;
        }
        public bool eliminarVehiculo(int idVehiculo)
        {
            bool ejecuto = false;
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "DELETE FROM vehiculo WHERE (veh_id = '"+idVehiculo+"');";

            try
            {
                if (objSelectCmd.ExecuteNonQuery() != 0)
                {
                    ejecuto = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            objPer.closeConnection();
            return ejecuto;
        }

    }
}