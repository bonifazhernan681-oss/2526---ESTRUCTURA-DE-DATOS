using System;

namespace GestionEstudiantes
{
    /// <summary>
    /// Clase Estudiante que representa a un estudiante con sus datos básicos
    /// y tres números de teléfono almacenados en un array
    /// </summary>
    public class Estudiante
    {
        // ATRIBUTOS DE LA CLASE
        private int id;                 // ID del estudiante
        private string nombres;         // Nombres del estudiante
        private string apellidos;       // Apellidos del estudiante
        private string direccion;       // Dirección del estudiante
        private string[] telefonos;     // Array para almacenar TRES números de teléfono

        // PROPIEDADES (getters y setters)
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Nombres
        {
            get { return nombres; }
            set { nombres = value; }
        }

        public string Apellidos
        {
            get { return apellidos; }
            set { apellidos = value; }
        }

        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public string[] Telefonos
        {
            get { return telefonos; }
            set { telefonos = value; }
        }

        /// <summary>
        /// Constructor de la clase Estudiante
        /// </summary>
        /// <param name="id">ID del estudiante</param>
        /// <param name="nombres">Nombres del estudiante</param>
        /// <param name="apellidos">Apellidos del estudiante</param>
        /// <param name="direccion">Dirección del estudiante</param>
        public Estudiante(int id, string nombres, string apellidos, string direccion)
        {
            this.id = id;
            this.nombres = nombres;
            this.apellidos = apellidos;
            this.direccion = direccion;
            this.telefonos = new string[3]; // Inicializa el array con capacidad para 3 teléfonos
        }

        /// <summary>
        /// Método para registrar los tres números de teléfono
        /// </summary>
        /// <param name="tel1">Primer número de teléfono</param>
        /// <param name="tel2">Segundo número de teléfono</param>
        /// <param name="tel3">Tercer número de teléfono</param>
        public void RegistrarTelefonos(string tel1, string tel2, string tel3)
        {
            telefonos[0] = tel1;  // Asigna el primer teléfono
            telefonos[1] = tel2;  // Asigna el segundo teléfono
            telefonos[2] = tel3;  // Asigna el tercer teléfono
        }

        /// <summary>
        /// Método para mostrar toda la información del estudiante
        /// </summary>
        public void MostrarInformacion()
        {
            Console.WriteLine($"ID: {id}");
            Console.WriteLine($"Nombres: {nombres}");
            Console.WriteLine($"Apellidos: {apellidos}");
            Console.WriteLine($"Dirección: {direccion}");
            Console.WriteLine("Teléfonos:");
            Console.WriteLine($"  1. {telefonos[0]}");
            Console.WriteLine($"  2. {telefonos[1]}");
            Console.WriteLine($"  3. {telefonos[2]}");
            Console.WriteLine(new string('-', 40));
        }
    }

    /// <summary>
    /// Clase principal del programa
    /// </summary>
    class ProgramaPrincipal
    {
        /// <summary>
        /// Método principal que inicia la ejecución del programa
        /// </summary>
        static void Main(string[] args)
        {
            // Crear array para almacenar estudiantes
            Estudiante[] estudiantes = new Estudiante[2];

            // Crear y configurar primer estudiante
            estudiantes[0] = new Estudiante(2025001, "Hernan Dario", "Bonifaz Naranjo", "CDLA. La Sopeña, Guayaquil");
            estudiantes[0].RegistrarTelefonos("0983421964", "0223455708", "0991234567");

            // Crear y configurar segundo estudiante
            estudiantes[1] = new Estudiante(2025002, "Jorgue Luis", "Guevara Bonifaz", "Av. Leopoldo Freire y La paz, Riobamba");
            estudiantes[1].RegistrarTelefonos("0987654321", "0986756453", "0985554444");

            // Mostrar título y información de los estudiantes
            Console.WriteLine("INFORMACIÓN DE LOS ESTUDIANTES");
            Console.WriteLine(new string('=', 40));
            
            for (int i = 0; i < estudiantes.Length; i++)
            {
                Console.WriteLine($"\nEstudiante {i + 1}:");
                estudiantes[i].MostrarInformacion();
            }

            Console.WriteLine("\nPresione cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}