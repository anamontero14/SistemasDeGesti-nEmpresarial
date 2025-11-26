using Domain.Entities;
using Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.DataBase;

namespace Data.Repositories.RepositoriosPersona
{
    public class PersonasRepositoryAzure : IPersonaRepository
    {
        /// <summary>
        /// Método que coge una lista de personas de la BBDD
        /// </summary>
        /// <returns>Una lista de todas las personas de la BBDD</returns>
        public List<Persona> getListaPersonas()
        {
            SqlConnection miConexion = new SqlConnection();

            List<Persona> listadoPersonas = new List<Persona>();

            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector;

            Persona oPersona;

            miConexion.ConnectionString = Connection.getConnectionString();

            try
            {

                miConexion.Open();

                //Creamos el comando (Creamos el comando, le pasamos la sentencia y la conexion, y lo ejecutamos)

                miComando.CommandText = "SELECT * FROM personas";

                miComando.Connection = miConexion;

                miLector = miComando.ExecuteReader();
                //Si hay lineas en el lector

                if (miLector.HasRows)
                {

                    while (miLector.Read())

                    {
                        oPersona = new Persona();

                        oPersona.ID = (int)miLector["ID"];

                        oPersona.Nombre = (string)miLector["Nombre"];

                        oPersona.Apellidos = (string)miLector["Apellidos"];

                        //Si sospechamos que el campo puede ser Null en la BBDD

                        if (miLector["FechaNacimiento"] != DBNull.Value)

                        { oPersona.FechaNacimiento = (DateTime)miLector["FechaNacimiento"]; }

                        oPersona.Direccion = (string)miLector["Direccion"];

                        oPersona.Telefono = (string)miLector["Telefono"];

                        listadoPersonas.Add(oPersona);

                    }

                }

                miLector.Close();

                miConexion.Close();

            }

            catch (SqlException exSql)
            {

                throw exSql;

            }

            return listadoPersonas;

        }

        /// <summary>
        /// PRE: el id de una persona y la persona no pueden ser nulos
        /// Método que devuelve un id en específico
        /// </summary>
        /// <param name="idPersona"></param>
        /// <returns>La persona con el mismo id</returns>
        public Persona getPersonaPorId(int idPersona)
        {
            //persona que se devuelve en el return
            Persona? personaGetByID = null;

            //variable que almacena todo el listado de las personas
            List<Persona> listaDePersonas = getListaPersonas();

            //recorro la lista de las personas
            foreach (Persona persona in listaDePersonas)
            {
                //comprueba si el id de la persona actual es igual al que entra por parámetros
                if (persona.ID == idPersona)
                {
                    //se iguala la variable a la persona actual
                    personaGetByID = persona;
                }
            }
            //deuelvo la persona con el mismo id
            return personaGetByID;
        }

        /// <summary>
        /// Se agrega una nueva persona a la BBDD
        /// </summary>
        /// <param name="personaNueva"></param>
        /// <returns>El número de filas que han sido afectadas</returns>
        public int crearPersona(Persona personaNueva)
        {
            //almacena las filas afectadas por la sentencia sql
            int filasAfectadas = -1;

            SqlConnection miConexion = new SqlConnection();

            SqlCommand miComando = new SqlCommand();

            miConexion.ConnectionString = Connection.getConnectionString();

            try
            {

                miConexion.Open();

                miComando.CommandText = "INSERT INTO Personas (ID, Nombre, Apellidos, Telefono, Direccion, Foto, FechaNacimiento, IDDepartamento) " +
                "VALUES (@ID, @Nombre, @Apellidos, @Telefono, @Direccion, @Foto, @FechaNacimiento, @IDDepartamento)";

                miComando.Parameters.AddWithValue("@ID", personaNueva.ID);
                miComando.Parameters.AddWithValue("@Nombre", personaNueva.Nombre);
                miComando.Parameters.AddWithValue("@Apellidos", personaNueva.Apellidos);
                miComando.Parameters.AddWithValue("@Telefono", personaNueva.Telefono);
                miComando.Parameters.AddWithValue("@Direccion", personaNueva.Direccion);
                miComando.Parameters.AddWithValue("@Foto", personaNueva.Foto);
                miComando.Parameters.AddWithValue("@FechaNacimiento", personaNueva.FechaNacimiento);
                miComando.Parameters.AddWithValue("@IDDepartamento", personaNueva.IDDepartamento);

                filasAfectadas = miComando.ExecuteNonQuery();

                miConexion.Open();

            }

            catch (SqlException exSql)
            {
                throw exSql;
            }

            //se devuelve la validez
            return filasAfectadas;
        }

