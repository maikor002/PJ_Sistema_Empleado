using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Empleado
{
    public class Empleado
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public string Cargo { get; set; }
        public decimal Salario { get; set; }
        public bool Activo { get; set; } = true;

        public Empleado(string nombre, string apellido, int edad, string cargo, decimal salario)
        {
            Nombre = nombre;
            Apellido = apellido;
            Edad = edad;
            Cargo = cargo;
            Salario = salario;
        }
    }
}
