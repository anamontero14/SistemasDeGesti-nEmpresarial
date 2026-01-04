using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.Data.SqlClient;
using Data.DataBase;
using System;
using System.Collections.Generic;

namespace Data.Repositories
{
    /// <summary>
    /// Repositorio para gestionar las operaciones de acceso a datos de Personas
    /// </summary>
    public class PersonaRepository : IPersonaRepository
    {
        #region Métodos Públicos
        /// <summary>
        /// Obtiene todas las personas de la base de datos
        /// </summary>
        /// <returns>Lista con todas las personas</returns>
        public List<Persona> getAllPersonas()
        {
            List<Persona> listadoPersonas = new List<Persona>();
            SqlConnection miConexion = null;
            SqlCommand miComando = null;
            SqlDataReader miLector = null;
            Connection connection = new Connection();

            try
            {
                miConexion = connection.getConnection();
                miComando = new SqlCommand();
                miComando.CommandText = "SELECT ID, Nombre, Apellidos, FechaNacimiento, Direccion, Telefono, IDDepartamento, Foto FROM Personas";
                miComando.Connection = miConexion;

                miLector = miComando.ExecuteReader();

                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        Persona oPersona = crearPersonaDesdeDataReader(miLector);
                        listadoPersonas.Add(oPersona);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                cerrarRecursos(miLector, miConexion, connection);
            }

            return listadoPersonas;
        }

        /// <summary>
        /// Obtiene una persona específica por su ID
        /// </summary>
        /// <param name="id">ID de la persona a buscar</param>
        /// <returns>La persona encontrada o null si no existe</returns>
        public Persona getPersonaById(int id)
        {
            Persona personaEncontrada = null;
            SqlConnection miConexion = null;
            SqlCommand miComando = null;
            SqlDataReader miLector = null;
            Connection connection = new Connection();

            try
            {
                miConexion = connection.getConnection();
                miComando = new SqlCommand();
                miComando.CommandText = "SELECT ID, Nombre, Apellidos, FechaNacimiento, Direccion, Telefono, IDDepartamento, Foto FROM Personas WHERE ID = @ID";
                miComando.Connection = miConexion;
                miComando.Parameters.AddWithValue("@ID", id);

                miLector = miComando.ExecuteReader();

                if (miLector.Read())
                {
                    personaEncontrada = crearPersonaDesdeDataReader(miLector);
                }
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                cerrarRecursos(miLector, miConexion, connection);
            }

            return personaEncontrada;
        }
        #endregion

        #region Métodos Privados
        /// <summary>
        /// Crea una instancia de Persona a partir de un DataReader
        /// </summary>
        /// <param name="reader">DataReader con los datos de la persona</param>
        /// <returns>Instancia de Persona</returns>
        private Persona crearPersonaDesdeDataReader(SqlDataReader reader)
        {
            Persona persona = new Persona();

            persona.ID = (int)reader["ID"];
            persona.Nombre = (string)reader["Nombre"];
            persona.Apellidos = (string)reader["Apellidos"];

            if (reader["FechaNacimiento"] != DBNull.Value)
            {
                persona.FechaNacimiento = (DateTime)reader["FechaNacimiento"];
            }

            persona.Direccion = reader["Direccion"] != DBNull.Value ? (string)reader["Direccion"] : string.Empty;
            persona.Telefono = reader["Telefono"] != DBNull.Value ? (string)reader["Telefono"] : string.Empty;
            persona.IDDepartamento = (int)reader["IDDepartamento"];
            persona.Foto = reader["Foto"] != DBNull.Value ? (string)reader["Foto"] : string.Empty;

            return persona;
        }

        /// <summary>
        /// Cierra y libera los recursos de base de datos
        /// </summary>
        /// <param name="reader">DataReader a cerrar</param>
        /// <param name="conexion">Conexión a cerrar</param>
        /// <param name="connection">Objeto Connection para cerrar la conexión</param>
        private void cerrarRecursos(SqlDataReader reader, SqlConnection conexion, Connection connection)
        {
            if (reader != null)
            {
                reader.Close();
            }

            if (conexion != null)
            {
                connection.closeConnection(ref conexion);
            }
        }
        #endregion
    }
}