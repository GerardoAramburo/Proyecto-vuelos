using MySql.Data.MySqlClient;
using Proyecto_vuelos.Base_de_datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_vuelos.Entidades
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Contra { get; set; }

        public static bool Guardar(Usuario usuario)
        {
            bool result = false;
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    MySqlCommand cmd = conexion.connection.CreateCommand();

                    if (usuario.Id == 0)
                    {
                        cmd.CommandText = "INSERT INTO usuarios (nombre_completo, correo, contra) " +
                            "VALUES (@nombre, @correo, @contra)";
                        cmd.Parameters.AddWithValue("@nombre", usuario.Nombre);
                        cmd.Parameters.AddWithValue("@correo", usuario.Correo);
                        cmd.Parameters.AddWithValue("@contra", usuario.Contra);
                    }
                    else
                    {
                        cmd.CommandText = "UPDATE usuarios SET nombre= @nombre, correo= @correo, contra= @contra " +
                            "WHERE id = @id";
                        cmd.Parameters.AddWithValue("@id", usuario.Id);
                        cmd.Parameters.AddWithValue("@nombre", usuario.Nombre);
                        cmd.Parameters.AddWithValue("@correo", usuario.Correo);
                        cmd.Parameters.AddWithValue("@contra", usuario.Contra);
                    }

                    result = cmd.ExecuteNonQuery() == 1;
                    conexion.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public static Usuario validarUsuario(Usuario usuario)
        {
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    string query = "SELECT idusuario, nombre_completo, correo, contra FROM usuarios WHERE correo=@correo AND contra=@contra;";

                    MySqlCommand cmd = new MySqlCommand(query, conexion.connection);
                    cmd.Parameters.AddWithValue("@correo", usuario.Correo);
                    cmd.Parameters.AddWithValue("@contra", usuario.Contra);

                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    if (dataReader.Read())
                    {
                        Usuario u = new Usuario();
                        u.Id = dataReader.GetInt32("idusuario");
                        u.Nombre = dataReader.GetString("nombre_completo");
                        u.Correo = dataReader.GetString("correo");
                        u.Contra = dataReader.GetString("contra");
                        dataReader.Close();
                        conexion.CloseConnection();
                        return u;
                    } else
                    {
                        dataReader.Close();
                        conexion.CloseConnection();
                        return null;
                    }

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }
    }
}