using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Crear una lista para almacenar las asignaturas
        List<string> asignaturas = new List<string>();
        
        // Agregar asignaturas a la lista
        asignaturas.Add("Matemáticas");
        asignaturas.Add("Estructura de datos");
        asignaturas.Add("Química");
        asignaturas.Add("Metodología de la investigación");
        asignaturas.Add("Deportes");
        
        // Mostrar las asignaturas por pantalla
        Console.WriteLine("=== ASIGNATURAS DEL CURSO ===");
        Console.WriteLine();
        
        foreach (string asignatura in asignaturas)
        {
            Console.WriteLine("- " + asignatura);
        }
        
        Console.WriteLine();
        Console.WriteLine("Total de asignaturas: " + asignaturas.Count);
        
        // Esperar para que no se cierre la consola
        Console.WriteLine();
        Console.WriteLine("Presiona cualquier tecla para salir...");
        Console.ReadKey();
    }
}