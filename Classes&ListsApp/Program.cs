using Classes_ListsApp.personas;
using Classes_ListsApp.utiils;

internal class Program
{
    private static void Main(string[] args)
    {
        List<Personas> persona = new List<Personas>();
        bool activo = true;
        int opc;

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
                    string nombre = Operaciones.Nombre();
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
                    activo = false;
                    break;
            }
        } while (activo == true);

    }
}