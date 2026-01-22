using System;
using System.Collections.Generic;
using System.Linq;

class TorresDeHanoi
{
    // Tres pilas representando las tres torres
    static Stack<int> torreA = new Stack<int>();
    static Stack<int> torreB = new Stack<int>();
    static Stack<int> torreC = new Stack<int>();
    
    static int contadorMovimientos = 0;
    
    static void Main()
    {
        Console.WriteLine("=== TORRES DE HANOI CON PILAS ===\n");
        
        Console.Write("Ingrese el número de discos: ");
        int numDiscos = int.Parse(Console.ReadLine());
        
        // Inicializar la Torre A con los discos (del más grande al más pequeño)
        for (int i = numDiscos; i >= 1; i--)
        {
            torreA.Push(i);
        }
        
        Console.WriteLine("\n--- ESTADO INICIAL ---");
        MostrarTorres();
        
        Console.WriteLine("\n--- MOVIMIENTOS ---\n");
        
        // Resolver el problema: mover todos los discos de A a C usando B como auxiliar
        ResolverHanoi(numDiscos, torreA, torreC, torreB, 'A', 'C', 'B');
        
        Console.WriteLine($"\n--- ESTADO FINAL ---");
        MostrarTorres();
        Console.WriteLine($"\nTotal de movimientos: {contadorMovimientos}");
        Console.WriteLine($"Fórmula: 2^n - 1 = 2^{numDiscos} - 1 = {Math.Pow(2, numDiscos) - 1}");
    }
    
    // Algoritmo recursivo para resolver las Torres de Hanoi
    static void ResolverHanoi(int n, Stack<int> origen, Stack<int> destino, Stack<int> auxiliar, 
                              char nombreOrigen, char nombreDestino, char nombreAuxiliar)
    {
        if (n == 1)
        {
            // Caso base: mover un disco directamente
            MoverDisco(origen, destino, nombreOrigen, nombreDestino);
            return;
        }
        
        // Paso 1: Mover n-1 discos de origen a auxiliar usando destino
        ResolverHanoi(n - 1, origen, auxiliar, destino, nombreOrigen, nombreAuxiliar, nombreDestino);
        
        // Paso 2: Mover el disco más grande de origen a destino
        MoverDisco(origen, destino, nombreOrigen, nombreDestino);
        
        // Paso 3: Mover n-1 discos de auxiliar a destino usando origen
        ResolverHanoi(n - 1, auxiliar, destino, origen, nombreAuxiliar, nombreDestino, nombreOrigen);
    }
    
    // Función para mover un disco entre torres
    static void MoverDisco(Stack<int> origen, Stack<int> destino, char nombreOrigen, char nombreDestino)
    {
        int disco = origen.Pop();
        destino.Push(disco);
        contadorMovimientos++;
        
        Console.WriteLine($"Movimiento {contadorMovimientos}: Mover disco {disco} de Torre {nombreOrigen} a Torre {nombreDestino}");
        MostrarTorres();
        Console.WriteLine();
    }
    
    // Función para mostrar el estado actual de las tres torres
    static void MostrarTorres()
    {
        Console.WriteLine($"Torre A: {MostrarPila(torreA)}");
        Console.WriteLine($"Torre B: {MostrarPila(torreB)}");
        Console.WriteLine($"Torre C: {MostrarPila(torreC)}");
    }
    
    // Función auxiliar para mostrar el contenido de una pila
    static string MostrarPila(Stack<int> pila)
    {
        if (pila.Count == 0)
            return "[ ]";
        
        // Convertir la pila a un array para mostrarla de base a tope
        int[] discos = pila.Reverse().ToArray();
        return "[ " + string.Join(", ", discos) + " ]";
    }
}