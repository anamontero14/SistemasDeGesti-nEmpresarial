using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Personas")]
    public class Persona
    {
        #region ATRIBUTOS PRIVADOS
        private int _id;
        private string _nombre;
        private string _apellidos;
        private int _edad;
        private DateTime _fechaNacimiento;
        private string _direccion;
        private string _telefono;
        private int _idDepartamento;
        private string _foto;
        #endregion

        #region CONSTRUCTOR
        /// <summary>
        /// Constructor de la clase persona con todos sus atributos
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellidos"></param>
        /// <param name="edad"></param>
        public Persona(int id, string nombre, string apellidos, int edad, DateTime fechaNacimiento, string direccion, string telefono, int idDepartamento, string foto)
        {
            _id = id;
            _nombre = nombre;
            _apellidos = apellidos;
            _edad = edad;
            _fechaNacimiento = fechaNacimiento;
            _direccion = direccion;
            _telefono = telefono;
            _idDepartamento = idDepartamento;
            _foto = foto;
        }
        /// <summary>
        /// Constructor de la clase persona vacío
        /// </summary>
        public Persona()
        {
            _id = 0;
            _nombre = "";
            _apellidos = "";
            _edad = 0;
            _direccion = "";
            _telefono = "";
            _idDepartamento = 0;
            _foto = "";
        }
        #endregion

        #region GETTERS Y SETTERS
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int ID
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        [Required]
        [StringLength(30)]
        [Column("Nombre")]
        public string Nombre
        {
            get
            {
                return _nombre;
            }
            set
            {
                _nombre = value;
            }
        }

        [Required]
        [StringLength(60)]
        [Column("Apellidos")]
        public string Apellidos
        {
            get
            {
                return _apellidos;
            }
            set
            {
                _apellidos = value;
            }
        }

        [NotMapped]
        public int Edad
        {
            get
            {
                return _edad;
            }
            set
            {
                _edad = value;
            }
        }

        [Column("FechaNacimiento")]
        public DateTime FechaNacimiento
        {
            get
            {
                return _fechaNacimiento;
            }
            set
            {
                _fechaNacimiento = value;
            }
        }

        [StringLength(60)]
        [Column("Direccion")]
        public string Direccion
        {
            get
            {
                return _direccion;
            }
            set
            {
                _direccion = value;
            }
        }

        [StringLength(15)]
        [Column("Telefono")]
        public string Telefono
        {
            get
            {
                return _telefono;
            }
            set
            {
                _telefono = value;
            }
        }

        [StringLength(255)]
        [Column("Foto")]
        public string Foto
        {
            get
            {
                return _foto;
            }
            set
            {
                _foto = value;
            }
        }

        [Required]
        [Column("IDDepartamento")]
        [ForeignKey("Departamento")]
        public int IDDepartamento
        {
            get
            {
                return _idDepartamento;
            }
            set
            {
                _idDepartamento = value;
            }
        }
        #endregion
    }
}