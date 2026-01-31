using System;
using System.Collections.Generic;
using System.Linq;

namespace ParqueDiversiones
{
    /// <summary>
    /// Clase que representa a una persona en la cola
    /// </summary>
    public class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime HoraLlegada { get; set; }

        public Persona(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
            HoraLlegada = DateTime.Now;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Nombre: {Nombre}, Llegada: {HoraLlegada:HH:mm:ss}";
        }
    }

    /// <summary>
    /// Clase que representa un asiento en la atracción
    /// </summary>
    public class Asiento
    {
        public int Numero { get; set; }
        public bool Ocupado { get; set; }
        public Persona PersonaAsignada { get; set; }

        public Asiento(int numero)
        {
            Numero = numero;
            Ocupado = false;
            PersonaAsignada = null;
        }

        public void AsignarPersona(Persona persona)
        {
            PersonaAsignada = persona;
            Ocupado = true;
        }

        public void Liberar()
        {
            PersonaAsignada = null;
            Ocupado = false;
        }
    }

    /// <summary>
    /// Clase principal que gestiona la cola y asientos del parque
    /// Implementa una Cola (Queue) para gestionar el orden de llegada
    /// </summary>
    public class GestorAtraccion
    {
        private Queue<Persona> colaEspera;
        private List<Asiento> asientos;
        private int capacidadMaxima;
        private int contadorPersonas;

        public GestorAtraccion(int capacidad = 30)
        {
            capacidadMaxima = capacidad;
            colaEspera = new Queue<Persona>();
            asientos = new List<Asiento>();
            contadorPersonas = 0;

            // Inicializar los 30 asientos
            for (int i = 1; i <= capacidadMaxima; i++)
            {
                asientos.Add(new Asiento(i));
            }
        }

        /// <summary>
        /// Agrega una persona a la cola de espera
        /// </summary>
        public void AgregarPersonaCola(string nombre)
        {
            contadorPersonas++;
            Persona nuevaPersona = new Persona(contadorPersonas, nombre);
            colaEspera.Enqueue(nuevaPersona);
            Console.WriteLine($"\n✓ {nombre} agregado a la cola (ID: {contadorPersonas})");
            Console.WriteLine($"  Personas en cola: {colaEspera.Count}");
        }

        /// <summary>
        /// Asigna asientos a las personas en la cola siguiendo el orden FIFO
        /// </summary>
        public void AsignarAsientos()
        {
            if (colaEspera.Count == 0)
            {
                Console.WriteLine("\n⚠ No hay personas en la cola de espera.");
                return;
            }

            int asientosDisponibles = asientos.Count(a => !a.Ocupado);
            
            if (asientosDisponibles == 0)
            {
                Console.WriteLine("\n⚠ Todos los asientos están ocupados. Espere a que termine la atracción.");
                return;
            }

            Console.WriteLine($"\n--- PROCESO DE ASIGNACIÓN ---");
            Console.WriteLine($"Asientos disponibles: {asientosDisponibles}");
            Console.WriteLine($"Personas en cola: {colaEspera.Count}\n");

            int asignados = 0;
            while (colaEspera.Count > 0 && asientosDisponibles > 0)
            {
                Persona persona = colaEspera.Dequeue();
                Asiento asientoLibre = asientos.First(a => !a.Ocupado);
                
                asientoLibre.AsignarPersona(persona);
                asignados++;
                asientosDisponibles--;

                Console.WriteLine($"✓ {persona.Nombre} asignado al Asiento #{asientoLibre.Numero}");
            }

            Console.WriteLine($"\n✓ Total asignados: {asignados} personas");
            
            if (asientos.All(a => a.Ocupado))
            {
                Console.WriteLine("🎢 ¡TODOS LOS ASIENTOS VENDIDOS! La atracción está llena.");
            }
        }

        /// <summary>
        /// Libera todos los asientos cuando termina la atracción
        /// </summary>
        public void TerminarAtraccion()
        {
            int ocupados = asientos.Count(a => a.Ocupado);
            
            if (ocupados == 0)
            {
                Console.WriteLine("\n⚠ No hay personas en la atracción.");
                return;
            }

            Console.WriteLine("\n--- FINALIZANDO ATRACCIÓN ---");
            Console.WriteLine($"Liberando {ocupados} asientos...\n");

            foreach (var asiento in asientos.Where(a => a.Ocupado))
            {
                Console.WriteLine($"✓ {asiento.PersonaAsignada.Nombre} bajó del Asiento #{asiento.Numero}");
                asiento.Liberar();
            }

            Console.WriteLine("\n✓ Atracción finalizada. Todos los asientos liberados.");
        }

        /// <summary>
        /// Muestra el estado actual de todos los asientos
        /// </summary>
        public void MostrarEstadoAsientos()
        {
            Console.WriteLine("\n╔════════════════════════════════════════════════════════╗");
            Console.WriteLine("║          ESTADO DE ASIENTOS DE LA ATRACCIÓN            ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════╝");

            int ocupados = 0;
            int disponibles = 0;

            for (int i = 0; i < asientos.Count; i++)
            {
                if (i % 5 == 0)
                    Console.WriteLine();

                var asiento = asientos[i];
                string estado = asiento.Ocupado 
                    ? $"[{asiento.Numero:D2}:OCUPADO]" 
                    : $"[{asiento.Numero:D2}:LIBRE  ]";

                Console.Write(estado + " ");

                if (asiento.Ocupado)
                    ocupados++;
                else
                    disponibles++;
            }

            Console.WriteLine("\n");
            Console.WriteLine($"📊 Resumen: {ocupados} ocupados | {disponibles} disponibles");
        }

        /// <summary>
        /// Muestra las personas en la cola de espera
        /// </summary>
        public void MostrarColaEspera()
        {
            Console.WriteLine("\n╔════════════════════════════════════════════════════════╗");
            Console.WriteLine("║              PERSONAS EN COLA DE ESPERA                ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════╝");

            if (colaEspera.Count == 0)
            {
                Console.WriteLine("\n  No hay personas en la cola de espera.");
            }
            else
            {
                Console.WriteLine($"\n  Total en cola: {colaEspera.Count} personas\n");
                int posicion = 1;
                foreach (var persona in colaEspera)
                {
                    Console.WriteLine($"  {posicion}. {persona}");
                    posicion++;
                }
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Muestra detalles de los asientos ocupados
        /// </summary>
        public void MostrarAsientosOcupados()
        {
            Console.WriteLine("\n╔════════════════════════════════════════════════════════╗");
            Console.WriteLine("║              ASIENTOS ACTUALMENTE OCUPADOS             ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════╝");

            var ocupados = asientos.Where(a => a.Ocupado).ToList();

            if (ocupados.Count == 0)
            {
                Console.WriteLine("\n  No hay asientos ocupados.");
            }
            else
            {
                Console.WriteLine($"\n  Total ocupados: {ocupados.Count}/{capacidadMaxima} asientos\n");
                foreach (var asiento in ocupados)
                {
                    Console.WriteLine($"  Asiento #{asiento.Numero:D2} -> {asiento.PersonaAsignada.Nombre} (ID: {asiento.PersonaAsignada.Id})");
                }
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Obtiene estadísticas del sistema
        /// </summary>
        public void MostrarEstadisticas()
        {
            Console.WriteLine("\n╔════════════════════════════════════════════════════════╗");
            Console.WriteLine("║              ESTADÍSTICAS DEL SISTEMA                  ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════╝");

            int ocupados = asientos.Count(a => a.Ocupado);
            int disponibles = capacidadMaxima - ocupados;
            double porcentajeOcupacion = (ocupados * 100.0) / capacidadMaxima;

            Console.WriteLine($"\n  📊 Capacidad total: {capacidadMaxima} asientos");
            Console.WriteLine($"  ✅ Asientos ocupados: {ocupados}");
            Console.WriteLine($"  🆓 Asientos disponibles: {disponibles}");
            Console.WriteLine($"  📈 Porcentaje de ocupación: {porcentajeOcupacion:F2}%");
            Console.WriteLine($"  👥 Personas en cola: {colaEspera.Count}");
            Console.WriteLine($"  🎫 Total de personas atendidas: {contadorPersonas}");
            Console.WriteLine();
        }
    }

    /// <summary>
    /// Clase principal del programa
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            GestorAtraccion gestor = new GestorAtraccion(30);
            bool continuar = true;

            Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
            Console.WriteLine("║    SISTEMA DE GESTIÓN DE ASIENTOS - PARQUE DIVERSIONES   ║");
            Console.WriteLine("║              Atracción: Montaña Rusa Extrema              ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════╝");

            while (continuar)
            {
                MostrarMenu();
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Write("\nIngrese el nombre de la persona: ");
                        string nombre = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(nombre))
                        {
                            gestor.AgregarPersonaCola(nombre);
                        }
                        else
                        {
                            Console.WriteLine("\n⚠ Nombre inválido.");
                        }
                        break;

                    case "2":
                        gestor.AsignarAsientos();
                        break;

                    case "3":
                        gestor.MostrarEstadoAsientos();
                        break;

                    case "4":
                        gestor.MostrarColaEspera();
                        break;

                    case "5":
                        gestor.MostrarAsientosOcupados();
                        break;

                    case "6":
                        gestor.TerminarAtraccion();
                        break;

                    case "7":
                        gestor.MostrarEstadisticas();
                        break;

                    case "8":
                        EjecutarDemostracion(gestor);
                        break;

                    case "9":
                        Console.WriteLine("\n¡Gracias por usar el sistema! 🎢");
                        continuar = false;
                        break;

                    default:
                        Console.WriteLine("\n⚠ Opción inválida. Intente nuevamente.");
                        break;
                }

                if (continuar)
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }

        static void MostrarMenu()
        {
            Console.WriteLine("\n╔═══════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                      MENÚ PRINCIPAL                       ║");
            Console.WriteLine("╠═══════════════════════════════════════════════════════════╣");
            Console.WriteLine("║  1. Agregar persona a la cola                             ║");
            Console.WriteLine("║  2. Asignar asientos a personas en cola                   ║");
            Console.WriteLine("║  3. Ver estado de todos los asientos                      ║");
            Console.WriteLine("║  4. Ver personas en cola de espera                        ║");
            Console.WriteLine("║  5. Ver asientos ocupados (detalle)                       ║");
            Console.WriteLine("║  6. Finalizar atracción (liberar asientos)                ║");
            Console.WriteLine("║  7. Ver estadísticas del sistema                          ║");
            Console.WriteLine("║  8. Ejecutar demostración automática                      ║");
            Console.WriteLine("║  9. Salir                                                 ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════╝");
            Console.Write("\nSeleccione una opción: ");
        }

        /// <summary>
        /// Ejecuta una demostración automática del sistema
        /// </summary>
        static void EjecutarDemostracion(GestorAtraccion gestor)
        {
            Console.WriteLine("\n╔═══════════════════════════════════════════════════════════╗");
            Console.WriteLine("║              INICIANDO DEMOSTRACIÓN AUTOMÁTICA            ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════╝");

            string[] nombres = {
                "Juan Pérez", "María García", "Carlos López", "Ana Martínez",
                "Pedro Rodríguez", "Laura Fernández", "Diego González", "Carmen Díaz",
                "Roberto Sánchez", "Patricia Romero", "Miguel Torres", "Isabel Ramírez",
                "Francisco Vargas", "Rosa Castillo", "Antonio Moreno", "Teresa Ortiz",
                "José Ruiz", "Luisa Mendoza", "Alberto Cruz", "Elena Silva",
                "Fernando Ramos", "Marta Herrera", "Ricardo Flores", "Sofía Vega",
                "Daniel Morales", "Gabriela Castro", "Andrés Reyes", "Valentina Núñez",
                "Sebastián Paredes", "Camila Ríos", "Leonardo Campos", "Daniela Fuentes",
                "Mateo Guzmán", "Natalia Rojas", "Nicolás Contreras"
            };

            // Agregar 35 personas a la cola (más que la capacidad)
            Console.WriteLine("\n--- Agregando personas a la cola ---");
            for (int i = 0; i < 35; i++)
            {
                gestor.AgregarPersonaCola(nombres[i]);
                System.Threading.Thread.Sleep(100);
            }

            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();

            // Mostrar cola
            gestor.MostrarColaEspera();
            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();

            // Primera asignación (llenará todos los 30 asientos)
            gestor.AsignarAsientos();
            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();

            // Mostrar estado
            gestor.MostrarEstadoAsientos();
            gestor.MostrarAsientosOcupados();
            gestor.MostrarColaEspera();
            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();

            // Intentar asignar más (no podrá porque está lleno)
            gestor.AsignarAsientos();
            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();

            // Estadísticas
            gestor.MostrarEstadisticas();
            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();

            // Terminar atracción
            gestor.TerminarAtraccion();
            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();

            // Asignar a las personas restantes
            gestor.AsignarAsientos();
            gestor.MostrarEstadoAsientos();
            gestor.MostrarEstadisticas();

            Console.WriteLine("\n╔═══════════════════════════════════════════════════════════╗");
            Console.WriteLine("║            DEMOSTRACIÓN COMPLETADA CON ÉXITO              ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════╝");
        }
    }
}