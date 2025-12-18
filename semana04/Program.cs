using System;

namespace AgendaTelefonica
{
    // Estructura de datos: Clase Contacto (Registro)
    public class Contacto
    {
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public int Categoria { get; set; } // 0=Familia, 1=Trabajo, 2=Amigos

        public Contacto(string nombre, string telefono, string email, int categoria)
        {
            Nombre = nombre;
            Telefono = telefono;
            Email = email;
            Categoria = categoria;
        }

        public override string ToString()
        {
            string[] categorias = { "Familia", "Trabajo", "Amigos" };
            return $"Nombre: {Nombre,-20} | Tel: {Telefono,-15} | Email: {Email,-25} | Categoría: {categorias[Categoria]}";
        }
    }

    class Program
    {
        // Vector de contactos (Array)
        static Contacto[] contactos = new Contacto[100];
        static int totalContactos = 0;

        // Matriz para contar contactos por categoría
        static int[,] estadisticas = new int[3, 2]; // [categoria][0=cantidad, 1=reservado]

        static void Main(string[] args)
        {
            // Datos de ejemplo precargados
            AgregarContactoInicial("María González", "0987654321", "maria@email.com", 0);
            AgregarContactoInicial("Pedro Sánchez", "0998765432", "pedro@empresa.com", 1);
            AgregarContactoInicial("Ana Torres", "0976543210", "ana@email.com", 2);
            AgregarContactoInicial("Luis Rodríguez", "0965432109", "luis@familia.com", 0);

            int opcion;
            do
            {
                MostrarMenu();
                opcion = LeerOpcion();

                switch (opcion)
                {
                    case 1:
                        AgregarContacto();
                        break;
                    case 2:
                        ListarContactos();
                        break;
                    case 3:
                        BuscarContacto();
                        break;
                    case 4:
                        EliminarContacto();
                        break;
                    case 5:
                        GenerarReportePorCategoria();
                        break;
                    case 6:
                        Console.WriteLine("\n¡Gracias por usar la Agenda Telefónica!");
                        break;
                    default:
                        Console.WriteLine("\nOpción inválida. Intente nuevamente.");
                        break;
                }

                if (opcion != 6)
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcion != 6);
        }

        static void MostrarMenu()
        {
            Console.Clear();
            Console.WriteLine("╔═══════════════════════════════════════════════╗");
            Console.WriteLine("║       AGENDA TELEFÓNICA - SISTEMA UEA         ║");
            Console.WriteLine("╚═══════════════════════════════════════════════╝");
            Console.WriteLine("\n[1] Agregar Contacto");
            Console.WriteLine("[2] Listar Todos los Contactos");
            Console.WriteLine("[3] Buscar Contacto por Nombre");
            Console.WriteLine("[4] Eliminar Contacto");
            Console.WriteLine("[5] Generar Reporte por Categoría");
            Console.WriteLine("[6] Salir");
            Console.Write("\nSeleccione una opción: ");
        }

        static int LeerOpcion()
        {
            try
            {
                return int.Parse(Console.ReadLine());
            }
            catch
            {
                return 0;
            }
        }

        static void AgregarContactoInicial(string nombre, string telefono, string email, int categoria)
        {
            if (totalContactos < contactos.Length)
            {
                contactos[totalContactos] = new Contacto(nombre, telefono, email, categoria);
                estadisticas[categoria, 0]++;
                totalContactos++;
            }
        }

        static void AgregarContacto()
        {
            Console.Clear();
            Console.WriteLine("═══════════════════════════════════════");
            Console.WriteLine("         AGREGAR NUEVO CONTACTO");
            Console.WriteLine("═══════════════════════════════════════\n");

            if (totalContactos >= contactos.Length)
            {
                Console.WriteLine("❌ La agenda está llena. No se pueden agregar más contactos.");
                return;
            }

            Console.Write("Nombre completo: ");
            string nombre = Console.ReadLine();

            Console.Write("Teléfono: ");
            string telefono = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Console.WriteLine("\nCategorías disponibles:");
            Console.WriteLine("[0] Familia");
            Console.WriteLine("[1] Trabajo");
            Console.WriteLine("[2] Amigos");
            Console.Write("Seleccione categoría (0-2): ");
            
            int categoria;
            try
            {
                categoria = int.Parse(Console.ReadLine());
                if (categoria < 0 || categoria > 2)
                {
                    Console.WriteLine("❌ Categoría inválida. Se asignará como 'Amigos'.");
                    categoria = 2;
                }
            }
            catch
            {
                Console.WriteLine("❌ Entrada inválida. Se asignará como 'Amigos'.");
                categoria = 2;
            }

            contactos[totalContactos] = new Contacto(nombre, telefono, email, categoria);
            estadisticas[categoria, 0]++;
            totalContactos++;

            Console.WriteLine("\n✓ Contacto agregado exitosamente.");
        }

