using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Empleado
{
    public class Administrativo : Empleado
    {
        public Administrativo(string nombre, string apellido, int edad, decimal salario)
            : base(nombre, apellido, edad, "Administrativo", salario)
        {
        }
    }
}
