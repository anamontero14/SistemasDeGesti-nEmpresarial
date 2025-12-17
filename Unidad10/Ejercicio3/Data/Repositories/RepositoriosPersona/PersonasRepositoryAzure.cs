using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.Data.SqlClient;
using Data.DataBase;

namespace Data.Repositories.RepositoriosPersona
{
    public class PersonasRepositoryAzure : IPersonaRepository
    {
        #region MÉTODOS CRUD
        /// <summary>
        /// Método que obtiene una lista de todas las personas de la BBDD
        /// </summary>
        /// <returns>Una lista de todas las personas de la BBDD</returns>
        public List<Persona> getListaPersonas()
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
                        Persona oPersona = new Persona();

                        oPersona.ID = (int)miLector["ID"];
                        oPersona.Nombre = (string)miLector["Nombre"];
                        oPersona.Apellidos = (string)miLector["Apellidos"];

                        if (miLector["FechaNacimiento"] != DBNull.Value)
                        {
                            oPersona.FechaNacimiento = (DateTime)miLector["FechaNacimiento"];
                        }

                        oPersona.Direccion = miLector["Direccion"] != DBNull.Value ? (string)miLector["Direccion"] : "";
                        oPersona.Telefono = miLector["Telefono"] != DBNull.Value ? (string)miLector["Telefono"] : "";
                        oPersona.IDDepartamento = (int)miLector["IDDepartamento"];
                        oPersona.Foto = miLector["Foto"] != DBNull.Value ? (string)miLector["Foto"] : "";

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
                if (miLector != null) miLector.Close();
                if (miConexion != null) connection.closeConnection(ref miConexion);
            }

