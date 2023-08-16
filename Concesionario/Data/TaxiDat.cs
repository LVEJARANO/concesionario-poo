using Data.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Data
{
    public class TaxiDat
    {
        Persistence objPer = new Persistence();

        //Metodo para mostrar todos los Taxis
        public List<Taxi> mostrarTaxis()
        {

            List<Taxi> lista = new List<Taxi>();

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "SELECT tax_id,veh_marca, veh_placa, veh_modelo,tax_num_pasajeros,vehiculo_veh_id FROM vehiculo INNER JOIN taxi ON vehiculo.veh_id = taxi.vehiculo_veh_id;";
            MySqlDataReader reader = objSelectCmd.ExecuteReader();

            if (!reader.HasRows)
                return lista;

            while (reader.Read())
            {
                lista.Add(new Taxi(int.Parse(reader["tax_id"].ToString()), reader["veh_marca"].ToString(), reader["veh_placa"].ToString(),int.Parse(reader["veh_modelo"].ToString()), int.Parse(reader["tax_num_pasajeros"].ToString()),int.Parse(reader["vehiculo_veh_id"].ToString())));
            }
            objPer.closeConnection();

            return lista;
        }

        public bool guardarTaxi(Taxi tax)
        {
            bool ejecuto = false;
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "INSERT INTO taxi(tax_num_pasajeros, vehiculo_veh_id) VALUES ('"+tax.NumPasajeros+"', '"+tax.FkVehiculo+"');";

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
        public bool actualizarTaxi(Taxi tax)
        {
            bool ejecuto = false;
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "UPDATE taxi SET tax_num_pasajeros = '"+tax.NumPasajeros+"', vehiculo_veh_id = '"+tax.FkVehiculo+"' WHERE (tax_id = '"+tax.IdTaxi+"');";

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
        public bool eliminarTaxi(int idTaxi)
        {
            bool ejecuto = false;
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "DELETE FROM taxi WHERE (tax_id = '"+idTaxi+"');";

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