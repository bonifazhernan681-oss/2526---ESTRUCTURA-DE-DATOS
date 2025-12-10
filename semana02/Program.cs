using System;

// ====================================================
// TRABAJO ACADÉMICO: FIGURAS GEOMÉTRICAS EN C#
// ESTUDIANTE: [TU NOMBRE AQUÍ]
// CURSO: Programación Orientada a Objetos
// FECHA: Diciembre 2025
// TAREA
// ====================================================

// ----------------------------------------------------
// CLASE CÍRCULO
// Propósito: Representa un círculo y calcula su área y perímetro
// ----------------------------------------------------
public class Circulo
{
    // Atributo privado que encapsula el radio
    private double radio;

    // Constructor: Inicializa el radio del círculo
    public Circulo(double radioInicial)
    {
        // Validación simple
        if (radioInicial > 0)
            radio = radioInicial;
        else
            radio = 1.0; // Valor por defecto
    }

    // Método para obtener el radio (getter)
    public double ObtenerRadio()
    {
        return radio;
    }

    // Método para establecer el radio (setter)
    public void EstablecerRadio(double nuevoRadio)
    {
        if (nuevoRadio > 0)
            radio = nuevoRadio;
    }

    // Método para calcular el área: A = π * r²
    public double CalcularArea()
    {
        return Math.PI * radio * radio;
    }

    // Método para calcular el perímetro: P = 2 * π * r
    public double CalcularPerimetro()
    {
        return 2 * Math.PI * radio;
    }

    // Método para mostrar información del círculo
    public void MostrarInformacion()
    {
        Console.WriteLine("╔══════════════════════════════════╗");
        Console.WriteLine("║           CÍRCULO                ║");
        Console.WriteLine("╠══════════════════════════════════╣");
        Console.WriteLine($"║ Radio: {radio,25:F2} ║");
        Console.WriteLine($"║ Área: {CalcularArea(),26:F2} ║");
        Console.WriteLine($"║ Perímetro: {CalcularPerimetro(),21:F2} ║");
        Console.WriteLine("╚══════════════════════════════════╝");
    }
}

// ----------------------------------------------------
// CLASE RECTÁNGULO
// Propósito: Representa un rectángulo y calcula su área y perímetro
// ----------------------------------------------------
public class Rectangulo
{
    // Atributos privados que encapsulan dimensiones
    private double baseRectangulo;
    private double altura;

    // Constructor: Inicializa base y altura
    public Rectangulo(double baseInicial, double alturaInicial)
    {
        if (baseInicial > 0 && alturaInicial > 0)
        {
            baseRectangulo = baseInicial;
            altura = alturaInicial;
        }
        else
        {
            baseRectangulo = 1.0;
            altura = 1.0;
        }
    }

    // Métodos getter
    public double ObtenerBase() { return baseRectangulo; }
    public double ObtenerAltura() { return altura; }

    // Métodos setter
    public void EstablecerBase(double nuevaBase)
    {
        if (nuevaBase > 0) baseRectangulo = nuevaBase;
    }

    public void EstablecerAltura(double nuevaAltura)
    {
        if (nuevaAltura > 0) altura = nuevaAltura;
    }

    // Método para calcular el área: A = base * altura
    public double CalcularArea()
    {
        return baseRectangulo * altura;
    }

    // Método para calcular el perímetro: P = 2*(base + altura)
    public double CalcularPerimetro()
    {
        return 2 * (baseRectangulo + altura);
    }

    // Método para mostrar información del rectángulo
    public void MostrarInformacion()
    {
        Console.WriteLine("╔══════════════════════════════════╗");
        Console.WriteLine("║          RECTÁNGULO              ║");
        Console.WriteLine("╠══════════════════════════════════╣");
        Console.WriteLine($"║ Base: {baseRectangulo,24:F2} ║");
        Console.WriteLine($"║ Altura: {altura,23:F2} ║");
        Console.WriteLine($"║ Área: {CalcularArea(),26:F2} ║");
        Console.WriteLine($"║ Perímetro: {CalcularPerimetro(),21:F2} ║");
        Console.WriteLine("╚══════════════════════════════════╝");
    }
}

// ----------------------------------------------------
// PROGRAMA PRINCIPAL
// ----------------------------------------------------
class Program
{
    static void Main()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("================================================");
        Console.WriteLine("    PROGRAMA DE FIGURAS GEOMÉTRICAS EN C#");
        Console.WriteLine("================================================\n");
        Console.ResetColor();

        // ==============================
        // DEMOSTRACIÓN DEL CÍRCULO
        // ==============================
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("DEMOSTRACIÓN 1: CÍRCULO");
        Console.WriteLine("───────────────────────");
        Console.ResetColor();

        // Crear un círculo con radio 5
        Circulo miCirculo = new Circulo(5.0);
        miCirculo.MostrarInformacion();

        // Modificar el radio y mostrar nuevos cálculos
        Console.WriteLine("\n▶ Modificando radio a 7.5 unidades:");
        miCirculo.EstablecerRadio(7.5);
        Console.WriteLine($"   Nuevo área: {miCirculo.CalcularArea():F2} u²");
        Console.WriteLine($"   Nuevo perímetro: {miCirculo.CalcularPerimetro():F2} u");

        Console.WriteLine("\n" + new string('═', 50) + "\n");

        // ==============================
        // DEMOSTRACIÓN DEL RECTÁNGULO
        // ==============================
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("DEMOSTRACIÓN 2: RECTÁNGULO");
        Console.WriteLine("──────────────────────────");
        Console.ResetColor();

        // Crear un rectángulo 4x6
        Rectangulo miRectangulo = new Rectangulo(4.0, 6.0);
        miRectangulo.MostrarInformacion();

        // Modificar dimensiones y mostrar nuevos cálculos
        Console.WriteLine("\n▶ Modificando dimensiones a 8x3:");
        miRectangulo.EstablecerBase(8.0);
        miRectangulo.EstablecerAltura(3.0);
        Console.WriteLine($"   Nuevo área: {miRectangulo.CalcularArea():F2} u²");
        Console.WriteLine($"   Nuevo perímetro: {miRectangulo.CalcularPerimetro():F2} u");

        Console.WriteLine("\n" + new string('═', 50) + "\n");

        // ==============================
        // RESUMEN FINAL
        // ==============================
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("RESUMEN DE RESULTADOS:");
        Console.WriteLine("──────────────────────");
        Console.ResetColor();

        Console.WriteLine("• Círculo (radio original: 5.0):");
        Console.WriteLine($"  Área: {new Circulo(5.0).CalcularArea():F2} u²");
        Console.WriteLine($"  Perímetro: {new Circulo(5.0).CalcularPerimetro():F2} u");

        Console.WriteLine("\n• Rectángulo (original: 4.0 x 6.0):");
        Console.WriteLine($"  Área: {new Rectangulo(4.0, 6.0).CalcularArea():F2} u²");
        Console.WriteLine($"  Perímetro: {new Rectangulo(4.0, 6.0).CalcularPerimetro():F2} u");

        Console.WriteLine("\n" + new string('═', 50));

        // ==============================
        // FINALIZACIÓN
        // ==============================
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n✅ EJECUCIÓN COMPLETADA EXITOSAMENTE");
        Console.ResetColor();
        
        Console.Write("\nPresiona ENTER para finalizar... ");
        Console.ReadLine();
    }
}