            return listadoPersonas;
        }

        /// <summary>
        /// PRE: el id de una persona no puede ser nulo
        /// Método que devuelve una persona por su ID
        /// </summary>
        /// <param name="idPersona">ID de la persona a buscar</param>
        /// <returns>La persona con el mismo id o null si no existe</returns>
        public Persona getPersonaPorId(int idPersona)
        {
            Persona personaGetByID = null;
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
                miComando.Parameters.AddWithValue("@ID", idPersona);

                miLector = miComando.ExecuteReader();

                if (miLector.Read())
                {
                    personaGetByID = new Persona();

                    personaGetByID.ID = (int)miLector["ID"];
                    personaGetByID.Nombre = (string)miLector["Nombre"];
                    personaGetByID.Apellidos = (string)miLector["Apellidos"];

                    if (miLector["FechaNacimiento"] != DBNull.Value)
                    {
                        personaGetByID.FechaNacimiento = (DateTime)miLector["FechaNacimiento"];
                    }

                    personaGetByID.Direccion = miLector["Direccion"] != DBNull.Value ? (string)miLector["Direccion"] : "";
                    personaGetByID.Telefono = miLector["Telefono"] != DBNull.Value ? (string)miLector["Telefono"] : "";
                    personaGetByID.IDDepartamento = (int)miLector["IDDepartamento"];
                    personaGetByID.Foto = miLector["Foto"] != DBNull.Value ? (string)miLector["Foto"] : "";
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

            return personaGetByID;
        }

        /// <summary>
        /// PRE: La persona nueva no puede ser nula
        /// Método que agrega una nueva persona a la BBDD
        /// </summary>
        /// <param name="personaNueva">Persona a insertar</param>
        /// <returns>El número de filas que han sido afectadas</returns>
        public int crearPersona(Persona personaNueva)
        {
            int filasAfectadas = 0;
            SqlConnection miConexion = null;
            SqlCommand miComando = null;
            Connection connection = new Connection();

            try
            {
                miConexion = connection.getConnection();

                miComando = new SqlCommand();
                miComando.CommandText = "INSERT INTO Personas (Nombre, Apellidos, FechaNacimiento, Direccion, Telefono, IDDepartamento, Foto) " +
                                       "VALUES (@Nombre, @Apellidos, @FechaNacimiento, @Direccion, @Telefono, @IDDepartamento, @Foto)";
                miComando.Connection = miConexion;

                miComando.Parameters.AddWithValue("@Nombre", personaNueva.Nombre);
                miComando.Parameters.AddWithValue("@Apellidos", personaNueva.Apellidos);
                miComando.Parameters.AddWithValue("@FechaNacimiento", personaNueva.FechaNacimiento);
                miComando.Parameters.AddWithValue("@Direccion", string.IsNullOrEmpty(personaNueva.Direccion) ? (object)DBNull.Value : personaNueva.Direccion);
                miComando.Parameters.AddWithValue("@Telefono", string.IsNullOrEmpty(personaNueva.Telefono) ? (object)DBNull.Value : personaNueva.Telefono);
                miComando.Parameters.AddWithValue("@IDDepartamento", personaNueva.IDDepartamento);
                miComando.Parameters.AddWithValue("@Foto", string.IsNullOrEmpty(personaNueva.Foto) ? (object)DBNull.Value : personaNueva.Foto);

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
        /// PRE: tiene que llegar un id de la persona a actualizar y los nuevos datos de esta
        /// Método que actualiza una persona
        /// </summary>
        /// <param name="idPersona">ID de la persona a actualizar</param>
        /// <param name="persona">Objeto persona con los nuevos datos</param>
        /// <returns>El número de filas que han sido afectadas</returns>
        public int actualizarPersona(int idPersona, Persona persona)
        {
            int filasAfectadas = 0;
            SqlConnection miConexion = null;
            SqlCommand miComando = null;
            Connection connection = new Connection();

            try
            {
                miConexion = connection.getConnection();

                miComando = new SqlCommand();
                miComando.CommandText = "UPDATE Personas SET " +
                                       "Nombre = @Nombre, " +
                                       "Apellidos = @Apellidos, " +
                                       "FechaNacimiento = @FechaNacimiento, " +
                                       "Direccion = @Direccion, " +
                                       "Telefono = @Telefono, " +
                                       "IDDepartamento = @IDDepartamento, " +
                                       "Foto = @Foto " +
                                       "WHERE ID = @ID";
                miComando.Connection = miConexion;

                miComando.Parameters.AddWithValue("@ID", idPersona);
                miComando.Parameters.AddWithValue("@Nombre", persona.Nombre);
                miComando.Parameters.AddWithValue("@Apellidos", persona.Apellidos);
                miComando.Parameters.AddWithValue("@FechaNacimiento", persona.FechaNacimiento);
                miComando.Parameters.AddWithValue("@Direccion", string.IsNullOrEmpty(persona.Direccion) ? (object)DBNull.Value : persona.Direccion);
                miComando.Parameters.AddWithValue("@Telefono", string.IsNullOrEmpty(persona.Telefono) ? (object)DBNull.Value : persona.Telefono);
                miComando.Parameters.AddWithValue("@IDDepartamento", persona.IDDepartamento);
                miComando.Parameters.AddWithValue("@Foto", string.IsNullOrEmpty(persona.Foto) ? (object)DBNull.Value : persona.Foto);

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
        /// PRE: tiene que llegar el id de una persona
        /// Método para eliminar una persona en específico
        /// </summary>
        /// <param name="idPersona">ID de la persona a eliminar</param>
        /// <returns>El número de filas que ha afectado</returns>
        public int eliminarPersona(int idPersona)
        {
            int numeroFilasAfectadas = 0;
            SqlConnection miConexion = null;
            SqlCommand miComando = null;
            Connection connection = new Connection();

            try
            {
                miConexion = connection.getConnection();

                miComando = new SqlCommand();
                miComando.CommandText = "DELETE FROM Personas WHERE ID = @ID";
                miComando.Connection = miConexion;
                miComando.Parameters.AddWithValue("@ID", idPersona);

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
        #endregion
    }
}