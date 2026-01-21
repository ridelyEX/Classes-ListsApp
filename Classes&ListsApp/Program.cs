using Classes_ListsApp.personas;
using Classes_ListsApp.utiils;

internal class Program
{
    private static void Main(string[] args)
    {
        List<Personas> persona = new List<Personas>();
        bool activo = true;
        int opc;
        string? nombre;

        do
        {

            Operaciones.Menu();
            while (!int.TryParse(Console.ReadLine(), out opc))
            {
                Console.WriteLine("Opción inválida");
            }
            switch (opc)
            {
                case 1:
                    nombre = Operaciones.Nombre();
                    string color = Operaciones.Color();
                    string sexo = Operaciones.Sexo();
                    int edad = Operaciones.Edad();
                    bool vive = Operaciones.Vive();

                    Personas nuevo = new Personas(nombre, color, sexo, edad, vive);
                    persona.Add(nuevo);
                    break;
                case 2:
                    if (persona.Count == 0)
                        Console.WriteLine("No hay registros de personas");
                    else
                    {
                        foreach (Personas p in persona)
                        {
                            if (p.Vive == true)
                                Console.WriteLine($"Nombre: {p.Nombre} - Edad: {p.Edad} años - Color: {p.Color} - Viva");
                            else
                                Console.WriteLine($"Nombre: {p.Nombre} - Edad: {p.Edad} años - Color: {p.Color} - Muerta");
                        }
                    }
                    break;
                case 3:
                    if (persona.Count == 0)
                        Console.WriteLine("No hay registros de personas");
                    else
                    {
                        foreach (Personas p in persona)
                        {
                            if (p.Edad >= 18 && p.Vive == true)
                                Console.WriteLine($"Nombre: {p.Nombre} - Edad: {p.Edad} años - Color: {p.Color} - Viva");
                            else if (p.Edad >= 18 && p.Vive != true)
                                Console.WriteLine($"Nombre: {p.Nombre} - Edad: {p.Edad} años - Color: {p.Color} - Muerta");
                        }
                    }
                    break;
                case 4:
                    Operaciones.Busqueda(persona);
                    break;
                case 5:
                    if (persona.Count == 0)
                        Console.WriteLine("No hay registros de personas");
                    else
                    {
                        var (_vivos, _muertos) = Operaciones.Conteo(persona);


                        Console.WriteLine($"Personas vivas: {_vivos}");
                        Console.WriteLine($"Personas fallecidas: {_muertos}");
                    }
                        break;
                case 6:
                    if (persona.Count == 0)
                        Console.WriteLine("No hay registros de personas");
                    else
                    {
                        var _promedio = Operaciones.Promedio(persona);
                        Console.WriteLine($"Promedio de edades: {_promedio}");

                    }
                    break;
                case 7:
                    if (persona.Count == 0)
                        Console.WriteLine("No hay registros de personas");
                    else
                    {
                        var (_nombre, _edad) = Operaciones.Mayor(persona);
                        //string _nombre = Operaciones.Mayor(persona).Item1;
                        //int _edad = Operaciones.Mayor(persona).Item2;
                        Console.WriteLine($"La persona con mayor edad es {_nombre} con {_edad} años");
                    }
                    break;
                case 8:
                    if (persona.Count == 0)
                        Console.WriteLine("No hay registros de personas");
                    else
                    {
                        var (_nombre, _edad) = Operaciones.Menor(persona);
                        Console.WriteLine($"La persona con mayor edad es {_nombre} con {_edad} años");
                    }
                    break;
                case 9:
                    activo = false;
                    break;
                default:
                    Console.WriteLine("Selecciona una opción del menú");
                    break;
            }
        } while (activo == true);

    }
}