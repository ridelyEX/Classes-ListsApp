using System;
using System.Collections.Generic;
using System.Text;

namespace Classes_ListsApp.personas
{
    internal class Personas
    {
        public string? Nombre { get; set; }
        public string? Color { get; set; }
        public string? Sexo { get; set; }
        public int Edad { get; set;  }
        public bool Vive { get; set; }

        public Personas()
        {
        }

        public Personas(string? nombre, string? color, string? sexo, int edad, bool vive)
        {
            Nombre = nombre;
            Color = color;
            Sexo = sexo;
            Edad = edad;
            Vive = vive;
        }


        public override string? ToString()
        {
            return base.ToString();
        }
    }
}
