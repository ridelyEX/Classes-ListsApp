using Classes_ListsApp.personas;
using System;
using System.Collections;
using System.Drawing;
using System.Text;

namespace Classes_ListsApp.utiils
{
    internal class Operaciones
    {
        List<Personas> persona = new List<Personas>();
        public static string Leer()
        {
            string? leer;
            do
            {
                leer = Console.ReadLine();
            } while (string.IsNullOrEmpty(leer));
            return leer;
        }

        public static void Menu()
        {
            Console.WriteLine("1. Registrar persona");
            Console.WriteLine("2. Mostrar todas");
            Console.WriteLine("3. Mostrar mayores de edad");
            Console.WriteLine("4. Buscar persona");
            Console.WriteLine("5. Salir");
        }

        public static string Nombre()
        {
            string? nombre;
            do
            {
                Console.WriteLine("Registre su nombre");
                nombre = Leer()?.Trim();

                if (string.IsNullOrEmpty(nombre))
                    Console.WriteLine("El nombr no puede estar vacío");
            } while (string.IsNullOrEmpty(nombre));
            
            return nombre;
        }

        public static string Color()
        {
            string? color;
            do
            {
                Console.WriteLine("De qué color eres");
                color = Leer()?.Trim();

                if (string.IsNullOrEmpty(color))
                    Console.WriteLine("El nombr no puede estar vacío");
            } while (string.IsNullOrEmpty(color));

            return color;
        }

        public static string Sexo()
        {
            string? sexo;
            do
            {
                Console.WriteLine("Sexo?");
                sexo = Leer()?.Trim();

                if (string.IsNullOrEmpty(sexo))
                    Console.WriteLine("El nombr no puede estar vacío");
            } while (string.IsNullOrEmpty(sexo));

            return sexo;
        }

        public static int Edad()
        {
            int edad;
            do
            {
                Console.WriteLine("Edad del sujeto");

                if (!int.TryParse(Leer(), out edad) || edad < 0 || edad > 120){
                    Console.WriteLine("Edad inválida");
                }

            } while (edad < 0 || edad > 120);

            return edad;
        }

        public static bool Vive()
        {
            string? vive;
            do
            {
                Console.WriteLine("La persona sigue viva?");
                vive = Leer()?.Trim().ToUpper();

                if (string.IsNullOrEmpty(vive) || (vive != "S" && vive != "N"))
                    Console.WriteLine("Debe responder con S o N");

            } while (string.IsNullOrEmpty(vive) || (vive != "S" && vive != "N"));

            return vive == "S";
        }

        /// Método "espejo" que realiza la búsqueda por medio de los parámetros
        /// 'lista' del tipo List<Personas> y 'nombre' del tipo string.
        /// Retorna el resultado de la búsqueda en la lista 'lista haciendo comparación con 'nombre'
        /// 
        public static Personas? Busqueda(List<Personas> lista, string nombre)
        {
            return lista.Find(p => p.Nombre?.Equals(nombre, StringComparison.OrdinalIgnoreCase) == true);
        }

        public static void Busqueda(List<Personas> lista)
        {
            string? nombre;

            Console.WriteLine("Ingrese el nombre a buscar");
            nombre = Leer()?.Trim();

            var resultado = Busqueda(lista, nombre);

            if (resultado != null)
            {
                Console.WriteLine("Persona econtrada:");
                MostrarPersonas(resultado);
            }
            else
                Console.WriteLine("Resultado no encontrado");

        }

        public static void MostrarPersonas(Personas persona)
        {
            Console.WriteLine($"nombre: {persona.Nombre}");
            Console.WriteLine($"color: {persona.Color}");
            Console.WriteLine($"sexo: {persona.Sexo}");
            Console.WriteLine($"edad: {persona.Edad}");
            Console.WriteLine($"vive: {(persona.Vive ? "sí" : "no")}");
        }
    }
}
