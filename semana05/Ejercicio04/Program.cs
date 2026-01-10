using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== CONTADOR DE VOCALES ===");
        Console.WriteLine();
        
        // Pedir palabra al usuario
        Console.Write("Ingresa una palabra: ");
        string palabra = Console.ReadLine();
        
        // Convertir a minúsculas para facilitar la búsqueda
        string palabraMinuscula = palabra.ToLower();
        
        // Lista de vocales
        List<char> vocales = new List<char> { 'a', 'e', 'i', 'o', 'u' };
        
        // Diccionario para contar cada vocal
        Dictionary<char, int> contadorVocales = new Dictionary<char, int>
        {
            {'a', 0}, {'e', 0}, {'i', 0}, {'o', 0}, {'u', 0}
        };
        
        int totalVocales = 0;
        
        // Contar vocales
        foreach (char letra in palabraMinuscula)
        {
            if (vocales.Contains(letra))
            {
                contadorVocales[letra]++;
                totalVocales++;
            }
        }
        
        // Mostrar resultados
        Console.WriteLine();
        Console.WriteLine($"La palabra '{palabra}' contiene {totalVocales} vocal(es):");
        Console.WriteLine();
        
        foreach (var vocal in contadorVocales)
        {
            if (vocal.Value > 0)
            {
                Console.WriteLine($"  {vocal.Key}: {vocal.Value} vez/veces");
            }
        }
        
        // Esperar para que no se cierre la consola
        Console.WriteLine();
        Console.WriteLine("Presiona cualquier tecla para salir...");
        Console.ReadKey();
    }
}