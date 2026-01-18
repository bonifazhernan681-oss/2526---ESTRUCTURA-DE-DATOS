using System;

namespace Ejercicio2
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

        // EJERCICIO 2: Método para invertir la lista
        public void Invertir()
        {
            Nodo anterior = null;
            Nodo actual = Cabeza;
            Nodo siguiente = null;

            // Recorremos la lista invirtiendo los enlaces
            while (actual != null)
            {
                // Guardamos el siguiente nodo
                siguiente = actual.Siguiente;
                
                // Invertimos el enlace: el actual ahora apunta al anterior
                actual.Siguiente = anterior;
                
                // Avanzamos los punteros
                anterior = actual;
                actual = siguiente;
            }

            // Al final, el anterior es la nueva cabeza
            Cabeza = anterior;
        }

        // Método auxiliar para contar elementos
        public int ContarElementos()
        {
            int contador = 0;
            Nodo actual = Cabeza;

            while (actual != null)
            {
                contador++;
                actual = actual.Siguiente;
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
            Console.WriteLine("=== EJERCICIO 2: INVERTIR UNA LISTA ENLAZADA ===\n");

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

            // Mostramos la lista original
            Console.WriteLine("\n--- LISTA ORIGINAL ---");
            lista.MostrarLista();
            Console.WriteLine($"Total de elementos: {lista.ContarElementos()}");

            // Invertimos la lista
            lista.Invertir();

            // Mostramos la lista invertida
            Console.WriteLine("\n--- LISTA INVERTIDA ---");
            lista.MostrarLista();
            Console.WriteLine($"Total de elementos: {lista.ContarElementos()}");

            Console.WriteLine("\nPresione cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}