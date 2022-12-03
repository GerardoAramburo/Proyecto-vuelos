using MySql.Data.MySqlClient;
using Proyecto_vuelos.Base_de_datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_vuelos.Entidades
{
    public class Vuelo
    {

        public int Id { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }

        public Avion Avion { get; set; }
        public string Capacidad { get; set; }
        public DateTime Fecha { get; set; }

        public static Vuelo GetById(int id)
        {
            Vuelo vuelo = new Vuelo();
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    string query = "SELECT vuelo.id, vuelo.origen, vuelo.destino, " +
                        "vuelo.capacidad, vuelo.fecha, avion.id AS idAvion, avion.nombre " +
                        "AS nombreAvion, avion.placa AS placaAvion FROM vuelo INNER JOIN avion " +
                        "ON vuelo.idAvion = avion.id WHERE vuelo.id = @id;";

                    MySqlCommand cmd = new MySqlCommand(query, conexion.connection);
                    cmd.Parameters.AddWithValue("@id", id);

                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        vuelo.Id = int.Parse(dataReader["id"].ToString());
                        vuelo.Origen = dataReader["origen"].ToString();
                        vuelo.Destino = dataReader["destino"].ToString();
                        Avion avion = new Avion();
                        avion.Id = int.Parse(dataReader["idAvion"].ToString());
                        vuelo.Capacidad = (dataReader["capacidad"].ToString());
                        vuelo.Fecha = DateTime.Parse(dataReader["fecha"].ToString());

                        vuelo.Avion = avion;

                    }
                    dataReader.Close();
                    conexion.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return vuelo;
        }

        public static List<Vuelo> GetAll()
        {
            List<Vuelo> vuelos = new List<Vuelo>();
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    string query = "SELECT vuelo.id, vuelo.origen, vuelo.destino, " +
                        "vuelo.capacidad, vuelo.fecha, avion.id AS idAvion, avion.nombre " +
                        "AS nombreAvion, avion.placa AS placaAvion FROM vuelo INNER JOIN avion " +
                        "ON vuelo.idAvion = avion.id;";
                    MySqlCommand command = new MySqlCommand(query, conexion.connection);

                    MySqlDataReader dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        Vuelo vuelo = new Vuelo();

                        vuelo.Id = int.Parse(dataReader["id"].ToString());
                        vuelo.Origen = dataReader["origen"].ToString();
                        vuelo.Destino = dataReader["destino"].ToString();
                        Avion avion = new Avion();
                        avion.Id = int.Parse(dataReader["idAvion"].ToString());
                        vuelo.Capacidad = (dataReader["capacidad"].ToString());
                        vuelo.Fecha = DateTime.Parse(dataReader["fecha"].ToString());

                        vuelo.Avion = avion;

                        vuelos.Add(vuelo);
                    }
                    dataReader.Close();
                    conexion.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return vuelos;
        }

        public static bool Guardar(int id, string origen, string destino, Avion Avion, string capacidad, DateTime fecha)
        {
            bool result = false;
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    MySqlCommand cmd = conexion.connection.CreateCommand();

                    if (id == 0)
                    {
                        cmd.CommandText = "INSERT INTO vuelo (origen, destino, idAvion, capacidad, fecha) VALUES (@origen, @destino, @idAvion, @capacidad, @fecha);";

                        cmd.Parameters.AddWithValue("@origen", origen);
                        cmd.Parameters.AddWithValue("@destino", destino);
                        cmd.Parameters.AddWithValue("@idAvion", Avion);
                        cmd.Parameters.AddWithValue("@capacidad", capacidad);
                        cmd.Parameters.AddWithValue("@DateTime", fecha);

                    }
                    else
                    {
                        cmd.CommandText = "UPDATE vuelo SET origen = @origen, destino = @destino, idAvion = @idAvion, capacidad = @capacidad, fecha = @fecha WHERE id = @id;";

                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@origen", origen);
                        cmd.Parameters.AddWithValue("@destino", destino);
                        cmd.Parameters.AddWithValue("@idAvion", Avion);
                        cmd.Parameters.AddWithValue("@capacidad", capacidad);
                        cmd.Parameters.AddWithValue("@DateTime", fecha);

                    }

                    result = cmd.ExecuteNonQuery() == 1;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
    
        }

        public static bool Eliminar(int id)
        {
            bool result = false;
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    MySqlCommand cmd = conexion.connection.CreateCommand();
                    cmd.CommandText = "DELETE FROM vuelo WHERE id = @id;";
                    cmd.Parameters.AddWithValue("@id", id);

                    result = cmd.ExecuteNonQuery() == 1;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }


    }
}