using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Departamentos")]
    public class Departamento
    {
        #region ATRIBUTOS
        private int _id;
        private string _nombre;
        #endregion

        #region CONSTRUCTORES
        /// <summary>
        /// Constructor con todos los atributos de la clase
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        public Departamento(int id, string nombre)
        {
            _id = id;
            _nombre = nombre;
        }
        /// <summary>
        /// Constructor vacío
        /// </summary>
        public Departamento()
        {
            _id = 0;
            _nombre = "";
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
        #endregion
    }
}