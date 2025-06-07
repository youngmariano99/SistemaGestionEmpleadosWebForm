using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaGestionEmpleadosWebForm.models
{
    public class Empleados
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public string Departamento { get; set; }
        public Empleados(int id, string nombre, string apellido, int edad, string departamento)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Edad = edad;
            Departamento = departamento;
        }
        public Empleados() { }
    }
}