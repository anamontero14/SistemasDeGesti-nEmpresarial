namespace Ejercicio1.Models.Entities
{
    public class CLSDepartamento
    {

        //atributo privado que hace referencia al id del departamento
        private int _idDepartamento;
        //atributo privado que hace referencia al nombre deldepartamento
        private string _nombreDepartamento = "";

        //constructor
        public CLSDepartamento(int idDepartamento, string nombreDepartamento) { 
            _idDepartamento = idDepartamento;
            _nombreDepartamento = nombreDepartamento;
        }

        #region GETTERS Y SETTERS

        public int IdDepartamento
        {
            get
            {
                return _idDepartamento;
            }
        }

        public String NombreDepartamento {
            get { 
                return _nombreDepartamento;
            }

            set { 
                _nombreDepartamento = value;
            }
        }

        #endregion

    }
}
