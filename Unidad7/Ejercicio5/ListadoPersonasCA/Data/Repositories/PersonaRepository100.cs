using Domain.Entities;
using Domain.Repositories;

namespace Data.Repositories
{
    class PersonaRepository100 : IPersonaRepository
    {
        /// <summary>
        /// Método sin parámetros que se encarga de simular una llamada
        /// a una API o BBDD.
        /// </summary>
        /// <returns>Una lista con 100 personas</returns>
        private List<Persona> ListaPersonas100()
        {
            #region RETURN CON 100 PERSONAS
            return [
                new Persona(1, "Juan", "Pérez", 23, new DateTime(2002, 5, 10), "Calle 1", "600000001"),
                new Persona(2, "Ana", "García", 30, new DateTime(1995, 3, 8), "Calle 2", "600000002"),
                new Persona(3, "Luis", "Martínez", 25, new DateTime(2000, 7, 12), "Calle 3", "600000003"),
                new Persona(4, "Marta", "López", 28, new DateTime(1997, 9, 4), "Calle 4", "600000004"),
                new Persona(5, "Carlos", "Sánchez", 40, new DateTime(1985, 1, 20), "Calle 5", "600000005"),
                new Persona(6, "Lucía", "Fernández", 22, new DateTime(2003, 11, 2), "Calle 6", "600000006"),
                new Persona(7, "Diego", "Torres", 35, new DateTime(1990, 4, 18), "Calle 7", "600000007"),
                new Persona(8, "Sofía", "Ruiz", 27, new DateTime(1998, 6, 25), "Calle 8", "600000008"),
                new Persona(9, "Miguel", "Vargas", 31, new DateTime(1994, 2, 10), "Calle 9", "600000009"),
                new Persona(10, "Elena", "Navarro", 29, new DateTime(1996, 12, 3), "Calle 10", "600000010"),

                new Persona(11, "Pablo", "Morales", 33, new DateTime(1992, 5, 10), "Calle 11", "600000011"),
                new Persona(12, "Isabel", "Gómez", 26, new DateTime(1999, 3, 8), "Calle 12", "600000012"),
                new Persona(13, "Jorge", "Ramos", 37, new DateTime(1988, 7, 12), "Calle 13", "600000013"),
                new Persona(14, "Natalia", "Ortiz", 24, new DateTime(2001, 9, 4), "Calle 14", "600000014"),
                new Persona(15, "Rubén", "Gil", 41, new DateTime(1984, 1, 20), "Calle 15", "600000015"),
                new Persona(16, "Carmen", "Blanco", 45, new DateTime(1980, 11, 2), "Calle 16", "600000016"),
                new Persona(17, "Sergio", "Herrera", 38, new DateTime(1987, 4, 18), "Calle 17", "600000017"),
                new Persona(18, "Beatriz", "Molina", 32, new DateTime(1993, 6, 25), "Calle 18", "600000018"),
                new Persona(19, "Alberto", "Castro", 29, new DateTime(1996, 2, 10), "Calle 19", "600000019"),
                new Persona(20, "María", "Iglesias", 27, new DateTime(1998, 12, 3), "Calle 20", "600000020"),

                new Persona(21, "Adrián", "Santos", 34, new DateTime(1991, 5, 10), "Calle 21", "600000021"),
                new Persona(22, "Paula", "Medina", 21, new DateTime(2004, 3, 8), "Calle 22", "600000022"),
                new Persona(23, "Iván", "Cruz", 36, new DateTime(1989, 7, 12), "Calle 23", "600000023"),
                new Persona(24, "Laura", "Vega", 28, new DateTime(1997, 9, 4), "Calle 24", "600000024"),
                new Persona(25, "Fernando", "Díaz", 50, new DateTime(1975, 1, 20), "Calle 25", "600000025"),
                new Persona(26, "Noelia", "Serrano", 23, new DateTime(2002, 11, 2), "Calle 26", "600000026"),
                new Persona(27, "Óscar", "Cabrera", 39, new DateTime(1986, 4, 18), "Calle 27", "600000027"),
                new Persona(28, "Rocío", "Pineda", 31, new DateTime(1994, 6, 25), "Calle 28", "600000028"),
                new Persona(29, "Raúl", "León", 42, new DateTime(1983, 2, 10), "Calle 29", "600000029"),
                new Persona(30, "Miriam", "Cortés", 26, new DateTime(1999, 12, 3), "Calle 30", "600000030"),

                new Persona(31, "Andrés", "Suárez", 35, new DateTime(1990, 5, 10), "Calle 31", "600000031"),
                new Persona(32, "Verónica", "Márquez", 30, new DateTime(1995, 3, 8), "Calle 32", "600000032"),
                new Persona(33, "Enrique", "Valencia", 47, new DateTime(1978, 7, 12), "Calle 33", "600000033"),
                new Persona(34, "Alicia", "Fuentes", 24, new DateTime(2001, 9, 4), "Calle 34", "600000034"),
                new Persona(35, "Javier", "Santos", 33, new DateTime(1992, 1, 20), "Calle 35", "600000035"),
                new Persona(36, "Natalia", "Campos", 29, new DateTime(1996, 11, 2), "Calle 36", "600000036"),
                new Persona(37, "Manuel", "Navarro", 44, new DateTime(1981, 4, 18), "Calle 37", "600000037"),
                new Persona(38, "Olga", "Mendez", 27, new DateTime(1998, 6, 25), "Calle 38", "600000038"),
                new Persona(39, "Héctor", "Rivas", 32, new DateTime(1993, 2, 10), "Calle 39", "600000039"),
                new Persona(40, "Sonia", "Vidal", 36, new DateTime(1989, 12, 3), "Calle 40", "600000040"),

                new Persona(41, "Gonzalo", "Mora", 28, new DateTime(1997, 5, 10), "Calle 41", "600000041"),
                new Persona(42, "Irene", "Montes", 25, new DateTime(2000, 3, 8), "Calle 42", "600000042"),
                new Persona(43, "Marco", "Bravo", 31, new DateTime(1994, 7, 12), "Calle 43", "600000043"),
                new Persona(44, "Ariadna", "Cano", 22, new DateTime(2003, 9, 4), "Calle 44", "600000044"),
                new Persona(45, "Diego", "Reyes", 37, new DateTime(1988, 1, 20), "Calle 45", "600000045"),
                new Persona(46, "Lidia", "Crespo", 40, new DateTime(1985, 11, 2), "Calle 46", "600000046"),
                new Persona(47, "Víctor", "Herranz", 34, new DateTime(1991, 4, 18), "Calle 47", "600000047"),
                new Persona(48, "Sara", "Beltrán", 26, new DateTime(1999, 6, 25), "Calle 48", "600000048"),
                new Persona(49, "Pablo", "Herrero", 29, new DateTime(1996, 2, 10), "Calle 49", "600000049"),
                new Persona(50, "Elisa", "Solano", 38, new DateTime(1987, 12, 3), "Calle 50", "600000050"),

                new Persona(51, "Tomás", "Marín", 41, new DateTime(1984, 5, 10), "Calle 51", "600000051"),
                new Persona(52, "Nuria", "Padilla", 27, new DateTime(1998, 3, 8), "Calle 52", "600000052"),
                new Persona(53, "Santiago", "Vega", 30, new DateTime(1995, 7, 12), "Calle 53", "600000053"),
                new Persona(54, "Clara", "Lara", 23, new DateTime(2002, 9, 4), "Calle 54", "600000054"),
                new Persona(55, "Bruno", "Domínguez", 35, new DateTime(1990, 1, 20), "Calle 55", "600000055"),
                new Persona(56, "Mónica", "Roldán", 33, new DateTime(1992, 11, 2), "Calle 56", "600000056"),
                new Persona(57, "Samuel", "Peña", 28, new DateTime(1997, 4, 18), "Calle 57", "600000057"),
                new Persona(58, "Iris", "Cervantes", 24, new DateTime(2001, 6, 25), "Calle 58", "600000058"),
                new Persona(59, "Óliver", "Marcos", 32, new DateTime(1993, 2, 10), "Calle 59", "600000059"),
                new Persona(60, "Rosa", "Esteban", 39, new DateTime(1986, 12, 3), "Calle 60", "600000060"),

                new Persona(61, "Nicolás", "Soler", 36, new DateTime(1989, 5, 10), "Calle 61", "600000061"),
                new Persona(62, "Celia", "Arias", 25, new DateTime(2000, 3, 8), "Calle 62", "600000062"),
                new Persona(63, "Raúl", "Prieto", 43, new DateTime(1982, 7, 12), "Calle 63", "600000063"),
                new Persona(64, "Marta", "Rico", 29, new DateTime(1996, 9, 4), "Calle 64", "600000064"),
                new Persona(65, "Fco. Javier", "Luna", 46, new DateTime(1979, 1, 20), "Calle 65", "600000065"),
                new Persona(66, "Silvia", "Bravo", 31, new DateTime(1994, 11, 2), "Calle 66", "600000066"),
                new Persona(67, "Iván", "Benítez", 27, new DateTime(1998, 4, 18), "Calle 67", "600000067"),
                new Persona(68, "Lorena", "Cordero", 34, new DateTime(1991, 6, 25), "Calle 68", "600000068"),
                new Persona(69, "Gustavo", "Oliva", 38, new DateTime(1987, 2, 10), "Calle 69", "600000069"),
                new Persona(70, "Ángela", "Tovar", 26, new DateTime(1999, 12, 3), "Calle 70", "600000070"),

                new Persona(71, "Ruben", "Garrido", 30, new DateTime(1995, 5, 10), "Calle 71", "600000071"),
                new Persona(72, "Inés", "Soto", 22, new DateTime(2003, 3, 8), "Calle 72", "600000072"),
                new Persona(73, "Leandro", "Marchal", 37, new DateTime(1988, 7, 12), "Calle 73", "600000073"),
                new Persona(74, "Paula", "Bueno", 28, new DateTime(1997, 9, 4), "Calle 74", "600000074"),
                new Persona(75, "César", "Palacios", 45, new DateTime(1980, 1, 20), "Calle 75", "600000075"),
                new Persona(76, "Blanca", "Ramos", 33, new DateTime(1992, 11, 2), "Calle 76", "600000076"),
                new Persona(77, "Martín", "Salas", 29, new DateTime(1996, 4, 18), "Calle 77", "600000077"),
                new Persona(78, "Aina", "Riera", 24, new DateTime(2001, 6, 25), "Calle 78", "600000078"),
                new Persona(79, "Hugo", "Barrios", 31, new DateTime(1994, 2, 10), "Calle 79", "600000079"),
                new Persona(80, "Mireia", "Bosch", 27, new DateTime(1998, 12, 3), "Calle 80", "600000080"),

                new Persona(81, "Alex", "Córdoba", 35, new DateTime(1990, 5, 10), "Calle 81", "600000081"),
                new Persona(82, "Ariadna", "Varela", 26, new DateTime(1999, 3, 8), "Calle 82", "600000082"),
                new Persona(83, "Carmelo", "López", 40, new DateTime(1985, 7, 12), "Calle 83", "600000083"),
                new Persona(84, "Yolanda", "Sanz", 42, new DateTime(1983, 9, 4), "Calle 84", "600000084"),
                new Persona(85, "Joel", "Paz", 23, new DateTime(2002, 1, 20), "Calle 85", "600000085"),
                new Persona(86, "Laura", "Herrera", 30, new DateTime(1995, 11, 2), "Calle 86", "600000086"),
                new Persona(87, "Fermín", "Cifuentes", 48, new DateTime(1977, 4, 18), "Calle 87", "600000087"),
                new Persona(88, "Noa", "Merino", 21, new DateTime(2004, 6, 25), "Calle 88", "600000088"),
                new Persona(89, "Brais", "Núñez", 34, new DateTime(1991, 2, 10), "Calle 89", "600000089"),
                new Persona(90, "Arancha", "Gutiérrez", 29, new DateTime(1996, 12, 3), "Calle 90", "600000090"),

                new Persona(91, "Eladio", "Molina", 50, new DateTime(1975, 5, 10), "Calle 91", "600000091"),
                new Persona(92, "Sabela", "Reina", 28, new DateTime(1997, 3, 8), "Calle 92", "600000092"),
                new Persona(93, "Raúl", "Córdoba", 36, new DateTime(1989, 7, 12), "Calle 93", "600000093"),
                new Persona(94, "Monica", "Soler", 32, new DateTime(1993, 9, 4), "Calle 94", "600000094"),
                new Persona(95, "Adolfo", "Ramos", 41, new DateTime(1984, 1, 20), "Calle 95", "600000095"),
                new Persona(96, "Aroa", "López", 25, new DateTime(2000, 11, 2), "Calle 96", "600000096"),
                new Persona(97, "Fabián", "Vega", 27, new DateTime(1998, 4, 18), "Calle 97", "600000097"),
                new Persona(98, "Ruth", "Mora", 30, new DateTime(1995, 6, 25), "Calle 98", "600000098"),
                new Persona(99, "Iván", "Sánchez", 33, new DateTime(1992, 2, 10), "Calle 99", "600000099"),
                new Persona(100, "Marta", "Gil", 26, new DateTime(1999, 12, 3), "Calle 100", "600000100")
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