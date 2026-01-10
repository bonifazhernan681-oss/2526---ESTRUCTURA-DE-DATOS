using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== ANÁLISIS DE PRECIOS ===");
        Console.WriteLine();
        
        // Crear lista con los precios dados
        List<int> precios = new List<int> { 50, 69, 22, 26, 31, 25, 10 };
        
        // Mostrar la lista de precios
        Console.WriteLine("Lista de precios:");
        Console.WriteLine(string.Join(", ", precios));
        Console.WriteLine();
        
        // Encontrar el precio menor
        int precioMenor = precios.Min();
        
        // Encontrar el precio mayor
        int precioMayor = precios.Max();
        
        // Mostrar resultados
        Console.WriteLine("--- RESULTADOS ---");
        Console.WriteLine($"Precio MENOR: {precioMenor}");
        Console.WriteLine($"Precio MAYOR: {precioMayor}");
        
        // Esperar para que no se cierre la consola
        Console.WriteLine();
        Console.WriteLine("Presiona cualquier tecla para salir...");
        Console.ReadKey();
    }
}