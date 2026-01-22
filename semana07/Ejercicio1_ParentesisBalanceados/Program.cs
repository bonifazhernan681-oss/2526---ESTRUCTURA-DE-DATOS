using System;
using System.Collections.Generic;

class VerificadorParentesis
{
    static void Main()
    {
        Console.WriteLine("=== VERIFICADOR DE PARÉNTESIS BALANCEADOS ===\n");
        
        while (true)
        {
            Console.Write("Ingrese una expresión matemática (o 'salir' para terminar): ");
            string expresion = Console.ReadLine();
            
            if (expresion.ToLower() == "salir")
            {
                Console.WriteLine("\n¡Hasta luego!");
                break;
            }
            
            if (string.IsNullOrWhiteSpace(expresion))
            {
                Console.WriteLine("Error: Debe ingresar una expresión válida.\n");
                continue;
            }
            
            VerificarExpresion(expresion);
            Console.WriteLine();
        }
    }
    
    static void VerificarExpresion(string expresion)
    {
        Console.WriteLine($"\nEntrada: {expresion}");
        
        Stack<char> pila = new Stack<char>();
        bool balanceado = true;
        
        foreach (char c in expresion)
        {
            // Si es un símbolo de apertura, lo agregamos a la pila
            if (c == '(' || c == '{' || c == '[')
            {
                pila.Push(c);
            }
            // Si es un símbolo de cierre, verificamos que coincida
            else if (c == ')' || c == '}' || c == ']')
            {
                // Si la pila está vacía, no hay balance
                if (pila.Count == 0)
                {
                    balanceado = false;
                    break;
                }
                
                char apertura = pila.Pop();
                
                // Verificar que el cierre coincida con la apertura
                if (!Coinciden(apertura, c))
                {
                    balanceado = false;
                    break;
                }
            }
        }
        
        // Si quedaron elementos en la pila, no está balanceado
        if (pila.Count > 0)
        {
            balanceado = false;
        }
        
        if (balanceado)
        {
            Console.WriteLine("Salida esperada: Fórmula balanceada.");
        }
        else
        {
            Console.WriteLine("Salida esperada: Fórmula NO balanceada.");
        }
    }
    
    // Función auxiliar para verificar si los símbolos coinciden
    static bool Coinciden(char apertura, char cierre)
    {
        return (apertura == '(' && cierre == ')') ||
               (apertura == '{' && cierre == '}') ||
               (apertura == '[' && cierre == ']');
    }
}