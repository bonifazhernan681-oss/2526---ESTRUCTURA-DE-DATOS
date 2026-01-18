using System;

namespace Ejercicio1
{
    // Clase Nodo
    public class Nodo
    {
        public int Dato { get; set; }
        public Nodo Siguiente { get; set; }

        public Nodo(int dato)
        {
            Dato = dato;
            Siguiente = null;
        }
    }

    // Clase Lista Enlazada
    public class ListaEnlazada
    {
        public Nodo Cabeza { get; set; }

        public ListaEnlazada()
        {
            Cabeza = null;
        }

        // Método para insertar al final de la lista
        public void InsertarAlFinal(int dato)
        {
            Nodo nuevoNodo = new Nodo(dato);

            // Si la lista está vacía, el nuevo nodo es la cabeza
            if (Cabeza == null)
            {
                Cabeza = nuevoNodo;
                return;
            }

            // Si no, recorremos hasta el último nodo
            Nodo actual = Cabeza;
            while (actual.Siguiente != null)
            {
                actual = actual.Siguiente;
            }

            // Agregamos el nuevo nodo al final
            actual.Siguiente = nuevoNodo;
        }

        // EJERCICIO 1: Método para contar el número de elementos
        public int ContarElementos()
        {
            int contador = 0;
            Nodo actual = Cabeza;

            // Recorremos la lista desde la cabeza hasta el final
            while (actual != null)
            {
                contador++;              // Incrementamos el contador
                actual = actual.Siguiente;  // Avanzamos al siguiente nodo
            }

            return contador;
        }

        // Método auxiliar para mostrar la lista
        public void MostrarLista()
        {
            if (Cabeza == null)
            {
                Console.WriteLine("La lista está vacía");
                return;
            }

            Nodo actual = Cabeza;
            Console.Write("Lista: ");

            while (actual != null)
            {
                Console.Write(actual.Dato);
                if (actual.Siguiente != null)
                {
                    Console.Write(" -> ");
                }
                actual = actual.Siguiente;
            }

            Console.WriteLine(" -> null");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== EJERCICIO 1: CONTAR ELEMENTOS DE UNA LISTA ===\n");

            // Creamos una nueva lista enlazada
            ListaEnlazada lista = new ListaEnlazada();

            // Preguntamos cuántos elementos quiere agregar
            Console.Write("¿Cuántos elementos desea agregar a la lista? ");
            int n = int.Parse(Console.ReadLine());

            // Insertamos los elementos
            Console.WriteLine();
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Ingrese el elemento {i + 1}: ");
                int dato = int.Parse(Console.ReadLine());
                lista.InsertarAlFinal(dato);
            }

            // Mostramos la lista
            Console.WriteLine();
            lista.MostrarLista();

            // Contamos y mostramos el número de elementos
            int totalElementos = lista.ContarElementos();
            Console.WriteLine($"\nNúmero total de elementos en la lista: {totalElementos}");

            Console.WriteLine("\nPresione cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}