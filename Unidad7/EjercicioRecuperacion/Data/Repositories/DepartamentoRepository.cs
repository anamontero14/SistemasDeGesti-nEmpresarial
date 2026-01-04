using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.Data.SqlClient;
using Data.DataBase;
using System;
using System.Collections.Generic;

namespace Data.Repositories
{
    /// <summary>
    /// Repositorio para gestionar las operaciones de acceso a datos de Departamentos
    /// </summary>
    public class DepartamentoRepository : IDepartamentoRepository
    {
        #region Métodos Públicos
        /// <summary>
        /// Obtiene todos los departamentos de la base de datos
        /// </summary>
        /// <returns>Lista con todos los departamentos</returns>
        public List<Departamento> getAllDepartamentos()
        {
            List<Departamento> listadoDepartamentos = new List<Departamento>();
            SqlConnection miConexion = null;
            SqlCommand miComando = null;
            SqlDataReader miLector = null;
            Connection connection = new Connection();

            try
            {
                miConexion = connection.getConnection();
                miComando = new SqlCommand();
                miComando.CommandText = "SELECT ID, Nombre FROM Departamentos";
                miComando.Connection = miConexion;

                miLector = miComando.ExecuteReader();

                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        Departamento oDepartamento = crearDepartamentoDesdeDataReader(miLector);
                        listadoDepartamentos.Add(oDepartamento);
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

            return listadoDepartamentos;
        }

        /// <summary>
        /// Obtiene un departamento específico por su ID
        /// </summary>
        /// <param name="id">ID del departamento a buscar</param>
        /// <returns>El departamento encontrado o null si no existe</returns>
        public Departamento getDepartamentoById(int id)
        {
            Departamento departamentoEncontrado = null;
            SqlConnection miConexion = null;
            SqlCommand miComando = null;
            SqlDataReader miLector = null;
            Connection connection = new Connection();

            try
            {
                miConexion = connection.getConnection();
                miComando = new SqlCommand();
                miComando.CommandText = "SELECT ID, Nombre FROM Departamentos WHERE ID = @ID";
                miComando.Connection = miConexion;
                miComando.Parameters.AddWithValue("@ID", id);

                miLector = miComando.ExecuteReader();

                if (miLector.Read())
                {
                    departamentoEncontrado = crearDepartamentoDesdeDataReader(miLector);
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

            return departamentoEncontrado;
        }
        #endregion

        #region Métodos Privados
        /// <summary>
        /// Crea una instancia de Departamento a partir de un DataReader
        /// </summary>
        /// <param name="reader">DataReader con los datos del departamento</param>
        /// <returns>Instancia de Departamento</returns>
        private Departamento crearDepartamentoDesdeDataReader(SqlDataReader reader)
        {
            Departamento departamento = new Departamento();

            departamento.ID = (int)reader["ID"];
            departamento.Nombre = (string)reader["Nombre"];

            return departamento;
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