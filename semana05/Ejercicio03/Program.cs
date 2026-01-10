using System;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== VERIFICADOR DE PALÍNDROMOS ===");
        Console.WriteLine();
        
        // Pedir palabra al usuario
        Console.Write("Ingresa una palabra: ");
        string palabra = Console.ReadLine();
        
        // Convertir a minúsculas y quitar espacios para comparación
        string palabraLimpia = palabra.ToLower().Replace(" ", "");
        
        // Invertir la palabra usando LINQ
        string palabraInvertida = new string(palabraLimpia.Reverse().ToArray());
        
        // Verificar si es palíndromo
        Console.WriteLine();
        if (palabraLimpia == palabraInvertida)
        {
            Console.WriteLine($"¡'{palabra}' ES un palíndromo!");
        }
        else
        {
            Console.WriteLine($"'{palabra}' NO es un palíndromo.");
        }
        
        Console.WriteLine($"Palabra invertida: {palabraInvertida}");
        
        // Esperar para que no se cierre la consola
        Console.WriteLine();
        Console.WriteLine("Presiona cualquier tecla para salir...");
        Console.ReadKey();
    }
}