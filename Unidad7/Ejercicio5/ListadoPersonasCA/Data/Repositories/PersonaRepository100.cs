using Domain.Entities;
using Domain.Repositories;

namespace Data.Repositories
{
    internal class PersonaRepository100 : IPersonaRepository
    {
        /// <summary>
        /// Método sin parámetros que se encarga de simular una llamada
        /// a una API o BBDD.
        /// </summary>
        /// <returns>Una lista con 100 personas</returns>
        public List<Persona> ListaPersonas100()
        {
            #region RETURN CON 100 PERSONAS
            return [
                new Persona(1, "Juan", "Pérez", 23),
                new Persona(2, "Ana", "García", 30),
                new Persona(3, "Luis", "Martínez", 25),
                new Persona(4, "Marta", "López", 28),
                new Persona(5, "Carlos", "Sánchez", 40),
                new Persona(6, "Lucía", "Fernández", 22),
                new Persona(7, "Diego", "Torres", 35),
                new Persona(8, "Sofía", "Ruiz", 27),
                new Persona(9, "Miguel", "Vargas", 31),
                new Persona(10, "Elena", "Navarro", 29),
                new Persona(11, "Pablo", "Morales", 33),
                new Persona(12, "Isabel", "Gómez", 26),
                new Persona(13, "Jorge", "Ramos", 37),
                new Persona(14, "Natalia", "Ortiz", 24),
                new Persona(15, "Rubén", "Gil", 41),
                new Persona(16, "Carmen", "Blanco", 45),
                new Persona(17, "Sergio", "Herrera", 38),
                new Persona(18, "Beatriz", "Molina", 32),
                new Persona(19, "Alberto", "Castro", 29),
                new Persona(20, "María", "Iglesias", 27),
                new Persona(21, "Adrián", "Santos", 34),
                new Persona(22, "Paula", "Medina", 21),
                new Persona(23, "Iván", "Cruz", 36),
                new Persona(24, "Laura", "Vega", 28),
                new Persona(25, "Fernando", "Díaz", 50),
                new Persona(26, "Noelia", "Serrano", 23),
                new Persona(27, "Óscar", "Cabrera", 39),
                new Persona(28, "Rocío", "Pineda", 31),
                new Persona(29, "Raúl", "León", 42),
                new Persona(30, "Miriam", "Cortés", 26),
                new Persona(31, "Andrés", "Suárez", 35),
                new Persona(32, "Verónica", "Márquez", 30),
                new Persona(33, "Enrique", "Valencia", 47),
                new Persona(34, "Alicia", "Fuentes", 24),
                new Persona(35, "Javier", "Santos", 33),
                new Persona(36, "Natalia", "Campos", 29),
                new Persona(37, "Manuel", "Navarro", 44),
                new Persona(38, "Olga", "Mendez", 27),
                new Persona(39, "Héctor", "Rivas", 32),
                new Persona(40, "Sonia", "Vidal", 36),
                new Persona(41, "Gonzalo", "Mora", 28),
                new Persona(42, "Irene", "Montes", 25),
                new Persona(43, "Marco", "Bravo", 31),
                new Persona(44, "Ariadna", "Cano", 22),
                new Persona(45, "Diego", "Reyes", 37),
                new Persona(46, "Lidia", "Crespo", 40),
                new Persona(47, "Víctor", "Herranz", 34),
                new Persona(48, "Sara", "Beltrán", 26),
                new Persona(49, "Pablo", "Herrero", 29),
                new Persona(50, "Elisa", "Solano", 38),
                new Persona(51, "Tomás", "Marín", 41),
                new Persona(52, "Nuria", "Padilla", 27),
                new Persona(53, "Santiago", "Vega", 30),
                new Persona(54, "Clara", "Lara", 23),
                new Persona(55, "Bruno", "Domínguez", 35),
                new Persona(56, "Mónica", "Roldán", 33),
                new Persona(57, "Samuel", "Peña", 28),
                new Persona(58, "Iris", "Cervantes", 24),
                new Persona(59, "Óliver", "Marcos", 32),
                new Persona(60, "Rosa", "Esteban", 39),
                new Persona(61, "Nicolás", "Soler", 36),
                new Persona(62, "Celia", "Arias", 25),
                new Persona(63, "Raúl", "Prieto", 43),
                new Persona(64, "Marta", "Rico", 29),
                new Persona(65, "Fco. Javier", "Luna", 46),
                new Persona(66, "Silvia", "Bravo", 31),
                new Persona(67, "Iván", "Benítez", 27),
                new Persona(68, "Lorena", "Cordero", 34),
                new Persona(69, "Gustavo", "Oliva", 38),
                new Persona(70, "Ángela", "Tovar", 26),
                new Persona(71, "Ruben", "Garrido", 30),
                new Persona(72, "Inés", "Soto", 22),
                new Persona(73, "Leandro", "Marchal", 37),
                new Persona(74, "Paula", "Bueno", 28),
                new Persona(75, "César", "Palacios", 45),
                new Persona(76, "Blanca", "Ramos", 33),
                new Persona(77, "Martín", "Salas", 29),
                new Persona(78, "Aina", "Riera", 24),
                new Persona(79, "Hugo", "Barrios", 31),
                new Persona(80, "Mireia", "Bosch", 27),
                new Persona(81, "Alex", "Córdoba", 35),
                new Persona(82, "Ariadna", "Varela", 26),
                new Persona(83, "Carmelo", "López", 40),
                new Persona(84, "Yolanda", "Sanz", 42),
                new Persona(85, "Joel", "Paz", 23),
                new Persona(86, "Laura", "Herrera", 30),
                new Persona(87, "Fermín", "Cifuentes", 48),
                new Persona(88, "Noa", "Merino", 21),
                new Persona(89, "Brais", "Núñez", 34),
                new Persona(90, "Arancha", "Gutiérrez", 29),
                new Persona(91, "Eladio", "Molina", 50),
                new Persona(92, "Sabela", "Reina", 28),
                new Persona(93, "Raúl", "Córdoba", 36),
                new Persona(94, "Monica", "Soler", 32),
                new Persona(95, "Adolfo", "Ramos", 41),
                new Persona(96, "Aroa", "López", 25),
                new Persona(97, "Fabián", "Vega", 27),
                new Persona(98, "Ruth", "Mora", 30),
                new Persona(99, "Iván", "Sánchez", 33),
                new Persona(100, "Marta", "Gil", 26)
                ];
            #endregion
        }

        /// <summary>
        /// Método que sirve para devolver un listado de personas
        /// </summary>
        /// <returns></returns>
        public List<Persona> getListaPersonas()
        {
            return ListaPersonas100();
        }
    }
}