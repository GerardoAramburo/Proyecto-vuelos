using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using Proyecto_vuelos.Base_de_datos;

namespace Proyecto_vuelos.Entidades
{
    public class Avion
    {

        public int Id { get; set; }
        public string Placa { get; set; }
        public string Nombre { get; set; }

        public static List<Avion> GetAll()
        {
            List<Avion> aviones = new List<Avion>();
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    string query = "SELECT id, placa, nombre FROM avion;";
                    MySqlCommand command = new MySqlCommand(query, conexion.connection);

                    MySqlDataReader dataReader = command.ExecuteReader();

                    while(dataReader.Read())
                    {
                        Avion avion = new Avion();

                        avion.Id = int.Parse(dataReader["id"].ToString());
                        avion.Placa = dataReader["placa"].ToString();
                        avion.Nombre = dataReader["nombre"].ToString();

                        aviones.Add(avion);
                    }
                    dataReader.Close();
                    conexion.CloseConnection();
                }
            } catch (Exception ex)
            {
                throw ex;
            }
            return aviones;
        }
    }
}