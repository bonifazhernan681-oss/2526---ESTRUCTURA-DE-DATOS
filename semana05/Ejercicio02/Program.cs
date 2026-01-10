using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Crear una lista para almacenar los números del 1 al 10
        List<int> numeros = new List<int>();
        
        // Agregar números del 1 al 10
        for (int i = 1; i <= 10; i++)
        {
            numeros.Add(i);
        }
        
        // Invertir la lista
        numeros.Reverse();
        
        // Mostrar los números en orden inverso separados por comas
        Console.WriteLine("=== NÚMEROS DEL 1 AL 10 EN ORDEN INVERSO ===");
        Console.WriteLine();
        Console.WriteLine(string.Join(", ", numeros));
        
        // Esperar para que no se cierre la consola
        Console.WriteLine();
        Console.WriteLine("Presiona cualquier tecla para salir...");
        Console.ReadKey();
    }
}