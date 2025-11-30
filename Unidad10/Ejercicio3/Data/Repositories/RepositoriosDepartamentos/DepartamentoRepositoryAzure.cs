using Data.DataBase;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.RepositoriosDepartamentos
{
    public class DepartamentoRepositoryAzure : IDepartamentoRepository
    {
        /// <summary>
        /// Método que devuelve una lista de todos los departamentos de la BBDD
        /// </summary>
        /// <returns></returns>
        public List<Departamento> getListaDepartamentos() {
            SqlConnection miConexion = new SqlConnection();

            List<Departamento> listadoDepartamentos = new List<Departamento>();

            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector;

            Departamento oDepartamento;

            miConexion.ConnectionString = Connection.getConnectionString();

            try
            {

                miConexion.Open();

                //Creamos el comando (Creamos el comando, le pasamos la sentencia y la conexion, y lo ejecutamos)

                miComando.CommandText = "SELECT * FROM Departamentos";

                miComando.Connection = miConexion;

                miLector = miComando.ExecuteReader();
                //Si hay lineas en el lector

                if (miLector.HasRows)
                {

                    while (miLector.Read())

                    {
                        oDepartamento = new Departamento();

                        oDepartamento.ID = (int)miLector["ID"];

                        oDepartamento.Nombre = (string)miLector["Nombre"];

                        //Si sospechamos que el campo puede ser Null en la BBDD

                        listadoDepartamentos.Add(oDepartamento);

                    }

                }

                miLector.Close();

                miConexion.Close();

            }

            catch (SqlException exSql)
            {

                throw exSql;

            }

            return listadoDepartamentos;
        }

        /// <summary>
        /// Método que devuelve un departamento en específico
        /// </summary>
        /// <param name="idDepartamento"></param>
        /// <returns></returns>
        public Departamento getDepartamentoPorId(int idDepartamento) {
            //Departamento que se devuelve en el return
            Departamento? departamentoGetByID = null;

            //variable que almacena todo el listado de las Departamentos
            List<Departamento> listaDeDepartamentos = getListaDepartamentos();

            //recorro la lista de las Departamentos
            foreach (Departamento departamento in listaDeDepartamentos)
            {
                //comprueba si el id de la Departamento actual es igual al que entra por parámetros
                if (departamento.ID == idDepartamento)
                {
                    //se iguala la variable a la Departamento actual
                    departamentoGetByID = departamento;
                }
            }
            //deuelvo la Departamento con el mismo id
            return departamentoGetByID;
        }

        /// <summary>
        /// Método que crea un nuevo departamento en la BBDD
        /// </summary>
        /// <param name="departamentoNuevo"></param>
        /// <returns></returns>
        public int crearDepartamento(Departamento departamentoNuevo) {
            //almacena las filas afectadas por la sentencia sql
            int filasAfectadas = -1;

            SqlConnection miConexion = new SqlConnection();

            SqlCommand miComando = new SqlCommand();

            miConexion.ConnectionString = Connection.getConnectionString();

            try
            {

                miConexion.Open();

                miComando.CommandText = "INSERT INTO Departamentos (ID, Nombre) VALUES (@ID, @Nombre)";

                miComando.Parameters.AddWithValue("@ID", departamentoNuevo.ID);
                miComando.Parameters.AddWithValue("@Nombre", departamentoNuevo.Nombre);

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
        /// Método que actualiza un departamento en específico de la BBBDD
        /// </summary>
        /// <param name="idDepartamento"></param>
        /// <param name="departamento"></param>
        /// <returns></returns>
        public int actualizarDepartamento(int idDepartamento, Departamento departamento) {
            //almacena las filas afectadas por la sentencia sql
            int filasAfectadas = -1;

            SqlConnection miConexion = new SqlConnection();

            SqlCommand miComando = new SqlCommand();

            miConexion.ConnectionString = Connection.getConnectionString();

            try
            {

                miConexion.Open();

                miComando.CommandText = "UPDATE Departamentos SET " +
                "ID = @ID, " +
                "Nombre = @Nombre, " +
                "WHERE ID = @IDDepartamento";

                // Parámetros
                miComando.Parameters.AddWithValue("@IDDepartamento", idDepartamento);
                miComando.Parameters.AddWithValue("@ID", departamento.ID);
                miComando.Parameters.AddWithValue("@Nombre", departamento.Nombre);

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
        /// Método que elimina un departamento
        /// </summary>
        /// <param name="idDepartamento"></param>
        /// <returns></returns>
        public int eliminarDepartamento(int idDepartamento) {
            int numeroFilasAfectadas = 0;

            SqlConnection miConexion = new SqlConnection();

            SqlCommand miComando = new SqlCommand();

            miConexion.ConnectionString = ("server=localhost;database=nombreBBDD;uid=prueba;pwd=123;server=107-03\\SQLEXPRESS;database=PERSONAS;uid=prueba; pwd = 123; TrustServerCertificate = true;");

            miComando.Parameters.Add("@ID", System.Data.SqlDbType.Int).Value = idDepartamento;

            try
            {

                miConexion.Open();

                miComando.CommandText = "DELETE FROM Departamentos WHERE IDDepartamento=@id";

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
