using System;

namespace VariablesDemo
{
    // 8. Enumeración (tipo valor)
    enum DiasSemana
    {
        Lunes,
        Martes,
        Miercoles
    }

    // 9. Estructura (tipo valor)
    struct Punto
    {
        public int X;
        public int Y;
        
        public Punto(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    // 10. Clase (tipo referencia)
    class Persona
    {
        public string Nombre { get; set; }
        
        public Persona(string nombre)
        {
            Nombre = nombre;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 1. Enteros
            byte byteVar = 255;                  // 8-bit
            sbyte sbyteVar = -128;               // 8-bit con signo
            short shortVar = -32768;             // 16-bit
            ushort ushortVar = 65535;            // 16-bit sin signo
            int intVar = -2147483648;            // 32-bit
            uint uintVar = 4294967295;           // 32-bit sin signo
            long longVar = -9223372036854775808; // 64-bit
            ulong ulongVar = 18446744073709551615; // 64-bit sin signo

            // 2. Punto flotante
            float floatVar = 3.14f;              // 32-bit
            double doubleVar = 2.71828;          // 64-bit
            decimal decimalVar = 123.456m;       // 128-bit

            // 3. Booleano
            bool boolVar = true;

            // 4. Carácter
            char charVar = 'A';

            // 5. Cadena (tipo referencia)
            string stringVar = "Hola Mundo";

            // 6. Objeto (tipo referencia)
            object objectVar = new object();

            // 7. Arreglo
            int[] arrayVar = new int[] {1, 2, 3};

            // 8. Uso de enumeración
            DiasSemana dia = DiasSemana.Lunes;

            // 9. Uso de estructura
            Punto punto = new Punto(10, 20);

            // 10. Instancia de clase
            Persona persona = new Persona("Ana");

            // 11. Nullable
            int? nullableVar = null;

            // 12. Dynamic
            dynamic dynamicVar = "Soy dinámico";
            dynamicVar = 42;  // Cambio de tipo

            // Mostrar valores
            Console.WriteLine("Variables enteras:");
            Console.WriteLine($"byte: {byteVar}");
            Console.WriteLine($"sbyte: {sbyteVar}");
            Console.WriteLine($"short: {shortVar}");
            Console.WriteLine($"ushort: {ushortVar}");
            Console.WriteLine($"int: {intVar}");
            Console.WriteLine($"uint: {uintVar}");
            Console.WriteLine($"long: {longVar}");
            Console.WriteLine($"ulong: {ulongVar}\n");

            Console.WriteLine("Variables de punto flotante:");
            Console.WriteLine($"float: {floatVar}");
            Console.WriteLine($"double: {doubleVar}");
            Console.WriteLine($"decimal: {decimalVar}\n");

            Console.WriteLine("Booleano y carácter:");
            Console.WriteLine($"bool: {boolVar}");
            Console.WriteLine($"char: {charVar}\n");

            Console.WriteLine("Tipos referencia:");
            Console.WriteLine($"string: {stringVar}");
            Console.WriteLine($"object: {objectVar}");
            Console.WriteLine($"array: [{string.Join(", ", arrayVar)}]");
            Console.WriteLine("clase: "+persona.Nombre + "\n");

            Console.WriteLine("Estructuras y enums:");
            Console.WriteLine($"estructura: ({punto.X}, {punto.Y})");
            Console.WriteLine($"enum: {dia}\n");

            Console.WriteLine("Especiales:");
            Console.WriteLine($"nullable: {nullableVar ?? 0}"); // Operador null-coalescing
            Console.WriteLine($"dynamic: {dynamicVar}");
        }
    }
}