        static void ListarContactos()
        {
            Console.Clear();
            Console.WriteLine("═══════════════════════════════════════════════════════════════════════════════════");
            Console.WriteLine("                           LISTA DE CONTACTOS");
            Console.WriteLine("═══════════════════════════════════════════════════════════════════════════════════\n");

            if (totalContactos == 0)
            {
                Console.WriteLine("❌ No hay contactos registrados en la agenda.");
                return;
            }

            Console.WriteLine($"Total de contactos: {totalContactos}\n");
            Console.WriteLine("───────────────────────────────────────────────────────────────────────────────────");

            for (int i = 0; i < totalContactos; i++)
            {
                Console.WriteLine($"[{i + 1}] {contactos[i]}");
            }

            Console.WriteLine("───────────────────────────────────────────────────────────────────────────────────");
        }

        static void BuscarContacto()
        {
            Console.Clear();
            Console.WriteLine("═══════════════════════════════════════");
            Console.WriteLine("         BUSCAR CONTACTO");
            Console.WriteLine("═══════════════════════════════════════\n");

            if (totalContactos == 0)
            {
                Console.WriteLine("❌ No hay contactos registrados en la agenda.");
                return;
            }

            Console.Write("Ingrese el nombre a buscar: ");
            string nombreBuscar = Console.ReadLine().ToLower();

            bool encontrado = false;
            Console.WriteLine("\nResultados de búsqueda:\n");
            Console.WriteLine("───────────────────────────────────────────────────────────────────────────────────");

            for (int i = 0; i < totalContactos; i++)
            {
                if (contactos[i].Nombre.ToLower().Contains(nombreBuscar))
                {
                    Console.WriteLine($"[{i + 1}] {contactos[i]}");
                    encontrado = true;
                }
            }

            Console.WriteLine("───────────────────────────────────────────────────────────────────────────────────");

            if (!encontrado)
            {
                Console.WriteLine("❌ No se encontraron contactos con ese nombre.");
            }
        }

        static void EliminarContacto()
        {
            Console.Clear();
            Console.WriteLine("═══════════════════════════════════════");
            Console.WriteLine("         ELIMINAR CONTACTO");
            Console.WriteLine("═══════════════════════════════════════\n");

            if (totalContactos == 0)
            {
                Console.WriteLine("❌ No hay contactos registrados en la agenda.");
                return;
            }

            ListarContactos();

            Console.Write("\nIngrese el número del contacto a eliminar (0 para cancelar): ");
            try
            {
                int numero = int.Parse(Console.ReadLine());

                if (numero == 0)
                {
                    Console.WriteLine("Operación cancelada.");
                    return;
                }

                if (numero < 1 || numero > totalContactos)
                {
                    Console.WriteLine("❌ Número de contacto inválido.");
                    return;
                }

                int indice = numero - 1;
                int categoriaEliminada = contactos[indice].Categoria;

                // Desplazar los elementos del array
                for (int i = indice; i < totalContactos - 1; i++)
                {
                    contactos[i] = contactos[i + 1];
                }

                contactos[totalContactos - 1] = null;
                totalContactos--;
                estadisticas[categoriaEliminada, 0]--;

                Console.WriteLine("\n✓ Contacto eliminado exitosamente.");
            }
            catch
            {
                Console.WriteLine("❌ Entrada inválida.");
            }
        }

        static void GenerarReportePorCategoria()
        {
            Console.Clear();
            Console.WriteLine("═══════════════════════════════════════════════════════════════════════════════════");
            Console.WriteLine("                    REPORTE POR CATEGORÍA (Uso de Matriz)");
            Console.WriteLine("═══════════════════════════════════════════════════════════════════════════════════\n");

            if (totalContactos == 0)
            {
                Console.WriteLine("❌ No hay contactos registrados en la agenda.");
                return;
            }

            string[] nombresCategorias = { "Familia", "Trabajo", "Amigos" };

            // Mostrar estadísticas generales usando la matriz
            Console.WriteLine("ESTADÍSTICAS GENERALES:");
            Console.WriteLine("───────────────────────────────────────────────────────────────────────────────────");
            for (int i = 0; i < 3; i++)
            {
                double porcentaje = totalContactos > 0 ? (estadisticas[i, 0] * 100.0 / totalContactos) : 0;
                Console.WriteLine($"{nombresCategorias[i],-15}: {estadisticas[i, 0],3} contactos ({porcentaje:F1}%)");
            }
            Console.WriteLine($"{"TOTAL",-15}: {totalContactos,3} contactos");
            Console.WriteLine("───────────────────────────────────────────────────────────────────────────────────\n");

            // Mostrar contactos por categoría
            for (int cat = 0; cat < 3; cat++)
            {
                Console.WriteLine($"\n═══ CATEGORÍA: {nombresCategorias[cat].ToUpper()} ({estadisticas[cat, 0]} contactos) ═══");
                Console.WriteLine("───────────────────────────────────────────────────────────────────────────────────");

                bool hayContactos = false;
                for (int i = 0; i < totalContactos; i++)
                {
                    if (contactos[i].Categoria == cat)
                    {
                        Console.WriteLine($"  • {contactos[i].Nombre,-20} | {contactos[i].Telefono,-15} | {contactos[i].Email}");
                        hayContactos = true;
                    }
                }

                if (!hayContactos)
                {
                    Console.WriteLine("  (Sin contactos en esta categoría)");
                }
            }

            Console.WriteLine("\n═══════════════════════════════════════════════════════════════════════════════════");
        }
    }
}