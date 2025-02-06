using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;


namespace SistemaGestionProductos
{
    // 1. Clase base para productos usando POO
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }

        public override string ToString() => 
            $"[{Id}] {Nombre} - {Precio:C2} | Stock: {Stock}";
    }

    // 2. Clase para manejar la lógica de negocio
    public class ProductManager
    {
        private List<Producto> productos = new List<Producto>();
        private readonly string archivo = "productos.txt";

        // 3. Método para agregar productos con validación
        public void AgregarProducto()
        {
            try
            {
                var producto = new Producto();
                
                Console.Write("ID: ");
                producto.Id = LeerEntero("ID inválida. Intente nuevamente: ");
                
                Console.Write("Nombre: ");
                producto.Nombre = LeerCadena("Valor No Valido. Ingrselo Nuevamente: ");

                Console.Write("Precio: "); 
                producto.Precio = LeerDecimal("Precio: ", 0.01m);

                Console.Write("Stock: ");
                producto.Stock = LeerEntero("Stock: ", 0);

                productos.Add(producto);
                Console.WriteLine("Producto agregado!\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        // 4. Método para listar productos usando LINQ
        public void ListarProductos()
        {
            var ordenados = productos
                .OrderBy(p => p.Precio)
                .ThenBy(p => p.Nombre);

            Console.WriteLine("\n=== LISTA DE PRODUCTOS ===");
            foreach (var p in ordenados)
            {
                Console.WriteLine(p);
            }
            Console.WriteLine($"\nTotal productos: {productos.Count}\n");
        }

        // 5. Búsqueda con LINQ
        public void BuscarProductos()
        {
            Console.Write("Buscar: ");
            string busqueda = Console.ReadLine().ToLower();

            var resultados = productos
                .Where(p => p.Nombre.ToLower().Contains(busqueda))
                .ToList();

            Console.WriteLine($"\nResultados ({resultados.Count}):");
            resultados.ForEach(Console.WriteLine);
        }

        // 6. Manejo de archivos asíncrono
        public async Task GuardarEnArchivoAsync()
        {
            try
            {
                using (var writer = new StreamWriter(archivo))
                {
                    foreach (var p in productos)
                    {
                        await writer.WriteLineAsync($"{p.Id},{p.Nombre},{p.Precio},{p.Stock}");
                    }
                }
                Console.WriteLine("\nDatos guardados exitosamente!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar: {ex.Message}");
            }
        }

        // 7. Métodos de validación reutilizables
        private int LeerEntero(string mensajeError, int min = int.MinValue)
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int valor) && valor >= min)
                    return valor;
                
                Console.Write(mensajeError);
            }
        }

       private string LeerCadena(string mensajeError)
        {
            while (true)
            {
                string valor = Console.ReadLine();
                if (!string.IsNullOrEmpty(valor))
                    return valor;
                
                Console.Write(mensajeError);
            }
        }

        private decimal LeerDecimal(string mensaje, decimal min)
        {
            while (true)
            {
                
                if (decimal.TryParse(Console.ReadLine(), NumberStyles.Number, CultureInfo.CurrentCulture, out decimal valor) && valor >= min)
                    return valor;
                
                Console.WriteLine($"Valor inválido. Mínimo permitido: {min:C2}");
            }
        }

    }

    class Program
    {
        static async Task Main(string[] args)
        {
            var manager = new ProductManager();
            bool salir = false;

            // 8. Menú interactivo
            while (!salir)
            {
                Console.WriteLine("=== SISTEMA DE GESTIÓN ===");
                Console.WriteLine("1. Agregar Producto");
                Console.WriteLine("2. Listar Productos");
                Console.WriteLine("3. Buscar Productos");
                Console.WriteLine("4. Guardar en Archivo");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        manager.AgregarProducto();
                        break;
                    case "2":
                        manager.ListarProductos();
                        break;
                    case "3":
                        manager.BuscarProductos();
                        break;
                    case "4":
                        await manager.GuardarEnArchivoAsync();
                        break;
                    case "5":
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opción inválida\n");
                        break;
                }
            }

            Console.WriteLine("¡Hasta luego!");
        }
    }
}