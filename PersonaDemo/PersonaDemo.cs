/*using System;
using System.Collections.Generic;


namespace PersonaDemo
{
    // 1. Enumeración para estado civil
    enum EstadoCivil
    {
        Soltero,
        Casado,
        Divorciado,
        Viudo
    }

    // 2. Estructura para información de salud
    struct InfoSalud
    {
        public double Peso;       // kg
        public double Altura;     // metros
        public string GrupoSanguineo;
    }

    class Persona
    {
        // 3. Diferentes tipos de propiedades
        public string Nombre { get; set; } = null!;       // string
        public int Edad { get; set; }             // entero
        public double Estatura { get; set; }      // punto flotante
        public decimal Salario { get; set; }      // decimal (precisión monetaria)
        public bool EsEstudiante { get; set; }    // booleano
        public char Genero { get; set; }          // carácter
        public DateTime FechaNacimiento { get; set; } // fecha
        public EstadoCivil EstadoCivilActual { get; set; } // enum
        public InfoSalud Salud { get; set; }      // estructura
        public List<string> Hobbies { get; set; } = null!; // lista (colección)
        public string? SegundoNombre { get; set; } // nullable type
        public int? NumeroHijos { get; set; }      // nullable int

        // 4. Método para mostrar información
        public void MostrarInformacion()
        {
            Console.WriteLine("=== Información Personal ===");
            Console.WriteLine($"Nombre: {Nombre} {(String.IsNullOrEmpty(SegundoNombre) ? "[Sin segundo nombre]"  : SegundoNombre)  }");//este es un operador ternario investigar despues
            Console.WriteLine($"Edad: {Edad} años");
            Console.WriteLine($"Fecha Nacimiento: {FechaNacimiento:dd/MM/yyyy}");
            Console.WriteLine($"Género: {Genero}");
            Console.WriteLine($"Estatura: {Estatura}m");
            Console.WriteLine($"Salario: {Salario:C2}");
            Console.WriteLine($"Es estudiante: {(EsEstudiante ? "Sí" : "No")}");
            Console.WriteLine($"Estado civil: {EstadoCivilActual}");
            Console.WriteLine($"Peso: {Salud.Peso}kg | Altura: {Salud.Altura}m | Grupo Sanguíneo: {Salud.GrupoSanguineo}");
            Console.WriteLine($"Hijos: {(NumeroHijos.HasValue ? NumeroHijos.ToString() : "No especificado")}");
            Console.WriteLine("Hobbies: " + string.Join(", ", Hobbies));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Crear instancia de Persona
            Persona persona = new Persona
            {
                Nombre = "María",
                SegundoNombre = "De Los Angeles", // Nullable type
                Edad = 28,
                Estatura = 1.65,
                Salario = 45000.50m,
                EsEstudiante = false,
                Genero = 'F',
                FechaNacimiento = new DateTime(1995, 5, 15),
                EstadoCivilActual = EstadoCivil.Casado,
                Salud = new InfoSalud
                {
                    Peso = 62.5,
                    Altura = 1.65,
                    GrupoSanguineo = "A+"
                },
                Hobbies = new List<string> { "Leer", "Natación", "Fotografía" },
                NumeroHijos = 2
            };

            // Mostrar información
            persona.MostrarInformacion();
        }
    }
}*/

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace PersonaDemoConsola
{
    enum EstadoCivil
    {
        Soltero = 1,
        Casado,
        Divorciado,
        Viudo
    }

    struct InfoSalud
    {
        public double Peso;
        public double Altura;
        public string GrupoSanguineo;
    }

    class Persona
    {
        public string Nombre { get; set; }
        public string? SegundoNombre { get; set; }
        public int Edad { get; set; }
        public double Estatura { get; set; }
        public decimal Salario { get; set; }
        public bool EsEstudiante { get; set; }
        public char Genero { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public EstadoCivil EstadoCivilActual { get; set; }
        public InfoSalud Salud { get; set; }
        public List<string> Hobbies { get; set; }
        public int? NumeroHijos { get; set; }

        public void MostrarInformacion()
        {
            Console.WriteLine("\n=== Información Registrada ===");
            Console.WriteLine($"Nombre: {Nombre} {SegundoNombre ?? "[Sin segundo nombre]"}");
            Console.WriteLine($"Edad: {Edad} años");
            Console.WriteLine($"Fecha Nacimiento: {FechaNacimiento:dd/MM/yyyy}");
            Console.WriteLine($"Género: {Genero}");
            Console.WriteLine($"Estatura: {Estatura}m");
            Console.WriteLine($"Salario: {Salario:C2}");
            Console.WriteLine($"Es estudiante: {(EsEstudiante ? "Sí" : "No")}");
            Console.WriteLine($"Estado civil: {EstadoCivilActual}");
            Console.WriteLine($"Peso: {Salud.Peso}kg | Altura: {Salud.Altura}m | Grupo Sanguíneo: {Salud.GrupoSanguineo}");
            Console.WriteLine($"Hijos: {NumeroHijos?.ToString() ?? "No especificado"}");
            Console.WriteLine($"Hobbies: {string.Join(", ", Hobbies)}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Persona persona = new Persona();
            
            Console.WriteLine("=== Ingreso de Datos ===");
            
            persona.Nombre = LeerString("Nombre: ");
            persona.SegundoNombre = LeerStringOpcional("Segundo nombre (opcional): ");
            persona.Edad = LeerEntero("Edad: ", 1, 120);
            persona.Estatura = LeerDouble("Estatura (metros): ", 0.5, 2.5);
            persona.Salario = LeerDecimal("Salario mensual: ", 0);
            persona.EsEstudiante = LeerSiNo("¿Es estudiante? (s/n): ");
            persona.Genero = LeerGenero("Género (M/F/O): ");
            persona.FechaNacimiento = LeerFecha("Fecha de nacimiento (dd/mm/aaaa): ");
            persona.EstadoCivilActual = LeerEstadoCivil();
            persona.Salud = LeerInfoSalud();
            persona.Hobbies = LeerHobbies();
            persona.NumeroHijos = LeerEnteroOpcional("Número de hijos (opcional): ");

            persona.MostrarInformacion();
        }

        static string LeerString(string mensaje)
        {
            Console.Write(mensaje);
            return Console.ReadLine().Trim();
        }

        static string? LeerStringOpcional(string mensaje)
        {
            Console.Write(mensaje);
            string input = Console.ReadLine().Trim();
            return string.IsNullOrEmpty(input) ? null : input;
        }

        static int LeerEntero(string mensaje, int min, int max)
        {
            while(true)
            {
                Console.Write(mensaje);
                if(int.TryParse(Console.ReadLine(), out int valor) && valor >= min && valor <= max)
                    return valor;
                Console.WriteLine($"Error: Ingrese un número entre {min} y {max}");
            }
        }

        static int? LeerEnteroOpcional(string mensaje)
        {
            Console.Write(mensaje);
            string input = Console.ReadLine().Trim();
            if(string.IsNullOrEmpty(input)) return null;
            return int.Parse(input);
        }

        static double LeerDouble(string mensaje, double min, double max)
        {
            while(true)
            {
                Console.Write(mensaje);
                if(double.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out double valor) && valor >= min && valor <= max)
                    return valor;
                Console.WriteLine($"Error: Ingrese un número entre {min} y {max}");
            }
        }

        static decimal LeerDecimal(string mensaje, decimal min)
        {
            while(true)
            {
                Console.Write(mensaje);
                if(decimal.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal valor) && valor >= min)
                    return valor;
                Console.WriteLine("Error: Ingrese un valor válido");
            }
        }

        static bool LeerSiNo(string mensaje)
        {
            while(true)
            {
                Console.Write(mensaje);
                string input = Console.ReadLine().Trim().ToLower();
                if(input == "s") return true;
                if(input == "n") return false;
                Console.WriteLine("Error: Ingrese 's' o 'n'");
            }
        }

        static char LeerGenero(string mensaje)
        {
            while(true)
            {
                Console.Write(mensaje);
                string input = Console.ReadLine().Trim().ToUpper();
                if(input == "M" || input == "F" || input == "O")
                    return input[0];
                Console.WriteLine("Error: Ingrese M, F u O");
            }
        }

        static DateTime LeerFecha(string mensaje)
        {
            while(true)
            {
                Console.Write(mensaje);
                if(DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fecha))
                    return fecha;
                Console.WriteLine("Error: Formato debe ser dd/mm/aaaa");
            }
        }

        static EstadoCivil LeerEstadoCivil()
        {
            Console.WriteLine("\nEstado Civil:");
            foreach (EstadoCivil estado in Enum.GetValues(typeof(EstadoCivil)))
                Console.WriteLine($"{(int)estado}. {estado}");

            return (EstadoCivil)LeerEntero("Seleccione una opción: ", 1, Enum.GetValues(typeof(EstadoCivil)).Length);
        }

        static InfoSalud LeerInfoSalud()
        {
            Console.WriteLine("\nDatos de Salud:");
            InfoSalud salud = new InfoSalud
            {
                Peso = LeerDouble("Peso (kg): ", 20, 300),
                Altura = LeerDouble("Altura (metros): ", 0.5, 2.5),
                GrupoSanguineo = LeerString("Grupo sanguíneo: ")
            };
            return salud;
        }

        static List<string> LeerHobbies()
        {
            Console.Write("\nIngrese hobbies separados por coma: ");
            string input = Console.ReadLine().Trim();
            return input.Split(',').Select(h => h.Trim()).Where(h => !string.IsNullOrEmpty(h)).ToList();
        }
    }
}