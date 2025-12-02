using Data.DataBase;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.Data.SqlClient;

namespace Data.Repositories.RepositoriosDepartamentos
{
    public class DepartamentoRepositoryAzure : IDepartamentoRepository
    {
        #region MÉTODOS CRUD

        /// <summary>
        /// Método que devuelve una lista de todos los departamentos de la BBDD
        /// </summary>
        /// <returns>Lista de departamentos</returns>
        public List<Departamento> getListaDepartamentos()
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
                        Departamento oDepartamento = new Departamento();

                        oDepartamento.ID = (int)miLector["ID"];
                        oDepartamento.Nombre = (string)miLector["Nombre"];

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
                if (miLector != null) miLector.Close();
                if (miConexion != null) connection.closeConnection(ref miConexion);
            }

            return listadoDepartamentos;
        }

        /// <summary>
        /// PRE: El id del departamento no puede ser nulo
        /// Método que devuelve un departamento en específico
        /// </summary>
        /// <param name="idDepartamento">ID del departamento a buscar</param>
        /// <returns>Departamento encontrado o null si no existe</returns>
        public Departamento getDepartamentoPorId(int idDepartamento)
        {
            Departamento departamentoGetByID = null;
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
                miComando.Parameters.AddWithValue("@ID", idDepartamento);

                miLector = miComando.ExecuteReader();

                if (miLector.Read())
                {
                    departamentoGetByID = new Departamento();

                    departamentoGetByID.ID = (int)miLector["ID"];
                    departamentoGetByID.Nombre = (string)miLector["Nombre"];
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
                if (miLector != null) miLector.Close();
                if (miConexion != null) connection.closeConnection(ref miConexion);
            }

            return departamentoGetByID;
        }

        /// <summary>
        /// PRE: El departamento nuevo no puede ser nulo
        /// Método que crea un nuevo departamento en la BBDD
        /// </summary>
        /// <param name="departamentoNuevo">Departamento a insertar</param>
        /// <returns>Número de filas afectadas</returns>
        public int crearDepartamento(Departamento departamentoNuevo)
        {
            int filasAfectadas = 0;
            SqlConnection miConexion = null;
            SqlCommand miComando = null;
            Connection connection = new Connection();

            try
            {
                miConexion = connection.getConnection();

                miComando = new SqlCommand();
                miComando.CommandText = "INSERT INTO Departamentos (Nombre) VALUES (@Nombre)";
                miComando.Connection = miConexion;

                miComando.Parameters.AddWithValue("@Nombre", departamentoNuevo.Nombre);

                filasAfectadas = miComando.ExecuteNonQuery();
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
                if (miConexion != null) connection.closeConnection(ref miConexion);
            }

            return filasAfectadas;
        }

        /// <summary>
        /// PRE: El id del departamento y el departamento no pueden ser nulos
        /// Método que actualiza un departamento en específico de la BBDD
        /// </summary>
        /// <param name="idDepartamento">ID del departamento a actualizar</param>
        /// <param name="departamento">Objeto departamento con los nuevos datos</param>
        /// <returns>Número de filas afectadas</returns>
        public int actualizarDepartamento(int idDepartamento, Departamento departamento)
        {
            int filasAfectadas = 0;
            SqlConnection miConexion = null;
            SqlCommand miComando = null;
            Connection connection = new Connection();

            try
            {
                miConexion = connection.getConnection();

                miComando = new SqlCommand();
                miComando.CommandText = "UPDATE Departamentos SET Nombre = @Nombre WHERE ID = @ID";
                miComando.Connection = miConexion;

                miComando.Parameters.AddWithValue("@ID", idDepartamento);
                miComando.Parameters.AddWithValue("@Nombre", departamento.Nombre);

                filasAfectadas = miComando.ExecuteNonQuery();
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
                if (miConexion != null) connection.closeConnection(ref miConexion);
            }

            return filasAfectadas;
        }

        /// <summary>
        /// PRE: El id del departamento no puede ser nulo
        /// Método que elimina un departamento
        /// </summary>
        /// <param name="idDepartamento">ID del departamento a eliminar</param>
        /// <returns>Número de filas afectadas</returns>
        public int eliminarDepartamento(int idDepartamento)
        {
            int numeroFilasAfectadas = 0;
            SqlConnection miConexion = null;
            SqlCommand miComando = null;
            Connection connection = new Connection();

            try
            {
                miConexion = connection.getConnection();

                miComando = new SqlCommand();
                miComando.CommandText = "DELETE FROM Departamentos WHERE ID = @ID";
                miComando.Connection = miConexion;
                miComando.Parameters.AddWithValue("@ID", idDepartamento);

                numeroFilasAfectadas = miComando.ExecuteNonQuery();
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
                if (miConexion != null) connection.closeConnection(ref miConexion);
            }

            return numeroFilasAfectadas;
        }

        /// <summary>
        /// PRE: El id del departamento no puede ser nulo
        /// Método que devuelve el número de personas que pertenecen a un departamento específico
        /// </summary>
        /// <param name="idDepartamento">ID del departamento a consultar</param>
        /// <returns>Número de personas en el departamento</returns>
        public int personaEnDepartamento(int idDepartamento)
        {
            int numeroPersonas = 0;
            SqlConnection miConexion = null;
            SqlCommand miComando = null;
            SqlDataReader miLector = null;
            Connection connection = new Connection();

            try
            {
                miConexion = connection.getConnection();

                miComando = new SqlCommand();
                miComando.CommandText = "SELECT COUNT(*) FROM Personas WHERE IDDepartamento = @IDDepartamento";
                miComando.Connection = miConexion;
                miComando.Parameters.AddWithValue("@IDDepartamento", idDepartamento);

                miLector = miComando.ExecuteReader();

                if (miLector.Read())
                {
                    numeroPersonas = (int)miLector[0];
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
                if (miLector != null) miLector.Close();
                if (miConexion != null) connection.closeConnection(ref miConexion);
            }

            return numeroPersonas;
        }
        #endregion
    }
}