        /// <summary>
        /// PRE: tiene que llegar un id de la persona a actualizar y los nuevos datos de esta
        /// Método que actualiza una persona
        /// </summary>
        /// <param name="idPersona"></param>
        /// <param name="persona"></param>
        /// <returns>El número de filas que han sido afectadas</returns>
        public int actualizarPersona(int idPersona, Persona persona)
        {
            //almacena las filas afectadas por la sentencia sql
            int filasAfectadas = -1;

            SqlConnection miConexion = new SqlConnection();

            SqlCommand miComando = new SqlCommand();

            miConexion.ConnectionString = Connection.getConnectionString();

            try
            {

                miConexion.Open();

                miComando.CommandText = "UPDATE Personas SET " +
                "ID = @ID, " +
                "Nombre = @Nombre, " +
                "Apellidos = @Apellidos, " +
                "Telefono = @Telefono, " +
                "Direccion = @Direccion, " +
                "Foto = @Foto, " +
                "FechaNacimiento = @FechaNacimiento, " +
                "IDDepartamento = @IDDepartamento " +
                "WHERE ID = @IDPersona";

                // Parámetros
                miComando.Parameters.AddWithValue("@IDPersona", idPersona);
                miComando.Parameters.AddWithValue("@ID", persona.ID);
                miComando.Parameters.AddWithValue("@Nombre", persona.Nombre);
                miComando.Parameters.AddWithValue("@Apellidos", persona.Apellidos);
                miComando.Parameters.AddWithValue("@Telefono", persona.Telefono);
                miComando.Parameters.AddWithValue("@Direccion", persona.Direccion);
                miComando.Parameters.AddWithValue("@Foto", persona.Foto);
                miComando.Parameters.AddWithValue("@FechaNacimiento", persona.FechaNacimiento);
                miComando.Parameters.AddWithValue("@IDDepartamento", persona.IDDepartamento);

                filasAfectadas = miComando.ExecuteNonQuery();

                miConexion.Open();

            }

            catch (SqlException exSql)
            {
                throw exSql;
            }

            //se devuelven las filas que han sido afectadas
            return filasAfectadas;
        }

        /// <summary>
        /// PRE: tiene que llegar el id de una persona
        /// Método para eliminar una persona en específico
        /// </summary>
        /// <param name="idPersona"></param>
        /// <returns>El número de filas que ha afectado</returns>
        public int eliminarPersona(int idPersona)
        {

            int numeroFilasAfectadas = 0;

            SqlConnection miConexion = new SqlConnection();

            SqlCommand miComando = new SqlCommand();

            miConexion.ConnectionString = ("server=localhost;database=nombreBBDD;uid=prueba;pwd=123;server=107-03\\SQLEXPRESS;database=PERSONAS;uid=prueba; pwd = 123; TrustServerCertificate = true;");

            miComando.Parameters.Add("@ID", System.Data.SqlDbType.Int).Value = idPersona;

            try

            {

                miConexion.Open();

                miComando.CommandText = "DELETE FROM Personas WHERE IDPersona=@id";

                miComando.Connection = miConexion;

                numeroFilasAfectadas = miComando.ExecuteNonQuery();

            }

            catch (Exception ex)

            {
                throw ex;
            }

            return numeroFilasAfectadas;

        }
    }
}
