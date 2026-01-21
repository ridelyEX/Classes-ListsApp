using Classes_ListsApp.personas;
using System;
using System.Collections;
using System.Drawing;
using System.Text;

namespace Classes_ListsApp.utiils
{
    internal class Operaciones
    {
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
            Console.WriteLine("2. Mostrar todos los registros");
            Console.WriteLine("3. Mostrar personas mayores de edad");
            Console.WriteLine("4. Buscar persona");
            Console.WriteLine("5. Conteo de personas vivas y fallecidas");
            Console.WriteLine("6. Promedio de edades");
            Console.WriteLine("7. Persona mayor");
            Console.WriteLine("8. Persona menor");
            Console.WriteLine("9. Salir");
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

        /// <summary>
        /// Searches for a person in the specified list whose name matches the given value, using a case-insensitive
        /// comparison.
        /// </summary>
        /// <param name="lista">The list of persons to search. Cannot be null.</param>
        /// <param name="nombre">The name to search for. The comparison is case-insensitive.</param>
        /// <returns>A <see cref="Personas"/> object whose <c>Nombre</c> property matches <paramref name="nombre"/>; otherwise,
        /// <see langword="null"/> if no match is found.</returns>
        public static Personas? Busqueda(List<Personas> lista, string nombre)
        {
            return lista.Find(p => p.Nombre?.Equals(nombre, StringComparison.OrdinalIgnoreCase) == true);
        }

        /// <summary>
        /// Prompts the user to enter a name and searches for a matching person in the provided list.
        /// </summary>
        /// <remarks>If a person with the specified name is found, their details are displayed in the
        /// console. Otherwise, a message indicating that no result was found is shown. This method is intended for
        /// interactive console applications.</remarks>
        /// <param name="lista">The list of persons to search for a matching name. Cannot be null.</param>
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

        /// <summary>
        /// Displays the details of the specified person to the console output.
        /// </summary>
        /// <param name="persona">The person whose details are to be displayed. Cannot be null.</param>
        public static void MostrarPersonas(Personas persona)
        {
            Console.WriteLine($"nombre: {persona.Nombre}");
            Console.WriteLine($"color: {persona.Color}");
            Console.WriteLine($"sexo: {persona.Sexo}");
            Console.WriteLine($"edad: {persona.Edad}");
            Console.WriteLine($"vive: {(persona.Vive ? "sí" : "no")}");
        }

        public static (int, int) Conteo(List<Personas> list)
        {
            int vivos = 0;
            int muertos = 0;
            foreach (var persona in list)
            {
                if (persona.Vive)
                    vivos++;
                else
                    muertos++;
            }

            return (vivos, muertos);
        }

        public static double Promedio(List<Personas> list)
        {
            double edades = 0;

            foreach (var persona in list)
            {
                edades = persona.Edad + edades;
            }

            double promedio = edades / list.Count;

            return promedio;
        }

        public static (string, int) Mayor(List<Personas> list)
        {
            if (list == null || list.Count == 0)
                return (string.Empty, 0);

            Personas? mayor = list[0];
            foreach (var persona in list)
            {
                if (persona.Edad > mayor.Edad)
                {
                    mayor = persona;
                }
            }

            return (mayor.Nombre ?? string.Empty, mayor.Edad);
        }

        public static (string, int) Menor(List<Personas> list)
        {
            if (list == null || list.Count == 0)
                return (string.Empty, 0);

            Personas? menor = list[0];
            foreach (var persona in list)
            {
                if (persona.Edad < menor.Edad)
                    menor = persona;
            }

            return (menor.Nombre ?? string.Empty, menor.Edad);
        }



        public static void Stats(List<Personas> list)
        {
            var (_vivos, _muertos) = Conteo(list);
            var _promedio = Promedio(list);
            var (_nombreM, _mayorM) = Mayor(list);
            var (_nombrem, _menorm) = Menor(list);

            Console.WriteLine($"La cantidad de personas vivas: {_vivos} y fallecidos: {_muertos}");
            Console.WriteLine($"El promedio de la edad de los usuarios es {_promedio}");
            Console.WriteLine($"La persona con mayor edad es: {_nombreM} con {_mayorM} años");
            Console.WriteLine($"La persona con menor edad es: {_nombrem} con {_menorm}");
        }
    }
}
