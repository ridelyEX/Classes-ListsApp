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
            Console.WriteLine("2. Mostrar todas");
            Console.WriteLine("3. Mostrar mayores de edad");
            Console.WriteLine("4. Salir");
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
    }
}
